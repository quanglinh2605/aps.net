using Modelclass.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelclass.DAO
{
    public class TemplateDAO
    {

        Model11 db =  new Model11();
        
        public List<Template> List()
        {
            return db.Templates.ToList();
        }
        public List<Template> ListAll(string name)
        {
            if(name != null)
            {
                return db.Templates.Where(x => x.Title.Contains(name)).ToList();
            }
            return db.Templates.ToList();
        }
        public List<Template> Search(string name)
        {
            return db.Templates.Where(x => x.Title == name).ToList();
        }
        //list template in category
        public List<Template> TemByCategory(int id)
        {
            return db.Templates.Where(x => x.IDCategory == id).ToList();
        }

        //template
        public Template ViewDetails(int id)
        {
            return db.Templates.Find(id);
        }

        //Create template


        //Action Insert
        public long Insert(Template entity)
        {
          
            db.Templates.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        //Action Update
        public Template ViewDetail(int id)
        {
            return db.Templates.Find(id);
        }
        public bool Update(Template entity)
        {
            try
            {
                var template = db.Templates.Find(entity.ID);
                template.Title = entity.Title;
                template.Descriptions = entity.Descriptions;
                template.ImageTem = entity.ImageTem;
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
                var tem = db.Templates.Find(id);
                db.Templates.Remove(tem);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
