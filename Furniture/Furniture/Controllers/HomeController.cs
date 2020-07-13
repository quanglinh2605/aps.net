using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;
namespace Furniture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dao = new ProductDao();
            var model = dao.listproduct();
            ViewBag.categories = new CategoryDao().ListAll(1);
            ViewBag.produce = new ProduceDao().listproduce(7,0);
            ViewBag.prodetail = new ProduceDetailDao().listProdetail();
            ViewBag.news = new NewsDao().listNews("");
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Partner()
        {
            var model = new PartnerDao().listPartner();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult MenuTop()
        {
            ViewBag.subMenu = new CateDetailDao().getSubMenuByTypeId(8);
            var model = new MenuDao().getListMenuByTypeID(8);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().getListMenuByTypeID(5);           
            for (int i = 0; i < model.Count; i++)
            {
                List<CategoryDetail> listCate = null;
                List<ProductCategory> listPro = null;
                var category = new CategoryDao().getByName(model[i].Text);
                var cateDetail = new CateDetailDao().getByName(model[i].Text);
                if (category != null)
                {
                    listCate = new CateDetailDao().getByCateID(category.ID);
                }
                if (cateDetail != null)
                {
                    listPro = new ProductCateDao().getByCateDetailId(cateDetail.ID);
                }
                if (listCate != null)
                    ViewData["menucate" + (i + 1)] = listCate;
                if(listPro != null)
                    ViewData["menupro" + (i + 1)] = listPro;
            }
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            var model = new CategoryDao().ListAll(1);
            ViewBag.listCateDetail = new CateDetailDao().listCateDetail();
            ViewBag.listProductCate = new ProductCateDao().listprocate();
            return PartialView(model);
        }
    } 
}