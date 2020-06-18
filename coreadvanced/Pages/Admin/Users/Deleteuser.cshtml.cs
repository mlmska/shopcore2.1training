using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Services;
using Core.DTOs;
using Core.Security;

namespace coreadvanced.Pages.Admin.Users
{
    [Permissionchecker(5)]
    public class DeleteuserModel : PageModel
    {
        private IUserService _userService;
        public DeleteuserModel(IUserService userService)
        {
            _userService = userService;
        }

        public InformationViewModel informationViewModel { get; set; }
        public void OnGet(int id)
        {


            ViewData["Userid"] = id;
            informationViewModel = _userService.getuserinformation(id);
        }
        public IActionResult OnPost(int id)
        {
            _userService.Deleteuser(id);
            return RedirectToPage("Index");
        }

    }
}