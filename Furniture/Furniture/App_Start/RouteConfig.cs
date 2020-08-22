using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Furniture
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
    new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "Furniture.Controllers" }
           );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );

            routes.MapRoute(
                name: "News",
                url: "tin-tuc-tu-van",
                defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );

            routes.MapRoute(
               name: "Check Order",
               url: "kiem-tra-don-hang",
               defaults: new { controller = "Invoice", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Furniture.Controllers" }
           );

            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "payment", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );


            routes.MapRoute(
                name: "CategoryDetail",
                url: "danh-muc-con/{metatitle}-{cateId}-{catedetailId}",
                defaults: new { controller = "CategoryDetail", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );

            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{metatitle}-{cateId}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );

            routes.MapRoute(
               name: "ProductCategory",
               url: "chi-tiet/{metatitle}-{cateId}-{catedetailId}-{id}",
               defaults: new { controller = "ProductCate", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Furniture.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Furniture.Controllers" }
            );
        }
    }
}
