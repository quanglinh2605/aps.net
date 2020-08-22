using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Furniture.Models;
using Models.DAO;
using Models.EF;
namespace Furniture.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
                Session[Common.CommonConstants.quantityCart] = list.Count;
            }
            return View(list);
        }

        public ActionResult AddItem(long ProductId, int Quantity)
        {
            var cart = Session[CartSession];
            var product = new ProductDao().getByID(ProductId);
            if (cart != null)
            {
                var list = (List<CartItem>)Session[CartSession];
                if(list.Exists(x => x.Product.ID == ProductId))
                {
                    foreach(var item in list)
                    {
                        if(item.Product.ID == ProductId)
                        {
                            item.Quantity += Quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = Quantity;
                var List = new List<CartItem>();
                List.Add(item);
                Session[CartSession] = List;
            }
            return RedirectToAction("Index");
        }

        public JsonResult RemoveItem(int pid)
        {
            List<CartItem> sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.Remove(sessionCart.Find(x => x.Product.ID == pid));
            Session[CartSession] = sessionCart;
            Session[Common.CommonConstants.quantityCart] = sessionCart.Count;
            decimal? total = 0;
            foreach(var item in sessionCart)
            {
                total = total + (item.Quantity * item.Product.Price);
            }
            return Json(new {
                total
            });
        }

        public ActionResult payment(string sDienthoai, string sEmail, string sTen, string sDiachi)
        {
            Order order = new Order();
            order.ShipEmail = sEmail;
            order.ShipAddress = sDiachi;
            order.ShipMobile = sDienthoai;
            order.ShipName = sTen;
            order.CreateDate = DateTime.Now;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var dao = new OrderDetailDao();
                Session["orderId"] = id;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.Quantity = item.Quantity;
                    dao.Insert(orderDetail);
                }
            }catch(Exception e)
            {
                throw;
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            ViewBag.hidemenu = "hidemenu";
            var id =(long) Session["orderId"];
            Order order = new OrderDao().getById(id);
            ViewBag.listcart = (List<CartItem>)Session[CartSession];
            Session.RemoveAll();
            return View(order);
        }
    }
}