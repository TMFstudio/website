using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public  class PageCommentRepository : IComment
    {
      private  MydbContext db;

        public PageCommentRepository(MydbContext context)
        {
            db = context;
        }

        public bool addcomment(camment_page comment)
        {
            
               try
            {
                 db.camment_Pages.Add(comment);
                db.SaveChanges();
                return true;
            }

            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<camment_page> Getcommentbyid(int pageid)
        {
            return db.camment_Pages.Where(n => n.PageID == pageid); 


        }
     

    }
}
