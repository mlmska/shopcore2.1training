using datalayer.Entities.Order;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DTOs.Order;

namespace Core.Services.Intefaces
{
    public interface IOrderservice
    {

        int AddOrder(string username, int courseid);

        void UpdatePriceOrder(int orderid);
        void UpdateOrder(Order order);

        Order Getordeforuserpanel(string username, int orderid);
        Order GetorderbyID(int orderid);

        bool FinalyOrder(string username,int orderid);

        List<Order> getuserorder(string username);

        DiscountUseType UseDiscount(int orderid, string code);

        void AddDiscount(Discount discount);
        List<Discount> getalldiscount();

        Discount getdiscountbyid(int discountid);

        void Updatediscount(Discount discount);

        bool isExistcode(string code);

        bool isuserincourse(string username, int courseid);

    }
}
