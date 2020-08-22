using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var dao = new OrderDao();
            ViewBag.keyword = keyword;
            ViewBag.listDetail = new OrderDetailDao().listAll();
            return View(dao.pagetolist(keyword, page, pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Insert(model);
                if (result > 0)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Them danh muc thanh cong");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new CategoryDao().getById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(model);
                if (result)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Cap nhat danh muc thanh cong");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var dao = new CategoryDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(long id)
        {
            var detail = new OrderDetailDao().pagetolist(id, 1,10);
            List<Product> listProduct = new List<Product>();
            foreach(var i in detail)
            {
                Product product = new Product();
                product = new ProductDao().getByID(i.ProductID);
                listProduct.Add(product);
            }
            ViewBag.listProduct = listProduct;
            return View(detail);
        }
    }
}