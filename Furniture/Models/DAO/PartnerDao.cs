using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class PartnerDao
    {
        Furniture db = null;
        public PartnerDao()
        {
            db = new Furniture();
        }
        public List<Partner> listPartner()
        {
            return db.Partners.ToList();
        }
    }
}
