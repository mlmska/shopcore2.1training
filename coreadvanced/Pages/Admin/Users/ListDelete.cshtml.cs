using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coreadvanced.Pages.Admin.Users
{
    public class ListDeleteModel : PageModel
    {
        private IUserService _userService;

        public ListDeleteModel(IUserService userService)
        {
            _userService = userService;
        }




        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet(int pageid = 1, string filterusername = "", string filteremail = "")
        {
            UserForAdminViewModel = _userService.getdeletedusers(pageid, filterusername, filteremail);
        }
    }
}