using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace datalayer.Entities.Course
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }


        [Required]
        public int GroupID { get; set; }

        public int? SubGroup { get; set; }

        public int MyProperty { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        public int LevelID { get; set; }



        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string CourseTitle { get; set; }


        [Display(Name = "توضیح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseDescription { get; set; }


        [Display(Name = "قیمت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoursePrice { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string CourseImagname { get; set; }

        [MaxLength(100)]
        public string DemofileName { get; set; }


        [Required]
        public DateTime Createdate { get; set; }

        public DateTime? Updatedate { get; set; }




        [ForeignKey("TeacherID")]
        public User.User User { get; set; }

        [ForeignKey("GroupID")]
        public CourseGroup CourseGroup { get; set; }


        [ForeignKey("SubGroup")]
        public CourseGroup Group { get; set; }


        public CourseStatus CourseStatus { get; set; }

        public CourseLevel CourseLevel { get; set; }

        public virtual List<CourseEpisode> CourseEpisodes { get; set; }

        public virtual List<Order.OrderDetail> OrderDetails { get; set; }

        public List<UserCourse> UserCourses { get; set; }

        public List<CourseComment> CourseComments { get; set; }


    }
}
