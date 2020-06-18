using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using datalayer.Entities.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coreadvanced.Pages.Admin.Courses
{
    public class IndexEpisodeModel : PageModel
    {
        private ICourseService _courseService;

        public IndexEpisodeModel(ICourseService courseService)
        {
            _courseService = courseService;
        }


        public List<CourseEpisode> Listepisode { get; set; }
        public void OnGet(int id)
        {
            ViewData["Courseid"] = id;
            Listepisode = _courseService.getlistepisode(id);
        }
    }
}