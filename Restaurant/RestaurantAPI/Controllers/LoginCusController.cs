using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantAPI.Controllers
{
    public class LoginCusController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public int loginCus(Models.ModelsView.CustomerModelView model)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var item = en.customers.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (item != null)
                {
                    return item.Id;
                }
                return 0;
            }
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}