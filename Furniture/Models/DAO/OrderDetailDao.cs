using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class OrderDetailDao
    {
        Furniture db = null;
        public OrderDetailDao()
        {
            db = new Furniture();
        }
        public bool Insert(OrderDetail orderDetail)
        {
            db.OrderDetails.Add(orderDetail);
            return db.SaveChanges() > 0;            
        }
    }
}
