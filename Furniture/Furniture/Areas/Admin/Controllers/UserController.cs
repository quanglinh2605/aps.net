using Furniture.Common;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Furniture.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string keyword,int page = 1, int pagesize = 5)
        {
            var dao = new UserDao();
            ViewBag.keyword = keyword;
            var model = dao.listAll(keyword, page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult create(User model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                model.Password = Encryptor.MD5Hash(model.Password);
                var id = dao.Insert(model);
                if (id > 0)
                {
                    setAlert("Them user thanh cong", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    setAlert("Them user khong thanh cong", "error");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new UserDao();
            var model = dao.getById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(model.Password))
                {
                    model.Password = Encryptor.MD5Hash(model.Password);
                }
                var result = dao.update(model);
                if (result)
                {
                    setAlert("Cap nhat user thanh cong", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    setAlert("Cap nhat user khong thanh cong", "error");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            var result = dao.delete(id);
            if (result == true)
            {
                setAlert("Xoa user thanh cong", "success");
            }
            else
            {
                setAlert("Xoa user khong thanh cong", "error");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult changeStatus(long id)
        {
            var result = new UserDao().changeStatus(id);
            return Json(new
            {
                status = result
            });
        }      
    }
}