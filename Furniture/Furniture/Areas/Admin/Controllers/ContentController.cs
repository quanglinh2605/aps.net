using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index(string keyword, int page = 1, int pagesize = 1)
        {
            var dao = new ContentDao();
            var model = dao.ListAll(keyword,page,pagesize);
            ViewBag.Cate = new CategoryDao().ListAll(1);
            ViewBag.keyword = keyword;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Content entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                var result = dao.Insert(entity);
                if (result > 0)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Them tin tuc thanh cong");
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            Content model = dao.GetById(id);
            SetViewBag(model.CategoryID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Content entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                var result = dao.Update(entity);
                if (result)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Cap nhat tin tuc thanh cong");
            }
            SetViewBag(entity.CategoryID);
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(1),"ID","Name", selectedId);
        }        
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var dao = new ContentDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}