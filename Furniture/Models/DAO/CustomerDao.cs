using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class CustomerDao
    {
        Furniture db = null;
        public CustomerDao()
        {
            db = new Furniture();   
        }

        public IEnumerable<Customer> pagetolist(string keyword, int page, int pagesize)
        {
            var model = db.Customers;
            if (!string.IsNullOrEmpty(keyword))
            {
                model.Where(x => x.Address.Contains(keyword) || x.Email.Contains(keyword) || x.Name.Contains(keyword)).ToList();
            }
            return model.ToPagedList(page, pagesize);
        }

        public List<Customer> ListAll()
        {
            return db.Customers.ToList();
        }

        public Customer getById(long? id)
        {
            return db.Customers.Find(id);
        } 
    }
}
