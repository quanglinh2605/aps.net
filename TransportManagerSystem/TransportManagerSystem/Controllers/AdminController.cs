using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;
using System.Web.Mvc;
using TransportManagerSystem.Models.ModelsViews;
using System.Web.Helpers;
using System.Net;
using System.Net.Mail;

namespace TransportManagerSystem.Controllers
{
    public class AdminController : Controller
    {
        int pagesize = 5;
        // GET: Admin
        public ActionResult Index()
        {
            string usertype = "";
            if (Session["userType"] != null)
            {
                usertype = Session["userType"] as string;
                return View();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login(Account model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Accounts.Where(x => x.Username == model.Username && x.Password == model.Password).Select(x => new Account { usertype_id = x.usertype_id, Id = x.Id }).FirstOrDefault();
            if (q != null)
            {
                var r = RTO.Usertypes.Where(x => x.Id == q.usertype_id).Select(x => new user { Name = x.Name }).First();
                ViewBag.Status = r.Name;
                Session["userType"] = r.Name;
                var cookie = new HttpCookie("userType");
                cookie.Value = r.Name;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Status"] = "Login fail";
                return View();
            }
        }
        public ActionResult logout()
        {
            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();

            Session["userType"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult AccessDeny()
        {
            return View();
        }
        #region Owner
        public ActionResult RegisterOwner()
        {
            return View();
        }
        public ActionResult CreateOwner(OwnerDetail model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            if (RTO.ownerDetails.Where(x => x.Id_Card == model.Id_Card).Count() != 0)
            {
                TempData["Warn"] = 1;
                return RedirectToAction("RegisterOwner");
            }
            RTO.ownerDetails.Add(new Models.ModelsData.ownerDetail { Fullname = model.Fullname, Address = model.Address, Birthday = Convert.ToDateTime(model.Birthday), PhoneNumber = model.PhoneNumber, Id_Card = model.Id_Card });
            RTO.SaveChanges();
            return RedirectToAction("ShowOwner");
        }
        public ActionResult ShowOwner(string searchString, int? page)
        {
            List<OwnerDetail> model;
            int pagenumber = (page ?? 1);
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            model = RTO.ownerDetails.Select(d => new OwnerDetail { Id = d.Id, Fullname = d.Fullname, Address = d.Address, Birthday = d.Birthday.ToString(), PhoneNumber = d.PhoneNumber, Id_Card = d.Id_Card }).ToList();
            ViewBag.searchString = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = RTO.ownerDetails.Where(d => d.Fullname.Contains(searchString) || d.Address.Contains(searchString)).OrderBy(d => d.Fullname).Select(d => new Models.ModelsViews.OwnerDetail { Id = d.Id, Fullname = d.Fullname, Address = d.Address, Birthday = d.Birthday.ToString(), PhoneNumber = d.PhoneNumber, Id_Card = d.Id_Card }).ToList();
            }
            return View(model.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult EditOwner(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.ownerDetails.Where(x => x.Id == Id).First();
            OwnerDetail item = new OwnerDetail();
            item.Id = q.Id;
            item.Fullname = q.Fullname;
            item.Address = q.Address;
            item.Birthday = q.Birthday.ToString();
            item.PhoneNumber = q.PhoneNumber;
            item.Id_Card = q.Id_Card;
            return View(item);
        }
        [HttpPost]
        public ActionResult EditOwner(OwnerDetail model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.ownerDetails.Where(x => x.Id == model.Id).First();
            q.Fullname = model.Fullname;
            q.Address = model.Address;
            q.Birthday = Convert.ToDateTime(model.Birthday);
            q.PhoneNumber = model.PhoneNumber;
            q.Id_Card = model.Id_Card;
            RTO.SaveChanges();
            return RedirectToAction("ShowOwner");
        }
        public ActionResult deleteOwner(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.ownerDetails.Where(x => x.Id == Id).SingleOrDefault();
            RTO.ownerDetails.Remove(q);
            RTO.SaveChanges();
            return RedirectToAction("ShowOwner");
        }
        #endregion
        #region Account
        public ActionResult CreateAccount()
        {            
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Usertypes.Select(d => new user { Id = d.Id, Name = d.Name }).ToList();
            var k = RTO.Regionals.Select(d => new Regional { Id = d.Id, Name = d.Name }).ToList();
             
            ViewBag.lsusertype = q;
            ViewBag.lsRegional = k;

            return View();
        }

        public ActionResult CreateAccountDB(Account model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            if (RTO.Accounts.Where(x => x.Username == model.Username).Count() != 0)
            {
                TempData["Warn"] = 1;
                return RedirectToAction("CreateAccount");
            }
            RTO.Accounts.Add(new Models.ModelsData.Account { Fullname = model.Fullname, Username = model.Username, Password = model.Password, PhoneNumber = model.PhoneNumber, usertype_id = model.usertype_id, Regional_Id = model.Regional_Id, Status = model.Status });
            RTO.SaveChanges();
            return RedirectToAction("ShowAccount");
        }
        public ActionResult ShowAccount(string searchString, int? page)
        {
            if (Session["userType"].Equals("Admin"))
            {
                List<Account> model;
                int pagenumber = (page ?? 1);
                Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
                var k = RTO.Usertypes.Select(d => new user { Id = d.Id, Name = d.Name }).ToList();
                var l = RTO.Regionals.Select(d => new Regional { Id = d.Id, Name = d.Name }).ToList();
                ViewBag.lsusertype = k;
                ViewBag.lsRegion = l;
                model = RTO.Accounts.Select(d => new Account { Id = d.Id, Username = d.Username, Password = d.Password, Fullname = d.Fullname, PhoneNumber = d.PhoneNumber, usertype_id = d.usertype_id, Regional_Id = d.Regional_Id, Status = d.Status }).ToList();
                ViewBag.searchString = searchString;
                if (!string.IsNullOrEmpty(searchString))
                {
                    model = RTO.Accounts.Where(x => x.Username.Contains(searchString) || x.Fullname.Contains(searchString)).OrderBy(d => d.Username).Select(d => new Models.ModelsViews.Account { Id = d.Id, Username = d.Username, Password = d.Password, Fullname = d.Fullname, PhoneNumber = d.PhoneNumber, usertype_id = d.usertype_id, Regional_Id = d.Regional_Id, Status = d.Status }).ToList();
                    var regions = RTO.Regionals.Where(x => x.Name.Contains(searchString)).Select(x => new Regional { Id = x.Id, Name = x.Name }).ToList();
                    foreach (var i in regions)
                    {
                        var accs = RTO.Accounts.OrderBy(d => d.Username).Select(d => new Account { Id = d.Id, Username = d.Username, Password = d.Password, Fullname = d.Fullname, PhoneNumber = d.PhoneNumber, usertype_id = d.usertype_id, Regional_Id = d.Regional_Id, Status = d.Status }).ToList();
                        foreach (var e in accs)
                        {
                            if (e.Regional_Id == i.Id)
                            {
                                model.Add(e);
                            }
                        }
                    }
                }
                return View(model.ToPagedList(pagenumber, pagesize));
            }
            else
            {
                return RedirectToAction("AccessDeny");
            }

        }
        public ActionResult editAccount(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Accounts.Where(x => x.Id == Id).First();
            var l = RTO.Usertypes.Select(x => new Models.ModelsViews.user { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.lsuser = l;
            var k = RTO.Regionals.Select(x => new Models.ModelsViews.Regional { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.lsregion = k;
            Models.ModelsViews.Account item = new Models.ModelsViews.Account();
            item.Id = q.Id;
            item.Username = q.Username;
            item.Password = q.Password;
            item.Fullname = q.Fullname;
            item.PhoneNumber = q.PhoneNumber;
            item.Regional_Id = q.Regional_Id;
            item.usertype_id = q.usertype_id;
            item.Status = q.Status;
            return View(item);
        }
        [HttpPost]
        public ActionResult editAccount(Models.ModelsViews.Account model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Accounts.Where(x => x.Id == model.Id).First();
            q.Username = model.Username;
            q.Password = model.Password;
            q.PhoneNumber = model.PhoneNumber;
            q.Fullname = model.Fullname;
            q.Regional_Id = model.Regional_Id;
            q.usertype_id = model.usertype_id;
            q.Status = model.Status;
            RTO.SaveChanges();
            return RedirectToAction("ShowAccount");
        }
        public ActionResult resetAccount(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Accounts.Where(x => x.Id == Id).First();
            q.Password = "12345678";
            RTO.SaveChanges();
            TempData["mess"] = "Reset Successfull";
            return RedirectToAction("ShowAccount");
        }
        #endregion
        #region Regional
        public ActionResult createRegional()
        {
            return View();
        }
        public ActionResult createRegionalDB(Regional model)
        {            
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            if(RTO.Regionals.Where(x=> x.Name == model.Name).Count() != 0)
            {
                TempData["Warn"] = "1";
                return RedirectToAction("createRegional"); 
            }
            RTO.Regionals.Add(new Models.ModelsData.Regional { Name = model.Name });
            RTO.SaveChanges();
            return RedirectToAction("showRegion");
        }
        public ActionResult showRegion(string searchString, int? page)
        {
            List<Regional> model;
            int pagenumber = (page ?? 1);
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            model = RTO.Regionals.Select(d => new Regional { Id = d.Id, Name = d.Name }).ToList();
            ViewBag.searchString = searchString;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                model = RTO.Regionals.Where(d => d.Name.Contains(searchString)).OrderBy(d => d.Name).Select(d => new Regional { Id = d.Id, Name = d.Name }).ToList();
            }
            return View(model.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult EditRegional(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Regionals.Where(x => x.Id == Id).First();
            Regional item = new Regional();
            item.Id = q.Id;
            item.Name = q.Name;
            return View(item);
        }
        [HttpPost]
        public ActionResult EditRegional(Regional model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Regionals.Where(x => x.Id == model.Id).First();
            q.Name = model.Name;
            RTO.SaveChanges();
            return RedirectToAction("showRegion",new { searchString="",page = ViewBag.pagenumber as int?});
        }
        public ActionResult deleteRegion(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Regionals.Where(x => x.Id == Id).SingleOrDefault();
            RTO.Regionals.Remove(q);
            RTO.SaveChanges();
            return RedirectToAction("showRegion");
        }
        #endregion
        #region Transport
        public ActionResult createTransport()
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.TransportTypes.Select(x => new Models.ModelsViews.TransportType { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.lsTypes = q;
            return View();
        }
        public ActionResult createTransportDB(Models.ModelsViews.TransportPart model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            if (RTO.TransportParts.Where(x => x.Name == model.Name).Count() != 0)
            {
                TempData["Warn"] = 1;
                return RedirectToAction("createTransport");
            }
            RTO.TransportParts.Add(new Models.ModelsData.TransportPart { Name = model.Name });
            RTO.SaveChanges();
            return RedirectToAction("showTransport");
        }
        public ActionResult showTransport(string searchString, int? page)
        {
            int pagenumber = (page ?? 1);
            List<TransportPart> model;
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            model = RTO.TransportParts.Select(x => new TransportPart { Id = x.Id, Name = x.Name, TwoWheelNumber = (RTO.TransportDetails.Where(d => x.Id == d.Transport_Id && d.TransType_Id == 1 ).ToList()).Count(), fourWheelNumber = (RTO.TransportDetails.Where(d => d.Transport_Id == x.Id && d.TransType_Id==2).ToList()).Count()}).ToList();
            var k = RTO.TransportTypes.Select(x => new Models.ModelsViews.TransportType { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.searchString = searchString;
            ViewBag.lsTypes = k;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                model = RTO.TransportParts.Where(x => x.Name.Contains(searchString)).Select(x => new TransportPart { Id = x.Id, Name = x.Name, TwoWheelNumber = (RTO.TransportDetails.Where(d => x.Id == d.Transport_Id && d.TransType_Id == 1).ToList()).Count(), fourWheelNumber = (RTO.TransportDetails.Where(d => d.Transport_Id == x.Id && d.TransType_Id == 2).ToList()).Count() }).ToList();
            }
            return View(model.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult editTrans(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.TransportParts.Where(x => x.Id == Id).First();
            TransportPart item = new TransportPart();
            item.Id = q.Id;
            item.Name = q.Name;
            return View(item);
        }
        [HttpPost]
        public ActionResult editTrans(TransportPart model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.TransportParts.Where(x => x.Id == model.Id).First();
            q.Name = model.Name;
            RTO.SaveChanges();
            return RedirectToAction("showTransport");
        }        
        public ActionResult deleteTrans(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.TransportParts.Where(x => x.Id == Id).SingleOrDefault();
            RTO.TransportParts.Remove(q);
            RTO.SaveChanges();
            return RedirectToAction("showTransport");
        }
        #endregion
        #region Transport Detail
        public ActionResult createTransportDetail()
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.Accounts.Select(x => new Account { Id = x.Id, Username = x.Username }).ToList();
            var k = RTO.TransportParts.Select(x => new TransportPart { Id = x.Id, Name = x.Name }).ToList();
            var l = RTO.ownerDetails.Select(x => new OwnerDetail { Id = x.Id, Fullname = x.Fullname }).ToList();
            var a = RTO.Regionals.Select(x => new Regional { Id = x.Id, Name = x.Name }).ToList();
            var b = RTO.TransportTypes.Select(x => new Models.ModelsViews.TransportType { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.lsregion = a;
            ViewBag.lstype = b;
            ViewBag.lsAcc = q;
            ViewBag.lstrans = k;
            ViewBag.lsowner = l;
            return View();
        }
        public ActionResult createTransDetailDB(TransportDetail model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            RTO.TransportDetails.Add(new Models.ModelsData.TransportDetail { Account_Id = model.Account_id, Owner_Id = model.Owner_id, Transport_Id = model.Transport_id, TransType_Id = model.transType_Id, License_Plate = model.Number, Color = model.Color, Region_Id = model.Region_Id, status = model.Status });
            RTO.SaveChanges();
            return RedirectToAction("showTransDetail");
        }
        public ActionResult showTransDetail(string searchString, int? page, int? Id)
        {            
            List<TransportDetail> model;
            int pagenumber = (page ?? 1);
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            model = RTO.TransportDetails.Select(x => new TransportDetail { Id = x.Id, Account_id = x.Account_Id, Owner_id = x.Owner_Id, Transport_id = x.Transport_Id, transType_Id = x.TransType_Id, Number = x.License_Plate, Color = x.Color, Region_Id=x.Region_Id, Status = x.status }).ToList();
            var m = RTO.Accounts.Select(x => new Account { Id = x.Id, Username = x.Username }).ToList();
            var k = RTO.TransportParts.Select(x => new TransportPart { Id = x.Id, Name = x.Name }).ToList();
            var l = RTO.ownerDetails.Select(x => new OwnerDetail { Id = x.Id, Fullname = x.Fullname }).ToList();
            var a = RTO.Regionals.Select(x => new Regional { Id = x.Id, Name = x.Name }).ToList();
            var b = RTO.TransportTypes.Select(x => new Models.ModelsViews.TransportType { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.lsregion = a;
            ViewBag.lstype = b;
            ViewBag.searchString = searchString;
            ViewBag.lsacc = m;
            ViewBag.lstranspart = k;
            ViewBag.lsowner = l;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                model = RTO.TransportDetails.Where(x => x.Color.Contains(searchString) || x.License_Plate.Contains(searchString)).Select(x => new TransportDetail { Id = x.Id, Account_id = x.Account_Id, Owner_id = x.Owner_Id, Transport_id = x.Transport_Id, transType_Id=x.TransType_Id, Number = x.License_Plate, Color = x.Color,Region_Id=x.Region_Id, Status = x.status }).ToList();
                var transdetail = RTO.TransportDetails.Select(x => new TransportDetail { Id = x.Id, Account_id = x.Account_Id, Owner_id = x.Owner_Id, Transport_id = x.Transport_Id, transType_Id = x.TransType_Id, Number = x.License_Plate, Color = x.Color, Region_Id=x.Region_Id, Status = x.status }).ToList();
                var trans = RTO.TransportParts.Where(x => x.Name.Contains(searchString)).Select(x => new TransportPart { Id = x.Id }).ToList();
                foreach (var i in trans)
                {
                    foreach (var e in transdetail)
                    {
                        if (e.Transport_id == i.Id)
                        {
                            model.Add(e);
                        }
                    }
                }
                var accs = RTO.Accounts.Where(x => x.Username.Contains(searchString)).Select(x => new Account { Id = x.Id }).ToList();
                foreach (var i in accs)
                {
                    foreach (var e in transdetail)
                    {
                        if (e.Account_id == i.Id)
                        {
                            model.Add(e);
                        }
                    }
                }
                var owners = RTO.ownerDetails.Where(x => x.Fullname.Contains(searchString)).Select(x => new Account { Id = x.Id }).ToList();
                foreach (var i in owners)
                {
                    foreach (var e in transdetail)
                    {
                        if (e.Owner_id == i.Id)
                        {
                            model.Add(e);
                        }
                    }
                }
            }
            if (Id != null)
            {
                model = RTO.TransportDetails.Where(x => x.Transport_Id == Id).Select(x => new TransportDetail { Id = x.Id, Account_id = x.Account_Id, Owner_id = x.Owner_Id, Transport_id = x.Transport_Id, transType_Id = x.TransType_Id, Number = x.License_Plate, Color = x.Color, Region_Id = x.Region_Id, Status = x.status }).ToList();
            }
            return View(model.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult editTransDetail(int Id)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.TransportDetails.Where(x => x.Id == Id).First();
            var m = RTO.Accounts.Select(x => new Models.ModelsViews.Account { Id = x.Id, Username = x.Username }).ToList();
            var k = RTO.TransportParts.Select(x => new Models.ModelsViews.TransportPart { Id = x.Id, Name = x.Name }).ToList();
            var l = RTO.ownerDetails.Select(x => new Models.ModelsViews.OwnerDetail { Id = x.Id, Fullname = x.Fullname }).ToList();
            var a = RTO.Regionals.Select(x => new Regional { Id = x.Id, Name = x.Name }).ToList();
            var b = RTO.TransportTypes.Select(x => new Models.ModelsViews.TransportType { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.lsregion = a;
            ViewBag.lstype = b;
            ViewBag.lsacc = m;
            ViewBag.lstranspart = k;
            ViewBag.lsowner = l;
            TransportDetail item = new TransportDetail();
            item.Account_id = q.Account_Id;
            item.Transport_id = q.Transport_Id;
            item.Owner_id = q.Owner_Id;
            item.transType_Id = q.TransType_Id;
            item.Number = q.License_Plate;
            item.Color = q.Color;
            item.Region_Id = q.Region_Id;
            item.Status = q.status;
            return View(item);
        }
        [HttpPost]
        public ActionResult editTransDetail(TransportDetail model)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var q = RTO.TransportDetails.Where(x => x.Id == model.Id).First();
            q.Account_Id = model.Account_id;
            q.Transport_Id = model.Transport_id;
            q.Owner_Id = model.Owner_id;
            q.TransType_Id = model.transType_Id;
            q.License_Plate = model.Number;
            q.Color = model.Color;
            q.status = model.Status;
            q.Region_Id = model.Region_Id;
            RTO.SaveChanges();
            return RedirectToAction("showTransDetail");
        }

        public ActionResult statusTrans(bool status)
        {
            Models.ModelsData.RegionalTransportOfficeEntities RTO = new Models.ModelsData.RegionalTransportOfficeEntities();
            var model = RTO.TransportDetails.Where(x => x.status == status).Select(x => new Models.ModelsViews.TransportDetail { Id = x.Id, Account_id = x.Account_Id, Owner_id = x.Owner_Id, Transport_id = x.Transport_Id,transType_Id=x.TransType_Id, Number = x.License_Plate, Color = x.Color,Region_Id=x.Region_Id, Status = x.status }).ToList();
            return View(model);
        }
        #endregion
        #region Feedback
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult sendFeedback(Models.ModelsViews.Feedback model)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("quanglinh220401@gmail.com");
            mailMessage.To.Add("quanglinh220401@gmail.com");
            mailMessage.Subject = "Feedback from" + model.Name;
            mailMessage.Body = model.Email + "\n" + model.PhoneNumber + "\n" + model.Content;
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
                ViewBag.Status = "Thanks for your feedback";
            }
            catch (SmtpFailedRecipientException)
            {
                ViewBag.Status = "Send error";
            }
            return View();
        }
    }
    #endregion
}