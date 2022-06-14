using Api.School.Models;

namespace Api.School.Services.Abstract
{
    public interface IStudentService
    {
        public List<StudentModel> getStudentList();
    }
}
