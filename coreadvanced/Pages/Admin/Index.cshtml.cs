using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coreadvanced.Pages.Admin
{
    [Permissionchecker(1)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}