using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace FieldStaffService.Models
{
    public static class AuthentificationHandler
    {
        public static void checklogin()
        {
            if (System.Web.HttpContext.Current.Session != null)
            {

                if (System.Web.HttpContext.Current.Session["Token"] != null)
                {
                    //Check token
                    if (System.Web.HttpContext.Current.Session["Token"] == WebConfigurationManager.AppSettings["securitytoken"])
                    {
                        //Authenticate user
                        var identity = new GenericIdentity("fotograf_a");
                        SetPrincipal(new GenericPrincipal(identity, new string[] { "fotograf" }));

                    }
                }
            }
            
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        public static bool Login(String token)
        {
            var session = HttpContext.Current.Session;
            if (token == WebConfigurationManager.AppSettings["securitytoken"])
            {
                System.Web.HttpContext.Current.Session["Token"] = token;
                Console.WriteLine(System.Web.HttpContext.Current.Session["Token"]);
                return true;
            }
            return false;
           
        }

       
    }
}