using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Furniture.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public object JavaScriptSerializer { get; private set; }

        // GET: Admin/Product
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var dao = new ProductDao();
            ViewBag.keyword = keyword;
            ViewBag.listCate = new CategoryDao().ListAll(1);
            return View(dao.listAll(keyword, page, pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.listCategory = new CategoryDao().ListAll(1);           
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                model.CreateDate = DateTime.Now;
                model.CateDetailID = new ProductCateDao().getbyID(model.ProCateID).ParentID;
                model.CategoryID = new CateDetailDao().getById(model.CateDetailID).CategoryID;
                var result = dao.Insert(model);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Them thanh cong");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new ProductDao().getByID(id);
            ViewBag.listCategory = new CategoryDao().ListAll(1);
            ViewBag.listCateDetail = new CateDetailDao().getByCateID(model.CategoryID);
            ViewBag.listProCate = new ProductCateDao().getByCateDetailId(model.CateDetailID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                model.CateDetailID = new ProductCateDao().getbyID(model.ProCateID).ParentID;
                model.CategoryID = new CateDetailDao().getById(model.CateDetailID).CategoryID;
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cap nhat thanh cong");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult LoadImages(long id)
        {
            ProductDao dao = new ProductDao();
            var images = dao.getByID(id).MoreImages;
            List<string> listImagesReturn = new List<string>();
            if (images != null)
            {
                XElement xImages = XElement.Parse(images);
                foreach (XElement element in xImages.Elements())
                {
                    listImagesReturn.Add(element.Value);
                }
            }
            return Json(new {
                data = listImagesReturn
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveImages(long id,string images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var listImages = serializer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("images");
            foreach(var item in listImages)
            {
                var subStringItem = item.Substring(22);
                xElement.Add(new XElement("image", subStringItem));
            }
            ProductDao dao = new ProductDao();
            try
            {
                dao.updateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch(Exception ex)
            {
                return Json(new {
                    status = false
                });
            }
        }
        
        public void SetViewBag(long? id = null)
        {
            ViewBag.ProCateID = new SelectList(new ProductCateDao().listprocate(), "ID", "Name", id);
        }       
    }
}