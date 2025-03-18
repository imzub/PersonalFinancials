using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class ApplicationConfigurationDataAccess : BaseDataAccess
    {
        // 🔹 Get All Configurations
        public List<ApplicationConfiguration> GetAllConfigurations()
        {
            string query = "SELECT * FROM tbl_ApplicationConfiguration ORDER BY appConfigTimeStamp DESC";
            DataTable dt = ExecuteQuery(query);

            List<ApplicationConfiguration> configurations = new List<ApplicationConfiguration>();
            foreach (DataRow row in dt.Rows)
            {
                configurations.Add(new ApplicationConfiguration
                {
                    AppConfigId = Convert.ToInt32(row["appConfigId"]),
                    AppKey = row["appKey"].ToString(),
                    AppKeyValue = row["appKeyValue"].ToString(),
                    AppConfigTimeStamp = Convert.ToDateTime(row["appConfigTimeStamp"])
                });
            }
            return configurations;
        }

        // 🔹 Get Configuration By Key
        public ApplicationConfiguration GetConfigurationByKey(string key)
        {
            string query = "SELECT * FROM tbl_ApplicationConfiguration WHERE appKey = @key";
            SqlParameter[] parameters = { new SqlParameter("@key", key) };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new ApplicationConfiguration
                {
                    AppConfigId = Convert.ToInt32(row["appConfigId"]),
                    AppKey = row["appKey"].ToString(),
                    AppKeyValue = row["appKeyValue"].ToString(),
                    AppConfigTimeStamp = Convert.ToDateTime(row["appConfigTimeStamp"])
                };
            }
            return null;
        }

        // 🔹 Insert Configuration
        public bool InsertConfiguration(ApplicationConfiguration config)
        {
            string query = @"
                INSERT INTO tbl_ApplicationConfiguration (appKey, appKeyValue, appConfigTimeStamp)
                VALUES (@key, @value, @timestamp)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@key", config.AppKey),
                new SqlParameter("@value", config.AppKeyValue),
                new SqlParameter("@timestamp", DateTime.Now)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 🔹 Update Configuration
        public bool UpdateConfiguration(ApplicationConfiguration config)
        {
            string query = @"
                UPDATE tbl_ApplicationConfiguration
                SET appKeyValue = @value, appConfigTimeStamp = @timestamp
                WHERE appKey = @key";

            SqlParameter[] parameters =
            {
                new SqlParameter("@key", config.AppKey),
                new SqlParameter("@value", config.AppKeyValue),
                new SqlParameter("@timestamp", DateTime.Now)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 🔹 Delete Configuration
        public bool DeleteConfiguration(int configId)
        {
            string query = "DELETE FROM tbl_ApplicationConfiguration WHERE appConfigId = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", configId) };

            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
