using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Services;
using Core.Services.Intefaces;
using Core.DTOs;
using Core.Security;

namespace coreadvanced.Pages.Admin.Users
{
    [Permissionchecker(2)]
    public class IndexModel : PageModel
    {
        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }




        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet(int pageid=1,string filterusername="",string filteremail= "")
        {
            UserForAdminViewModel = _userService.getusers(pageid,filterusername,filteremail);
        }

      
    }
}