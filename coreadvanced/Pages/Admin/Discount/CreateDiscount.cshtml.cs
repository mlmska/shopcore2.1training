using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coreadvanced.Pages.Admin.Discount
{
    public class CreateDiscountModel : PageModel
    {

        private IOrderservice _orderservice;

        public CreateDiscountModel(IOrderservice orderservice)
        {
            _orderservice = orderservice;
        }


        [BindProperty]
        public datalayer.Entities.Order.Discount Discount { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost(string stDate="",string enDate="")
        {
            if (!ModelState.IsValid&&_orderservice.isExistcode(Discount.DiscountCode))
            {
                return Page();
            }

            if (stDate != "")
            {
                string[] std = stDate.Split('/');
                Discount.StartDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                    );
            }
            if (enDate != "")
            {
                string[] end = enDate.Split('/');
                Discount.EndeDate = new DateTime(int.Parse(end[0]),
                    int.Parse(end[1]),
                    int.Parse(end[2]),
                    new PersianCalendar()
                    );
            }

            _orderservice.AddDiscount(Discount);

            return RedirectToPage("Index");
        }
        public IActionResult OnGetCheckCode(string code)
        {
            return Content(_orderservice.isExistcode(code).ToString());
        }
    }
}