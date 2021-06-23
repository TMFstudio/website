using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class searchController : Controller
    {
        private IPageRepositories pageRepositories;
        MydbContext db = new MydbContext();
        public searchController()
        {
            pageRepositories = new PageRepository(db);
        }
        // GET: search
        public ActionResult Index(string q)
        {
            ViewBag.name = q;
            return View(pageRepositories.searchitem(q));
        }
    }
}