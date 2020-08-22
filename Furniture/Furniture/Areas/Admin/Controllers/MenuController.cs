using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/MenuType
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var dao = new MenuDao();
            ViewBag.keyword = keyword;
            ViewBag.listType = new MenuTypeDao().AllMenuType();
            return View(dao.pagetolist(keyword, page, pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Menu model)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                var result = dao.Insert(model);
                if (result > 0)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Them menu thanh cong");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            setViewBag(id);
            var model = new MenuDao().getById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Menu model)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
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
            var dao = new MenuDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        public void setViewBag(long? id = null)
        {
            ViewBag.TypeID = new SelectList(new MenuTypeDao().AllMenuType(), "ID", "Name", id);
        }
    }
}