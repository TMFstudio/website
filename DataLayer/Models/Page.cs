using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public class Page
    {
        [Key]

        public int PageID { get; set; }
         [Display(Name ="دسته بندی صفحه")]
        [Required(ErrorMessage ="pleas insert {0} ")]

        public int GroupID { get; set; }
          [Display(Name ="عنوان")]
        [Required(ErrorMessage ="pleas insert {0} ")]
        [MaxLength(250)]
        public string Title { get; set; }
       
        [Display(Name ="توضیح مختصر")] 
      [Required(ErrorMessage ="pleas insert {0} ")]
         [MaxLength(350)]
         [DataType (DataType.MultilineText)]

        public string ShortDiscription { get; set; }
           [Required(ErrorMessage ="pleas insert {0} ")]
        [Display(Name ="توضیح")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
       
        [Display(Name ="بازدید")]

        public int Visit { get; set; }
 
        [Display(Name ="اسم تصویر")]

        public string Imagename { get; set; }

         [Display(Name ="اسلایدر")]

        public bool ShowInSliders { get; set; }
        
        [Display(Name ="تاریخ")]
        [DisplayFormat(DataFormatString ="{0: yyyy/mm/dd}")]
        public DateTime CreatDate { get; set; }

        ///navigation proprty
        ///

        [Display(Name = "کلمات کلیدی")]
        public string tags { get; set; }


        public virtual List<camment_page> camment_Pages { get; set; }

        public virtual group_page group_Page { get; set; }

       

        public Page()
        {

        }


    }
}
