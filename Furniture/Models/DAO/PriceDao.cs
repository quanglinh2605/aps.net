using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class PriceDao
    {
        Furniture db = null;
        public PriceDao()
        {
            db = new Furniture();
        }
        public FilterPrice getbyId(long? id)
        {
            if (id != null)
            {
                return db.FilterPrices.Where(x => x.ID == id).SingleOrDefault();
            }
            return null;
        }
        public List<FilterPrice> listAll()
        {
            return db.FilterPrices.ToList();
        }
    } 
}
