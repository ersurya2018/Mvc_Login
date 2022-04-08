using MVCLoginSurya.Db_Connect_EF;
using MVCLoginSurya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCLoginSurya.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Registration modelreg)
        {
            suryaEntities dbobj = new suryaEntities();
            var resuser = dbobj.userinfoes.Where(m => m.email == modelreg.email).FirstOrDefault();
            if (resuser==null)
            {
                TempData["invalid"] = "Invalid Email or user";
            }
            else
            {
                if(resuser.email==modelreg.email && resuser.password==modelreg.password)
                {
                    FormsAuthentication.SetAuthCookie(resuser.email, false);
                    Session["username"] = resuser.name;
                    Session["user"] = resuser.email;
                    return RedirectToAction("index","Admin");
                }
                else
                {
                    TempData["invalidpass"] = "Invalid password";
                }
            }

            return View();
        }
        [HttpGet]
        
        public ActionResult Reg()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Reg(Registration modelreg)
        {
            suryaEntities dbobj = new suryaEntities();
            userinfo tblobj = new userinfo();
            tblobj.name = modelreg.name;
            tblobj.email = modelreg.email;
            tblobj.password = modelreg.password;
            tblobj.mobile = modelreg.mobile;
            dbobj.userinfoes.Add(tblobj);
            dbobj.SaveChanges();
            return RedirectToAction("index","Home");
        }
    }
}