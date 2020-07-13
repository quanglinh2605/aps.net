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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }        
        public ActionResult editOrder(int Id,int Res_Id, bool status)
        {
            Models.OrderModelView model = null;
            List<Models.TableModelView> lsTable = new List<Models.TableModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Order?id=" + Id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Models.OrderModelView>();
                    readTask.Wait();
                    model = readTask.Result;
                } 
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                var searchTask = client.GetAsync("Table?Res_Id=" + Res_Id.ToString() + "&status=" + status.ToString());
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.TableModelView>>();
                    readTask.Wait();
                    lsTable = readTask.Result;
                    ViewBag.lstable = lsTable;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult editOrder(Models.OrderModelView model)
        {
            if (model.status == "Cancel")
            {
                using (var client = new HttpClient())
                {
                    List<Models.TableModelView> table = new List<Models.TableModelView>();
                    client.BaseAddress = new Uri("http://localhost:55572/api/Table");
                    var reponse = client.GetAsync("Table?Res_Id=" + model.Id_Res.ToString() + "&name=" + model.choosetable);
                    reponse.Wait();
                    if (reponse.Result.IsSuccessStatusCode)
                    {
                        var readTask = reponse.Result.Content.ReadAsAsync<List<Models.TableModelView>>();
                        table = readTask.Result;
                    }
                    table.First().Status = true;
                    var editTask = client.PutAsJsonAsync("Table", table.First());
                    editTask.Wait();
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Order");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("Order", model);
                putTask.Wait();                
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("checkOrder",new { Res_Id = model.Id_Res, model.status});
                }
            }
            return View(model);
        }
        public ActionResult deleteOrder(int id,int Res_Id, string status)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Order");
                var deleteTask = client.DeleteAsync("Order?id=" + id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Delete Success";
                    return RedirectToAction("checkOrder", new {Res_Id, status = status });
                }
                TempData["Message"] = "Delete Fail";
                return RedirectToAction("checkOrder", new {Res_Id, status = status });

            }
        }     
        public ActionResult showOrder(int Res_Id, string name,int? page)
        {
            ViewBag.Tukhoa = name;
            ViewBag.Res_Id = Res_Id;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsOrder = new List<Models.OrderModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                var searchTask = client.GetAsync("Menu?id_Cus=" + name + "&tablename=" + name);
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.OrderModelView>>();
                    readTask.Wait();
                    lsOrder = readTask.Result;
                }
            }
            return View(lsOrder.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult checkOrder(string status, int Res_Id, int? page)
        {
            ViewBag.Res_Id = Res_Id;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsOrder = new List<Models.OrderModelView>();
            var lsCustomer = new List<Models.CustomerModelView>();
            ViewBag.lscus = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Order");
                var reponseTask = client.GetAsync("Order?Id_Res=" + Res_Id.ToString()  + "&status=" + status);
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.OrderModelView>>();
                    readTask.Wait();
                    lsOrder = readTask.Result;
                }

                var reponseCusTask = client.GetAsync("Customer");
                reponseCusTask.Wait();
                var final = reponseCusTask.Result;
                if (final.IsSuccessStatusCode)
                {
                    var readTask = final.Content.ReadAsAsync<List<Models.CustomerModelView>>();
                    readTask.Wait();
                    lsCustomer = readTask.Result;
                    ViewBag.lscus = lsCustomer;
                }
            }
            return View(lsOrder.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult actionOrder(bool status, int Res_Id, int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsOrder = new List<Models.OrderModelView>();
            var lsCustomer = new List<Models.CustomerModelView>();
            ViewBag.lscus = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Order");
                var reponseTask = client.GetAsync("Order?status=" + status);
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.OrderModelView>>();
                    readTask.Wait();
                    lsOrder = readTask.Result;
                }

                var reponseCusTask = client.GetAsync("Customer");
                reponseCusTask.Wait();
                var final = reponseCusTask.Result;
                if (final.IsSuccessStatusCode)
                {
                    var readTask = final.Content.ReadAsAsync<List<Models.CustomerModelView>>();
                    readTask.Wait();
                    lsCustomer = readTask.Result;
                    ViewBag.lscus = lsCustomer;
                }
            }
            return View(lsOrder.ToPagedList(pagenumber, pagesize));
        }
    }
}