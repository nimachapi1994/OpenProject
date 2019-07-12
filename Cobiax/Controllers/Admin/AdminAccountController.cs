using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using IdentitySample.Models;

namespace Cobiax.Controllers.Admin
{
   
    public class AdminAccountController : Controller
    {
        public ApplicationRoleManager rolemngr
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        public ApplicationUserManager usermngr
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
        }
        public ApplicationSignInManager singinmnger
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

        }
        Cobiax.Models.CobiaxDb db = new Models.CobiaxDb();
        [Authorize(Roles = "admin")]
        public ActionResult ResetpassConfirm(string newpass)
        {
         
        
            var find = db.AspNetUsers.Find(User.Identity.GetUserId());
            var hash = usermngr.PasswordHasher.HashPassword(newpass);
            find.PasswordHash = hash;
            db.SaveChanges();
            TempData["ok"] = "پسورد شما با موفقیت ذخیره شد لطفا پسورد خود را همیشه به یاد داشته باشید";


            return RedirectToAction("Resetpass","AdminAccount");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Resetpass()
        {

            return View();

        }
        [Authorize(Roles = "admin")]
        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home/Index");
        }
        public ActionResult LoginConfirm(LoginViewModel model)
        {
            var user = singinmnger.PasswordSignIn(model.Email, model.Password, model.RememberMe, true);
            if (user == SignInStatus.Success)
            {
                return RedirectToAction("ControlPanel", "AdminPanel");
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
    }
}