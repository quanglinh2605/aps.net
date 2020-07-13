using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantAPI.Models.ModelsView;

namespace RestaurantAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<RestaurantModelView> GetAllRestaurant()
        {
            var lsRes = new List<RestaurantModelView>();
            Models.ModelsData.RESTAURANTEntities re = new Models.ModelsData.RESTAURANTEntities();
            lsRes = re.Restaurants.Select(x => new RestaurantModelView { Id = x.Id, Name = x.Name, Address = x.Address, Password = x.Password, Phonenumber = x.Phonenumber, Username = x.Username }).ToList();
            return lsRes;
        }
        // GET api/<controller>/5
        public RestaurantModelView GetRestaurant(int id)
        {
            RestaurantModelView res = new RestaurantModelView();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                res = en.Restaurants.Where(x => x.Id == id).Select(x => new RestaurantModelView { Id = x.Id, Name = x.Name, Address = x.Address, Password = x.Password, Phonenumber = x.Phonenumber, Username = x.Username }).FirstOrDefault();
            }
            return res;
        }
        public IEnumerable<RestaurantModelView> getRestaurant(string name)
        {
            var res = new List<RestaurantModelView>();
            using(var en = new Models.ModelsData.RESTAURANTEntities())
            {
                res = en.Restaurants.Where(x => x.Name.Contains(name)||x.Address.Contains(name)||x.Username.Contains(name)).Select(x => new RestaurantModelView { Id = x.Id, Name = x.Name, Address = x.Address, Password = x.Password, Phonenumber = x.Phonenumber, Username = x.Username }).ToList();
                if (name == ""||name==null)
                {
                    res = en.Restaurants.Select(x => new RestaurantModelView { Id = x.Id, Name = x.Name, Address = x.Address, Password = x.Password, Phonenumber = x.Phonenumber, Username = x.Username }).ToList();
                }
            }
            return res;
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult newRes(RestaurantModelView model)
        {
            
            using(var re = new Models.ModelsData.RESTAURANTEntities())
            {
                re.Restaurants.Add(new Models.ModelsData.Restaurant { Name = model.Name, Address = model.Address, Password = model.Password, Phonenumber = model.Phonenumber, Username = model.Username });
                re.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult editRes(RestaurantModelView model)
        {
            using (var re = new Models.ModelsData.RESTAURANTEntities())
            {
                var resCurrent = re.Restaurants.Where(x => x.Id == model.Id).FirstOrDefault();
                if (resCurrent != null)
                {
                    resCurrent.Name = model.Name;
                    resCurrent.Address = model.Address;
                    resCurrent.Password = model.Password;
                    resCurrent.Phonenumber = model.Phonenumber;
                    resCurrent.Username = model.Username;
                    re.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var res = en.Restaurants.Where(x => x.Id == id).FirstOrDefault();
                if (res != null)
                {
                    en.Restaurants.Remove(res);
                    en.SaveChanges();
                }
            }
            return Ok();
        }
    }
}