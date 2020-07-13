using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Greetings.Models.Bussiness.ModuleCustomer;
using E_Greetings.Models.ModelsView;
using PagedList;

namespace E_Greetings.Controllers
{
    public class PaymentController : Controller
    {
        PaymentAction pa = new PaymentAction();
        ActionUser au = new ActionUser();
        // GET: Payment
        public ActionResult createPayment(int userId)
        {
            ViewBag.userId = userId;
            bool kq = au.getUserById(userId).isSubcrise;
            ViewBag.check = kq;
            return View();
        }
        [HttpPost]
        public ActionResult createPayment(PaymentView model)
        {
            UserModelView user = new UserModelView();
            user = au.getUserById(model.IDMem);
            user.isSubcrise = true;
            au.updateUser(user);
            if (pa.createPayment(model) == true) return RedirectToAction("Index","User", new { id = model.IDMem});
            return View(model);
        }
        public ActionResult showPayment(int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<PaymentView> lspayment = new List<PaymentView>();
            lspayment = pa.showPayment("");
            ViewBag.lsuser = au.showUser("");
            return View(lspayment.ToPagedList(pagenumber, pagesize));
        }
        [HttpPost]
        public ActionResult showPayment(string name, int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            ViewBag.Keyword = name;
            List<PaymentView> lspayment = new List<PaymentView>();
            lspayment = pa.showPayment(name);
            ViewBag.lsuser = au.showUser("");
            return View(lspayment.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult updatePayment(int id)
        {
            PaymentView item = new PaymentView();
            item = pa.getPaymentById(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult updatePayment(PaymentView model)
        {
            if (pa.updatePayment(model) == true)
            {
                ViewBag.Mess = "Update Succesfull";
                return RedirectToAction("showPayment",new { name = ""});
            }
            return View(model);
        }
        public ActionResult deletePayment(int id)
        {
            if (pa.deletePayment(id) == true)
            {
                ViewBag.Mess = "Delete Successfull";
            }
            else
            {
                ViewBag.Mess = "Can't Delete";
            }
            return RedirectToAction("showPayment", new { name = ""});
        }
    }
}