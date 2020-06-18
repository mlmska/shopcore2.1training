using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using datalayer.Entities.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreadvanced.Pages.Admin.Courses
{
    public class EditCourseModel : PageModel
    {
        private ICourseService _courseService;
        public EditCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }



        [BindProperty]
        public Course Course { get; set; }
        public void OnGet(int id)
        {
            Course=_courseService.getcoursebyid(id);

            var groups = _courseService.getgroupformanagecourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text",Course.GroupID);

            List<SelectListItem> subgroup = new List<SelectListItem>()
            {
                new SelectListItem(){Text="انتخاب کنید" ,Value="" }
            };
            subgroup.AddRange(_courseService.getsubgroupformanagecourse(Course.GroupID));

            string selectedSubGroup = null;

            if (Course.SubGroup != null)
            {
                selectedSubGroup = Course.SubGroup.ToString();
            }

            ViewData["subGroups"] = new SelectList(subgroup, "Value", "Text",selectedSubGroup);

            var teacher = _courseService.getteachers();
            ViewData["Teacher"] = new SelectList(teacher, "Value", "Text",Course.TeacherID);

            var status = _courseService.getstatus();
            ViewData["Status"] = new SelectList(status, "Value", "Text",Course.StatusID);

            var level = _courseService.getlevels();
            ViewData["Level"] = new SelectList(level, "Value", "Text",Course.LevelID);
        }

        public  IActionResult OnPost(IFormFile imgcourseup, IFormFile demoUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _courseService.updatecourse(Course, imgcourseup, demoUp);

            return RedirectToPage("Index");


        }


    }
}