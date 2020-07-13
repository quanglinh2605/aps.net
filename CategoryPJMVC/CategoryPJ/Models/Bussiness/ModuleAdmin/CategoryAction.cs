using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Greetings.Models.ModelsData;
using E_Greetings.Models.ModelsView;

namespace E_Greetings.Models.Bussiness.ModuleAdmin
{
    public class CategoryAction
    {
        E_GreetingsEntities en = new E_GreetingsEntities();
        public List<CategoryView> showCate(string name)
        {
            List<CategoryView> lsCate = new List<CategoryView>();
            if(name ==null||name == "")
            {
                lsCate = en.Categories.Select(x => new CategoryView { ID = x.ID, Occasions = x.Occasions}).ToList();
            }
            else
            {
                lsCate = en.Categories.Where(x=> x.Occasions.Contains(name)).Select(x => new CategoryView { ID = x.ID, Occasions = x.Occasions }).ToList();
            }
            return lsCate;
        }
        public bool createCate(CategoryView model)
        {
            en.Categories.Add(new Category { Occasions = model.Occasions });
            if (en.SaveChanges() > 0) return true;
            return false;
        }
        public CategoryView getCateById(int id)
        {
            CategoryView item = new CategoryView();
            item = en.Categories.Where(x => x.ID == id).Select(x => new CategoryView { ID = x.ID, Occasions = x.Occasions}).SingleOrDefault();
            return item;
        }
        public bool deleteCate(int id)
        {
            var q = en.Categories.Where(x => x.ID == id).FirstOrDefault();
            if (q != null)
            {
                en.Categories.Remove(q);
            }
            if (en.SaveChanges() > 0) return true;
            return false;
        }
        public bool updateCate(CategoryView model)
        {
            var q = en.Categories.Where(x => x.ID == model.ID).FirstOrDefault();
            if (q != null)
            {
                q.Occasions = model.Occasions;
            }
            if (en.SaveChanges() > 0) return true;
            return false;
        }
    }
}