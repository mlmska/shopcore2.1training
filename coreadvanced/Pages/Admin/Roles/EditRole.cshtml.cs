using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Services;
using datalayer.Entities.User;
using Core.Security;

namespace coreadvanced.Pages.Admin.Roles
{
    [Permissionchecker(8)]
    public class EditRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public EditRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role role { get; set; }
        public void OnGet(int id)
        {
            role = _permissionService.GetRolebyid(id);
            ViewData["Permissions"] = _permissionService.Getallpermissions();
            ViewData["SelectedPermissions"] = _permissionService.Permissionrole(id);
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _permissionService.Updaterole(role);
            _permissionService.UpdatepermissionRole(role.RoleID, SelectedPermission);

            return RedirectToPage("Index");
        }

    }
}