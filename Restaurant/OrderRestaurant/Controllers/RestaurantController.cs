using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace OrderRestaurant.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showRes(int? page, int Cus_Id)
        {
            ViewBag.Cus_Id = Cus_Id;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsRes = new List<Models.RestaurantModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Restaurant");
                var reponseTask = client.GetAsync("Restaurant");
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.RestaurantModelView>>();
                    readTask.Wait();
                    lsRes = readTask.Result;
                }
            }
            return View(lsRes.ToPagedList(pagenumber, pagesize));
        }
        [HttpPost]
        public ActionResult showRes(int? page, string name)
        {
            ViewBag.Tukhoa = name;
            int pagenumber = page ?? 1;
            int pagesize = 10;
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
    }
}