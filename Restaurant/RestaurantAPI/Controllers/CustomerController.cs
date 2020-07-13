using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantAPI.Models.ModelsView;

namespace RestaurantAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CustomerModelView> GetAllCustomer()
        {
            var lscus = new List<CustomerModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lscus = en.customers.Select(x => new CustomerModelView { Email = x.Email, Id=x.Id, Password=x.Password, PhoneNumber=x.PhoneNumber, Fullname = x.Fullname,Gender=x.Gender }).ToList();
            }
            return lscus;
        }

        // GET api/<controller>/5
        public CustomerModelView GetCustomer(int id)
        {
            var item = new CustomerModelView();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                item = en.customers.Where(x => x.Id == id).Select(x => new CustomerModelView {Email = x.Email,Fullname=x.Fullname,Gender=x.Gender,Id=x.Id,Password=x.Password,PhoneNumber=x.PhoneNumber }).FirstOrDefault();
            }
            return item;
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult NewCus(CustomerModelView model)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                en.customers.Add(new Models.ModelsData.customer {Fullname = model.Fullname, Email=model.Email, Gender =model.Gender, Password = model.Password, PhoneNumber = model.PhoneNumber });
                en.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult EditCus(CustomerModelView model)
        {
            using(var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var CurCus = en.customers.Where(x => x.Id == model.Id).FirstOrDefault();
                CurCus.Fullname = model.Fullname;
                CurCus.Email = model.Email;
                CurCus.Gender = model.Gender;
                CurCus.Password = model.Password;
                CurCus.PhoneNumber = model.PhoneNumber;
                en.SaveChanges();
            }
            return Ok();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string name)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var item = en.customers.Where(x => x.Fullname == name).FirstOrDefault();
                if (item != null)
                {
                    en.customers.Remove(item);
                    en.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}