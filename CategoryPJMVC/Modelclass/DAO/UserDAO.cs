using Modelclass.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Modelclass.DAO
{
    public class UserDAO
    {
        Model11 db = new Model11();

        //Action Insert
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        //Action Update
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Username = entity.Username;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.email = entity.email;
                user.phone = entity.phone;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Action Delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public IEnumerable<User> ListAllPaging( int page, int pageSize)
        {
            IOrderedQueryable<User> model = db.Users;
            /*if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString)).OrderByDescending(x => x.ID);
            }*/
            return model.OrderByDescending(x => x.ID).ToPagedList( page, pageSize);
        }

        public int Login(string userName, string passWord)
        {
            var result = 3;
            if (userName == "nghia")
            {
                if (passWord == "hehe")
                { result = 1;
                    return 1; }
                else
                {
                    result = -1;
                    return -1;
                }

            }else
                return 0;
        }
        public int CustomLogin (string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == passWord)
                    return 1;
                else
                    return -1;
            }
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.Username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.email == email) > 0;
        }
    }
}
