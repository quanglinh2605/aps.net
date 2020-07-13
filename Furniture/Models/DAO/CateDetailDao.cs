using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class CateDetailDao
    {
        Furniture db = null;
        public CateDetailDao()
        {
            db = new Furniture();
        }
        public List<CategoryDetail> listCateDetail()
        {
            return db.CategoryDetails.ToList();
        }
        public List<CategoryDetail> getByCateID(long id)
        {
            return db.CategoryDetails.Where(x => x.CategoryID == id && x.TypeID == 2).ToList();
        }
        public CategoryDetail getById(long? cateDetailId)
        {
            return db.CategoryDetails.Where(x => x.ID == cateDetailId).SingleOrDefault();
        }
        public CategoryDetail getByName(string name)
        {
            return db.CategoryDetails.Where(x => x.Name == name).SingleOrDefault();
        }
        public List<CategoryDetail> getSubMenuByTypeId(long id)
        {
            return db.CategoryDetails.Where(x => x.TypeID == id).ToList();
        }
    }
}
