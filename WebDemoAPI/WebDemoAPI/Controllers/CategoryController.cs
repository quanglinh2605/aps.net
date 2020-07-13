using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebDemoAPI.Controllers
{
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Models.CategoryViewModel> Get()
        {
            List<Models.CategoryViewModel> lsCate = new List<Models.CategoryViewModel>();
            using(var en = new Models.exerciseEntities())
            {
                lsCate = en.categories.OrderBy(x => x.name).Select(x => new Models.CategoryViewModel { Id = x.id, Name = x.name, Label = x.label }).ToList();
            }
            return lsCate;
        }

        // GET api/<controller>/5
        public Models.CategoryViewModel Get(int id)
        {
            Models.CategoryViewModel cate = null; 
            using(var en = new Models.exerciseEntities())
            {
                cate = en.categories.Where(x => x.id == id).Select(x => new Models.CategoryViewModel {
                    Id = x.id,
                    Name = x.name,
                    Label = x.label
                }).FirstOrDefault();
            }
            return cate;
        }

        // POST api/<controller>
        public IHttpActionResult PostNewCategory(Models.CategoryViewModel cate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new Models.exerciseEntities())
            {
                ctx.categories.Add(new Models.category()
                {
                    name = cate.Name,
                    label=cate.Label
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Models.CategoryViewModel model)
        {
            using(var en = new Models.exerciseEntities())
            {
                var existingCate = en.categories.Where(x => x.id == model.Id).FirstOrDefault();
                if (existingCate != null)
                {
                    existingCate.name = model.Name;
                    existingCate.label = model.Label;
                    en.SaveChanges();
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
            using(var en = new Models.exerciseEntities())
            {
                var cate = en.categories.Where(x => x.id == id).FirstOrDefault();
                en.categories.Remove(cate);
                en.SaveChanges();
            }
            return Ok();
        }
    }
}