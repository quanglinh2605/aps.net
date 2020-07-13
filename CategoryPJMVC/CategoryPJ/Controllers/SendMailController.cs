using CategoryPJ.Models.Bussiness.ModuleCustomer;
using CategoryPJ.Models.ModelData;
using CategoryPJ.Models.ModelsView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Controllers
{
    public class SendMailController : BaseController
    {
        // GET: SendCard
        MailAction ma = new MailAction();
        sendMailAction sa = new sendMailAction();
        temp_userAction tua = new temp_userAction();
        PaymentAction pa = new PaymentAction();
        ActionUser au = new ActionUser();
        // GET: SendMail
        public ActionResult SendCard()
        {
            UserModelView user = new UserModelView();
            MailAction ma = new MailAction();

            if (Session["userId"] != null)
            {
                user = Session["userId"] as UserModelView;
            }
            ViewBag.lsMail = ma.showMail("", user.ID);
            return View();
        }
        [HttpPost]
        public ActionResult SendCard(SendMailView model)
        {
            template_userView item = new template_userView();
            MailAction ma = new MailAction();
            E_GreetingsEntities en = new E_GreetingsEntities();
            if (Session["temp_user"] != null)
            {
                item = Session["temp_user"] as template_userView;
            }

            Session["userId"] = au.getUserById(item.IDUser);
            ViewBag.userId = item.IDUser;
            ViewBag.lsMail = ma.showMail("", item.IDUser);

            if (au.getUserById(item.IDUser).isSubcrise == false && model.Receiver.Count() > 2)
            {
                ViewBag.Mess = "You have to subcrise to send more than 9 email";
                return View(model);
            }
            model.IDtemp_user = tua.create(item);
            ViewBag.tu_Id = model.IDtemp_user;

            sa.createSend(model);
            var lsmail = ma.showMail("", item.IDUser);
            for (int i = 0; i < lsmail.Count(); i++)
            {
                if (i == model.Receiver.Count()) break;
                foreach (var e in lsmail)
                {
                    if (e.ID.ToString() == model.Receiver[i])
                    {
                        sa.sendMail(model, e.Email);
                    }
                }
            }
            Session.Remove("temp_user");
            return RedirectToAction("index", "Home", new { id = item.IDUser });
        }
        [HttpPost]
        public ActionResult showCard(string name, int? page)
        {
            UserModelView user = new UserModelView();
            user = Session["userId"] as UserModelView;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            ViewBag.Keyword = name;
            ViewBag.lsmail = ma.showMail("", user.ID);
            ViewBag.lstemp = tua.show("");
            List<SendMailView> lsSend = new List<SendMailView>();
            lsSend = sa.showMail(name, user.ID);
            return View(lsSend.ToPagedList(pagenumber, pagesize));

        }
        public ActionResult showCard(int? page)
        {
            UserModelView user = new UserModelView();
            user = Session["userId"] as UserModelView;
            int pagenumber = page ?? 1;
            int pagesize = 10;
            ViewBag.lsmail = ma.showMail("", user.ID);
            ViewBag.lstemp = tua.show("");
            List<SendMailView> lsSend = new List<SendMailView>();
            lsSend = sa.showMail("", user.ID);
            return View(lsSend.ToPagedList(pagenumber, pagesize));
        }
    }
}