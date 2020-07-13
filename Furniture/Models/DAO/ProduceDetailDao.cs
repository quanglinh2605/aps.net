using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class ProduceDetailDao
    {
        Furniture db = null;
        public ProduceDetailDao()
        {
            db = new Furniture();
        }
        public List<ProduceDetail> listProdetail()
        {
            return db.ProduceDetails.ToList();
        }
        public List<ProduceDetail> listByProduceID(long id)
        {
            return db.ProduceDetails.Where(x => x.ProduceID == id).ToList();
        }
    }
}
