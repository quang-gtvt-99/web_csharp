using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoginLogin
{
    public class LoginModel
    {
        private QuanLyBanXeEntities1 context = null;
        public LoginModel()
        {
            context = new QuanLyBanXeEntities1();
        }
        public bool Login(string User, string Password)
        {
            object[] sqlParams =
            {
            new SqlParameter("@user",User),
            new SqlParameter("@Password", Password),
            };
            var res = context.Database.SqlQuery<bool>("Account_Login @user, @password", sqlParams
                ).SingleOrDefault();
            return res;
        }
        public string user(string x)
        {
            return x;
        }
       

    }

}
