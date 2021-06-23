using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IGroupRepository:IDisposable
    {
        IEnumerable<group_page> GetAllGroups();
        group_page getgroupbuyid(int GroupID);

        bool Insert(group_page group_Page);
        bool Update(group_page group_Page);
        bool delete(group_page group_Page);
        bool deletebyid(int GroupID);
       
        void save();

        IEnumerable<show_group_vm> Getgroupforview();
    
    }
}
