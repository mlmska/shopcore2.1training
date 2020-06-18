using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.Order
{
    public class OrderDetail
    {

        [Key]
        public int DetailID { get; set; }

        [Required]
        public int OrderID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int Count { get; set; }

        [Required]
        public int Price { get; set; }



        public virtual Order Order { get; set; }

        public virtual Course.Course Course { get; set; }



    }
}
