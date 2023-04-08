using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProjectTaskKabadiwala.Data;
using WebAPIProjectTaskKabadiwala.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIProjectTaskKabadiwala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        public IEnumerable<StudentModel> GetStudent()
        {
            try
            {
                return _studentDbContext.Students;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("{id}")]
        public StudentModel GetStudentById(int id)
        {
            try
            {
                return _studentDbContext.Students.SingleOrDefault(x => x.StudentId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult AddStudent(StudentModel studentModel)
        {
            try
            {
                _studentDbContext.Students.Add(studentModel);
                _studentDbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, StatusCode = 500 });
            }
        }

        [HttpPut("")]
        public IActionResult UpdateStudent(StudentModel studentModel)
        {
            try
            {
                var exists = _studentDbContext.Students.Any(x => x.StudentId == studentModel.StudentId);
                if (exists)
                {
                    _studentDbContext.Students.Update(studentModel);
                    _studentDbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, StatusCode = 500 });
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var del = _studentDbContext.Students.FirstOrDefault(x => x.StudentId == id);
                if (del != null)
                {
                    _studentDbContext.Students.Remove(del);
                    _studentDbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, StatusCode = 500 });
            }
        }
    }
}
