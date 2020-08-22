using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class ProductCateDao
    {
        Furniture db = null;
        public ProductCateDao()
        {
            db = new Furniture();
        }
        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public List<ProductCategory> listprocate()
        {
            return db.ProductCategories.Where(x => x.Status == true).ToList();
        }
        public List<ProductCategory> getByCateDetailId(long? id)
        {
            return db.ProductCategories.Where(x => x.ShowOnHome==true && x.ParentID == id).OrderBy(x => x.DisplayOrder).ToList();
        }
        public IEnumerable<ProductCategory> listAll(string keyword, int page, int pagesize)
        {
            var model = db.ProductCategories;
            if (!string.IsNullOrEmpty(keyword))
            {
                model.Where(x => x.Name.Contains(keyword));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pagesize);
        }
        public ProductCategory getbyID(long? id)
        {
            return db.ProductCategories.Find(id);
        } 
        public bool Update(ProductCategory entity)
        {
            var model = getbyID(entity.ID);
            try
            {
                model.CreateBy = entity.CreateBy;
                model.CreatedDate = DateTime.Now;
                model.MetaDescriptions = entity.MetaDescriptions;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaTitle = entity.MetaTitle;
                model.ModifidedBy = entity.ModifidedBy;
                model.ModifidedDate = DateTime.Now;
                model.Name = entity.Name;
                model.Status = entity.Status;
                model.Size = entity.Size;
                model.Pattern1 = entity.Pattern1;
                model.Pattern2 = entity.Pattern2;
                model.Pattern3 = entity.Pattern3;
                model.DesignStyle = entity.DesignStyle;
                model.DesignShape = entity.DesignShape;
                model.SizeDetail = entity.SizeDetail;
                model.Color = entity.Color;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            var model = getbyID(id);
            db.ProductCategories.Remove(model);
            db.SaveChanges();
            return true;
        }
    }
}
