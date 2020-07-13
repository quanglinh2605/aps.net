using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Greetings.Models.ModelsView;
using E_Greetings.Models.ModelsData;
using E_Greetings.Models.Bussiness.ModuleAdmin;

namespace E_Greetings.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult loginUser()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult loginUser(UserModelView model)
        {
            Admin check = new Admin();
            if (model.Username == check.name() && model.Password == check.pass())
            {
                Session["userID"] = model;
                return View("Index");
            }
            E_GreetingsEntities en = new E_GreetingsEntities();
            var q = en.Users.Where(x => x.Username == model.Username && x.Password == model.Password).Select(x => new UserModelView {
                ID = x.ID,
                isSubcrise = x.isSubcrise,
                Password = x.Password,
                Username = x.Username
            }).FirstOrDefault();
            if (q != null)
            {
                Session["userId"] = q;
                return RedirectToAction("Index","User", new { id = q.ID});
            }
            else
            {
                ViewBag.Mess = "Login Fail";
                return View();
            }            
        }    
        public ActionResult LogoutUser()
        {
            if (Session["userId"] != null)
            {
                Session.Remove("userId");
            }
            if (Session["temp_user"] != null)
            {
                Session.Remove("temp_user");
            }
            return RedirectToAction("Index", "User");
        }
        public ActionResult changePassword(UserModelView model)
        {
            Models.Bussiness.ModuleCustomer.ActionUser au = new Models.Bussiness.ModuleCustomer.ActionUser();
            bool result = au.updateUser(model);
            if (result == true)
            {
                if (Session["userId"] != null)
                {
                    Session.Remove("userId");
                }
                ViewData["mess"] = "Change password Successfull";
                return RedirectToAction("loginUser","Login");
            }
            ViewData["mess"] = "Can't change";
            return View(model);
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(UserModelView model)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            Random rd = new Random();
            model.Password = rd.Next(100000, 999999).ToString();
            Models.Bussiness.ModuleCustomer.ActionUser au = new Models.Bussiness.ModuleCustomer.ActionUser();
            if(en.Users.Where(x=>x.Username==model.Username).Count() == 0)
            {
                ViewBag.eror = "Your Account have not created already";
                return View();
            }
            bool result = au.updateUser(model);
            if (result == true)
            {
                return RedirectToAction("loginUser", "User");
            }
            return View();
        }
    }
} 

  
