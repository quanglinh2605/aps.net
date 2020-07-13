using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantAPI.Models.ModelsView;

namespace RestaurantAPI.Controllers
{
    public class TableController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<TableModelView> GetTableActive(int Res_Id, bool status)
        {
            List<TableModelView> lstable = new List<TableModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lstable = en.tablenumbers.Where(x => x.Res_ID == Res_Id && x.Status==status).Select(x => new TableModelView { Id=x.Id,Name = x.Name, Res_ID = x.Res_ID, Status = x.Status, NumberSeat = x.NumberSeat }).ToList();
            }
            return lstable;
        }
        // GET api/<controller>/5
        public IEnumerable<TableModelView> GetTable(string Name, int Res_Id)
        {
            var item = new List<TableModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {                
                item = en.tablenumbers.Where(x => x.Res_ID == Res_Id && x.Name.Contains(Name)).Select(x => new TableModelView
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    Res_ID = x.Res_ID,
                    NumberSeat = x.NumberSeat
                }).ToList();
                if (Name == "" || Name == null)
                {
                    item = en.tablenumbers.Where(x => x.Res_ID == Res_Id).Select(x => new TableModelView
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Status = x.Status,
                        Res_ID = x.Res_ID,
                        NumberSeat = x.NumberSeat
                    }).ToList();
                }
            }
            return item;
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post(TableModelView model)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                en.tablenumbers.Add(new Models.ModelsData.tablenumber { Name = model.Name, Res_ID = model.Res_ID, Status = model.Status, NumberSeat = model.NumberSeat });
                en.SaveChanges();
                return Ok();
            }        
        }
        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult Put(TableModelView model)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var item = en.tablenumbers.Where(x => x.Id == model.Id && x.Res_ID == model.Res_ID).FirstOrDefault();
                item.Name = model.Name;
                item.Status = model.Status;
                item.NumberSeat = model.NumberSeat;
                en.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string name)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var item = en.tablenumbers.Where(x => x.Name == name).FirstOrDefault();
                en.tablenumbers.Remove(item);
                en.SaveChanges();
                return Ok();
            }
        }
    }
}