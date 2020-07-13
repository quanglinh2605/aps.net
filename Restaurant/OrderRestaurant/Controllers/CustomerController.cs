using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OrderRestaurant.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Models.CustomerModelView model)
        {
            int kq = 0;
            ViewBag.Warn = null;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/LoginCus");
                var postTask = client.PostAsJsonAsync("LoginCus",model);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    kq = readTask.Result;
                    if (kq == 0)
                    {
                        ViewBag.Warn = "Login Fail";
                        return View();
                    }
                    ViewBag.Warn = kq;
                }
            }
            return RedirectToAction("showRes","Restaurant", new { Cus_Id = kq});
        }
        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult registerCustomer(Models.CustomerModelView model)
        {
            ViewBag.mess = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Customer");
                var postTask = client.PostAsJsonAsync("Customer", model);
                postTask.Wait();
                if (postTask.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("login");
                }
                ViewBag.mess = "Register Fail";
                return View();
            }
        }
        public ActionResult editCus(int id)
        {
            var model = new Models.CustomerModelView();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Customer");
                var reponseTask = client.GetAsync("Customer?id=" + id.ToString());
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.CustomerModelView>();
                    readTask.Wait();
                    model = readTask.Result;
                }
                return View(model);
            }
        }
    }
}