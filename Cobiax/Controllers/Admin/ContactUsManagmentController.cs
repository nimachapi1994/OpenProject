
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HamiZarf.Controllers
{
    [Authorize(Roles = "admin")]
    public class ContactUsManagmentController : Controller
    {
        Cobiax.Models.CobiaxDb db = new Cobiax.Models.CobiaxDb();
        public ActionResult DeleteContactUs(int id)
        {
            var find = db.ContactUs.Find(id);
            if (find.Id != null)
            {
                db.ContactUs.Remove(db.ContactUs.Find(find.Id));


            }
            db.SaveChanges();
            TempData["msgsuccess"] = "با موفقیت حذف شد";
            return RedirectToAction("ManageContactUs");
        }
        public ActionResult ManageContactUs()
        {
            ViewBag.ShowAllContacts = db.Sp_ReadContactUs().ToList();
            return View();
        }
        public ActionResult ShowOneContact(int id)
        {
            TempData["kkk"] = db.ContactUs.Where(x => x.Id == id).Select(x=>x.Text).ToList();
            return View(db.ContactUs.Where(x => x.Id == id).ToList());
        }
    }
}