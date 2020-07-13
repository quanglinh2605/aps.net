using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace RestaurantManagement.Controllers
{
    public class RestaurantController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.RestaurantModelView model)
        {
            ViewBag.Res_Id = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Login");
                var postTask = client.PostAsJsonAsync("Login", model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();
                    int kq = readTask.Result;
                    ViewBag.Res_Id = kq;
                    if (kq == 0)
                    {
                        ViewBag.Res_Id = "Login Fail";
                        return View();
                    }
                    if (kq == 2)
                    {
                        ViewBag.Res_Id = kq;
                        return View("Admin");
                    }

                }
                return RedirectToAction("showMenu", "Menu", new { Res_Id = ViewBag.Res_Id, name ="", page = 1 });
            }
        }
        #endregion
        #region ResTaurant      
        public ActionResult createRes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createRes(Models.RestaurantModelView model)
        {
            var lsres = new List<Models.RestaurantModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Restaurant");

                var reponseTask = client.GetAsync("Restaurant");
                if (reponseTask.Result.IsSuccessStatusCode)
                {
                    var readTask = reponseTask.Result.Content.ReadAsAsync<List<Models.RestaurantModelView>>();
                    readTask.Wait();
                    lsres = readTask.Result;
                }
                foreach (var item in lsres)
                {
                    if (item.Username == model.Username && item.Name == model.Name && item.Password == model.Password)
                    {
                        ViewBag.Warn = "This Account has exist already";
                        return View();
                    }
                }

                var postTask = client.PostAsJsonAsync("Restaurant", model);
                postTask.Wait();               
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("showRes");
                }
                return View(model);
            }
        }
        public ActionResult editRes(int id)
        {
            Models.RestaurantModelView model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Restaurant?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.RestaurantModelView>();
                    readTask.Wait();
                    model = readTask.Result;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult editRes(Models.RestaurantModelView model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Restaurant");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("Restaurant", model);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("showRes");
                }
            }
            return View(model);
        }
        public ActionResult deleteRes(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Restaurant");
                var deleteTask = client.DeleteAsync("Restaurant?id=" + id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Delete Success";
                    return RedirectToAction("showRes");
                }             
                    TempData["Message"] = "Delete Fail";
                return RedirectToAction("showRes");
                
            }
        }
        public ActionResult showRes(int? page, string name)
        {
            ViewBag.Tukhoa = name;
            int pagenumber = page ?? 1;
            int pagesize = 5;
            var lsres = new List<Models.RestaurantModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Restaurant");
                var searchTask = client.GetAsync("Restaurant?name=" + name);
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.RestaurantModelView>>();
                    readTask.Wait();
                    lsres = readTask.Result;
                }
            }
            return View(lsres.ToPagedList(pagenumber, pagesize));
        }
        #endregion       
    }
}