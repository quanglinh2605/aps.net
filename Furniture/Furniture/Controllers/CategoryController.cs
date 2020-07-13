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
    public class CategoryController : Controller
    {
        ProductDao dao = new ProductDao();
        // GET: Category
        public ActionResult Index(long cateId, long? proId, long? price)
        {
            var model = dao.filterByPrice(price, cateId,proId);
            if (Session["sort"] != null)
            {
                model = dao.sortProduct((long)Session["sort"]);
            }
            ViewBag.cateDetail = new CateDetailDao().getByCateID(cateId);
            ViewBag.category = new CategoryDao().getById(cateId);
            ViewBag.listprice = new PriceDao().listAll();
            ViewBag.produce = new ProduceDao().findproduce(new CategoryDao().getById(cateId).TypeID,cateId);
            Session["cateDetailId"] = null;
            Session.Add("price", price);
            Session.Add("cateId", cateId);
            Session.Add("news", new CategoryDao().getById(cateId).ShortName);
            ViewBag.hidemenu = "hidemenu";
            return View(model);            
        }
        [HttpPost]
        public JsonResult action(long value, string action)
        {
            Session.Add("sort", value);
            return Json(new {
                sort = value
            });
        }
        [HttpPost]     
        public JsonResult loadmore(long? id, int val, int count)
        {
            List<Product> result;
            if (Session["price"] != null || Session["cateId"] != null)
            {
                result = dao.filterByPrice((long?)Session["price"], (long)Session["cateId"], (long?)Session["cateDetailId"]);
            }
            if (Session["sort"] != null)
            {
                result = dao.sortProduct((long)Session["sort"]);
            }
            int quantity;
            if (Session["cateDetailId"] != null)
            {
                result = dao.loadMore((long?)Session["cateDetailId"], id, val, count);
            }
            else
            {
                result = dao.loadMore(id, null, val, count);
            }
            if (count + val >= result.Count)
            {
                quantity = 0;
            }
            else
            {
                quantity = count + val;
            }
            string viewContent = ConvertViewToString("loadmore", result);
            return Json(new
            {
                PartialView = viewContent,
                quantity
            });
        }
        private string ConvertViewToString(string viewName, object model)
        {
            ViewBag.productlist = model;
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