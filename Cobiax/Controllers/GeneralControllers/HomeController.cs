using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using IdentitySample.Models;

namespace Cobiax.Controllers
{
    public class HomeController : Controller
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
        public ActionResult Index()
        {
            string[] roles = { "admin" };
            roles.ToList().ForEach(x =>
            {
                if (rolemngr.RoleExists(x) == false)
                {
                    IdentityRole role = new IdentityRole(x);
                    rolemngr.Create(role);
                }
            });
            ViewBag.showSlider = db.Sp_ReadSlider().ToList();
            ViewBag.showService = db.Sp_Readservices().Take(6).ToList();
            ViewBag.showProject = db.Sp_ReadProject().Take(3).ToList();
            var user = usermngr.FindByEmail("cobiaxshiraz@yahoo.com");
            if (user == null)
            {
                ApplicationUser admin = new ApplicationUser()
                {
                    UserName = "cobiaxshiraz@yahoo.com",
                    PhoneNumber = "000000",
                    Email = "cobiaxshiraz@yahoo.com",
                    EmailConfirmed = true,

                };
                var usersuccess = usermngr.Create(admin, "cobiaxshiraz@yahoo.com");
                if (usersuccess.Succeeded == true)
                {
                    usermngr.AddToRole(admin.Id, "admin");

                }
            }

            return View();
        }
      
        public ActionResult ContactUs()
        {
            ViewBag.showallsocialnetwoks = db.SocialNetworks.Where(x => x.Id == 1).ToList();

            return View();
        }
        public ActionResult contactusconfirm(Cobiax.Models.ContactU cu)
        {
            db.ContactUs.Add(new Models.ContactU
            {
                NameAndFamily = cu.NameAndFamily,
                Text = cu.Text,
                Subject = cu.Subject,
                PhoneNumber = cu.PhoneNumber,
                Email = cu.Email
            });
            db.SaveChanges();
            TempData["Success"] = "پیغام شما با موفقیت ذخیره شد.";

            return Json("ok");
        }
        public ActionResult ShowAllProjects()
        {
            ViewBag.showAllProjects = db.Sp_ReadProject().ToList();
            return View();
        }
        public ActionResult ShowOneProject(int id)
        {
           
            ViewBag.ShowOneProject = db.Sp_ReadProjectone(id).ToList();
            return View();
        }
        public ActionResult ShowAllServices()
        {
            ViewBag.showAllServices = db.Sp_Readservices().ToList();
            return View();
        }
        public ActionResult ShowOneService(int id)
        {
           
            ViewBag.ShowOneService = db.Sp_Readservicesone(id).ToList();
            return View();
        }
    }
}