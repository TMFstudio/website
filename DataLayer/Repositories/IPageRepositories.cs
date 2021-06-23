using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepositories : IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPagebuyid(int PageID);
        bool insert(Page Page);
        bool update(Page page);
        bool delete(Page page);
        bool deleteid(int pageid);
        void save();
        IEnumerable<Page> topnews(int Task= 4);
        IEnumerable<Page> slidernews();
        IEnumerable<Page> LastNews(int take = 5);
        IEnumerable<Page> showgroupbyid(int groupid);
        IEnumerable<Page> searchitem(string search);
    }
}
