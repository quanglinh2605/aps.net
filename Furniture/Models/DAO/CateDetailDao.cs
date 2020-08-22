using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class CateDetailDao
    {
        Furniture db = null;
        public CateDetailDao()
        {
            db = new Furniture();
        }

        public IEnumerable<CategoryDetail> pagetolist(string keyword, int page, int pagesize)
        {
            var model = db.CategoryDetails;
            if (!string.IsNullOrEmpty(keyword))
            {
                model.Where(x => x.Name.Contains(keyword));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pagesize);
        }

        public List<CategoryDetail> listCateDetail()
        {
            return db.CategoryDetails.ToList();
        }

        public List<CategoryDetail> getByCateID(long? id)
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

        public long Insert(CategoryDetail entity)
        {
            entity.TypeID = 2;
            db.CategoryDetails.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }
        
        public bool Update(CategoryDetail entity)
        {
            var model = db.CategoryDetails.Find(entity.ID);
            try
            {
                model.MetaDescription = entity.MetaDescription;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaTitle = entity.MetaTitle;
                model.ModifidedBy = entity.ModifidedBy;
                model.ModifidedDate = DateTime.Now;
                model.Name = entity.Name;
                model.CategoryID = entity.CategoryID;
                model.CreatedBy = entity.CreatedBy;
                model.CreatedDate = DateTime.Now;
                model.Description = entity.Description;
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
            db.CategoryDetails.Remove(getById(id));
            db.SaveChanges();
            return true;
        }
    }
}
