using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cobiax.Models;

namespace Cobiax.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class ServicesController : Controller
    {
        Cobiax.Models.CobiaxDb db = new Models.CobiaxDb();
        public ActionResult ManagmentServices()
        {
            return View();
        }
        public ActionResult AddService(Service ser,HttpPostedFileBase img)
        {
            byte[] b = { };
         
            if (img== null)
            {
                b = System.IO.File.ReadAllBytes(Server.MapPath("~/Template/assets/images/ProductNotHaveImage/d.jpg"));
            }else
            {
                b = new byte[img.ContentLength];
                img.InputStream.Read(b, 0, b.Length);
            }
            db.Services.Add(new Service
            {
                Subject = ser.Subject,
                Text = HttpUtility.HtmlDecode(ser.Text),
                Logo = b
            });
            db.SaveChanges();
            TempData["Success"] = "خدمت مورد نظر با موفقیت ذخیره شد";
            return RedirectToAction("ManagmentServices");
        }
        public ActionResult ShowAllServices()
        { 
          ViewBag.showAllServices=  db.Services.ToList();
            return View();
        }
        public ActionResult Deleteservices(int id)
        {
            db.Services.Remove(db.Services.Find(id));
            db.SaveChanges();
            TempData["msgsuccess"] = "عملیات حذف با موفقیت انجام شد";
            return RedirectToAction("ShowAllServices");
        }
        public ActionResult Editservices(int id)
        {
            Session["id"] = id;
            var findid = db.Services.Remove(db.Services.Find(id));
            ViewBag.showService = db.Services.Where(x => x.Id == findid.Id).ToList();
            return View();
        }
        public ActionResult EditservicesConfirm(Service ser, HttpPostedFileBase img)
        {
            byte[] b = { };
            var id = (int)Session["id"];
            var findid = db.Services.Remove(db.Services.Find(id));
            if (img == null)
            {
                b = findid.Logo;
            }
            else
            {
                b = new byte[img.ContentLength];
                img.InputStream.Read(b, 0, b.Length);
            }
            db.Services.Add(new Service
            {
                Subject = ser.Subject,
                Text = HttpUtility.HtmlDecode(ser.Text),
                Logo = b
            });
            db.SaveChanges();
            TempData["Success"] = "خدمت مورد نظر با موفقیت ویرایش شد";
            return RedirectToAction("ShowAllServices");
        }
    }
}