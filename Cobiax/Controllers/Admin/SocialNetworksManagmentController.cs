using Cobiax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HamiZarf.Controllers
{
    [Authorize(Roles = "admin")]
    public class SocialNetworksManagmentController : Controller
    {
        CobiaxDb db = new CobiaxDb();
        public ActionResult AddSocialNetwork(SocialNetwork s)
        {
            var find = db.SocialNetworks.Find(1);
            find.facebook = s.facebook;

            find.Instag = s.Instag;
            find.Teleg = s.Teleg;

            db.SaveChanges();
            TempData["msgSocialNeteworks"] = "اطلاعات با موفقیت ذخیره گردید";
            return RedirectToAction("SocialNetworksManagment");
        }
        public ActionResult SocialNetworksManagment()
        {

            ViewBag.showallsocialnetwoks = db.SocialNetworks.ToList();
            return View();
        }
    }
}