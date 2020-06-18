using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Course;
using Core.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coreadvanced.Pages.Admin.Courses
{
    public class IndexModel : PageModel
    {
        private ICourseService _courseService;

        public IndexModel(ICourseService CourseService)
        {
            _courseService = CourseService;
        }


        public List<ShowcourseforadminViewModel> listcourse { get; set; }
        public void OnGet()
        {
            listcourse = _courseService.getcourseforadmin();
        }
    }
}