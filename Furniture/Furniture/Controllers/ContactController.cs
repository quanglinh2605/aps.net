using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;

namespace Furniture.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.hidemenu = "hidemenu";
            return View();
        }
        public ActionResult sendFeedBack(string sEmail, string sTen, string sDienthoai, string sDiachi, string sNoidung)
        {
            Feedback feedback = new Feedback();
            feedback.Address = sDiachi;
            feedback.Content = sNoidung;
            feedback.CreateDate = DateTime.Now;
            feedback.Email = sEmail;
            feedback.Name = sTen;
            feedback.Phone = sDienthoai;
            var id = new FeedBackDao().Insert(feedback);
            if(id > 0)
            {
                TempData["success"] = "Da Gui Thanh Cong";
            }
            return View("Thanks");
        }
        public ActionResult Thanks()
        {
            ViewBag.hidemenu = "hidemenu";
            return View();
        }
    }
}