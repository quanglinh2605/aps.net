using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class ContentDao
    {
        Furniture db = null;
        public ContentDao()
        {
            db = new Furniture();
        }
        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Content> ListAll(string keyword, int page, int pagesize)
        {
            return db.Contents.OrderByDescending(x => x.CreateDate).ToPagedList(page, pagesize);
        }      
        public IEnumerable<Content> listByParentID(long id)
        {
            return db.Contents.Where(x => x.CategoryID == id).ToList();
        }
        public Content GetById(long id)
        {
            return db.Contents.Find(id);
        }
        public bool Update(Content entity)
        {
            var model = db.Contents.Find(entity.ID);
            try
            {
                model.Image = entity.Image;
                model.MetaDescriptions = entity.MetaDescriptions;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaTitle = entity.MetaTitle;
                model.ModifidedBy = entity.ModifidedBy;
                model.ModifidedDate = DateTime.Now;
                model.CreateBy = entity.CreateBy;
                model.CreateDate = DateTime.Now;
                model.Name = entity.Name;
                model.Status = entity.Status;
                model.Tags = entity.Tags;
                model.Description = entity.Description;
                model.Description1 = entity.Description1;
                model.Description2 = entity.Description2;
                model.Description3 = entity.Description3;
                model.Description4 = entity.Description4;
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
            db.Contents.Remove(GetById(id));
            db.SaveChanges();
            return true;
        }
    }
}
