using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers.API
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext dbContext { get; set; }
        public CoursesController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var UserId = User.Identity.GetUserId();
            var course = dbContext.Courses.Single(c => c.Id == id && c.LecturerId == UserId);
            if (course.IsCanceled)
            {
                return NotFound();
            }
            course.IsCanceled = true;
            dbContext.SaveChanges();
            return Ok();

        }
    }
}
