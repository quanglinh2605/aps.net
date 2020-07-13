using Modelclass.DAO;
using Modelclass.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CategoryPJ.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new CategoryDAO();
            ViewBag.Searching = searchString;
            ViewBag.Category = new CategoryDAO().ListAll();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        //controller create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                string fileName = Path.GetFileNameWithoutExtension(category.Imagefile.FileName);
                string extension = Path.GetExtension(category.Imagefile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                category.ImageCate = "~/Areas/Admin/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Admin/Image/"), fileName );
                category.Imagefile.SaveAs(fileName);
                
                long id = dao.Insert(category);
                
                if (id > 0)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "them thanh cong user");
                }
            }
            return View("Index");
        }

        //Action edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = new CategoryDAO().ViewDetail(id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                string fileName = Path.GetFileNameWithoutExtension(category.Imagefile.FileName);
                string extension = Path.GetExtension(category.Imagefile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                category.ImageCate = "~/Areas/Admin/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Admin/Image/"), fileName);
                category.Imagefile.SaveAs(fileName);
                var result = dao.Update(category);
                if (result)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Edit user success!!");
                }
            }
            return View("Index");
        }

        //Action Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}