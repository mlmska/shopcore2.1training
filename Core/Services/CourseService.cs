using Core.Convertors;
using Core.DTOs.Course;
using Core.Generator;
using Core.Security;
using Core.Services.Intefaces;
using datalayer.Context;
using datalayer.Entities.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class CourseService : ICourseService
    {

        private Corecontext _db;

        public CourseService(Corecontext db)
        {
            _db = db;
        }

        public void addcomment(CourseComment comment)
        {
            _db.CourseComments.Add(comment); 
            _db.SaveChanges();
        }

        public int Addcourse(Course course, IFormFile imgCourse, IFormFile democourse)
        {
            course.Createdate = DateTime.Now;
            course.CourseImagname = "no-image.png";
            if (imgCourse != null&& imgCourse.Isimage())
            {
                course.CourseImagname = Namegenerator.GenerateUniqcode() + Path.GetExtension(imgCourse.FileName);
                string imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/Image", course.CourseImagname);

                using(var stream=new FileStream(imagepath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }
                ImageConvertor imageresizer = new ImageConvertor();
                string thumpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/thumb", course.CourseImagname);
                imageresizer.Image_resize(imagepath, thumpath,150);



            }
            if (democourse != null)
            {
                course.DemofileName = Namegenerator.GenerateUniqcode() + Path.GetExtension(democourse.FileName);
                string demopath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/demos", course.DemofileName);
                using (var stream = new FileStream(demopath, FileMode.Create))
                {
                    democourse.CopyTo(stream);
                }
            }

            _db.Add(course);
            _db.SaveChanges();
            return course.CourseID;

        }

        public int addepisode(CourseEpisode episode,IFormFile episodefile)
        {
            episode.EpisodeFileName = episodefile.FileName;

          
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles",episode.EpisodeFileName);
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                episodefile.CopyTo(stream);
            }



            _db.CourseEpisodes.Add(episode);
            _db.SaveChanges();
            return episode.EpisodeID;
        }

        public void AddGroup(CourseGroup group)
        {
            _db.CourseGroup.Add(group);
            _db.SaveChanges();
        }

        public bool CheckexistFile(string filename)
        {
            string path= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles", filename);
            return File.Exists(path);
        }

        public void editepisode(CourseEpisode episode, IFormFile episodefile)
        {
            if (episodefile != null)
            {
                string deletefilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles", episode.EpisodeFileName);
                File.Delete(deletefilepath);

                episode.EpisodeFileName = episodefile.FileName;

                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/courseFiles", episode.EpisodeFileName);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    episodefile.CopyTo(stream);
                }
            }
            _db.CourseEpisodes.Update(episode);
            _db.SaveChanges();


        }

        public List<CourseGroup> Getallgroups()
        {
            return _db.CourseGroup.Include(p=>p.CourseGroups).ToList();
        }

        public CourseGroup getbyid(int groupid)
        {
            return _db.CourseGroup.Find(groupid);
        }

        public Tuple<List<ShowcourselistViewModel>, int> GetCourse(int pageid = 1, string filter = "", string getType = "all",
            string orderbytype = "date", int startpeice = 0,
            int endprice = 0, List<int> SelectedGroups = null,int take=0)
        {
            if (take == 0)
            {
                take = 8;
            }

            IQueryable<Course> result = _db.Courses;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.CourseTitle.Contains(filter)||p.Tags.Contains(filter));
            }
            switch (getType)
            {
                case "all":
                    break;
                case "buy":
                    {
                        result = result.Where(p => p.CoursePrice != 0);
                        break;
                    }
                case "free":
                    {
                        result = result.Where(p => p.CoursePrice == 0);
                        break;
                    }
            }
            switch (orderbytype)
            {
                case "date":
                    {
                        result = result.OrderByDescending(p => p.Createdate);
                        break;
                    }
                case "Updatedate":
                    {
                        result = result.OrderByDescending(p => p.Updatedate);
                        break;
                    }
            }
            if (startpeice > 0)
            {
                result = result.Where(p => p.CoursePrice > startpeice);
            }
            if (endprice > 0)
            {
                result = result.Where(p => p.CoursePrice < startpeice);
            }
            if(SelectedGroups!=null&& SelectedGroups.Any())
            {
                foreach(int groupsid in SelectedGroups)
                {
                    result = result.Where(p => p.GroupID == groupsid || p.GroupID == groupsid);
                }
            }

            int skip = (pageid - 1) * take;

            int pageCount = result.Include(p => p.CourseEpisodes).Select(p => new ShowcourselistViewModel()
            {
                CourseID = p.CourseID,
                Imagename = p.CourseImagname,
                Price = p.CoursePrice,
                Title = p.CourseTitle,
                TotalTime = new TimeSpan(p.CourseEpisodes.Sum(e => e.EpisodeTime.Ticks))
            }).Count() / take;

            var query= result.Include(p => p.CourseEpisodes).Select(p => new ShowcourselistViewModel()
            {
                CourseID = p.CourseID,
                Imagename = p.CourseImagname,
                Price = p.CoursePrice,
                Title = p.CourseTitle,
                TotalTime = new TimeSpan(p.CourseEpisodes.Sum(e => e.EpisodeTime.Ticks))
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);

        }

        public Course getcoursebyid(int courseid)
        {
            return _db.Courses.Find(courseid);
        }

        public Tuple<List<CourseComment>, int> getcoursecomment(int courseid, int pageid = 1)
        {
            int take = 5;
            int skip = (pageid - 1) * take; 
            int pagecount = _db.CourseComments.Where(p => !p.isDelete && p.CourseID == courseid).Count() / take;

            if ((pagecount % 2) != 0)
            {
                pagecount+=1; 
            }


            return Tuple.Create(_db.CourseComments.Include(p=>p.User).Where(p => !p.isDelete && p.CourseID == courseid)
                .Skip(skip).Take(take).OrderByDescending(p=>p.CreaDate).ToList(), pagecount);
        }

        public List<ShowcourseforadminViewModel> getcourseforadmin()
        {
            return _db.Courses.Select(c => new ShowcourseforadminViewModel()
            {
                CourseID = c.CourseID,
                ImageName = c.CourseImagname,
                Title = c.CourseTitle,
                EpisodeCount = c.CourseEpisodes.Count

            }).ToList();
        }

        public Course GetcourseForshow(int courseid)
        {
            return _db.Courses.Include(c => c.CourseEpisodes)
                .Include(c => c.CourseStatus)
                .Include(c => c.CourseLevel).
                Include(c => c.User).Include(c=>c.UserCourses)
                .FirstOrDefault(c => c.CourseID == courseid);
        }

        public CourseEpisode getepisodebyid(int episodeid)
        {
            return _db.CourseEpisodes.Find(episodeid);
        }

        public List<SelectListItem> getgroupformanagecourse()
        {
            return _db.CourseGroup.Where(p => p.ParentID == null).Select(p => new SelectListItem()
            {
                Text = p.GroupTitle,
                Value = p.GroupID.ToString()
            }).ToList();
        }

        public List<SelectListItem> getlevels()
        {
            return _db.CourseLevels.Select(p => new SelectListItem()
            {
                Value = p.LevelID.ToString(),
                Text = p.LevelTitle
            }).ToList();
        }

        public List<CourseEpisode> getlistepisode(int courseid)
        {
            return _db.CourseEpisodes.Where(p => p.CourseID == courseid).ToList();
        }

        public List<ShowcourselistViewModel> GetPopularcourse()
        {
            return _db.Courses.Include(p => p.OrderDetails)
                .Where(p=>p.OrderDetails.Any())
                .OrderByDescending(o => o.OrderDetails.Count)
                .Take(8)
                .Select(p=>new ShowcourselistViewModel()
                {
                    CourseID=p.CourseID,
                    Title=p.CourseTitle,
                    Imagename=p.CourseImagname,
                    Price=p.CoursePrice,
                    TotalTime=new TimeSpan(p.CourseEpisodes.Sum(e=>e.EpisodeTime.Ticks))
                })
                .ToList();
        }

        public List<SelectListItem> getstatus()
        {
            return _db.CourseStatuses.Select(p => new SelectListItem()
            {
                Value = p.StatusID.ToString(),
                Text = p.StatusTitle
            }).ToList();
        }

        public List<SelectListItem> getsubgroupformanagecourse(int groupid)
        {
            return _db.CourseGroup.Where(p => p.ParentID == groupid).Select(p => new SelectListItem()
            {
                Text = p.GroupTitle,
                Value = p.GroupID.ToString()
            }).ToList();
        }

        public List<SelectListItem> getteachers()
        {
            return _db.User_Roles.Where(p => p.RoleID == 4).Include(p => p.User).Select(p => new SelectListItem()
            {
                Value = p.UserID.ToString(),
                Text = p.User.UserName
            }).ToList();
        }

        public void updatecourse(Course course, IFormFile imgCourse, IFormFile democourse)
        {
            course.Createdate = DateTime.Now;
            if (imgCourse != null && imgCourse.Isimage())
            {
                if (course.CourseImagname != "no-image.png")
                {
                    string deleteimagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/Image", course.CourseImagname);
                    if (File.Exists(deleteimagepath))
                    {
                        File.Delete(deleteimagepath);
                    }
                    string deleteimagethumbpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/thumb", course.CourseImagname);
                    if (File.Exists(deleteimagethumbpath))
                    {
                        File.Delete(deleteimagethumbpath);
                    }
                }


                course.CourseImagname = Namegenerator.GenerateUniqcode() + Path.GetExtension(imgCourse.FileName);
                string imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/Image", course.CourseImagname);

                using (var stream = new FileStream(imagepath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }
                ImageConvertor imageresizer = new ImageConvertor();
                string thumpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/thumb", course.CourseImagname);
                imageresizer.Image_resize(imagepath, thumpath, 150);



            }

            if (democourse != null)
            {

                if (course.DemofileName != null)
                {
                   string deletedemopath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/demos", course.DemofileName);
                    if (File.Exists(deletedemopath))
                    {
                        File.Delete(deletedemopath);
                    }
                }
                course.DemofileName = Namegenerator.GenerateUniqcode() + Path.GetExtension(democourse.FileName);
                string demopath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Course/demos", course.DemofileName);
                using (var stream = new FileStream(demopath, FileMode.Create))
                {
                    democourse.CopyTo(stream);
                }
            }
            _db.Courses.Update(course);
            _db.SaveChanges();


        }

        public void UpdateGroup(CourseGroup group)
        {
            _db.CourseGroup.Update(group);
            _db.SaveChanges();
        }
    }
}
