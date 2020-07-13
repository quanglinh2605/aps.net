using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CategoryPJ.Models.ModelsView;
using CategoryPJ.Models.ModelData;
namespace CategoryPJ.Models.Bussiness.ModuleCustomer
{
    public class PaymentAction
    {
        E_GreetingsEntities en = new E_GreetingsEntities();        
        public List<PaymentView> showPayment(string name)
        {
            List<PaymentView> lspayment = new List<PaymentView>();
            if(name==null || name == "")
            {
                foreach(var item in en.Payments.ToList())
                {
                    PaymentView model = new PaymentView{ IDMem = item.IDMem, ID = item.ID, endDate = item.endDate.ToString("MM/dd/yyyy"), Price = item.Price, status = item.status, StartDate = item.StartDate.ToString("MM/dd/yyyy") };
                    lspayment.Add(model);
                }
            }
            else
            {
                foreach (var it in en.Users.Where(x => x.Username.Contains(name)))
                {
                    var item = en.Payments.Where(x => x.IDMem == it.ID).FirstOrDefault();
                    PaymentView model = new PaymentView { IDMem = item.IDMem, ID = item.ID, endDate = item.endDate.ToString("MM/dd/yyyy"), Price = item.Price, status = item.status, StartDate = item.StartDate.ToString("MM/dd/yyyy") };
                    lspayment.Add(model);
                }
            }
            return lspayment;
        }
        public bool createPayment(PaymentView model)
        {
            en.Payments.Add(new Payment {
                IDMem = model.IDMem,
                StartDate = Convert.ToDateTime(model.StartDate),
                endDate = Convert.ToDateTime(model.endDate),
                Price = model.Price,
                status = model.status
            });
            if (en.SaveChanges() > 0) return true;
            else return false;
        }
        public PaymentView getPaymentById(int id)
        {
            PaymentView item = new PaymentView();
            var q = en.Payments.Where(x => x.ID == id).FirstOrDefault();
            if (q != null)
            {
                item.ID = q.ID;
                item.IDMem = q.IDMem;
                item.Price = q.Price;
                item.StartDate = q.StartDate.ToShortDateString();
                item.endDate = q.endDate.ToShortDateString();
                item.status = q.status;
            }
            return item;
        }
        public PaymentView getPaymentByMemID(int id)
        {
            PaymentView item = new PaymentView();
            var q = en.Payments.Where(x => x.IDMem == id).FirstOrDefault();
            if (q != null)
            {
                item.ID = q.ID;
                item.IDMem = q.IDMem;
                item.Price = q.Price;
                item.StartDate = q.StartDate.ToShortDateString();
                item.endDate = q.endDate.ToShortDateString();
                item.status = q.status;
            }
            return item;
        }
        public bool updatePayment(PaymentView model)
        {
            var q = en.Payments.Where(x => x.IDMem == model.IDMem).FirstOrDefault();
            if (q != null)
            {
                q.IDMem = model.IDMem;
                if (q.status == true && model.status == true)
                {
                    q.StartDate = q.endDate;
                }
                else
                {
                    q.StartDate = Convert.ToDateTime(model.StartDate);
                }                
                q.endDate = q.StartDate.AddMonths(+1);
                q.StartDate = Convert.ToDateTime(model.StartDate);
                q.Price = model.Price;
                q.status = model.status;
            }
            if (en.SaveChanges() > 0) return true;
            return false;
        }
        public bool deletePayment(int id)
        {
            var q = en.Payments.Where(x => x.ID == id).FirstOrDefault();
            if (q != null)
            {
                en.Payments.Remove(q);
            }
            if (en.SaveChanges() > 0) return true;
            return false;
        }
    }
}