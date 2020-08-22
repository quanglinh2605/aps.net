using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class MenuDao
    {
        Furniture db = null;
        public MenuDao()
        {
            db = new Furniture();
        }
        public List<Menu> getListMenuByTypeID(long id)
        {
            return db.Menus.Where(x => x.TypeID == id).OrderBy(x => x.DisplayOrder).ToList();
        }

        public IEnumerable<Menu> pagetolist(string keyword, int page, int pagesize)
        {
            var model = db.Menus;
            if (!string.IsNullOrEmpty(keyword))
            {
                model.Where(x => x.Text.Contains(keyword));
            }
            return model.OrderBy(x => x.TypeID).ToPagedList(page, pagesize);
        }

        public List<Menu> ListAll()
        {
            return db.Menus.ToList();
        }

        public long Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }
        public Menu getById(long? id)
        {
            return db.Menus.Find(id);
        }
        public Menu getByName(string name)
        {
            return db.Menus.Where(x => x.Text == name).SingleOrDefault();
        }
        public bool Update(Menu entity)
        {
            var model = db.Menus.Find(entity.ID);
            try
            {
                model.Link = entity.Link;
                model.Text = entity.Text;
                model.TypeID = entity.TypeID;
                model.DisplayOrder = entity.DisplayOrder;
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
            db.Menus.Remove(getById(id));
            db.SaveChanges();
            return true;
        }
    }
}
