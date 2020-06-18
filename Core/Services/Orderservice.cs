using Core.Services.Intefaces;
using datalayer.Context;
using datalayer.Entities.Course;
using datalayer.Entities.Order;
using datalayer.Entities.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DTOs.Order;
using datalayer.Entities.User;


namespace Core.Services
{
    public class Orderservice : IOrderservice
    {
        private Corecontext _db;
        private IUserService _userService;
        public Orderservice(Corecontext db,IUserService userService)
        {
            _db = db;
            _userService = userService;
        }

        public void AddDiscount(Discount discount)
        {
            _db.Discounts.Add(discount);
            _db.SaveChanges();
        }

        public int AddOrder(string username, int courseid)
        {
            int userid = _userService.getuseridbyusername(username);

            Order order = _db.Orders.FirstOrDefault(o => o.UserID == userid && !o.isFinally);

            var course = _db.Courses.Find(courseid);


            if (order == null)
            {
                order = new Order()
                {
                    UserID=userid,
                    isFinally=false,
                    Createdate=DateTime.Now,
                    Ordersum=course.CoursePrice,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            CourseID=courseid,
                            Count=1,
                            Price=course.CoursePrice,

                        }
                    }

                };
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            else
            {
                OrderDetail detail = _db.OrderDetails.FirstOrDefault(d => d.OrderID == order.OrderID && d.CourseID == courseid);
                if (detail != null)
                {
                    detail.Count += 1;
                    _db.OrderDetails.Update(detail);
                }
                else
                {
                    detail = new OrderDetail()
                    {
                        OrderID = order.OrderID,
                        Count = 1,
                        CourseID = courseid,
                        Price = course.CoursePrice,

                    };
                    _db.OrderDetails.Add(detail);
                }
                
                _db.SaveChanges();
                UpdatePriceOrder(order.OrderID);
            }

            
            
            return order.OrderID;

        }

        public bool FinalyOrder(string username,int orderid)
        {
            int userid = _userService.getuseridbyusername(username);
            var order = _db.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Course)
                .FirstOrDefault(o => o.OrderID == orderid && o.UserID == userid);

            if (order == null || order.isFinally)
            {
                return false;
            }
            if (_userService.Balanceuserwallett(username)>=order.Ordersum)
            {
                order.isFinally = true;
                _userService.addwallet(new Wallet()
                {
                    Amount=order.Ordersum,
                    Createdate=DateTime.Now,
                    isPay=true,
                    Description="فاکتور شما #"+order.OrderID,
                    UserID=userid,
                    TypeID=2
                });

                _db.Orders.Update(order);
                foreach(var detail in order.OrderDetails)
                {
                    _db.UserCourses.Add(new UserCourse()
                    {
                        CourseID = detail.CourseID,
                        UserID = userid
                    });
                }


                _db.SaveChanges();
                return true;
            }
            return false;

        }

        public List<Discount> getalldiscount()
        {
            return _db.Discounts.ToList();
        }

        public Discount getdiscountbyid(int discountid)
        {
            return _db.Discounts.Find(discountid);
        }

        public Order Getordeforuserpanel(string username, int orderid)
        {
            int userid = _userService.getuseridbyusername(username);
            return _db.Orders.Include(o => o.OrderDetails).ThenInclude(od=>od.Course)
                .FirstOrDefault(o => o.UserID == userid && o.OrderID == orderid);
        }

        public Order GetorderbyID(int orderid)
        {
            return _db.Orders.Find(orderid);
        }

        public List<Order> getuserorder(string username)
        {
            int userid = _userService.getuseridbyusername(username);

            return _db.Orders.Where(p => p.UserID == userid).ToList();
        }

        public bool isExistcode(string code)
        {
           return _db.Discounts.Any(p => p.DiscountCode == code);


        }

        public bool isuserincourse(string username, int courseid)
        {
            int userid = _userService.getuseridbyusername(username);
            return _db.UserCourses.Any(p => p.UserID == userid && p.CourseID == courseid);
        }

        public void Updatediscount(Discount discount)
        {
            _db.Discounts.Update(discount);
            _db.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _db.Orders.Update(order);
            _db.SaveChanges();
        }

        public void UpdatePriceOrder(int orderid)
        {
            var order = _db.Orders.Find(orderid);
            order.Ordersum = _db.OrderDetails.Where(d => d.OrderID == orderid).Sum(d => d.Price);
            _db.Orders.Update(order);
            _db.SaveChanges();
        }

        public DiscountUseType UseDiscount(int orderid, string code)
        {
            var dicount = _db.Discounts.SingleOrDefault(p => p.DiscountCode == code);
            if (dicount == null)
            {
                return DiscountUseType.NotFound;
            }
            if (dicount.StartDate != null && dicount.StartDate < DateTime.Now)
            {
                return DiscountUseType.ExpireDate;
            }
            if (dicount.EndeDate != null && dicount.EndeDate >= DateTime.Now)
            {
                return DiscountUseType.ExpireDate;
            }

            if (dicount.DiscountCode != null && dicount.UsableCount < 1)
            {
                return DiscountUseType.Finished;
            }

            var order = GetorderbyID(orderid);
            if (_db.UserDiscountCodes.Any(d => d.UserID == order.UserID && d.DiscountID == dicount.DiscountID))
            {
                return DiscountUseType.UserUsed;
            }


            int percent= (order.Ordersum * dicount.DiscountPercent) / 100;

            order.Ordersum = order.Ordersum - percent;

            UpdateOrder(order);

            if (dicount.UsableCount != null)
            {
                dicount.UsableCount -= 1;
            }

            _db.Discounts.Update(dicount);
            _db.UserDiscountCodes.Add(new UserDiscountCode()
            {
                UserID=order.UserID,
                DiscountID=dicount.DiscountID,

            });
            _db.SaveChanges();

            return DiscountUseType.Success;

        }
    }
}
