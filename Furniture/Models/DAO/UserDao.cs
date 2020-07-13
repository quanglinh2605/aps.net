using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;
namespace Models.DAO
{
    public class UserDao
    {
        Furniture db = null;
        public UserDao()
        {
            db = new Furniture();
        }
        public List<User> list()
        {
            return db.Users.ToList();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User getByName(string username)
        {
            return db.Users.SingleOrDefault(x => x.Username == username);
        }
        public int Login(string username, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == username);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;
                    }
                    return -2;
                }
            }
        }
        public IEnumerable<User> listAll(string keyword, int page, int pagesize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.Username.Contains(keyword) || x.Name.Contains(keyword));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pagesize);
        }

        public User getById(int id)
        {
            return db.Users.Find(id);
        }
        public bool update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Name = entity.Name;
                user.Phone = entity.Phone;
                user.Address = entity.Address;
                user.ModifidedBy = entity.ModifidedBy;
                user.ModifidedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool changeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool delete(int id)
        {
            try
            {
                var result = db.Users.Find(id);
                db.Users.Remove(result);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
         }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.Username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
