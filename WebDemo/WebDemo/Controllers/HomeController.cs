using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Models.CategoryViewModel> lscate = null;
            using(var client = new HttpClient())
            {   
                client.BaseAddress = new Uri("http://localhost:56907/api/");
                var responseTask = client.GetAsync("Category");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CategoryViewModel>>();
                    readTask.Wait();
                    lscate = readTask.Result;
                }
            }
            return View(lscate);
        }

        public ActionResult createCate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createCate(CategoryViewModel model)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56907/api/");
                var responseTask = client.PostAsJsonAsync("Category", model);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult editCate(int id)
        {
            CategoryViewModel cate = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56907/api/");
                var responseTask = client.GetAsync("Category?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                    readTask.Wait();
                    cate = readTask.Result;
                }
                return View(cate);
            }
        }
       [HttpPost]
       public ActionResult editCate(CategoryViewModel model)
        {            
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56907/api/");
                var responseTask = client.PutAsJsonAsync("Category", model);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult deleteCate(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56907/api/");
                var deleteTask = client.DeleteAsync("Category/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}