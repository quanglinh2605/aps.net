using CategoryPJ.Models.Bussiness.ModuleAdmin;
using CategoryPJ.Models.Bussiness.ModuleCustomer;
using CategoryPJ.Models.ModelData;
using CategoryPJ.Models.ModelsView;
using Modelclass.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Controllers
{
    public class temp_userController : Controller
    {
        Models.Library.FileUploadValidation fs = new Models.Library.FileUploadValidation();

        temp_userAction tua = new temp_userAction();        
        
        // GET: temp_user
        public ActionResult TempDetail(int id, int? userId, template_userView model)
        {

            var session = (CurrentUser)Session[CategoryPJ.Commont.CommontConst.USER_SECCION];
            userId = session.UserID ;

            TemplateModelView item = new TemplateModelView();
            item = tua.getTempById(id);
            ViewBag.userId = userId;
            if (model != null)
            {
                if (model.IDUser != 0)
                {
                    fs.supportedTypes = new[] { "mp3", "ogg" };
                    fs.filesize = 50;
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
            var q = en.Users.Where(x => x.Username == model.Username && x.Password == model.Password).Select(x => new UserModelView
            {
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
                if (Session["temp_user"] == null)
                {
                    Session["temp_user"] = item;
                }
            }
            else
            {
                if (Session["temp_user"] != null)
                {
                    item = Session["temp_user"] as template_userView;
                }
            }
            ViewBag.Temp = tua.getTempById(item.IDTemp);
            return View(item);
        }
        //public ActionResult deleteTemp_user(int id)
        //{
        //    tua.delete(id);
        //    return RedirectToAction("showCard","SendMail");
        //}
    }
}