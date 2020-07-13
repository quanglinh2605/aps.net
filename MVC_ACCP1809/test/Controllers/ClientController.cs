using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterPost(Models.ModelViews.UserChatView model, HttpPostedFileBase avatar)
        {
            string test = "";
            return RedirectToAction("Index");
        }
    }
}