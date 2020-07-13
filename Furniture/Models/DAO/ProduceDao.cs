using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class ProduceDao
    {
        Furniture db = null;
        public ProduceDao()
        {
            db = new Furniture();
        }
        public List<Produce> listproduce(long type, long? parentId)
        {
            return db.Produces.Where(x => x.Type==type).ToList();
        }
        public Produce findproduce(long? type, long parentId)
        {
            return db.Produces.Where(x => x.Type == type && x.ParentID == parentId).SingleOrDefault();
        }
    }
}
