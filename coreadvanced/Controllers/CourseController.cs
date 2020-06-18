 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Intefaces;
using datalayer.Entities.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coreadvanced.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;
        private IOrderservice _orderservice;
        private IUserService _userService;


        public CourseController(ICourseService courseService,IOrderservice orderservice,IUserService userService)
        {
            _courseService = courseService;
            _orderservice = orderservice;
            _userService = userService;
        }

        public IActionResult Index(int pageid = 1, string filter = "", string getType = "all",
            string orderbytype = "date", int startpeice = 0,
            int endprice = 0, List<int> SelectedGroups = null, int take = 0)
        {
            ViewBag.selectedGroup = SelectedGroups;
            ViewBag.group = _courseService.Getallgroups();
            ViewBag.pageid = pageid;
            return View(_courseService.GetCourse(pageid,filter,getType,orderbytype,startpeice,endprice,SelectedGroups,9));
        }

        [Route("ShowCourse/{id}")]

        public IActionResult ShowCourse(int id)
        {
            var course = _courseService.GetcourseForshow(id);
            if (course == null)
            {
                return NotFound();
            }


            return View(course);
        }

        [Authorize]
        public IActionResult BuyCourse(int id)
        {
           int orderid=_orderservice.AddOrder(User.Identity.Name, id);
            return Redirect("/UserPanel/MyOrders/ShowOrder/"+ orderid);
        }

        [Route("DownloadFile/{episodeid}")]
        public IActionResult DownloadFile(int episodeid)
        {

            var episode = _courseService.getepisodebyid(episodeid);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles"
                , episode.EpisodeFileName);
            string filename = episode.EpisodeFileName;
            if (episode.isFree)
            {
                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", filename);
            }
            if (User.Identity.IsAuthenticated)
            {
                if (_orderservice.isuserincourse(User.Identity.Name, episode.CourseID))
                {
                    byte[] file = System.IO.File.ReadAllBytes(filepath);
                    return File(file, "application/force-download", filename);
                }
            }

            return Forbid();    

        }


        [HttpPost]
        public IActionResult CreateComment(CourseComment coomment)
        {
            coomment.isDelete = false;  
            coomment.CreaDate = DateTime.Now;
            coomment.UserID = _userService.getuseridbyusername(User.Identity.Name);
            _courseService.addcomment(coomment);

            return View("ShowComment", _courseService.getcoursecomment(coomment.CourseID));

        }


        public IActionResult ShowComment(int id,int pageid=1)
        {
            return View(_courseService.getcoursecomment(id,pageid));
        }


    }
}