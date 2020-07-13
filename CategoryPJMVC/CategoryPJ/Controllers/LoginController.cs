using CategoryPJ.Commont;
using CategoryPJ.Models.ModelData;
using CategoryPJ.Models.ModelsView;
using Modelclass.DAO;
using CategoryPJ.Models.Bussiness.ModuleCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        PaymentAction pa = new PaymentAction();
        ActionUser au = new ActionUser();
        public ActionResult loginUser()
        {
            Session.Add(CommontConst.USER_SECCION, null);
            return View();
        }
        [HttpPost]
        public ActionResult loginUser(UserModelView model)
        {
            
            var dao = new UserDAO();
            var result = dao.CustomLogin(model.Username, Encryptor.MD5Hash(model.Password));
            if (result == 1)
            {
                var user = dao.GetById(model.Username);
                var userSession = new CurrentUser();
                userSession.Username = user.Username;
                userSession.UserID = user.ID;
                Session.Add(CommontConst.USER_SECCION, userSession);
                E_GreetingsEntities en = new E_GreetingsEntities();


                var q = en.Users.Where(x => x.Username == model.Username).Select(x => new UserModelView
                {
                    ID = x.ID,
                    isSubcrise = x.isSubcrise,
                    Password = x.Password,
                    Username = x.Username,
                    Phone = x.phone,
                    Email = x.email
                }).FirstOrDefault();
                if (q != null)
                {
                    if (DateTime.Compare(Convert.ToDateTime(pa.getPaymentByMemID(q.ID).endDate), DateTime.Today) <= 0)
                    {
                        q.isSubcrise = false;
                        au.updateUser(q);
                        PaymentView item = new PaymentView();
                        item = pa.getPaymentByMemID(q.ID);
                        item.status = false;
                        pa.updatePayment(item);
                    }
                    Session["userId"] = q;
                    return RedirectToAction("Index", "Home", new { id = q.ID });
                }
                else
                {
                    ViewBag.Mess = "Login Fail";
                    return View();
                }
            }
            else if (result == 0)
            {
                ModelState.AddModelError("", "sai ten dang nhap");
                ViewBag.Mess = "Login Fail ";
            }
            else
            {
                ModelState.AddModelError("", "sai mat khau");
                ViewBag.Mess = "Login Fail";
            }
          
            return View();
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
            Session.Add(CommontConst.USER_SECCION, null);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult changePassword()
        {
            UserModelView model = new UserModelView();
            if (Session["userId"] != null)
            {
                model = Session["userId"] as UserModelView;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult changePassword(UserModelView model)
        {
            bool result = au.updateUser(model);
            if (result == true)
            {
                if (Session["userId"] != null)
                {
                    Session.Remove("userId");
                }
                ViewData["mess"] = "Change Inform Successfull";
                return RedirectToAction("loginUser", "Login");
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
            if (en.Users.Where(x => x.Username == model.Username).Count() == 0)
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