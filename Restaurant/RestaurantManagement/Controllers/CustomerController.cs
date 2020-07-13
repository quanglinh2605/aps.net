using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace RestaurantManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showCustomer(int? page, int Res_Id)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsCustomer = new List<Models.CustomerModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Customer");
                var reponseTask = client.GetAsync("Customer?Res_Id=" + Res_Id.ToString());
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerModelView>>();
                    readTask.Wait();
                    lsCustomer = readTask.Result;
                }
            }
            return View(lsCustomer.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult editCustomer(int Id)
        {
            Models.CustomerModelView model = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Customer?id=" + Id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.CustomerModelView>();
                    readTask.Wait();
                    model = readTask.Result;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult editCustomer(Models.CustomerModelView model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Customer");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("Customer", model);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("showCustomer");
                }
            }
            return View(model);
        }
        public ActionResult deleteCustomer(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Customer");
                var deleteTask = client.DeleteAsync("Customer?id=" + id);
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
        [HttpPost]
        public ActionResult showCustomer(int Res_Id, string name, int? page)
        {
            ViewBag.Tukhoa = name;
            ViewBag.Res_Id = Res_Id;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsCustomer = new List<Models.CustomerModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                var searchTask = client.GetAsync("Menu?id_Cus=" + name + "&tablename=" + name);
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.CustomerModelView>>();
                    readTask.Wait();
                    lsCustomer = readTask.Result;
                }
            }
            return View(lsCustomer.ToPagedList(pagenumber, pagesize));
        }
    }
}