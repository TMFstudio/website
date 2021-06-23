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
        public DbSet<group_page> group_Pages { get; set; }
        public DbSet<Page> pages { get; set; }
        public DbSet<camment_page> camment_Pages { get; set; }

    }
}
