using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(long parentID)
        {
            var model = new ContentDao().listByParentID(parentID);
            ViewBag.news = new NewsDao().getById(parentID);
            ViewBag.relatedNews = new NewsDao().relatedNews(new NewsDao().getById(parentID).ParentID);
            ViewBag.hidemenu = "hidemenu";
            return View(model);
        }
    }
}