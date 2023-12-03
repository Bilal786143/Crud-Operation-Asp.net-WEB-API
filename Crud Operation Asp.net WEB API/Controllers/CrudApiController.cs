using Crud_Operation_Asp.net_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace Crud_Operation_Asp.net_WEB_API.Controllers
{
    public class CrudApiController : ApiController
    {
        ELEARNINGEntities db = new ELEARNINGEntities();


        [HttpGet]
        public IHttpActionResult GetStudents() {
            List<Student> list = db.Students.ToList();
            return Ok(list);
        
        
        }
        [HttpPost]
        public IHttpActionResult StdInsert(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetStdById(int id)
        {
            var std = db.Students.Where(x => x.Student_id == id).FirstOrDefault();
            return Ok(std);
        }

        [HttpPut]
        public IHttpActionResult UpdateStdById(Student s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
            //Student std = db.Students.Where(x => x.Student_id == s.Student_id).FirstOrDefault();
            //if (std != null)
            //{
            //    std.Student_id = s.Student_id;
            //    std.student_contact = s.student_contact;
            //    std.student_email = s.student_email;
            //    std.student_name = s.student_name;
            //    std.student_password = s.student_password;
            //    std.student_pic = s.student_pic;
            //    std.total_enrolment = s.total_enrolment;
            //    db.SaveChanges();

            //}
            //else
            //{
            //    return NotFound();
            //}
            //return Ok(std);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var std = db.Students.Where(x => x.Student_id == id).FirstOrDefault();
            db.Entry(std).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
