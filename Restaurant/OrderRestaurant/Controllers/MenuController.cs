using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OrderRestaurant.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showMenu(int Res_Id, int Cus_Id,string name, int? page)
        {
            ViewBag.Tukhoa = name;
            ViewBag.Res_Id = Res_Id;
            ViewBag.Cus_Id = Cus_Id;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsmenu = new List<Models.MenuModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                var searchTask = client.GetAsync("Menu?Res_Id=" + Res_Id.ToString() + "&Name=" + name);
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
        public ActionResult showAllmenu(int Cus_Id, string name, int? page)
        {
            ViewBag.Tukhoa = name;
            ViewBag.Cus_Id = Cus_Id;
            ViewBag.Res = null;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsmenu = new List<Models.MenuModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                var searchTask = client.GetAsync("Menu");
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.MenuModelView>>();
                    readTask.Wait();
                    lsmenu = readTask.Result;
                }            
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                var searchTask = client.GetAsync("Restaurant");
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.RestaurantModelView>>();
                    readTask.Wait();
                    ViewBag.Res = readTask.Result;
                }
            }
                return View(lsmenu.ToPagedList(pagenumber, pagesize));
        }
    }
}