using Core.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreadvanced.ViewComponents
{
    public class CourseGroupComponents:ViewComponent
    {
        private ICourseService _courseService;

        public CourseGroupComponents(ICourseService CourseService)
        {
            _courseService = CourseService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("CourseGroup",_courseService.Getallgroups()));
        }
    }
}
