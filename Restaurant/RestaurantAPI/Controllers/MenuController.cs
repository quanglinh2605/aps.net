using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantAPI.Models.ModelsView;
namespace RestaurantAPI.Controllers
{
    public class MenuController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<MenuModelView> getallMenu()
        {
            List<MenuModelView> lsmenu = new List<MenuModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lsmenu = en.Menus.Select(x => new MenuModelView { Name = x.Name,ImgPath = x.ImgName,Price = x.Price, Res_Id = x.Res_Id, Id=x.Id }).ToList();
            }
            return lsmenu;
        }

        // GET api/<controller>/5
        public MenuModelView GetMeal(int Id, int Res_Id)
        {
            MenuModelView item = new MenuModelView();
            using(var en = new Models.ModelsData.RESTAURANTEntities())
            {
                item = en.Menus.Where(x => x.Id == Id && x.Res_Id == Res_Id).Select(x => new MenuModelView { Id = x.Id, ImgPath = x.ImgName, Name=x.Name, Res_Id=x.Res_Id, Price =x.Price}).FirstOrDefault();
            }
            return item;
        }

        public IEnumerable<MenuModelView> getMenuRes(int Res_Id)
        {
            List<MenuModelView> lsmenu = new List<MenuModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lsmenu = en.Menus.Where(x => x.Res_Id == Res_Id).Select(x => new MenuModelView { Name = x.Name, ImgPath = x.ImgName, Price = x.Price, Res_Id = x.Res_Id, Id = x.Id }).ToList();
            }
            return lsmenu;
        } 

        public IEnumerable<MenuModelView> getMenuByName(int Res_Id, string Name)
        {
            List<MenuModelView> lsmenu = new List<MenuModelView>();
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                lsmenu = en.Menus.Where(x => x.Res_Id == Res_Id && x.Name.Contains(Name)).Select(x => new MenuModelView
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImgPath = x.ImgName,
                    Price = x.Price,
                    Res_Id = x.Res_Id
                }).ToList();
                if (Name == ""||Name == null)
                {
                    lsmenu = en.Menus.Where(x => x.Res_Id==Res_Id).Select(x => new MenuModelView
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ImgPath = x.ImgName,
                        Price = x.Price,
                        Res_Id = x.Res_Id
                    }).ToList();
                }
            }
            return lsmenu;
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult NewMenu(MenuModelView item)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                en.Menus.Add(new Models.ModelsData.Menu { ImgName = item.ImgPath, Name = item.Name, Price = item.Price, Res_Id = item.Res_Id });
                en.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult editMenu(MenuModelView model)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var curMenu = en.Menus.Where(x => x.Id == model.Id).FirstOrDefault();
                if (curMenu != null)
                {
                    curMenu.Name = model.Name;
                    curMenu.Price = model.Price;
                    curMenu.Res_Id = model.Res_Id;
                    curMenu.ImgName = model.ImgPath;
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
        public IHttpActionResult Delete(int Res_id, int Id)
        {
            using (var en = new Models.ModelsData.RESTAURANTEntities())
            {
                var curMenu = en.Menus.Where(x => x.Res_Id == Res_id && x.Id==Id).FirstOrDefault();
                if (curMenu != null)
                {
                    en.Menus.Remove(curMenu);
                    en.SaveChanges();
                }
                return Ok();
            }
        }
    }
}