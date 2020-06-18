using datalayer.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.User
{
    public class UserDiscountCode
    {

        [Key]
        public int UD_ID { get; set; }

        public int UserID { get; set; }

        public int DiscountID { get; set; }





        public User User { get; set; }

        public Discount Discount { get; set; }

    }
}
