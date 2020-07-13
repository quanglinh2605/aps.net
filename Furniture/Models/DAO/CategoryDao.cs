using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;
namespace Models.DAO
{
    public class CategoryDao
    {
        Furniture db = null;
        public CategoryDao()
        {
            db = new Furniture();
        }
        public IEnumerable<Category> pagetolist(string keyword, int page, int pagesize)
        {
            var model = db.Categories;
            if (!string.IsNullOrEmpty(keyword)){
                model.Where(x => x.Name.Contains(keyword));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pagesize);
        }
        public List<Category> ListAll(long id)
        {
            return db.Categories.Where(x => x.Status==true && x.TypeID == id).ToList();
        }
        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }
        public Category getById(long? id)
        {
            return db.Categories.Find(id);
        }
        public Category getByName(string name)
        {
            return db.Categories.Where(x => x.Name==name || x.ShortName == name).SingleOrDefault();
        }
        public bool Update(Category entity)
        {
            var model = db.Categories.Find(entity.ID);
            try
            {
                model.MetaDescriptions = entity.MetaDescriptions;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaTitle = entity.MetaTitle;
                model.ModifidedBy = entity.ModifidedBy;
                model.ModifidedDate = DateTime.Now;
                model.Name = entity.Name;
                model.ParentID = entity.ParentID;
                model.SeoTittle = entity.SeoTittle;
                model.ShowOnHome = entity.ShowOnHome;
                model.CreateBy = entity.CreateBy;
                model.CreatedDate = DateTime.Now;
                model.DisplayOrder = entity.DisplayOrder;
                model.Description = entity.Description;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            db.Categories.Remove(getById(id));
            db.SaveChanges();
            return true;
        }
    }
}
