using System;
using System.Configuration;
using System.Data.SqlClient;

public static class ConnectionStringHelper
{
    public static string GetConnectionString()
    {
        // Get the selected database from AppSettings
        string selectedDB = ConfigurationManager.AppSettings["SelectedDatabase"] ?? "PersonalFinancialsDBProd";
        return ConfigurationManager.ConnectionStrings[selectedDB].ConnectionString;
    }

    public static SqlConnection GetSqlConnection()
    {
        return new SqlConnection(GetConnectionString());
    }
}
