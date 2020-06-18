using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.DTOs;
using Core.Services;
using Core.Services.Intefaces;
using Core.Security;

namespace coreadvanced.Pages.Admin.Users
{
    [Permissionchecker(3)]

    public class CreateUserModel : PageModel
    {
        private IUserService _userService;
        private IPermissionService _permissionService;

        public CreateUserModel(IUserService userService,IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public CreateUserViewModel createUserViewModel { get; set; }

        public void OnGet()
        {
            ViewData["Roles"] = _permissionService.getroles();

        }

        public IActionResult OnPost(List<int> SelectedRole)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int userid = _userService.adduserfromadmin(createUserViewModel);

            _permissionService.Addrolestouser(SelectedRole, userid);


            return Redirect("/Admin/Users");
        }
    }
}