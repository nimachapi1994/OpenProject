using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cobiax.Models;

namespace HamiZarf.Controllers.Admin
{
    public class ManageContentPagesController : Controller
    {
        // GET: ManageContentPages
        /*modoriate safahate darbare ma tamas ba ma safheye moshahehe on dar home mibashad*/
        CobiaxDb db = new CobiaxDb();
        [Authorize(Roles = "admin")]
        public ActionResult SelectPageType()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Editpages(int id)
        {
            Session["id"] = id;

            ViewBag.showPage = db.Sp_SelectOnePage(id).ToList();
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult EditPagesConfirm(ContentPage cp)
        {
            int id = (int)Session["id"];
          
           
            
                db.Sp_UpdateOnePage(id, HttpUtility.HtmlDecode(cp.PageTxt));

            
            db.SaveChanges();
            Session.Remove("id");
            return RedirectToAction("SelectPageType");
        }


        //show to customer
        public ActionResult IntroductionCompany()
        {
            ViewBag.show = db.Sp_SelectOnePage(1).ToList();
            return View();
        }
        public ActionResult whatiscobiax()
        {
           
            ViewBag.show = db.Sp_SelectOnePage(2).ToList();
            return View();
        }
        public ActionResult TestimonialandCertificates()
        {
      
            ViewBag.show = db.Sp_SelectOnePage(3).ToList();
            return View();
        }
        public ActionResult componentsCobiax()
        {
           
            ViewBag.show = db.Sp_SelectOnePage(4).ToList();
            return View();
        }
        public ActionResult products()
        {
           
            ViewBag.show = db.Sp_SelectOnePage(5).ToList();
            return View();
        }
        public ActionResult TechnicalAndEconomicBenefits()
        {
          
            ViewBag.show = db.Sp_SelectOnePage(6).ToList();
            return View();
        }
        public ActionResult Estimatesandcalculations()
        {
          
            ViewBag.show = db.Sp_SelectOnePage(7).ToList();
            return View();
        }
        public ActionResult Designing()
        {
            
            ViewBag.show = db.Sp_SelectOnePage(8).ToList();
            return View();
        }
        public ActionResult ejra()
        {
            
            ViewBag.show = db.Sp_SelectOnePage(9).ToList();
            return View();
        }


    }
}