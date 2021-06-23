using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public  class PageGroupRepostory : IGroupRepository
    {
        private MydbContext db;


      public  PageGroupRepostory(MydbContext context)
        {
            this.db = context;
        }

        public IEnumerable<group_page> GetAllGroups()
        {
            return db.group_Pages;
        }

        public  group_page getgroupbuyid(int GroupID)
        {
            return db.group_Pages.Find(GroupID);
        }

        public bool Update(group_page group_Page)
        {
         
            try
            {
                 db.Entry(group_Page).State = EntityState.Modified;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
           
        }
    

       
        public bool Insert(group_page group_Page)
        {
            try
            {
                db.group_Pages.Add(group_Page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool delete(group_page group_Page)
        {
       
           
            try
            {
                db.Entry(group_Page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deletebyid(int GroupID)
        {
            try
            {
                var group = getgroupbuyid(GroupID);
                delete(group);
                return true;
                    }
            catch (Exception)
            {
                return false;
            }
        }
        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<show_group_vm> Getgroupforview()
        {
            return db.group_Pages.Select(n => new show_group_vm()
            {
                groupid = n.GroupID ,
                title = n.groupTitle ,
                pagecount = n.Page.Count
            }) ;
        }

     
    }
}
