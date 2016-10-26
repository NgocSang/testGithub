
using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocMVC.Dao
{
    public class UserDao
    {
        HocMVCdbConnect context = null;
        public UserDao()
        {
            context = new HocMVCdbConnect();
        }
        public long insert(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
            return user.ID;
        }
        public User GetbyID(string username)
        {
            var user = context.User.SingleOrDefault(x => x.UserName == username);
            return user;
        }
        public int login(string username, string password)
        {
            var count = context.User.SingleOrDefault(x => x.UserName == username);
            if (count == null)
            {
                return -1;
            }
            else
            {
                if (count.Status == false)
                {
                    return -2;
                }
                else
                {
                    if(count.Password == password)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }
    }
}