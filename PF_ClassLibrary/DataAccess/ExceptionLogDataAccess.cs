using System;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PF_ClassLibrary.DataAccess
{
    public class ExceptionLogDataAccess
    {
        private readonly string _connectionString;

        public ExceptionLogDataAccess()
        {
            _connectionString = ConnectionStringHelper.GetConnectionString();
        }

        public void LogException(Exception ex)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO tbl_ExceptionLog 
                                    (exceptionMessage, exceptionStackTrace, exceptionSource, exceptionDateTime) 
                                    VALUES (@message, @stackTrace, @source, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@message", ex.Message);
                        cmd.Parameters.AddWithValue("@stackTrace", ex.StackTrace ?? "");
                        cmd.Parameters.AddWithValue("@source", ex.Source ?? "");

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine("Error logging exception: " + logEx.Message);
            }
        }
    }
}
