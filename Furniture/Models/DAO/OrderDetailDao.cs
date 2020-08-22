using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class OrderDetailDao
    {
        Furniture db = null;
        public OrderDetailDao()
        {
            db = new Furniture();
        }

        public IEnumerable<OrderDetail> pagetolist(long id, int page, int pagesize)
        {
            var model = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            return model.ToPagedList(page, pagesize);
        }

        public List<OrderDetail> listAll()
        {
            return db.OrderDetails.ToList();
        }

        public bool Insert(OrderDetail orderDetail)
        {
            db.OrderDetails.Add(orderDetail);
            return db.SaveChanges() > 0;            
        }

        public List<OrderDetail> getByOrderId(long id)
        {
            return db.OrderDetails.Where(x => x.OrderID == id).ToList();
        }
    }
}
