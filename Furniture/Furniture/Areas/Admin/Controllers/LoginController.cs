using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Furniture.Areas.Admin.Models;
using Furniture.Common;
using Models.DAO;
using Models.EF;

namespace Furniture.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            Session.Add(CommonConstants.USER_SESSION, null);
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            
                var dao = new UserDao();
                var result = dao.Login(model.username, Encryptor.MD5Hash(model.password));
                if (result == 1)
                {
                    var user = dao.getByName(model.username);
                    var userSession = new UserLogin();
                    userSession.UserID = user.ID;
                    userSession.Username = user.Name;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if(result == 0)
                    {
                        ModelState.AddModelError("", "Tai khoan khong ton tai");
                    }else if(result == -1)
                    {
                        ModelState.AddModelError("", "Tai khoan da bi khoa");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mat khau khong chinh xac");
                    }
                }         
            return View("Index");
        }
    }
}