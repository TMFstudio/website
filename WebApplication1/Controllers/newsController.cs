using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class newsController : Controller
    {
        private IGroupRepository PageGroupRepostory;
        private IPageRepositories pageRepositories;
        private IComment PagecommentRepository;
        MydbContext db = new MydbContext();
        public newsController()
        {
            pageRepositories = new PageRepository(db);
            PageGroupRepostory = new PageGroupRepostory(db);
            PagecommentRepository = new PageCommentRepository(db);
        }
        public ActionResult showgroup()
        {
            return PartialView(PageGroupRepostory.Getgroupforview());
        }
        public ActionResult ShowDropdown ()
        {
            return PartialView(PageGroupRepostory.GetAllGroups());
        }
        public ActionResult topne()
        {
            return PartialView(pageRepositories.topnews());
        }
        public ActionResult lastnews()
        {
            return PartialView(pageRepositories.LastNews());
        }
        [Route("Archive")]
        public ActionResult Archivenews()
        {
            return View(pageRepositories.GetAllPage());

        }
        [Route("Group/{id}/{title}")]
        public ActionResult shownewsbyid(string title , int id)
        {
            ViewBag.name = title;
            return View(pageRepositories.showgroupbyid(id));
        }
        [Route("news/{id}")]
        public ActionResult showNews(int id)
        {
            var news = pageRepositories.GetPagebuyid(id);
       if(news == null)
            {
                HttpNotFound();
            }
            news.Visit +=1;
            pageRepositories.update(news);
            pageRepositories.save();

            return View(news);
        }

        public ActionResult AddCommenet(string name ,string email ,string comment, int id )
        {
            camment_page addcm = new camment_page()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Comment = comment,
                Eamil = email,
                Name = name,


            };
            PagecommentRepository.addcomment(addcm);
            return PartialView("showcomment", PagecommentRepository.Getcommentbyid(id));
        }
        [HttpGet]
        public ActionResult showcomment(int id)
        {
            return PartialView(PagecommentRepository.Getcommentbyid(id));
        }
    }
}