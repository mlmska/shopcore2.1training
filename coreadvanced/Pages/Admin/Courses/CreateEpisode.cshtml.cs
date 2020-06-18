using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using datalayer.Entities.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coreadvanced.Pages.Admin.Courses
{
    public class CreateEpisodeModel : PageModel
    {
        private ICourseService _courseService;

        public CreateEpisodeModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public CourseEpisode CourseEpisode { get; set; }
        public void OnGet(int id)
        {
            CourseEpisode = new CourseEpisode();
            CourseEpisode.CourseID = id;
        }

        public IActionResult OnPost(IFormFile FileEpisode)
        {
            if (!ModelState.IsValid || FileEpisode == null)
            {
                return Page();
            }

            if (_courseService.CheckexistFile(FileEpisode.FileName))
            {
                ViewData["isExist"] = true;
                return Page();
            }


            _courseService.addepisode(CourseEpisode, FileEpisode);

            return Redirect("/Admin/Courses/IndexEpisode/" + CourseEpisode.CourseID);

        }
    }
}