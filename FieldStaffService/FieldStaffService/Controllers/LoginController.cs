using FieldStaffService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;


namespace FieldStaffService.Controllers
{
    public class LoginController : ApiController
    {
        
        /*[HttpGet]
        public String Login(string token)
        {
            String testtxt="NO";
            if (System.Web.HttpContext.Current.Session != null && System.Web.HttpContext.Current.Session["Token"] != null)
            {
                testtxt = System.Web.HttpContext.Current.Session["Token"].ToString();
            }
            System.Web.HttpContext.Current.Session["Token"] = DateTime.Now.ToShortDateString();
            return testtxt;
            //return AuthentificationHandler.Login(token);
        }*/

        public void checklogin()
        {
            if (System.Web.HttpContext.Current.Session != null)
            {

                if (System.Web.HttpContext.Current.Session["Token"] != null)
                {
                    //Check token
                    if (System.Web.HttpContext.Current.Session["Token"].ToString() == WebConfigurationManager.AppSettings["securitytoken"])
                    {
                        //Authenticate user
                        var identity = new GenericIdentity("fotograf_a");
                        SetPrincipal(new GenericPrincipal(identity, new string[] { "fotograf" }));

                    }
                }
            }

        }

        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        [HttpGet]
        public String Login(string token)
        {
            
            //var session = HttpContext.Current.Session;
            var txt = "NO";
            if (System.Web.HttpContext.Current.Session != null && System.Web.HttpContext.Current.Session["Token"] != null)
            {
                txt = System.Web.HttpContext.Current.Session["Token"].ToString();
            }
            if (token == WebConfigurationManager.AppSettings["securitytoken"])
            {
                System.Web.HttpContext.Current.Session["Token"] = token;
                Console.WriteLine(System.Web.HttpContext.Current.Session["Token"]);
                
            }
            return txt;
        }
    }
}
