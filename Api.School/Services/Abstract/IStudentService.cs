using Api.School.Models;
using System.Data;

namespace Api.School.Services.Abstract
{
    public interface IStudentService
    {
        public DataTable getStudentList(SearchModel searchModel);
    }
}
