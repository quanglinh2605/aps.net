using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Controllers
{
    public class CategoryDetailController : Controller
    {
        ProductDao dao = new ProductDao();
        // GET: CategoryDetail
        public ActionResult Index(long cateId, long catedetailId, long? price)
        {
            var model = dao.filterByPrice(price, cateId, catedetailId);
            ViewBag.listProCate = new ProductCateDao().getByCateDetailId(catedetailId);
            ViewBag.category = new CategoryDao().getById(cateId);
            ViewBag.cateDetail = new CateDetailDao().getById(catedetailId);
            if (Session["sort"] != null)
            {
                model = dao.sortProduct((long)Session["sort"]);
            }
            ViewBag.listprice = new PriceDao().listAll();
            ViewBag.produce = new ProduceDao().findproduce(new CateDetailDao().getById(catedetailId).TypeID, catedetailId);
            Session.Add("price", price);
            Session.Add("cateId", cateId);
            Session.Add("cateDetailId", catedetailId);
            Session.Add("news", new CateDetailDao().getById(catedetailId).ShortName);        
            ViewBag.hidemenu = "hidemenu";
            return View(model);
        }
    }
}