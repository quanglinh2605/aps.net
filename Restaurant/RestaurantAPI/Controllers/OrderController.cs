using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantAPI.Models.ModelsView;

namespace RestaurantAPI.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/<controller>
        public List<OrderModelView> GetAllOrder (int Res_Id)
        {
            var lsOrder = new List<OrderModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lsOrder = en.checkOrders.Where(x => x.Id_Res==Res_Id).Select(x => new OrderModelView { choosetable = x.choosetable, Id = x.Id, Id_Customer = x.Id_Customer, Id_Res = x.Id_Res, numberSeat = x.numberSeat, status = x.status, timeStart = x.timeStart, OrderStatus = x.OrderStatus }).ToList();
            }
            return lsOrder;
        }

        // GET api/<controller>/5
        public OrderModelView Get(int id)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var item = en.checkOrders.Where(x => x.Id == id).Select(x => new OrderModelView { Id = x.Id, choosetable = x.choosetable,Menu = x.Menu, Id_Customer = x.Id_Customer, Id_Res = x.Id_Res, numberSeat = x.numberSeat, status = x.status, timeStart = x.timeStart, OrderStatus =x.OrderStatus }).FirstOrDefault();
                return item;
            }
        }

        public List<OrderModelView> getlsOrder(int id_Cus, string tablename)
        {
            var lsOrder = new List<OrderModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lsOrder = en.checkOrders.Where(x => x.Id_Customer == id_Cus || x.choosetable.Contains(tablename)).Select(x => new OrderModelView
                {
                    choosetable = x.choosetable,
                    Id_Customer = x.Id_Customer,
                    Id = x.Id,
                    Id_Res = x.Id_Res,
                    numberSeat = x.numberSeat,
                    timeStart = x.timeStart,
                    status = x.status,
                    OrderStatus=x.OrderStatus,
                    Menu=x.Menu
                }).ToList();
            }
            return lsOrder;
        }

        public List<OrderModelView> getcheckOrder(int Id_Res, string status)
        {
            var lsOrder = new List<OrderModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lsOrder = en.checkOrders.Where(x => x.Id_Res == Id_Res && x.status==status).Select(x => new OrderModelView
                {
                    choosetable = x.choosetable,
                    Id_Customer = x.Id_Customer,
                    Id = x.Id,
                    Id_Res = x.Id_Res,
                    numberSeat = x.numberSeat,
                    timeStart = x.timeStart,
                    status = x.status,
                    OrderStatus = x.OrderStatus,
                    Menu=x.Menu
                }).ToList();
            }
            return lsOrder;
        }

        public List<OrderModelView> getStatusOrder(int id_Cus, bool status)
        {
            var lsOrder = new List<OrderModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lsOrder = en.checkOrders.Where(x => x.Id_Customer == id_Cus && x.OrderStatus == status).Select(x => new OrderModelView
                {
                    choosetable = x.choosetable,
                    Id_Customer = x.Id_Customer,
                    Id = x.Id,
                    Id_Res = x.Id_Res,
                    numberSeat = x.numberSeat,
                    timeStart = x.timeStart,
                    status = x.status,
                    OrderStatus = x.OrderStatus,
                    Menu=x.Menu
                }).ToList();
            }
            return lsOrder;
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult newOrder(OrderModelView item)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                en.checkOrders.Add(new Models.ModelsData.checkOrder
                {
                    Id_Customer = item.Id_Customer,
                    Id_Res = item.Id_Res,
                    numberSeat = item.numberSeat,
                    timeStart = item.timeStart,
                    status = item.status,
                    OrderStatus = item.OrderStatus,
                    Menu = item.Menu
                });
                en.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult editOrder(OrderModelView item)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var curOrder = en.checkOrders.Where(x => x.Id == item.Id).FirstOrDefault();
                curOrder.Id_Customer = item.Id_Customer;
                curOrder.Id_Res = item.Id_Res;
                curOrder.numberSeat = item.numberSeat;
                curOrder.status = item.status;
                curOrder.timeStart = item.timeStart;
                curOrder.choosetable = item.choosetable;
                curOrder.OrderStatus = item.OrderStatus;
                curOrder.Menu = item.Menu;
                en.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            using(var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var item = en.checkOrders.Where(x => x.Id == id).FirstOrDefault();
                en.checkOrders.Remove(item);
                en.SaveChanges();
            }
            return Ok();
        }
    }
}