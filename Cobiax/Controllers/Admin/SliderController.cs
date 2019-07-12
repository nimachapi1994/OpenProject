using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HamiZarf.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class SliderController : Controller
    {
        Cobiax.Models.CobiaxDb db = new Cobiax.Models.CobiaxDb();
        public ActionResult Slider()
        {
            ViewBag.showallslider = db.MainSliders.ToList();
            return View();
        }
      
        public ActionResult InsertSliderConfirm(HttpPostedFileBase img)
        {
            byte[] b = new byte[img.ContentLength];
            img.InputStream.Read(b, 0, b.Length);
            db.MainSliders.Add(new Cobiax.Models.MainSlider {Image=b });
            db.SaveChanges();
            return RedirectToAction("slider");
        }
      
        
        public ActionResult DeleteSlider(int id)
        {
            db.MainSliders.Remove(db.MainSliders.Find(id));
            db.SaveChanges();
            return RedirectToAction("slider");
        }
    }
}