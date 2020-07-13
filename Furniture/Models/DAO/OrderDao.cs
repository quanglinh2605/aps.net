using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class OrderDao
    {
        Furniture db = null;
        public OrderDao()
        {
            db = new Furniture();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public Order getById(long id)
        {
            return db.Orders.Find(id);
        }
    }
}
