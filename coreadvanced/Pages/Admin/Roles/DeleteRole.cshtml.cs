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
    [Permissionchecker(9)]
    public class DeleteRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public DeleteRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role role { get; set; }
        public void OnGet(int id)
        {
            role = _permissionService.GetRolebyid(id);
        }

        public IActionResult OnPost()
        {

            _permissionService.Deleterole(role);

            return RedirectToPage("Index");
        }

    }
}