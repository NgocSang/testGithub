using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Framework;
using System.Data.SqlClient;

namespace Model
{
    public class AccountModel
    {
        private HocMVCdbConnect context = null;
        public AccountModel()
        {
            context = new HocMVCdbConnect();
        }
        public bool Login(string userName,string password)
        {
            object[] sqlParames =
                {
                new SqlParameter("@userName", userName),
                new SqlParameter("@passWord", password),
            };
            var res = context.Database.SqlQuery<int>("usp_login @userName, @passWord", sqlParames).SingleOrDefault();
            bool k = Convert.ToBoolean(res);
            return k;
        }
    }
}
