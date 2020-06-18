using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Services;
using Core.Services.Intefaces;
using Core.DTOs;
using datalayer.Entities.User;
using Core.Security;

namespace coreadvanced.Pages.Admin.Roles
{

    [Permissionchecker(6)]
    public class IndexModel : PageModel
    {
        private IPermissionService _permissionService;

        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }


        public List<Role> Roleslist { get; set; }
        public void OnGet()
        {
            Roleslist = _permissionService.getroles();
        }

      
    }
}