
using Modelclass.DAO;
using Modelclass.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Areas.Admin.Controllers
{
    public class TemplateController : BaseController
    {
        // GET: Admin/Template
        public ActionResult IndexEdit(string name)
        {

            ViewBag.KeyWord = name;
            ViewBag.template = new TemplateDAO().ListAll(name);
            return View();
        }
        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dao = new TemplateDAO();
            var model = dao.TemByCategory(id);

            
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

         //controller create
         public void setViewBag(int? selectID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.IDCategory = new SelectList(dao.ListAll(), "ID", "Occasions", selectID);
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Template template)
        {
            if (ModelState.IsValid)
            {
                var dao = new TemplateDAO();
                string fileName = Path.GetFileNameWithoutExtension(template.Namefile.FileName);
                string extension = Path.GetExtension(template.Namefile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                template.ImageTem = "~/Areas/Admin/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Admin/Image/"), fileName);
                template.Namefile.SaveAs(fileName);


                long id = dao.Insert(template);

                if (id > 0)
                {
                    return RedirectToAction("IndexEdit", "Template");
                }
                else
                {
                    ModelState.AddModelError("", "them thanh cong user");
                }
            }
            setViewBag();
            return View("IndexEdit");
        }

        //Action edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var template = new TemplateDAO().ViewDetail(id);
            setViewBag(template.IDCategory);
            return View(template);
        }
        [HttpPost]
        public ActionResult Edit(Template template)
        {
            if (ModelState.IsValid)
            {
                var dao = new TemplateDAO();
                string fileName = Path.GetFileNameWithoutExtension(template.Namefile.FileName);
                string extension = Path.GetExtension(template.Namefile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                template.ImageTem = "~/Areas/Admin/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Admin/Image/"), fileName);
                template.Namefile.SaveAs(fileName);
                var result = dao.Update(template);
                if (result)
                {
                    return RedirectToAction("IndexEdit");

                }
                else
                {
                    ModelState.AddModelError("", "Edit template success!!");
                }
            }
            setViewBag(template.IDCategory);
            return View("Details");
        }
        
        //Action Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new TemplateDAO().Delete(id);
            return RedirectToAction("IndexEdit");
        }
    }
}