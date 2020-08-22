using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Areas.Admin.Controllers
{
    public class CategoryDetailController : Controller
    {
        // GET: Admin/CategoryDetail
        public ActionResult Index(string keyword,int page = 1, int pagesize = 10)
        {
            var dao = new CateDetailDao();
            ViewBag.Keyword = keyword;
            return View(dao.pagetolist(keyword,page,pagesize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryDetail model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CateDetailDao();
                model.CreatedDate = DateTime.Now;
                var result = dao.Insert(model);
                if (result > 0)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Them danh muc thanh cong");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            setViewBag(id);
            return View(new CateDetailDao().getById(id));
        }
        [HttpPost]
        public ActionResult Edit(CategoryDetail model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CateDetailDao();
                var result = dao.Update(model);
                if (result)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Cap nhat danh muc thanh cong");
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var dao = new CateDetailDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult listCateDetail(long id)
        {
            var listCateDetail = new CateDetailDao().getByCateID(id);
            return Json(new
            {
                data = listCateDetail
            }, JsonRequestBehavior.AllowGet);
        }

        public void setViewBag(long? id = null)
        {
            ViewBag.CategoryID = new SelectList(new CategoryDao().ListAll(1), "ID", "Name", id);
        }
    }
}