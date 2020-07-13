using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Greetings.Models.ModelsView;
using E_Greetings.Models.ModelsData;
using E_Greetings.Models.Bussiness.ModuleCustomer;
using PagedList;

namespace E_Greetings.Controllers
{
    public class MailGroupController : Controller
    {
        // GET: MailGroup
        public ActionResult showMail(int? page)
        {
            UserModelView user = new UserModelView();
            if (Session["userId"] != null) user = Session["userId"] as UserModelView;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<MailGroupView> lsMail = new List<MailGroupView>();
            MailAction ma = new MailAction();
            E_GreetingsEntities en = new E_GreetingsEntities();
            lsMail = ma.showMail("",user.ID);
            ViewBag.MemId = user.ID;
            return View(lsMail.ToPagedList(pagenumber, pagesize));
        }
        [HttpPost]
        public ActionResult showMail(string name, int? page)
        {
            UserModelView user = new UserModelView();
            if (Session["userId"] != null) user = Session["userId"] as UserModelView;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            ViewBag.Keyword = name;
            List<MailGroupView> lsMail = new List<MailGroupView>();
            MailAction ma = new MailAction();
            lsMail = ma.showMail(name,user.ID);
            return View(lsMail.ToPagedList(pagenumber,pagesize));
        }
        public ActionResult updateMail(int id)
        {
            MailAction ma = new MailAction();
            MailGroupView item = new MailGroupView();
            item = ma.getMailById(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult updateMail(MailGroupView model)
        {
            MailAction ma = new MailAction();
            var kq = ma.updateMail(model);
            if (kq == true) return RedirectToAction("showMail");
            else
            {
                ViewBag.Mess = "Can't Update";
                return View(model);
            }
        }
        public ActionResult deleteMail(int id, int MemId)
        {
            ViewBag.MemId = MemId;
            MailAction ma = new MailAction();
            bool kq = ma.deleteMail(id);
            if (kq == true)
            {
                TempData["Mess"] = "Delete Successful";
            }
            else
            {
                TempData["Mess"] = "Can't delete";
            }
            return RedirectToAction("showMail", new {id = ViewBag.MemId });
        }
        public ActionResult AddMail(int id)
        {
            ViewBag.IDMem = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddMail(MailGroupView model)
        {
            MailAction ma = new MailAction();
            ma.AddMail(model);
            return RedirectToAction("showMail", new { id = model.IDMem});
        }
    }
}