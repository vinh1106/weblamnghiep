using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

      /*  [HttpGet]
        public ActionResult FormsTest()
        {
            return View();
        }*/

        [HttpPost]
        public ActionResult FormsTestPost()
        {
            var list = new DbLamNghiepConnectApp().Accounts.ToList();
            Account account = new Account();
            account.password = HttpContext.Request.Form["password"];
            account.username = HttpContext.Request.Form["username"];

            foreach(Account a in list)
            {
                if(a.username.Equals(account.username) && a.password.Equals(account.password))
                {
                    if (a.type.ToLower().Equals("admin"))
                    {
                        return RedirectToAction("HomeAdmin", "HomeAdmin");
                    }
                    else
                    {
                         return RedirectToAction("Trang","Trang");
                    }
                }
            }

            //    Content("Hello, " + HttpContext.Request.Form["UserName"] + ". You are " + HttpContext.Request.Form["UserAge"] + " years old!");
            return null;
        }
    }
}