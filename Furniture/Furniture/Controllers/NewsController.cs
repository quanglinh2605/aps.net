using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;
namespace Furniture.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index(long id, int page = 1)
        {
            int pagesize = 2;
            int pagenumber = page;
            ViewBag.category = new CategoryDao().getById(id);
            ViewBag.listCateDetail = new CateDetailDao().getByCateID(id);
            var model = new NewsDao().listPageNews("", pagenumber, pagesize);
            ViewBag.hidemenu = "hidemenu";        
            return View(model);
        }

        public ActionResult Title(long id,long titleID, int page = 1)
        {
            int pagesize = 30;
            int pagenumber = page;
            ViewBag.category = new CategoryDao().getById(id);
            ViewBag.listCateDetail = new CateDetailDao().getByCateID(id);
            var model = new NewsDao().listByTitle(titleID, page, pagesize);
            ViewBag.hidemenu = "hidemenu";
            ViewBag.titleContent = new CateDetailDao().getById(titleID);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult tintuc()
        {
            NewsDao dao = new NewsDao();            
            string content = Session["news"] == null ? "":(string)Session["news"];
            var model = dao.listNews(content);
            return PartialView(model);
        }
    }
}