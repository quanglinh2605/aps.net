using CategoryPJ.Models.Bussiness.ModuleCustomer;
using CategoryPJ.Models.ModelsView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Areas.Admin.Controllers
{
    public class PaymentController : BaseController
    {
        PaymentAction pa = new PaymentAction();
        ActionUser au = new ActionUser();
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
                return RedirectToAction("showPayment", new { name = "" });
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
            return RedirectToAction("showPayment", new { name = "" });
        }
    }
}