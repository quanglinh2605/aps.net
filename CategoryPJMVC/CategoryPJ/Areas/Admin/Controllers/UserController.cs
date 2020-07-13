using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CategoryPJ.Commont;
using CategoryPJ.Models.ModelData;
using CategoryPJ.Models.ModelsView;
using Modelclass.DAO;
using Modelclass.EF;
using PagedList;
using User = Modelclass.EF.User;

namespace CategoryPJ.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index( int page =1, int pageSize= 5)
        {
            var dao = new UserDAO();
            /*ViewBag.Searching = searchString;*/
            var model = dao.ListAllPaging( page, pageSize);
            return View(model);
        }

        //controller create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pa = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pa;
                }
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "them thanh cong user");
                }
            }
            return View("Index");
        }

        //Action edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;

                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Edit user success!!");
                }
            }
            return View("Index");
        }
        
        //Action Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult ShowFeedBack()
        {
            List<CategoryPJ.Models.ModelsView.FeedBackView> list = new List<FeedBackView>();
            E_GreetingsEntities en = new E_GreetingsEntities();
            list = en.FeedBacks.Select(x => new FeedBackView
            {


                
                Text = x.Text,
            }).ToList();
            return View(list);
        }
    }
}