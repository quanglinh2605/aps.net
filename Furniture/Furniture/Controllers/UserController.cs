using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Furniture.Models;
using Models.DAO;
using Models.EF;
using BotDetect.Web.Mvc;
namespace Furniture.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.hidemenu = "hidemenu";
            return View();
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "RegisterCaptcha", "Wrong Captcha!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.Username))
                {
                    ModelState.AddModelError("", "ten dang nhap da ton tai");
                }
                else if(dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "email da ton tai");
                }
                else
                {
                    var user = new User();
                    user.Username = model.Username;
                    user.Name = model.Name;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    var result = dao.Insert(user);
                    if(result > 0)
                    {
                        ViewBag.Success = "Dang ky thanh cong.";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Dang ky khong thanh cong.");
                    }
                }
            }
            ViewBag.hidemenu = "hidemenu";
            return View(model);
        }
    }
}