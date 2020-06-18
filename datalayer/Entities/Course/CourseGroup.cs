using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace datalayer.Entities.Course
{
    public class CourseGroup
    {
        [Key]
        public int GroupID { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string GroupTitle { get; set; }

        [Display(Name = "حذف شده")]
        public bool isDelete { get; set; }

        [Display(Name = "عنوان اصلی")]
        public int? ParentID { get; set; }


        [ForeignKey("ParentID")]
        public List<CourseGroup> CourseGroups { get; set; }


        [InverseProperty("CourseGroup")]
        public List<Course> Courses { get; set; }

        [InverseProperty("Group")]
        public List<Course> SubGroup { get; set; }




    }
}
