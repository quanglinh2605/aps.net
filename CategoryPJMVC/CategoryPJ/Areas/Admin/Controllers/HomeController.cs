using CategoryPJ.Models.Bussiness.ModuleCustomer;
using CategoryPJ.Models.ModelsView;
using Modelclass.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        PaymentAction pa = new PaymentAction();
        ActionUser au = new ActionUser();
        // GET: Admin/Home
        public ActionResult Index(int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<PaymentView> lspayment = new List<PaymentView>();
            lspayment = pa.showPayment("");
            ViewBag.lsuser = au.showUser("");


            return View(lspayment.ToPagedList(pagenumber, pagesize));
        }
    }
}