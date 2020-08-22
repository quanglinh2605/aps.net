using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;
namespace Models.DAO
{
    public class NewsDao
    {
        Furniture db = null;
        public NewsDao()
        {
            db = new Furniture();
        }

        public List<News> listNews(string filter)
        {
            return db.News.Where(x => x.Description.Contains(filter)).OrderBy(x=>x.ViewCount).ToList();
        }

        public IEnumerable<News> listPageNews(string keyword, int pagenumber, int pagesize)
        {
            return db.News.Where(x => x.Description.Contains(keyword)).OrderBy(x => x.ViewCount).ToPagedList(pagenumber, pagesize);
        }

        public IEnumerable<News> listByTitle(long titleID, int pagenumber, int pagesize)
        {
            return db.News.Where(x => x.ParentID == titleID).OrderBy(x => x.CreateDate).ToPagedList(pagenumber,pagesize); 
        }

        public News getById(long id)
        {
            return db.News.Find(id);
        }

        public List<News> Search(string keyword)
        {
            return db.News.Where(x => x.Name.Contains(keyword)).ToList();
        }

        public List<News> relatedNews(long? id)
        {
            return db.News.Where(x => x.ParentID == id).Take(13).ToList();
        }
    }
}
