using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebMVC.Controllers
{
    public class adminController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }
    }
}