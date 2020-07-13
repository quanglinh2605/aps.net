using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class FeedBackDao
    {
        Furniture db = null;
        public FeedBackDao()
        {
            db = new Furniture(); 
        }
        public int Insert(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}
