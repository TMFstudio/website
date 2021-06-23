using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class MydbContext:DbContext
    {
      public  DbSet<group_page> Group_Pages { get; set; }
      public  DbSet<Page> Page { get; set; }
      public  DbSet<camment_page> Camment_Pages { get; set; }

    }
}
