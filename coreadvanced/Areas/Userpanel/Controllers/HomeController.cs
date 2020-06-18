using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Core.Services.Intefaces;
using Core.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace coreadvanced.Areas.Userpanel.Controllers
{
    [Area("Userpanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserService _Userservice;

        public HomeController(IUserService userService)
        {
            _Userservice = userService;
        }


        public IActionResult Index()
        {
            return View(_Userservice.getuserinformation(User.Identity.Name));
        }


        [Route("Userpanel/EditProfile")]
        public IActionResult Editprofile()
        {
            return View(_Userservice.getdataforeditprofile(User.Identity.Name));
        }

        [Route("Userpanel/EditProfile")]
        [HttpPost]
        public IActionResult Editprofile(EditprofileViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            _Userservice.Editprofile(edit.UserName, edit);

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Login?Editprofile=true");

        }


        [Route("Userpanel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        [Route("Userpanel/ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel change)
        {
            string Currentusername = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                return View(change);
            }

            if (!_Userservice.CompareOldepassword(change.OldPassword, Currentusername))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبوری فعلی معتبر نمی باشد");
                return View(change);
            }
            _Userservice.Changepassword(Currentusername, change.Password);
            ViewBag.issuccess = true;


            return View();
        }


    }
}