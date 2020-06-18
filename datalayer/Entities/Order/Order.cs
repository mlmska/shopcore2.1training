using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.Order
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int Ordersum { get; set; }

        public bool isFinally { get; set; }

        [Required]
        public DateTime Createdate { get; set; }



        public virtual User.User User { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }



    }
}
