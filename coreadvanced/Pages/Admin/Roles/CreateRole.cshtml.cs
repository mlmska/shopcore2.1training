using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using datalayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Services;
using Core.Security;

namespace coreadvanced.Pages.Admin.Roles
{
    [Permissionchecker(7)]
    public class CreateRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }


        [BindProperty]
        public Role role { get; set; }
        public void OnGet()
        {
            ViewData["Permissions"] = _permissionService.Getallpermissions();
        }
        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            role.isDelete = false;
            int roleid = _permissionService.Addrole(role);

            _permissionService.AddPermissiontoRole(roleid, SelectedPermission);

            return RedirectToPage("Index");
        }



    }
}