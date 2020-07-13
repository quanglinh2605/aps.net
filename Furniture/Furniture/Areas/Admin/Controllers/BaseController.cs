using Furniture.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Furniture.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", area = "Admin" })
                    );
            }
            base.OnActionExecuting(filterContext);
        }
        protected void setAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }else if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
        }
    }
}