using System;
using System.ComponentModel.DataAnnotations;

namespace datalayer.Entities.Course
{
    public class CourseEpisode
    {

        [Key]
        public int EpisodeID { get; set; }

        public int CourseID { get; set; }


        [Display(Name = "عنوان بخش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string EpisodeTitle { get; set; }


        [Display(Name = "زمان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TimeSpan EpisodeTime { get; set; }


        [Display(Name = "فایل")]
        public string EpisodeFileName { get; set; }

        [Display(Name = "رایگان")]
        public bool isFree { get; set; }

        public Course Course { get; set; }


    }
}
