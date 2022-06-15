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
        [HttpGet("getStudentList")]
        public MultipleEntityResult<StudentModel> getStudentList(int Page,int Size,String SearchValue)
        {
            try
            {
                SearchModel searchModel = new SearchModel()
                {
                    Page=Page,
                    Size=Size,
                    SearchValue= SearchValue
                };

                var studentlist = studentService.getStudentList(searchModel);
                List<StudentModel> stdlist = new List<StudentModel>();
                foreach (DataRow student in studentlist.Rows) {
                    stdlist.Add(new StudentModel
                    {
                        Address = student["Address"].ToString(),
                        DateOfBirth = Convert.ToDateTime(student["DateOfBirth"].ToString()),
                        EmailID = student["EmailID"].ToString(),
                        FirstName = student["FirstName"].ToString(),
                        LastName = student["LastName"].ToString(),
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
                    MultipleEntityResult<StudentModel> response = new MultipleEntityResult<StudentModel>(stdlist, HttpStatusCode.ExpectationFailed, "Record Not Found");
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
