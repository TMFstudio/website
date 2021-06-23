using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepositories
    {
        private MydbContext db;

        public PageRepository(MydbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.pages;
        }

        public Page GetPagebuyid(int PageID)
        {
        return    db.pages.Find(PageID);
        }

        public bool insert(Page Page)
        {
            try
            {
                db.pages.Add(Page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      

        public bool update(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool delete(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteid(int pageid)
        {
          
            try
            {
                var page = GetPagebuyid(pageid);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public void Dispose()
        {
            db.Dispose();
        }
        public void save()
        {
           db.SaveChanges();
        }

        public IEnumerable<Page> topnews(int Task = 4)
        {
            return db.pages.OrderByDescending(n => n.Visit).Take(Task);
        }

        public IEnumerable<Page> slidernews()
        {
          return  db.pages.Where(n => n.ShowInSliders == true);
        }

        public IEnumerable<Page> LastNews(int take = 5)
        {
        return    db.pages.OrderByDescending(p => p.CreatDate).Take(take);
        }
        public IEnumerable<Page> showgroupbyid(int groupid)
        {
            return db.pages.Where(p => p.GroupID == groupid);
        }

        public IEnumerable<Page> searchitem(string search)
        {
            return db.pages.Where(n => n.Title.Contains(search) || n.Text.Contains(search) || n.tags.Contains(search) || n.ShortDiscription.Contains(search)).Distinct();
        }
    }
}
