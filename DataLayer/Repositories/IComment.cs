using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IComment
    {
        IEnumerable<camment_page> Getcommentbyid(int pageid);
        bool addcomment(camment_page comment );


    }
}
