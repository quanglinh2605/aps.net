using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CategoryPJ.Models.ModelData;
using CategoryPJ.Models.ModelsView;

namespace CategoryPJ.Models.Bussiness.ModuleCustomer
{      
    public class temp_userAction
    {
        E_GreetingsEntities en = new E_GreetingsEntities();
        public List<template_userView> show(string name)
        {
            List<template_userView> lsitem = new List<template_userView>();
            if(name != null && name != "")
            {
                lsitem = en.Temp_User.Where(x => x.Title == name).Select(x => new template_userView
                {
                    ID = x.ID,
                    IDTemp = x.TempID,
                    IDUser = x.UserID,
                    Message = x.Message,
                    PathMusic = x.music,
                    PathPhoto = x.photo,
                    Title = x.Title
                }).ToList();
            }
            else
            {
                lsitem = en.Temp_User.Select(x => new template_userView
                {
                    ID = x.ID,
                    IDTemp = x.TempID,
                    IDUser = x.UserID,
                    Message = x.Message,
                    PathMusic = x.music,
                    PathPhoto = x.photo,
                    Title = x.Title
                }).ToList();
            }
            return lsitem;
        }
        public int create(template_userView model)
        {         
                var q = new Temp_User { TempID = model.IDTemp, UserID = model.IDUser, Message = model.Message, Title = model.Title, photo = model.PathPhoto, music = model.PathMusic };
                en.Temp_User.Add(q);
                if (en.SaveChanges() > 0) return q.ID;
            return 0;
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
        public template_userView getitembyId(int id)
        {
            template_userView item = new template_userView();
            item = en.Temp_User.Where(x => x.ID == id).Select(x => new template_userView {
                ID = x.ID,
                IDTemp = x.TempID,
                IDUser = x.UserID,
                PathMusic = x.music,
                Message = x.Message,
                PathPhoto = x.photo,
                Title = x.Title
            }).FirstOrDefault();
            return item;
        }
        public bool update(template_userView model)
        {
            var q = en.Temp_User.Where(x => x.ID == model.ID).FirstOrDefault();
            if (q != null)
            {
                q.TempID = model.IDTemp;
                q.UserID = model.IDUser;
                q.music = model.PathMusic;
                q.photo = model.PathPhoto;
                q.Message = model.Message;
                q.Title = model.Title;
            }
            if (en.SaveChanges() > 0) return true;
            return false;
        }
        public bool delete(int id)
        {
            var q = en.Temp_User.Where(x => x.ID == id).FirstOrDefault();
            if (q != null)
            {
                en.Temp_User.Remove(q);
            }
            if (en.SaveChanges() > 0) return true;
            return false;
        }
    }
}