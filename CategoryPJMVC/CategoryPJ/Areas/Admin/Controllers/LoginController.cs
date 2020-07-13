using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CategoryPJ.Areas.Admin.Models;
using CategoryPJ.Commont;
using Modelclass.DAO;

namespace CategoryPJ.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            Session.Add(CommontConst.USER_SECCION, null);
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName,model.Password);
                if (result == 1 )
                {
                    var userSession = new CurrentUser();
                    userSession.Username = "nghia";
                    userSession.UserID =1;
                    Session.Add(CommontConst.USER_SECCION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "sai ten dang nhap");
                }
                else
                {
                    ModelState.AddModelError("", "sai mat khau");
                }
            }
            return View("Index");

        }
    }
}