using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Course
{
    public class ShowcourselistViewModel
    {
        public int CourseID { get; set; }

        public string Title { get; set; }

        public string Imagename { get; set; }

        public int Price { get; set; }

        public TimeSpan TotalTime { get; set; }



    }
}
