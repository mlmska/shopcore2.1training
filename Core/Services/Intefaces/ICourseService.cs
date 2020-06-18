using Core.DTOs.Course;
using datalayer.Entities.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Intefaces
{
    public interface ICourseService
    {
        List<CourseGroup> Getallgroups();

        List<SelectListItem> getgroupformanagecourse();
        List<SelectListItem> getsubgroupformanagecourse(int groupid);

        List<SelectListItem> getteachers();
        List<SelectListItem> getlevels();
        List<SelectListItem> getstatus();

        Tuple<List<ShowcourselistViewModel>,int> GetCourse(int pageid=1,string filter="",string getType="all"
            ,string orderbytype="date",int startpeice=0
            ,int endprice=0,List<int> SelectedGroups=null,int take=0);

        Course GetcourseForshow(int courseid);

        List<ShowcourseforadminViewModel> getcourseforadmin();
        int Addcourse(Course course, IFormFile imgCourse, IFormFile democourse);

        Course getcoursebyid(int courseid);
        void updatecourse(Course course, IFormFile imgCourse, IFormFile democourse);


        int addepisode(CourseEpisode episode, IFormFile episodefile);
        bool CheckexistFile(string filename);

        List<CourseEpisode> getlistepisode(int courseid);

        CourseEpisode getepisodebyid(int episodeid);

        void editepisode(CourseEpisode episode, IFormFile episodefile);


        void addcomment(CourseComment comment);

        Tuple<List<CourseComment>,int> getcoursecomment(int courseid,int pageid=1);

        List<ShowcourselistViewModel> GetPopularcourse();

        void AddGroup(CourseGroup group);

        void UpdateGroup(CourseGroup group);

        CourseGroup getbyid(int groupid);

    }
}
