using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OrderRestaurant.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult createOrder(int Cus_Id, int Res_Id,string menu)
        {
            ViewBag.menu = menu;
            ViewBag.Cus_Id = Cus_Id;
            ViewBag.Res_Id = Res_Id;
            return View();
        }
        [HttpPost]
        public ActionResult createOrder(Models.OrderModelView model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Order");
                var PostTask = client.PostAsJsonAsync("Order", model);
                PostTask.Wait();
                var result = PostTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mess = "Order Successfully";                   
                }
                return RedirectToAction("showRes", "Restaurant", new { Cus_Id = model.Id_Customer });
            }
        }
    }
}