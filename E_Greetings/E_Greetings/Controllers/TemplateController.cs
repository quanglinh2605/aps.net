using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Greetings.Models.ModelsView;
using E_Greetings.Models.Bussiness.ModuleAdmin;
using PagedList;

namespace E_Greetings.Controllers
{
    public class TemplateController : Controller
    {
        TemplateAction ta = new TemplateAction();
        CategoryAction ca = new CategoryAction();
        // GET: Template
        public ActionResult createTemp()
        {
            ViewBag.lsCate = ca.showCate("");
            return View();
        }
        [HttpPost]
        public ActionResult createTemp(TemplateModelView model)
        {
            model.ImagePath = DateTime.Now.Ticks + System.IO.Path.GetFileName(model.ImageFile.FileName);
            model.ImageFile.SaveAs(Server.MapPath("~/Content/Uploads/") + model.ImagePath);
            if(ta.createTemplate(model))
            {
                return RedirectToAction("showTemp", new { name =""});
            }
            else
            {
                ViewBag.Mess = "Can't create";
                return View(model);
            }
        }
        public ActionResult showTemp(int? page)
        {
            ViewBag.lscate = ca.showCate("");
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<TemplateModelView> lstemp = new List<TemplateModelView>();
            lstemp = ta.showTemplate("");
            return View(lstemp.ToPagedList(pagenumber, pagesize));
        }
        [HttpPost]
        public ActionResult showTemp(int? page, string name)
        {
            ViewBag.lscate = ca.showCate("");
            ViewBag.KeyWord = name;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<TemplateModelView> lstemp = new List<TemplateModelView>();
            lstemp = ta.showTemplate(name);
            return View(lstemp.ToPagedList(pagenumber, pagesize));
        }
        [HttpPost]
        public ActionResult TemplateDetail(int? page,int id, string name)
        {
            ViewBag.lscate = ca.showCate("");
            ViewBag.KeyWord = name;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<TemplateModelView> lstemp = new List<TemplateModelView>();
            lstemp = ta.showTempByCateId(id,name);
            return View(lstemp.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult TemplateDetail(int id, int? page)
        {
            ViewBag.lscate = ca.showCate("");
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<TemplateModelView> lstemp = new List<TemplateModelView>();
            lstemp = ta.showTempByCateId(id,"");
            return View(lstemp.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult updateTemp(int id)
        {
            ViewBag.lsCate = ca.showCate("");
            TemplateModelView item = new TemplateModelView();
            item = ta.getTempById(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult updateTemp(TemplateModelView model)
        {
            if (model.ImageFile != null)
            {
                if(System.IO.Directory.Exists("~/Content/Uploads/"+ model.ImagePath))
                {
                    System.IO.Directory.Delete("~/Content/Uploads/" + model.ImagePath);
                }
                model.ImagePath = DateTime.Now.Ticks + System.IO.Path.GetFileName(model.ImageFile.FileName);
                model.ImageFile.SaveAs(Server.MapPath("~/Content/Uploads/") + model.ImagePath);
            }
            var result = ta.updateTemp(model);
            if (result == true)
            {
                ViewBag.Mess = "Update Successful";
                return RedirectToAction("showTemp");
            }
            ViewBag.Mess = "Can't update";
            return View(model);
        }
        public ActionResult deleteTemp(int id)
        {
            var result = ta.deleteTemp(id);
            if (result == true)
            {
                ViewBag.Mess = "Delete Success";
            }
            else
            {
                ViewBag.Mess = "Can't Delete";
            }
            return RedirectToAction("showTemp");
        }
    }
}