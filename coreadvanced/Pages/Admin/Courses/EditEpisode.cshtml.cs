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
    public class EditEpisodeModel : PageModel
    {
        private ICourseService _courseService;

        public EditEpisodeModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [BindProperty]
        public CourseEpisode Courseepisode { get; set; }
        public void OnGet(int id)
        {
            Courseepisode = _courseService.getepisodebyid(id);
        }

        public IActionResult OnPost(IFormFile FileEpisode)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FileEpisode != null)
            {
                if (_courseService.CheckexistFile(FileEpisode.FileName))
                {
                    ViewData["isExist"] = true;
                    return Page();
                } 
            }
          


            _courseService.editepisode(Courseepisode, FileEpisode);

            return Redirect("/Admin/Courses/IndexEpisode/" + Courseepisode.CourseID);

        }


    }


}