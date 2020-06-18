using datalayer.Entities.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
   public class UserForAdminViewModel
    {
        public List<User> users { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

    }
    public class CreateUserViewModel
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



        [Display(Name = "کلمه عبوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string Password { get; set; }


        public IFormFile UserAvatar { get; set; }

    }

    public class EditUserViewModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }



        [Display(Name = "کلمه عبوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string Password { get; set; }


        public IFormFile UserAvatar { get; set; }

        public List<int> UserRoles { get; set; }

        public string AvatarName { get; set; }


    }

}
