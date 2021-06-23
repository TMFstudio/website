using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        private IPageRepositories pageRepository;
        private IGroupRepository PageGroupRepostory;
        private MydbContext db = new MydbContext();

        public PagesController()
        {
            pageRepository = new PageRepository(db);
            PageGroupRepostory = new PageGroupRepostory(db);
        }
        // GET: Admin/Pages
        public ActionResult Index()
        {

            return View(pageRepository.GetAllPage()) ;
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPagebuyid(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(PageGroupRepostory.GetAllGroups(), "GroupID", "groupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDiscription,Text,Visit,Imagename,ShowInSliders,CreatDate,tags")] Page page , HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreatDate = DateTime.Now;
              
                if(imgup != null)
                {
                   page.Imagename = Guid.NewGuid() + Path.GetExtension(imgup.FileName);
                   imgup.SaveAs(Server.MapPath("/pageimge/"+page.Imagename));
                }


                pageRepository.insert(page);
                pageRepository.save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(pageRepository.GetAllPage(), "GroupID", "groupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPagebuyid(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(PageGroupRepostory.GetAllGroups(), "GroupID", "groupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDiscription,Text,Visit,Imagename,ShowInSliders,CreatDate")] Page page , HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {

                if (imgup != null)
                {
                    if( page.Imagename !=null)
                    {
                        System.IO.File.Delete(Server.MapPath("/pageimge/" + page.Imagename));
                    }
                    page.Imagename = Guid.NewGuid() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/pageimge/" + page.Imagename));
                }
                pageRepository.update(page);
                PageGroupRepostory.save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.group_Pages, "GroupID", "groupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPagebuyid(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepository.GetPagebuyid(id);
            if (page.Imagename != null)
            {
                System.IO.File.Delete(Server.MapPath("/pageimge/" + page.Imagename));
            }
            pageRepository.delete(page);
            pageRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PageGroupRepostory.Dispose();
                pageRepository.Dispose();              
            }
            base.Dispose(disposing);
        }
    }
}
