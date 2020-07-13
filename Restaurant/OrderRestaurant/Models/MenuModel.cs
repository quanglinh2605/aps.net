using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace OrderRestaurant.Models
{
    public class MenuModel
    {

        List<MenuModelView> lsmenu = new List<MenuModelView>();
        public MenuModel()
        {
            
        }
        public List<MenuModelView> allMenu(int Res_Id, string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55572/api/Menu");
                var searchTask = client.GetAsync("Menu?Res_Id=" + Res_Id.ToString() + "&Name=" + name);
                searchTask.Wait();
                var result = searchTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<MenuModelView>>();
                    readTask.Wait();
                    lsmenu = readTask.Result;
                }
            }
            return lsmenu;
        }
        public MenuModelView find(int id,int Res_Id, string name)
        {
            lsmenu = allMenu(Res_Id, name);
            return lsmenu.Where(x => x.Id == id).SingleOrDefault();
        }

    }
}

