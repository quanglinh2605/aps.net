using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantAPI.Controllers
{
    public class LoginController : ApiController
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
        //POST api/<controller>
        public int LoginRes(Models.ModelsView.RestaurantModelView model)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var item = en.Restaurants.Where(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
                if (item != null)
                {
                    return item.Id;
                }
                return 0;
            }
        }
   
        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult ChangePassword(Models.ModelsView.RestaurantModelView model)
        {
            using(var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var q = en.Restaurants.Where(x => x.Id == model.Id).FirstOrDefault();               
                    q.Password = model.Password;
                    return Ok();                                    
            }
        }
        
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}