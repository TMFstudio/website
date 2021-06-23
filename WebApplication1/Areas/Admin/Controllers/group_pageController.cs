using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class group_pageController : Controller
    {
        private IGroupRepository PageGroupRepostory;
        MydbContext db = new MydbContext();
public group_pageController()
        {
            PageGroupRepostory = new PageGroupRepostory(db);
        }


        public ActionResult Index()
        {
            return View(PageGroupRepostory.GetAllGroups());
        }

        // GET: Admin/group_page/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_page group_page = PageGroupRepostory.getgroupbuyid(id.Value);
            if (group_page == null)
            {
                return HttpNotFound();
            }
            return View(group_page);
        }

        // GET: Admin/group_page/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/group_page/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,groupTitle")] group_page group_page)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepostory.Insert(group_page);
                PageGroupRepostory.save();
                return RedirectToAction("Index");
            }

            return View(group_page);
        }

        // GET: Admin/group_page/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_page group_page = PageGroupRepostory.getgroupbuyid(id.Value);
            if (group_page == null)
            {
                return HttpNotFound();
            }
            return PartialView(group_page);
        }

        // POST: Admin/group_page/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,groupTitle")] group_page group_page)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepostory.Update(group_page);
               PageGroupRepostory.save();
                return RedirectToAction("Index");
            }
            return View(group_page);
        }

        // GET: Admin/group_page/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_page group_page = PageGroupRepostory.getgroupbuyid(id.Value);
            if (group_page == null)
            {
                return HttpNotFound();
            }
            return PartialView(group_page);
        }

        // POST: Admin/group_page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
        PageGroupRepostory.deletebyid(id);
            PageGroupRepostory.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              PageGroupRepostory.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
