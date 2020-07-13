using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Greetings.Models.Bussiness.ModuleCustomer;
using E_Greetings.Models.Bussiness.ModuleAdmin;
using E_Greetings.Models.ModelsView;
using PagedList;
namespace E_Greetings.Controllers
{
    public class UserController : Controller
    {
        ActionUser au = new ActionUser();
        TemplateAction ta = new TemplateAction();
        // GET: User
        public ActionResult Index(int? id, int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            ViewBag.userId = id;
            List<TemplateModelView> lstemp = new List<TemplateModelView>();
            lstemp = ta.showTemplate("");
            return View(lstemp.ToPagedList(pagenumber,pagesize));
        }
        public ActionResult showUser(int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 5;
            List<UserModelView> lsuser = new List<UserModelView>();
            lsuser = au.showUser("");
            return View(lsuser.ToPagedList(pagenumber, pagesize));
        }
        [HttpPost]
        public ActionResult showUser(string name, int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 5;
            ViewBag.Keyword = name;
            List<UserModelView> lsuser = new List<UserModelView>();
            lsuser = au.showUser(name);
            return View(lsuser.ToPagedList(pagenumber,pagesize));
        }
        public ActionResult createUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createUser(UserModelView model)
        {           
                int kq = au.InsertUser(model);
                return RedirectToAction("loginUser", "Login");            
        }
        public ActionResult updateUser(int id)
        {
            UserModelView item = new UserModelView();
            item = au.getUserById(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult updateUser(UserModelView model)
        {
            bool result = au.updateUser(model);
            if (result == true)
            {
                ViewData["mess"] = "Update Successfull";
                return RedirectToAction("showUser", new { name = "" });
            }
            ViewData["mess"] = "Can't Update";
            return View(model);
        }
        public ActionResult detelteUser(int id)
        {
            bool result = au.deleteUser(id);
            if (result == true)
            {
                TempData["mess"] = "Delete Sucessfull";           
            }
            else
            {
                TempData["mess"] = "Can't Delete";               
            }
            return RedirectToAction("showUser", new { name = "" });
        }
        public ActionResult FeedBack()
        {
            UserModelView user = new UserModelView();
            if (Session["userId"] != null)
            {
                user = Session["userId"] as UserModelView;
            }
            ViewBag.userId = user.ID;
            return View();
        }
        [HttpPost]
        public ActionResult FeedBack(FeedBackView model)
        {
            au.feedback(model);
            return RedirectToAction("Thanks");
        }
        public ActionResult Thanks()
        {
            return View();
        }
    }
}