using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs.Order;


namespace coreadvanced.Areas.Userpanel.Controllers
{

    [Area("Userpanel")]
    [Authorize]
    public class MyOrdersController : Controller
    {
        private IOrderservice _orderservice;

        public MyOrdersController(IOrderservice orderservice)
        {
            _orderservice = orderservice;
        }

        public IActionResult Index()
        {
            return View(_orderservice.getuserorder(User.Identity.Name));
        }
       
        public IActionResult ShowOrder(int id,bool finaly=false,string type="")
        {
            var order = _orderservice.Getordeforuserpanel(User.Identity.Name,id);
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.typeDiscount = type;
            ViewBag.finaly = finaly;
            return View(order);
        }

        public IActionResult FinallyOrder(int id)
        {
            if (_orderservice.FinalyOrder(User.Identity.Name, id))
            {
                return Redirect("/UserPanel/MyOrders/ShowOrder/" + id + "?finaly=true");
            }
            return BadRequest();
        }
        public IActionResult UseDiscount(int orderid,string code)
        {
            DiscountUseType type = _orderservice.UseDiscount(orderid, code);
            return Redirect("/UserPanel/MyOrders/ShowOrder/" + orderid + "?type=" + type.ToString());

        }
    }
}