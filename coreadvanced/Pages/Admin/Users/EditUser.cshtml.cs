using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.DTOs;
using Core.Services.Intefaces;
using Core.Services;
using Core.Security;

namespace coreadvanced.Pages.Admin.Users
{
    [Permissionchecker(4)]
    public class EditUserModel : PageModel
    {
        private IUserService _userService;
        private IPermissionService _permissionService;

        public EditUserModel(IUserService userService,IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }


        [BindProperty]
        public EditUserViewModel editUserViewModel { get; set; }
        public void OnGet(int id)
        {
            editUserViewModel = _userService.getuserforshowinedit(id);
            ViewData["Roles"] = _permissionService.getroles();
        }

        public IActionResult OnPost(List<int> SelectedRole)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.edituserfromadmin(editUserViewModel);

            _permissionService.Editrolesuser(editUserViewModel.UserID, SelectedRole);

            return RedirectToPage("Index");
        }
    }
}