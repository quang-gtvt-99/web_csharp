using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace ClassLibrary1
{
  public class LoginModel
    {
        private QuanLyBanXeEntities contextt = null;
        public LoginModel()
        {
            contextt = new QuanLyBanXeEntities();
        }
        public bool login(string User, string Password)
        {
            object[] sqlParams =
            {
            new SqlParameter("@user",User),
            new SqlParameter("@Password", Password),
        };
            var res = contextt.Database.SqlQuery<bool>("Account_Login @user, @password", sqlParams
                ).SingleOrDefault();
            return res;
        }
    
    }
    
}
