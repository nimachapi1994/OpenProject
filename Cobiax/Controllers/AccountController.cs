using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cobiax.Controllers
{
    public class AccountController : Controller
    {
        Cobiax.Models.CobiaxDb db = new Models.CobiaxDb();
        public ActionResult Login()
        {
            ViewBag.showSlider = db.Sp_ReadSlider().ToList();
            ViewBag.showService = db.Sp_Readservices().Take(6).ToList();
            ViewBag.showProject = db.Sp_ReadProject().Take(3).ToList();
            return View();
        }
    }
}