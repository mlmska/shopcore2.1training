using datalayer.Entities.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.User
{
    public class User
    {


        public User()
        {
                
        }

        [Key]
        public int UserID { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }



        [Display(Name = "کلمه عبوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string Password { get; set; }



        [Display(Name = "کد فعال سازی")]
        [MaxLength(50,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string Activecode { get; set; }

        [Display(Name = "وضغیت")]
        public bool isActive { get; set; }


        [Display(Name = "عکس")]
        [MaxLength(200,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string UserAvatar { get; set; }

        public bool isDelete { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime Registerdate { get; set; }


        #region Relation

        public virtual List<User_Role>  user_Roles { get; set; }

        public virtual List<Wallet.Wallet> wallets { get; set; }

        public virtual List<Course.Course> Courses { get; set; }

        public virtual List<Order.Order> Orders { get; set; }

        public List<UserCourse> UserCourses { get; set; }

        public List<UserDiscountCode> UserDiscountCodes { get; set; }


        public List<CourseComment> CourseComments { get; set; }



        #endregion



    }
}
