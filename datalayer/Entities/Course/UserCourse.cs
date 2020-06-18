using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.Course
{
    public class UserCourse
    {
        [Key]
        public int UC_ID { get; set; }

        public int UserID { get; set; }

        public int CourseID { get; set; }


        public Course Course { get; set; }

        public User.User User { get; set; }


    }
}
