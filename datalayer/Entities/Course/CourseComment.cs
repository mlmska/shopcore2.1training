using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.Course
{
    public class CourseComment
    {

        [Key]
        public int CommentID { get; set; }


        public int UserID { get; set; }

        public int CourseID { get; set; }


        [MaxLength(700)]
        public string Comment { get; set; }

        public DateTime CreaDate { get; set; }

        public bool isDelete { get; set; }

        public bool isAdminread { get; set; }




        public Course Course { get; set; }

        public User.User User { get; set; }



    }
}
