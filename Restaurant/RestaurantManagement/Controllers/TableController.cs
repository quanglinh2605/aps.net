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
    public class TableController : Controller
    {
        // GET: Table
        #region Table
        public ActionResult createTable(int Id)
        {
            ViewBag.Res_Id = Id;
            return View();
        }
        [HttpPost]
        public ActionResult createTable(Models.TableModelView model)
        {
            using (var client = new HttpClient())
            {
                var lsTable = new List<Models.TableModelView>();
                client.BaseAddress = new Uri("http://localhost:55572/api/Table");
                var reponseTask = client.GetAsync("Table?Res_Id" + model.Res_ID +"&name=");
                if (reponseTask.Result.IsSuccessStatusCode)
                {
                    var readTask = reponseTask.Result.Content.ReadAsAsync<List<Models.TableModelView>>();
                    readTask.Wait();
                    lsTable = readTask.Result;
                }
                foreach (var item in lsTable)
                {
                    if (item.Name == model.Name)
                    {
                        ViewBag.Res_Id = model.Res_ID;
                        ViewBag.Warn = "This table has exist already";
                        return View();
                    }
                }               
                var postTask = client.PostAsJsonAsync("Table", model);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("showTable", new { Res_Id = model.Res_ID, name = "" });
                }
                return View(model);
            }
        }
        public ActionResult editTable(string name, int Res_id)
        {
            ViewBag.Res_Id = Res_id;
            List<Models.TableModelView> table = new List<Models.TableModelView>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                var reponseTask = client.GetAsync("Table?Res_Id=" + Res_id.ToString() + "&Name=");
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var ReadTask = result.Content.ReadAsAsync<List<Models.TableModelView>>();
                    ReadTask.Wait();
                    table = ReadTask.Result;
                }               
            }
            return View(table[0]);
        }
        [HttpPost]
        public ActionResult editTable(Models.TableModelView model)
        {
            var lsTable = new List<Models.TableModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Table");               
                var putTask = client.PutAsJsonAsync("Table", model);
                putTask.Wait();
                var result = putTask.Result;
            }
            return RedirectToAction("showTable", new { Res_Id = model.Res_ID, name = "" });
        }
        public ActionResult deleteTable(string name, int Res_Id)
        {
            ViewData["Message"] = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Table");
                var deleteTask = client.DeleteAsync("Table?Res_id=" + Res_Id.ToString() + "&name=" + name);
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
                return RedirectToAction("showTable", new { Res_Id = Res_Id.ToString(), name = ""});
            }
        }
        public ActionResult showTable(int Res_Id, string name, int? page)
        {
            ViewBag.Tukhoa = name;
            ViewBag.Res_Id = Res_Id;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            var lsTable = new List<Models.TableModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Table");
                var searchTask = client.GetAsync("Table?Name=" + name + "&Res_Id=" + Res_Id.ToString());
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.TableModelView>>();
                    readTask.Wait();
                    lsTable = readTask.Result;
                }
            }
            return View(lsTable.ToPagedList(pagenumber, pagesize));
        }
       public ActionResult showactive(int Res_Id,bool status)
        {
            var lsTable = new List<Models.TableModelView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/");
                var searchTask = client.GetAsync("Table?Res_Id=" + Res_Id.ToString()+ "&status=" + status.ToString());
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Models.TableModelView>>();
                    readTask.Wait();
                    lsTable = readTask.Result;
                }
            }
            return View(lsTable);
        }
        #endregion       
    }
}