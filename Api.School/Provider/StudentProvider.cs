using Api.School.Helper;
using Api.School.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api.School.Provider
{
    public class StudentProvider
    {
        SQLHelper _sqlHelper = new SQLHelper();
        public DataTable getStudentList(SearchModel searchModel)
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>
            {
                new SqlParameter("@Page", searchModel.Page),
                new SqlParameter("@Size", searchModel.Size),
                new SqlParameter("@SearchValue", searchModel.SearchValue)

            };

            return _sqlHelper.executeByStoredProcedureObject("spGetRecordsByPageAndSize", sqlParameter);
        }

    }
}
