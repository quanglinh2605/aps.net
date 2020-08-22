using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;

namespace Furniture.Controllers
{
    public class ProductCateController : Controller
    {
        ProductDao dao = new ProductDao();
        // GET: ProductCate
        public ActionResult Index(long cateId, long catedetailId, long id, long? idPrice) 
        {
            var model = dao.filterByPrice(idPrice, cateId, catedetailId);
            model = dao.listByProCateId(id);
            if (Session["sort"] != null)
            {
                model = dao.sortProduct((long)Session["sort"]);
            }
            Session.Add("cateId", cateId);
            Session.Add("catedetailId", catedetailId);
            ViewBag.proCate = new ProductCateDao().getbyID(id);
            //var produce = new ProduceDao().findproduce(type, id);
            //ViewBag.produce = produce;
            //ViewBag.listProduce = new ProduceDetailDao().listByProduceID(produce.ID);
            ViewBag.category = new CategoryDao().getById((long)Session["cateId"]);
            ViewBag.categoryDetail = new CateDetailDao().getById((long)Session["cateDetailId"]);
            ViewBag.listprice = new PriceDao().listAll();
            ViewBag.listProCate = new ProductCateDao().getByCateDetailId((long)Session["cateDetailId"]);
            Session.Add("price", idPrice);
            Session.Add("news", new ProductCateDao().getbyID(id).ShortName);            
            ViewBag.hidemenu = "hidemenu";
            return View(model);            
        }

    }
}