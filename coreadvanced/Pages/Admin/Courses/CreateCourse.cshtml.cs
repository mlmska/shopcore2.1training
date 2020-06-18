using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Core.Services.Intefaces;
using datalayer.Entities.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreadvanced.Pages.Admin.Courses
{
    public class CreateCourseModel : PageModel
    {
        private ICourseService _courseService;

        public CreateCourseModel(ICourseService CourseService)
        {
            _courseService = CourseService;
        }


        [BindProperty]
        public Course Course { get; set; }
        public void OnGet()
        {
            var groups= _courseService.getgroupformanagecourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var subgroup = _courseService.getsubgroupformanagecourse(int.Parse(groups.First().Value));
            ViewData["subGroups"] = new SelectList(subgroup, "Value", "Text");

            var teacher = _courseService.getteachers();
            ViewData["Teacher"] = new SelectList(teacher, "Value", "Text");

            var status = _courseService.getstatus();
            ViewData["Status"] = new SelectList(status, "Value", "Text");

            var level = _courseService.getlevels();
            ViewData["Level"] = new SelectList(level, "Value", "Text");

        }

        public IActionResult OnPost(IFormFile imgcourseup, IFormFile demoUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _courseService.Addcourse(Course, imgcourseup, demoUp);

            return RedirectToPage("Index");

        }
    }
}