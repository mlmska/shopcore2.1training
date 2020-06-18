using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Services;
using Core.Services.Intefaces;
using Core.Convertors;
using datalayer.Entities.User;
using Core.Generator;
using Core.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Core.Senders;

namespace coreadvanced.Controllers
{
    public class AccountController : Controller
    {

        private IUserService _UserService;
        private IViewRenderService _viewRender;

        public AccountController(IUserService userService,IViewRenderService viewRender)
        {
            _UserService = userService;
            _viewRender = viewRender;
        }



        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_UserService.isExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری م.جود نمی باشد");
                return View(register);
            }
            if (_UserService.isExistEmail(FixedText.Fixemail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل تکراری می باشد");
                return View(register);
            }

            User user = new User()
            {
                Activecode = Namegenerator.GenerateUniqcode(),
                Email=FixedText.Fixemail(register.Email),
                isActive=false,
                Password=PasswordHelper.EncodePasswordMd5(register.Password),
                Registerdate=DateTime.Now,
                UserName=register.UserName,
                UserAvatar="Deafault.jpg",
            };
            _UserService.adduser(user);

            #region send activison email

            string body = _viewRender.RenderToStringAsync("activisionemail",user);
            SendEmail.Send(user.Email, "فعال سازی", body);


            #endregion


            return View("SuccessRegister",user);
        }
        #endregion

        #region Login

        [Route("Login")]
        public ActionResult Login(bool Editprofile=false)
        {
            ViewBag.Editprofile = Editprofile;

            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login,string ReturnUrl="/")
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _UserService.Loginuser(login);
            if (user!=null)
            {
                if (user.isActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)

                    };
                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent=login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.issuccess = true;
                    if (ReturnUrl != "/")
                    {
                        return Redirect(ReturnUrl);
                    }
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب شما فعال نیست");
                }

            }
            ModelState.AddModelError("Email", "کاربری یافت نشد");
            return View(login);
        }


        #endregion


        #region Active account

        public IActionResult ActiveAccount(string id)
        {

            ViewBag.isactive = _UserService.ActiveAccount(id);
            return View();
        }

        #endregion


        #region Logout
        [Route("Logout")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion


        #region forgotpassword
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }
            string fixedemail = FixedText.Fixemail(forgot.Email);

            User user = _UserService.getuserbyemail(fixedemail);

            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری با این ایمیل یافت نشد");
                return View(forgot);
            }
            string body = _viewRender.RenderToStringAsync("forgotpasswordemail", user);
            SendEmail.Send(forgot.Email, "بازیابی کلمه عبوری", body);
            ViewBag.issuccess = true;



            return View();
        }


        #endregion


        #region resetpassword


       
        public IActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel()
            {
                ActiveCode=id
            });
        }


        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel reset)
        {
            if (!ModelState.IsValid)
            {
                return View(reset);
            }

            User user = _UserService.getuserbyactivecode(reset.ActiveCode);
            if (user == null)
            {
                return NotFound();
            }
            string hashnewpassword = PasswordHelper.EncodePasswordMd5(reset.Password);
            user.Password = hashnewpassword;
            _UserService.updateuser(user);

            return Redirect("/Login");


        }


        #endregion



    }
}