using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Models.DAO;
using Models.EF;
namespace Furniture.Controllers
{
    public class ProductController : Controller
    {
        ProductDao dao = new ProductDao();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().getByID(id);
            ViewBag.category = new CategoryDao().getById(product.CategoryID);
            ViewBag.productCate = new ProductCateDao().getbyID(product.ProCateID);
            ViewBag.cateDetail = new CateDetailDao().getById(product.CateDetailID);
            ViewBag.relatedProduct = new ProductDao().listRelatedProduct(id).Take(2).ToList();
            ViewBag.proCate = new ProductCateDao().getbyID(product.ProCateID);
            ViewBag.hidemenu = "hidemenu";
            var images = dao.getByID(id).MoreImages;
            if(images != null)
            {
                XElement xImages = XElement.Parse(images);
                List<string> listImagesReturn = new List<string>();
                foreach (XElement element in xImages.Elements())
                {
                    listImagesReturn.Add(element.Value);
                }
                ViewBag.listImage = listImagesReturn;
            }
            return View(product);
        }
        [HttpPost]
        public JsonResult loadMore(long id, int count)
        {
            count = count + 2;
            var model = dao.listRelatedProduct(id);
            string viewContent = ConvertViewToString("loadMore", model.Take(count).ToList());            
            if (count >= model.Count)
            {
                count = 0;
            }
            return Json(new {
                PartialView = viewContent,
                count,
                title = "xem them " + (model.Count - count) + " san pham"
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

        public JsonResult ViewIncrease(long id)
        {
            ProductDao dao = new ProductDao();
            bool kq = dao.viewIncrease(id);
            if (kq)
            {
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
    }
}