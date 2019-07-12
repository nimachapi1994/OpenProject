using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cobiax.Models;

namespace Cobiax.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class ProjectController : Controller
    {
        Cobiax.Models.CobiaxDb db = new Models.CobiaxDb();
        public ActionResult ManagmentProject()
        {
            return View();
        }
        public ActionResult AddProject(Project pro, HttpPostedFileBase img)
        {
            byte[] b = { };

            if (img == null)
            {
                b = System.IO.File.ReadAllBytes(Server.MapPath("~/Template/assets/images/ProductNotHaveImage/d.jpg"));
            }
            else
            {
                b = new byte[img.ContentLength];
                img.InputStream.Read(b, 0, b.Length);
            }
            db.Projects.Add(new Project
            {
                Name=pro.Name,
                Text = HttpUtility.HtmlDecode(pro.Text),
                Logo=b
            });
            db.SaveChanges();
            TempData["Success1"] = "پروژه مورد نظر با موفقیت ذخیره شد";
            return RedirectToAction("ManagmentProject");
        }
        public ActionResult ShowAllProjects()
        {
            ViewBag.showAllProjects = db.Projects.ToList();
            return View();
        }
        public ActionResult DeleteProjects(int id)
        {
            db.Projects.Remove(db.Projects.Find(id));
            db.SaveChanges();
            TempData["msgsuccess"] = "عملیات حذف با موفقیت انجام شد";
            return RedirectToAction("ShowAllProjects");
        }
        public ActionResult EditProjects(int id)
        {
            Session["id"] = id;
            var findid = db.Projects.Remove(db.Projects.Find(id));
            ViewBag.showproject = db.Projects.Where(x => x.Id == findid.Id).ToList();
            return View();
        }
        public ActionResult EditProjectConfirm(Project pro, HttpPostedFileBase img)
        {
            byte[] b = { };
            var id = (int)Session["id"];
            var findid = db.Projects.Remove(db.Projects.Find(id));
            if (img == null)
            {
                b = findid.Logo;
            }
            else
            {
                b = new byte[img.ContentLength];
                img.InputStream.Read(b, 0, b.Length);
            }
            db.Projects.Add(new Project
            {
                Name = pro.Name
                ,Text = HttpUtility.HtmlDecode(pro.Text),
                Logo = b
            });
            db.SaveChanges();
            TempData["Success1"] = "پروژه مورد نظر با موفقیت ویرایش شد";
            return RedirectToAction("ShowAllProjects");
        }
    }
}