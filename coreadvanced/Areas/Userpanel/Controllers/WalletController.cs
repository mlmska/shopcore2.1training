using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Services;
using Core.Services.Intefaces;


namespace coreadvanced.Areas.Userpanel.Controllers
{
    [Area("Userpanel")]
    [Authorize]
    public class WalletController : Controller
    {
        private IUserService _UserService;

        public WalletController(IUserService userService)
        {
            _UserService = userService;
        }



        [Route("Userpanel/Wallet")]
        public IActionResult Index()
        {

            ViewBag.listwallet = _UserService.getuserwallet(User.Identity.Name);

            return View();
        }

        [Route("Userpanel/Wallet")]
        [HttpPost]
        public IActionResult Index(ChargeViewModel charge)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.listwallet = _UserService.getuserwallet(User.Identity.Name);
                return View(charge);
            }


            int walletid=_UserService.Chargewallet(User.Identity.Name, charge.Amount, "شارژ کیف");

            #region Payment
            var payment = new ZarinpalSandbox.Payment(charge.Amount);
            var res = payment.PaymentRequest("شارژ کیف پول","https://localhost:44373/OnlinePayment/"+walletid);
            if (res.Result.Status == 100)
            {
                Response.Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);  
            }


            #endregion

            return null;
        }

    }
}