using System;
using System.Data;
using System.Data.SqlClient;

namespace PersonalFinancials.DataAccess
{
    public abstract class BaseDataAccess
    {
        protected string ConnectionString => ConnectionStringHelper.GetConnectionString();

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        protected int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery(); // 🔹 Return the number of affected rows
                }
            }
        }

        protected DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters, SqlTransaction transactio)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }       

        public DataTable ExecuteQuery(string query, SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters, SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
