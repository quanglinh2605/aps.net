﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CategoryPJ.Models.ModelsView;
using CategoryPJ.Models.ModelData;

namespace CategoryPJ.Models.Bussiness.ModuleCustomer
{
    public class ActionUser
    {
        public int InsertUser(UserModelView model)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            User q = new User{ Username = model.Username, isSubcrise = model.isSubcrise, Password = model.Password };
            en.Users.Add(q);
            int kq = en.SaveChanges();
            if (kq > 0)
            {
                return q.ID;
            }
            else return 0;
        }
        public bool deleteUser(int id)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            User q = new User();
            q = en.Users.Where(x => x.ID == id).FirstOrDefault();
            en.Users.Remove(q);
            int kq = en.SaveChanges();
            if (kq != 0)
            {
                return true;
            }
            else return false;
        }
        public bool updateUser(UserModelView model)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            User q = en.Users.Where(x => x.ID == model.ID).FirstOrDefault();
            if(q != null)
            {
                q.isSubcrise = model.isSubcrise;                           
            }
            int kq = en.SaveChanges();
            if (kq != 0) return true;
            else return false;
        }
        public List<UserModelView> showUser(string name)
        {
            List<UserModelView> lsUser = new List<UserModelView>();
            E_GreetingsEntities en = new E_GreetingsEntities();
            if (name == "" || name == null)
            {
                lsUser = en.Users.Select(x => new UserModelView
                {
                    ID = x.ID,
                    isSubcrise = x.isSubcrise,
                    Password = x.Password,
                    Username = x.Username
                }).ToList();
                return lsUser;
            }
            else
            {
                lsUser = en.Users.Where(x => x.Username.Contains(name)).Select(x => new UserModelView
                {
                    ID = x.ID,                   
                    isSubcrise = x.isSubcrise,
                    Password = x.Password,
                    Username = x.Username
                }).ToList();
                return lsUser;
            }
        }
        public UserModelView getUserById(int id)
        {
            UserModelView item = new UserModelView();
            E_GreetingsEntities en = new E_GreetingsEntities();
            item = en.Users.Where(x => x.ID == id).Select(x => new UserModelView { ID = x.ID, isSubcrise= x.isSubcrise, Password = x.Password, Username = x.Username}).FirstOrDefault();
            return item;
        }
        public bool feedback(FeedBackView model)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            en.FeedBacks.Add(new FeedBack {Text = model.Text });
            if (en.SaveChanges() > 0)
                return true;
            else return false;
        }
    }
}