﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace Furniture.Areas.Admin.Controllers
{
    public class ProductCateController : Controller
    {
        // GET: Admin/ProductCate
        public ActionResult Index(string keyword, int page = 1,int pagesize = 10)
        {  
            var dao = new ProductCateDao();
            ViewBag.keyword = keyword;
            ViewBag.listCate = new CategoryDao().ListAll(1);
            var model = dao.listAll(keyword, page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.listCategory = new CategoryDao().ListAll(1);
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCateDao();
                model.CreatedDate = DateTime.Now;
                var result = dao.Insert(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "ProductCate");
                }
                else
                {
                    ModelState.AddModelError("", "Them thanh cong");
                }
            }           
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductCateDao();
            var model = dao.getbyID(id);
            var cateDetail = new CateDetailDao().getById(model.ParentID);
            ViewBag.cateDetail = cateDetail;
            ViewBag.listCategory = new CategoryDao().ListAll(1);
            ViewBag.listCateDetail = new CateDetailDao().getByCateID(cateDetail.CategoryID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCateDao();
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "ProductCate");
                }
                else
                {
                    ModelState.AddModelError("", "Cap nhat thanh cong");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var dao = new ProductCateDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult listProCate(long id)
        {
            var listProCate = new ProductCateDao().getByCateDetailId(id);
            return Json(new
            {
                data = listProCate
            }, JsonRequestBehavior.AllowGet);
        }
    }
}