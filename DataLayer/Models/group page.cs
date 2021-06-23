using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLayer
{
  public  class group_page
    {
        [Key]
        public int GroupID { get; set; }
        [Display(Name ="topic")]
        [Required(ErrorMessage ="pleas insert {0} ")]
        [MaxLength(150)]
        public string groupTitle { get; set; }

        ///navigation proprty
        ///

        public virtual List<Page> Page { get; set; }

        public group_page()
        {

        }
    }
}
