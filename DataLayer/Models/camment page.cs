using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class camment_page
    {
        [Key]
        public int commentID { get; set; }
         [Display(Name ="خبر")]
           [Required(ErrorMessage ="pleas insert {0} ")]

        public int PageID { get; set; }
         [Display(Name ="نام")]  [Required(ErrorMessage ="pleas insert {0} ")]   [MaxLength(150)]

        public string Eamil { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "pleas insert {0} ")]
        [MaxLength(450)]

        public string Name { get; set; }
         [Display(Name ="کامنت")]  [Required(ErrorMessage ="pleas insert {0} ")]   [MaxLength(450)]
        public string Comment { get; set; }
         [Display(Name ="زمان")]
        public DateTime CreateDate{ get; set; }
        ///navigation proprty
        ///
        public virtual Page Page { get; set; }

        public camment_page()
        {

        }
    }
}
