using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class OrderDao
    {
        Furniture db = null;
        public OrderDao()
        {
            db = new Furniture();
        }

        public IEnumerable<Order> pagetolist(string keyword, int page, int pagesize)
        {
            var model = db.Orders;
            if (!string.IsNullOrEmpty(keyword))
            {
                model.Where(x => x.ShipAddress.Contains(keyword) || x.ShipEmail.Contains(keyword) || x.ShipMobile.Contains(keyword) || x.ShipName.Contains(keyword));
            }
            return model.OrderBy(x => x.ShipName).ToPagedList(page, pagesize);
        }

        public List<Order> ListAll()
        {
            return db.Orders.ToList();
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

        public Order getByName(string name)
        {
            return db.Orders.Where(x => x.ShipName == name || x.ShipMobile == name).SingleOrDefault();
        }

        public List<Order> getByPhone(string value)
        {
            return db.Orders.Where(x => x.ShipMobile == value).ToList();
        }

        public bool Update(Order entity)
        {
            var model = db.Orders.Find(entity.ID);
            try
            {
                model.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            db.Orders.Remove(getById(id));
            db.SaveChanges();
            return true;
        }
    }
}
