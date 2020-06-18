using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
   public class InformationViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime Registerdate { get; set; }

        public int Wallet { get; set; }

    }

    public class SidebarUserpanelViewModel
    {
        public string UserName { get; set; }

        public DateTime Registerdate { get; set; }

        public string Imagename { get; set; }

    }

    public class EditprofileViewModel
    {

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        public IFormFile UserAvatar { get; set; }

        public string AvatarName { get; set; }



    }

    public class ChangePasswordViewModel
    {
        [Display(Name = " کلمه عبوری فعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string OldPassword { get; set; }


        [Display(Name = "کلمه عبوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string Password { get; set; }


        [Display(Name = " تکرار کلمه عبوری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        [Compare("Password", ErrorMessage = "کلمه های عبوری مغایرت دارند")]
        public string RePassword { get; set; }
    }



}
