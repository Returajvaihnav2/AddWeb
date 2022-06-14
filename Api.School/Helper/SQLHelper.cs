using Api.School.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Api.School.Helper
{
    public class SQLHelper
    {
        SchoolContext context = new SchoolContext();
   
        public DataTable executeByStoredProcedureObject(string spName, List<SqlParameter> param = null)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection connection = context.Database.GetDbConnection() as SqlConnection;
                connection.Open();
                using (SqlCommand command = new SqlCommand(spName, (SqlConnection)connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (param != null && param.Count > 0)
                        command.Parameters.AddRange(param.ToArray());

                    dt.Load(command.ExecuteReader());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                
                dt = new DataTable();
            }
            return dt;
        }

        public DataSet executeByStoredProcedureDataset(string spName, List<SqlParameter> param = null)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection connection = context.Database.GetDbConnection() as SqlConnection;
                connection.Open();
                using (SqlCommand command = new SqlCommand(spName, (SqlConnection)connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    command.CommandType = CommandType.StoredProcedure;
                    if (param != null && param.Count > 0)
                        command.Parameters.AddRange(param.ToArray());

                    da = new SqlDataAdapter(command);
                    da.Fill(ds);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
            }
            return ds;
        }
        public DataSet executeByStoredProcedureDatasetWithOutput(string spName, out int totalPages, List<SqlParameter> param = null)
        {
            DataSet ds = new DataSet();
            totalPages = 0;
            try
            {
                SqlConnection connection = context.Database.GetDbConnection() as SqlConnection;
                connection.Open();
                using (SqlCommand command = new SqlCommand(spName, (SqlConnection)connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    command.CommandType = CommandType.StoredProcedure;


                    if (param != null && param.Count > 0)
                        command.Parameters.AddRange(param.ToArray());
                    SqlParameter parameter = new SqlParameter("@TotalPages", SqlDbType.Int);
                    parameter.Direction = ParameterDirection.Output;

                    command.Parameters.Add(parameter);

                    da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    totalPages = Convert.ToInt32(parameter.Value.ToString());
                }
                connection.Close();
             }
            catch (Exception ex)
            {
                ds = new DataSet();
            }
            return ds;
        }
      

    }
}
