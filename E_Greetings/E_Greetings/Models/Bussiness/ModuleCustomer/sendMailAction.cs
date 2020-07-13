using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using E_Greetings.Models.ModelsData;
using E_Greetings.Models.ModelsView;
using Newtonsoft.Json;
namespace E_Greetings.Models.Bussiness.ModuleCustomer
{
    public class sendMailAction
    {
        ActionUser au = new ActionUser();
        temp_userAction tua = new temp_userAction();
        E_GreetingsEntities en = new E_GreetingsEntities();
        public List<SendMailView> showMail(string name, int userId)
        {
            List<SendMailView> lsMail = new List<SendMailView>();
            if (name !=null && name != "")
            {
                List<SendMail> mails = new List<SendMail>();
                var lstemp_user = en.Temp_User.Where(x => x.Title.Contains(name)).ToList();
                foreach (var e in lstemp_user)
                {
                    var q = en.SendMails.Where(x => x.IDtemp_user == e.ID).FirstOrDefault();
                    mails.Add(q);
                }
                SendMailView item = new SendMailView();
                foreach (var i in mails)
                {
                    item.ID = i.ID; item.IDtemp_user = i.IDtemp_user; item.Message = i.Message;
                    item.Sendby = i.Sendby; item.SendDate = i.SendDate.ToString("MM/dd/yyyy");
                    item.Receiver = JsonConvert.DeserializeObject<List<string>>(i.Receiver);
                    lsMail.Add(item);
                }
            }
            else
            {
                List<SendMail> mails = new List<SendMail>();
                var q = en.SendMails.ToList();
                foreach(var i in q)
                {
                    if (tua.getitembyId(i.IDtemp_user).IDUser == userId) mails.Add(i);
                }
                SendMailView item = new SendMailView();
                foreach(var i in mails)
                {
                    item.ID = i.ID; item.IDtemp_user = i.IDtemp_user; item.Message = i.Message;
                    item.Sendby = i.Sendby; item.SendDate = i.SendDate.ToString("MM/dd/yyyy");                    
                    item.Receiver = JsonConvert.DeserializeObject<List<string>>(i.Receiver);                   
                    lsMail.Add(item);
                }
            }
            return lsMail;
        }
        public bool createSend(SendMailView model)
        {
            string jsonReceiver = JsonConvert.SerializeObject(model.Receiver);
            DateTime date = DateTime.Today;
            en.SendMails.Add(new SendMail
            {
                SendDate = date,
                IDtemp_user = model.IDtemp_user,
                Message = model.Message,
                Receiver = jsonReceiver, 
                Sendby = model.Sendby
            });
            if (en.SaveChanges() > 0) return true;
            return false;
        }
        public SendMailView getSendById(int id)
        {
            SendMailView item = new SendMailView();
            var q = en.SendMails.Where(x => x.ID == id).FirstOrDefault();
            item.ID = q.ID;
            item.IDtemp_user = q.IDtemp_user;
            item.Message = q.Message;
            item.Receiver = JsonConvert.DeserializeObject<List<string>>(q.Receiver);
            item.Sendby = q.Sendby;
            item.SendDate = q.SendDate.ToString("MM/dd/yyyy");
            return item;
        }
        public bool sendMail(SendMailView model, string receiver)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("quanglinh220401@gmail.com");
            mailMessage.To.Add(receiver);
            mailMessage.Subject = model.Sendby + " had send for you a card onlie";
            mailMessage.Body = model.Message+"\n" + "<a href=http://localhost:52373/temp_user/showTemp_user?id=" + model.IDtemp_user +"'>";
            mailMessage.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();

            //Add the Creddentials- use your own email id and password
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("quanglinh220401@gmail.com", "dangbichtrinh");
            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (SmtpFailedRecipientException)
            {
                return false;
            }
        }
   
    //public bool updateSend(SendMailView model)
    //{
    //    var q = en.SendMails.Where(x => x.ID == model.ID).FirstOrDefault();
    //    if(q != null)
    //    {
    //        q.IDtemp_user = model.IDtemp_user;
    //        q.Message = model.Message;
    //        q.Receiver = model.Receiver;
    //        q.Sendby = model.Sendby;
    //        q.SendDate = model.SendDate;
    //    }
    //    if (en.SaveChanges() > 0) return true;
    //    return false;
    //}
    //public bool deteleSend(int id)
    //{
    //    var q = en.SendMails.Where(x => x.ID == id).FirstOrDefault();
    //    if (q != null)
    //    {
    //        en.SendMails.Remove(q);
    //    }
    //    if (en.SaveChanges() > 0) return true;
    //    return false;
    //}       
}
}