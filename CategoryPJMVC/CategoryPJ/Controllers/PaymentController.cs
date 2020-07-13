using CategoryPJ.Models.Bussiness.ModuleCustomer;
using CategoryPJ.Models.Library;
using CategoryPJ.Models.ModelsView;
using PagedList;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Controllers
{
    public class PaymentController : BaseController
    {
        PaymentAction pa = new PaymentAction();
        ActionUser au = new ActionUser();
        // GET: Payment
        public ActionResult createPayment(int userId)
        {
            ViewBag.userId = userId;
            bool kq = au.getUserById(userId).isSubcrise;
            ViewBag.check = kq;
            return View();
        }
        [HttpPost]
        public ActionResult createPayment(PaymentView model)
        {
            if (model.Price != 0)
            {
                if (Session["payment"] == null)
                {
                    Session["payment"] = model;
                }
                return RedirectToAction("PaymentWithPayPal");
            }
            else
            {
                ViewBag.check = false;
                ViewBag.userId = model.IDMem;
                return View(model);
            }
        }
        
        public ActionResult deletePayment(int id)
        {
            if (pa.deletePayment(id) == true)
            {
                ViewBag.Mess = "Delete Successfull";
            }
            else
            {
                ViewBag.Mess = "Can't Delete";
            }
            return RedirectToAction("showPayment", new { name = "" });
        }
        public ActionResult PaymentWithPayPal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Payment/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }
            //on successful payment, show success page to user.  
            return RedirectToAction("SuccessView");
        }
        private Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            PaymentView model = new PaymentView();
            //create itemlist and add item objects to it  
            if (Session["payment"] != null)
            {
                model = Session["Payment"] as PaymentView;
            }
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "Service Invoice",
                currency = "USD",
                price = model.Price.ToString(),
                quantity = "1"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = model.Price.ToString()
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = model.Price.ToString(), // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction send card here",
                invoice_number = DateTime.Now.Ticks.ToString(), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }
       public ActionResult SuccessView()
        {
            PaymentView model = new PaymentView();
            if (Session["payment"] != null)
            {
                model = Session["payment"] as PaymentView;
            }
            UserModelView user = new UserModelView();
            user = au.getUserById(model.IDMem);
            user.isSubcrise = true;
            au.updateUser(user);
            PaymentView payment = new PaymentView();
            payment = pa.getPaymentByMemID(model.IDMem);
            if (payment.ID != 0)
            {
                pa.updatePayment(model);
            }
            else
            {
                pa.createPayment(model);
            }
            Session.Remove("payment");
            return RedirectToAction("Index", "Home", new { id = model.IDMem});
       }
        public ActionResult FailureView()
        {
            return View();
        }
    }    
}