using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Greetings.Models.ModelsView;
using E_Greetings.Models.ModelsData;
using E_Greetings.Models.Bussiness.ModuleCustomer;
using E_Greetings.Models.Bussiness.ModuleAdmin;
namespace E_Greetings.Controllers
{
    public class temp_userController : Controller
    {
        Models.Library.FileUploadValidation fs = new Models.Library.FileUploadValidation();
        TemplateAction ta = new TemplateAction();
        temp_userAction tua = new temp_userAction();
        // GET: temp_user
        public ActionResult TempDetail(int id, int? userId, template_userView model)
        {
            TemplateModelView item = new TemplateModelView();
            item = ta.getTempById(id);
            ViewBag.userId = userId;
            if (model != null)
            {
                if (model.IDUser != 0)
                {
                    fs.supportedTypes = new[] { "mp3", "ogg" };
                    fs.filesize = 5;
                    var us = fs.UploadUserFile(model.FileMusic);
                    if (us != null)
                    {
                        ViewBag.ResultErrorMessage = fs.ErrorMessage;
                        model.FileMusic = null;
                        return View(item);
                    }
                    else
                    {
                        if (model.FileMusic != null)
                        {
                            model.PathMusic = DateTime.Now.Ticks + System.IO.Path.GetFileName(model.FileMusic.FileName);
                            model.FileMusic.SaveAs(Server.MapPath("~/Content/customerMusic/") + model.PathMusic);
                        }
                    }
                    fs.supportedTypes = new[] { "jpg", "jpeg", "png" };
                    us = fs.UploadUserFile(model.FilePhoto);
                    if (us != null)
                    {
                        ViewBag.ResultErrorMessage = fs.ErrorMessage;
                        model.FilePhoto = null;
                        return View(item);
                    }
                    else
                    {
                        if (model.FilePhoto != null)
                        {
                            model.PathPhoto = DateTime.Now.Ticks + System.IO.Path.GetFileName(model.FilePhoto.FileName);
                            model.FilePhoto.SaveAs(Server.MapPath("~/Content/customerPhoto/") + model.PathPhoto);
                        }
                    }
                    Session["temp_user"] = model;
                    return RedirectToAction("showTemp_user");
                }
            }
            return View(item);           
        }   
        [HttpPost]
        public ActionResult TempDetailAction(int id, UserModelView model)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            var q = en.Users.Where(x => x.Username == model.Username&& x.Password==model.Password).Select(x => new UserModelView {
                isSubcrise = x.isSubcrise,
                ID = x.ID,
                Password = x.Password,
                Username = x.Username
            }).FirstOrDefault();
            if (q != null) Session["userId"] = q;
            return RedirectToAction("TempDetail", new { id, userId = q.ID });
        }
        public ActionResult showTemp_user(int? id)
        {
            template_userView item = new template_userView();
            if (id != null)
            {
                ViewBag.id = id;
                item = tua.getitembyId(ViewBag.id);                
            }
            else
            {
                if (Session["temp_user"] != null)
                {
                    item = Session["temp_user"] as template_userView;
                }
            }
            ViewBag.Temp = ta.getTempById(item.IDTemp);
            return View(item);
        }        
    }
}