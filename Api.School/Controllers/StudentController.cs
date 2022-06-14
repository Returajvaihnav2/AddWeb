using Api.School.Models;
using Api.School.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentService studentService =new StudentService();
        // GET: api/<StudentController>
        [HttpGet]
        public MultipleEntityResult<StudentModel> getStudentList(SearchModel searchModel)
        {
            try
            {

                var studentlist = studentService.getStudentList(searchModel);
                List<StudentModel> stdlist = new List<StudentModel>();
                foreach (DataRow student in studentlist.Rows) {
                    stdlist.Add(new StudentModel
                    {
                        Address = student["student"].ToString(),
                        DateOfBirth = Convert.ToDateTime(student["student"].ToString()),
                        EmailID = student["student"].ToString(),
                        FirstName = student["student"].ToString(),
                        LastName = student["student"].ToString(),
                        StudentID = Convert.ToInt32(student["StudentID"])
                    });
                }

                if (studentlist!=null && studentlist.Rows.Count>0)
                {
                    MultipleEntityResult<StudentModel> response = new MultipleEntityResult<StudentModel>(stdlist, HttpStatusCode.OK, "");
                    return response;
                }
                else
                {
                    MultipleEntityResult<StudentModel> response = new MultipleEntityResult<StudentModel>(stdlist, HttpStatusCode.ExpectationFailed, "");
                    return response;
                }
                

            }
            catch (Exception ex)
            {
                MultipleEntityResult<StudentModel> response = new MultipleEntityResult<StudentModel>(null, HttpStatusCode.ExpectationFailed, ex.Message);
                return response;
            }


        }

    }
}
