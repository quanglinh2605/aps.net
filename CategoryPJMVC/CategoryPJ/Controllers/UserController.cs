using BotDetect.Web.Mvc;
using CategoryPJ.Commont;
using CategoryPJ.Models;
using CategoryPJ.Models.Bussiness.ModuleCustomer;
using CategoryPJ.Models.ModelData;
using CategoryPJ.Models.ModelsView;
using Modelclass.DAO;
using Modelclass.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.Username))
                {
                    ModelState.AddModelError("", "Username have exit!!");
                }else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email have exit!!");
                }
                else
                {
                    var user = new Modelclass.EF.User();
                    user.Username = model.Username;;
                    user.email = model.Email;
                    user.phone = model.Phone;
                    user.Password = Encryptor.MD5Hash(model.Password);

                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Register success";
                        model = new RegisterModel();
                        return RedirectToAction("Index", "Home");
                    }else
                    {
                        ModelState.AddModelError("", "Register not success");
                    }
                }

            }
            
            return View(model);
        }
        ActionUser au = new ActionUser();
        public ActionResult FeedBack()
        {
            UserModelView user = new UserModelView();
            if (Session["userId"] != null)
            {
                user = Session["userId"] as UserModelView;
            }
            var session = (CurrentUser)Session[CategoryPJ.Commont.CommontConst.USER_SECCION];
            ViewBag.userId = session.UserID;
            return View();
        }
        [HttpPost]
        public ActionResult FeedBack(FeedBackView model)
        {
            au.feedback(model);
            return RedirectToAction("Thanks");
        }
        public ActionResult Thanks()
        {
            return View();
        }
    }
}