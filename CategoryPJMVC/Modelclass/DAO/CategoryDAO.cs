using Modelclass.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelclass.DAO
{
    public class CategoryDAO
    {
        Model11 db = new Model11();
        
        //List in menu
        public List<Category> ListAll()
        {
            return db.Categories.OrderBy(x=> x.ID).ToList();
        }

        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IOrderedQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Occasions.Contains(searchString)).OrderByDescending(x => x.ID);
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
 
       //Action Insert
        public long Insert(Category entity)
        {
          
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        //Action Update
        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }
        public bool Update(Category entity)
        {
            try
            {
                var category = db.Categories.Find(entity.ID);
                category.Occasions = entity.Occasions;
                category.Descriptions = entity.Descriptions;
                category.ImageCate = entity.ImageCate;
                
                /*+ DateTime.Now.ToString("yymmssfff");*/
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Action Delete
        public bool Delete(int id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //category in list product
        public Category Categoryoftemplate (int id)
        {
            return db.Categories.Find(id);
        }
    }
}
