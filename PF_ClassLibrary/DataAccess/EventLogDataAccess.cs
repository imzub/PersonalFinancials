using System;
using System.Data;
using System.Data.SqlClient;
using PersonalFinancials.Models;

namespace PersonalFinancials.DataAccess
{
    public class EventLogDataAccess
    {
        private readonly string _connectionString;

        public EventLogDataAccess()
        {
            _connectionString = ConnectionStringHelper.GetConnectionString();
        }

        /// <summary>
        /// Logs an event into the database.
        /// </summary>
        public void LogEvent(EventLogModel eventLog)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_EventLog (EventType, EventMessage, EventSource, UserName, AdditionalData) " +
                                                           "VALUES (@EventType, @EventMessage, @EventSource, @UserName, @AdditionalData)", conn))
                    {
                        cmd.Parameters.AddWithValue("@EventType", eventLog.EventType);
                        cmd.Parameters.AddWithValue("@EventMessage", eventLog.EventMessage);
                        cmd.Parameters.AddWithValue("@EventSource", eventLog.EventSource);
                        cmd.Parameters.AddWithValue("@UserName", (object)eventLog.UserName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@AdditionalData", (object)eventLog.AdditionalData ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error logging event: " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the latest event logs.
        /// </summary>
        public DataTable GetRecentLogs(int topCount = 10)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT TOP {topCount} * FROM tbl_EventLog ORDER BY CreatedAt DESC", conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving event logs: " + ex.Message);
            }
            return dt;
        }
    }
}
