using Api.School.Models;
using Api.School.Provider;
using Api.School.Services.Abstract;
using System.Data;

namespace Api.School.Services.Concrete
{
    public class StudentService : IStudentService
    {
        StudentProvider studentProvider = new StudentProvider();

        public DataTable getStudentList(SearchModel searchModel)
        {
           
                try
                {
                    var datatable= studentProvider.getStudentList(searchModel);                
                }
                catch (Exception ex)
                {
                     Console.WriteLine(ex.Message);
                }
                return new DataTable();
           
        }
    }
}
