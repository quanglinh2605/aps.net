using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Greetings.Models.ModelsView;
using E_Greetings.Models.ModelsData;
using PagedList;

namespace E_Greetings.Models.Bussiness.ModuleCustomer
{
    public class MailAction
    {
        public bool AddMail(MailGroupView model)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            en.Mailgroups.Add(new Mailgroup { IDMem = model.IDMem, Mail = model.Email });
            if (en.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateMail(MailGroupView model)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            var q = en.Mailgroups.Where(x => x.ID == model.ID).FirstOrDefault();
            if (q != null)
            {
                q.Mail = model.Email;
            }
            if (en.SaveChanges() > 0)
            {
                return true;
            }
            else return false;
        }
        public MailGroupView getMailById(int id)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            MailGroupView item = new MailGroupView();
            item = en.Mailgroups.Where(x => x.ID == id).Select(x => new MailGroupView { Email = x.Mail, ID = x.ID, IDMem = x.IDMem }).FirstOrDefault();
            return item;
        }
        public bool deleteMail(int id)
        {
            E_GreetingsEntities en = new E_GreetingsEntities();
            var q = en.Mailgroups.Where(x => x.ID == id).FirstOrDefault();
            if (q != null)
            {
                en.Mailgroups.Remove(q);
            }
            if (en.SaveChanges() > 0) return true;
            else return false;
        }
        public List<MailGroupView> showMail(string name, int id)
        {
            List<MailGroupView> lsMail = new List<MailGroupView>();
            E_GreetingsEntities en = new E_GreetingsEntities();
            if (name == ""||name == null)
            {
                lsMail = en.Mailgroups.Where(x => x.IDMem==id).Select(x => new MailGroupView
                {
                    Email = x.Mail,
                    ID = x.ID,
                    IDMem = x.IDMem
                }).ToList();
            }
            else
            {
                lsMail = en.Mailgroups.Where(x => x.Mail.Contains(name)&&x.IDMem == id).Select(x => new MailGroupView
                {
                    Email = x.Mail,
                    ID = x.ID,
                    IDMem = x.IDMem
                }).ToList();
            }
            return lsMail;
        }       
    }
}