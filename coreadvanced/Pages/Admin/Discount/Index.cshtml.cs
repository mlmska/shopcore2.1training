using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coreadvanced.Pages.Admin.Discount
{
    public class IndexModel : PageModel
    {
        private IOrderservice _orderservice;

        public IndexModel(IOrderservice orderservice)
        {
            _orderservice = orderservice;
        }



        public List<datalayer.Entities.Order.Discount> Discounts { get; set; }

        public void OnGet()
        {
           Discounts= _orderservice.getalldiscount();
        }
    }
}