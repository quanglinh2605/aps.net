using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            ViewBag.hidemenu = "hidemenu";
            return View();
        }

        public JsonResult loadInvoice(string value)
        {
            var result = new OrderDao().getByPhone(value);
            var json = ConvertViewToString("loadInvoice", result);
            return Json(new
            {
                PartialView = json
            });
        }

        public JsonResult loadDetail(long value)
        {
            var result = new OrderDao().getById(value);
            var json = ConvertViewToString("loadDetail", result);
            return Json(new
            {
                PartialView = json
            });
        }

        private string ConvertViewToString(string viewName, object model)
        {
            ViewBag.invoicelist = model;
            ViewBag.listDetail = new OrderDetailDao().listAll();
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                vResult.ViewEngine.ReleaseView(ControllerContext, vResult.View);
                return writer.GetStringBuilder().ToString();
            }
        }        
    }
}