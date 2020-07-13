using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class MenuDao
    {
        Furniture db = null;
        public MenuDao()
        {
            db = new Furniture();
        }
        public List<Menu> getListMenuByTypeID(long id)
        {
            return db.Menus.Where(x => x.TypeID == id).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
