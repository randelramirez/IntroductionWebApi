using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingCompany.Controllers
{

    public class CoursesController : ApiController
    {
        [HttpGet]
        public IEnumerable<Course> AllCourses()
        {
            return courses;
        }
        public HttpResponseMessage Post([FromBody]Course c)
        {
            c.Id = courses.Count;
            courses.Add(c);
            //i should return a 201 with a location header
            var msg = Request.CreateResponse(
                HttpStatusCode.Created);
            msg.Headers.Location =
                new Uri(Request.RequestUri + c.Id.ToString());
            return msg;


        }
        public void Put(int id, [FromBody]Course course)
        {
            var ret = (from c in courses
                       where c.Id == id
                       select c).FirstOrDefault();
            ret.Title = course.Title;


        }
        public void Delete(int id)
        {
            var ret = (from c in courses
                       where c.Id == id
                       select c).FirstOrDefault();
            courses.Remove(ret);
        }
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage msg = null;
            var ret = (from c in courses
                       where c.Id == id
                       select c).FirstOrDefault();
            //if null  - I should return a 404
            if (ret == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Course not found!");

            }
            else
            {
                msg = Request.CreateResponse<Course>(HttpStatusCode.OK, ret);
            }
            return msg;
        }

        static List<Course> courses = InitCourses();

        private static List<Course> InitCourses()
        {
            var ret = new List<Course>
            {
                new Course { Id = 0, Title = "Web Api"},
                new Course { Id = 1, Title = "Mobile Apps with HTML5" }
            };

            return ret;
        }
    }

    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
