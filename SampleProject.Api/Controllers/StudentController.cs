using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using SampleProject.Model;
using System.IO;

namespace SampleProject.Api.Controllers
{
    [Route("api/SampleProject/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        IStudentRepository _repository;
        public IActionResult Index()
        {
            return View();
        }

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // Get Single Student
        [HttpGet("Select")]
        public async Task<ActionResult> SelectStudent(string StudentID)
        {
            var response = await _repository.SelectStudent(StudentID);

            if (response.Success)
            {
                return Ok(response);
             }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // Get All Student
        [HttpGet("SelectAll")]
        public async Task<ActionResult> SelectAllStudents()
        {
            var response = await _repository.SelectAllStudents();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        // Delete Student
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteStudent(string StudentID)
        {
            var response = await _repository.DeleteStudent(StudentID);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // Insert Student
        [HttpPost("Insert")]
        public async Task<ActionResult> InsertStudent(Student st)
        {
            

            var response = await _repository.InsertStudent(st);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
         
        //Insert Student using Request Parameters
        //[HttpPost("Insert")]
        //public async Task<ActionResult> InsertStudent(string StudentID, string fname, string lname, DateTime DOB, string Address)
        //{
        //    var response = await _repository.InsertStudent(StudentID, fname, lname, DOB, Address);

        //    if (response.Success)
        //    {
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, response);
        //    }
        //}

        // Update Students
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateStudent([FromBody] Student st)
        {


            var response = await _repository.UpdateStudent(st);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
