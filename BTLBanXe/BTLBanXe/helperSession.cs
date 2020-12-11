using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




namespace BTLBanXe
{
    public class helperSession
    {
        public static void setSession(userSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }



        public static userSession getSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
            {
                return null;
            }
            else
            {
                return session as userSession;
            }

        }

    }    }