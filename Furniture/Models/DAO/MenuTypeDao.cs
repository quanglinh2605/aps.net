using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{   
    public class MenuTypeDao
    {
        Furniture db = null;       
        public MenuTypeDao()
        {
            db = new Furniture();
        }

        public List<MenuType> AllMenuType()
        {
            return db.MenuTypes.ToList();
        } 
    }
}
