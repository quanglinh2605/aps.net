using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace RestaurantManagement.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        #region Menu
        public ActionResult createMenu(int Id)
        {
            ViewBag.Res_Id = Id;
            return View();
        }
        [HttpPost]
        public ActionResult createMenu(Models.MenuModelView model)
        {                      
            using (var client = new HttpClient())
            {
                var lsMenu = new List<Models.MenuModelView>();
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                var reponseTask = client.GetAsync("Menu");                
                if (reponseTask.Result.IsSuccessStatusCode)
                {
                    var readTask = reponseTask.Result.Content.ReadAsAsync<List<Models.MenuModelView>>();
                    readTask.Wait();
                    lsMenu = readTask.Result;
                }
                foreach (var item in lsMenu)
                {
                    if (item.Name == model.Name && item.Res_Id==model.Res_Id)
                    {
                        ViewBag.Res_Id = model.Res_Id;
                        ViewBag.Warn = "This meal has exist already";
                        return View();
                    }
                }
                model.ImgPath = DateTime.Now.Ticks + System.IO.Path.GetFileName(model.ImgName.FileName);
                model.ImgName.SaveAs(Server.MapPath("~/Content/Uploads/") + model.ImgPath);
                model.ImgName = null;
                var postTask = client.PostAsJsonAsync("Menu", model);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("showMenu", new { Res_id = model.Res_Id, name =""});
                }
                return View(model);
            }
        }
        public ActionResult editMenu(int id, int Res_id)
        {
            var item = new Models.MenuModelView();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                var reponseTask = client.GetAsync("Menu?" + "Id=" + id + "&"+ "Res_Id="+Res_id.ToString());
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.MenuModelView>();
                    readTask.Wait();
                    item = readTask.Result;
                }
            }
            return View(item);
        }
        [HttpPost]
        public ActionResult editMenu(Models.MenuModelView model)
        {
            var lsMenu = new List<Models.MenuModelView>();           
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                if (model.ImgName != null)
                {
                    string fullPath = Request.MapPath("~/Content/Uploads/" + model.ImgPath);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    model.ImgPath = DateTime.Now.Ticks + System.IO.Path.GetFileName(model.ImgName.FileName);
                    model.ImgName.SaveAs(Server.MapPath("~/Content/Uploads/") + model.ImgPath);
                    model.ImgName = null;
                }

                var putTask = client.PutAsJsonAsync("Menu", model);
                putTask.Wait();
                var result = putTask.Result;              
            }
            return RedirectToAction("showMenu/" + model.Res_Id.ToString());
        }
        public ActionResult deleteMenu(int Id, int Res_Id)
        {
            ViewData["Message"] = null;
          using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                var deleteTask = client.DeleteAsync("Menu?Res_id=" + Res_Id.ToString() + "&Id=" + Id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Delete Successful";
                }
                else
                {
                    ViewData["Message"] = "Delete Fail";
                }
                return RedirectToAction("showMenu" ,new { Res_Id = Res_Id, name = "" });
            }  
        }
        public ActionResult showMenu(int Res_Id, string name,int? page)
        {
            ViewBag.Tukhoa = name;
            ViewBag.Res_Id = Res_Id;        
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsmenu = new List<Models.MenuModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                var searchTask = client.GetAsync("Menu?Res_Id="+Res_Id.ToString()+"&Name="+name);
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.MenuModelView>>();
                    readTask.Wait();
                    lsmenu = readTask.Result;
                }
            }
            return View(lsmenu.ToPagedList(pagenumber, pagesize));
        }
        #endregion       
    }
}