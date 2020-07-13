using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderRestaurant.Controllers
{
    public class CartController : Controller
    {
        
        // GET: Cart
        public ActionResult Index(int Cus_Id)
        {
            ViewBag.Cus_Id = Cus_Id;
            return View();
        }
        public ActionResult Buy(int id, int Res_Id, int Cus_Id)
        {
            Models.MenuModel md = new Models.MenuModel();
            if (Session["cart"] == null)
            {
                List<Models.DetailMenu> cart = new List<Models.DetailMenu>();
                cart.Add(new Models.DetailMenu { Menu = md.find(id,Res_Id,""), quantity = 1, Cus_Id = Cus_Id });
                Session["cart"] = cart;
            }
            else
            {
                List<Models.DetailMenu> cart = (List<Models.DetailMenu>)Session["cart"];
                int index = isExist(id,Cus_Id);
                if (index != -1)
                {
                    cart[index].quantity++;
                }
                else
                {
                    cart.Add(new Models.DetailMenu { Menu = md.find(id, Res_Id, ""), quantity = 1, Cus_Id = Cus_Id });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("showMenu","Menu",new {Res_Id, Cus_Id, name =""});
        }

        public ActionResult Remove(int id, int Cus_Id)
        {
            List<Models.DetailMenu> cart = (List<Models.DetailMenu>)Session["cart"];
            int index = isExist(id,Cus_Id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int isExist(int id, int Cus_Id)
        {
            List<Models.DetailMenu> cart = (List<Models.DetailMenu>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Menu.Id == id && cart[i].Cus_Id == Cus_Id)
                    return i;
            return -1;
        }

    }
}