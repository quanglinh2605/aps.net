using CategoryPJ.Models.ModelData;
using CategoryPJ.Models.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryPJ.Models.Bussiness.ModuleAdmin
{
    public class TemplateAction
    {
        E_GreetingsEntities en = new E_GreetingsEntities();
        public bool createTemplate(TemplateModelView model)
        {
            try
            {
                en.Templates.Add(new Template
                {
                    IDCategory = model.IDCategory,
                    ImageTem = model.ImagePath,
                    Title = model.Title,
                    Descriptions = model.Descriptions
                });
                var kq = en.SaveChanges();
                if (kq > 0) return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return false;
        }
        public List<TemplateModelView> showTemplate(string name)
        {
            List<TemplateModelView> lstem = new List<TemplateModelView>();
            if (name == null || name == "")
            {
                lstem = en.Templates.OrderBy(x => x.IDCategory).Select(x => new TemplateModelView
                {
                    Descriptions = x.Descriptions,
                    ID = x.ID,
                    IDCategory = x.IDCategory,
                    ImagePath = x.ImageTem,
                    Title = x.Title
                }).ToList();
            }
            else
            {
                lstem = en.Templates.Where(x => x.Title.Contains(name)).OrderBy(x => x.IDCategory).Select(x => new TemplateModelView
                {
                    Descriptions = x.Descriptions,
                    ID = x.ID,
                    IDCategory = x.IDCategory,
                    ImagePath = x.ImageTem,
                    Title = x.Title
                }).ToList();
            }
            return lstem;
        }
        public List<TemplateModelView> showTempByCateId(int id, string name)
        {
            List<TemplateModelView> lstem = new List<TemplateModelView>();
            if (name == null || name == "")
            {
                lstem = en.Templates.Where(x => x.IDCategory == id).Select(x => new TemplateModelView
                {
                    Descriptions = x.Descriptions,
                    ID = x.ID,
                    IDCategory = x.IDCategory,
                    ImagePath = x.ImageTem,
                    Title = x.Title
                }).ToList();
            }
            else
            {
                lstem = en.Templates.Where(x => x.IDCategory == id && x.Title.Contains(name)).Select(x => new TemplateModelView
                {
                    Descriptions = x.Descriptions,
                    ID = x.ID,
                    IDCategory = x.IDCategory,
                    ImagePath = x.ImageTem,
                    Title = x.Title
                }).ToList();
            }
            return lstem;
        }
        public TemplateModelView getTempById(int id)
        {
            TemplateModelView item = new TemplateModelView();
            item = en.Templates.Where(x => x.ID == id).Select(x => new TemplateModelView
            {
                ID = x.ID,
                Descriptions = x.Descriptions,
                IDCategory = x.IDCategory,
                ImagePath = x.ImageTem,
                Title = x.Title
            }).FirstOrDefault();
            return item;
        }
        public bool updateTemp(TemplateModelView model)
        {
            var q = en.Templates.Where(x => x.ID == model.ID).FirstOrDefault();
            if (q != null)
            {
                q.IDCategory = model.IDCategory;
                q.ImageTem = model.ImagePath;
                q.Descriptions = model.Descriptions;
                q.Title = model.Title;
            }
            if (en.SaveChanges() > 0) return true;
            else return false;
        }
        public bool deleteTemp(int id)
        {
            var q = en.Templates.Where(x => x.ID == id).FirstOrDefault();
            if (q != null)
            {
                en.Templates.Remove(q);
            }
            if (en.SaveChanges() > 0) return true;
            return false;
        }
    }
}