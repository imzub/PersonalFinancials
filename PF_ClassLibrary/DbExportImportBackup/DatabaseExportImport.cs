using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using PF_ClassLibrary.Common;
using static PF_ClassLibrary.Common.EnumAndKeys;

public class DatabaseExportImport
{
    private string _connectionString;

    public DatabaseExportImport()
    {
        _connectionString = ConnectionStringHelper.GetConnectionString();
    }

    public List<string> GetAllTableNames()
    {
        List<string> tables = new List<string>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
            }
        }

        return tables;
    }


    // 🔹 EXPORT ALL TABLES IN DIFFERENT FORMATS
    public void ExportAllTables(string exportPath, ExportFileFormat format)
    {
        if (format == ExportFileFormat.Select)
        {
            throw new ArgumentException("Invalid file format selected for export.");
        }

        List<string> tableNames = GetAllTableNames();

        foreach (var table in tableNames)
        {
            string filePath = Path.Combine(exportPath, $"{table}.{format.ToString().ToLower()}");

            switch (format)
            {
                case ExportFileFormat.JSON:
                    ExportToJson(table, filePath);
                    break;
                case ExportFileFormat.XML:
                    ExportToXml(table, filePath);
                    break;
                case ExportFileFormat.CSV:
                    ExportToCsv(table, filePath);
                    break;
                default:
                    throw new NotSupportedException($"Export format {format} is not supported.");
            }
        }
    }


    // 🔹 IMPORT ALL TABLES FROM FILES
    public void ImportAllTables(string directoryPath, string format)
    {
        List<string> tables = GetAllTableNames();

        foreach (var table in tables)
        {
            string filePath = Path.Combine(directoryPath, $"{table}.{format}");
            if (!File.Exists(filePath)) continue;

            switch (format.ToLower())
            {
                case "json":
                    ImportFromJson(table, filePath);
                    break;
                case "xml":
                    ImportFromXml(table, filePath);
                    break;
                case "csv":
                    ImportFromCsv(table, filePath);
                    break;
                default:
                    Console.WriteLine($"Unsupported format: {format}");
                    break;
            }
        }
    }

    // Export data to JSON
    //public void ExportToJson(string tableName, string filePath)
    //{
    //    DataTable dt = GetTableData(tableName);
    //    string json = JsonSerializer.Serialize(dt);
    //    File.WriteAllText(filePath, json);
    //}

    public void ExportToJson(string tableName, string filePath)
    {
        DataTable dt = GetTableData(tableName);

        // ✅ Convert DataTable to List of Dictionary for serialization
        var rowsList = new List<Dictionary<string, object>>();

        foreach (DataRow row in dt.Rows)
        {
            var rowDict = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                rowDict[col.ColumnName] = row[col] == DBNull.Value ? null : row[col]; // Handle NULL values
            }
            rowsList.Add(rowDict);
        }

        // ✅ Serialize to JSON
        string json = JsonSerializer.Serialize(rowsList, new JsonSerializerOptions { WriteIndented = true });

        // ✅ Write to File
        File.WriteAllText(filePath, json);
    }

    // Export data to XML
    //public void ExportToXml(string tableName, string filePath)
    //{
    //    DataTable dt = GetTableData(tableName);
    //    XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
    //    using (TextWriter writer = new StreamWriter(filePath))
    //    {
    //        serializer.Serialize(writer, dt);
    //    }
    //}

    //public void ExportToXml(string tableName, string filePath)
    //{
    //    DataTable dt = GetTableData(tableName);

    //    if (dt == null || dt.Rows.Count == 0)
    //    {
    //        throw new InvalidOperationException("No data available to export.");
    //    }

    //    // ✅ Set Table Name to Avoid Serialization Error
    //    dt.TableName = tableName;

    //    XmlSerializer serializer = new XmlSerializer(typeof(DataTable));

    //    using (TextWriter writer = new StreamWriter(filePath))
    //    {
    //        serializer.Serialize(writer, dt);
    //    }
    //}

    public void ExportToXml(string tableName, string filePath)
    {
        DataTable dt = GetTableData(tableName);

        // ✅ Skip export if the table is null or empty
        if (dt == null || dt.Rows.Count == 0)
        {
            Console.WriteLine($"Skipping export: No data found in table '{tableName}'.");
            return; // Simply exit without throwing an exception
        }

        // ✅ Set Table Name to Avoid Serialization Error
        dt.TableName = tableName;

        XmlSerializer serializer = new XmlSerializer(typeof(DataTable));

        using (TextWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, dt);
        }

        Console.WriteLine($"Successfully exported '{tableName}' to {filePath}");
    }

    // Export data to CSV
    public void ExportToCsv(string tableName, string filePath)
    {
        DataTable dt = GetTableData(tableName);
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            foreach (DataColumn column in dt.Columns)
                csv.WriteField(column.ColumnName);
            csv.NextRecord();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                    csv.WriteField(row[column]);
                csv.NextRecord();
            }
        }
    }

    // Get data from table
    private DataTable GetTableData(string tableName)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            string query = $"SELECT * FROM {tableName}";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }

    //// Import JSON to Database
    //public void ImportFromJson(string tableName, string filePath)
    //{
    //    string json = File.ReadAllText(filePath);
    //    DataTable dt = JsonSerializer.Deserialize<DataTable>(json);
    //    BulkInsert(tableName, dt);
    //}
    public void ImportFromJson(string tableName, string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);

            // ✅ Deserialize JSON into a list of dictionaries
            List<Dictionary<string, object>> rows = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

            if (rows == null || rows.Count == 0)
            {
                Console.WriteLine($"Skipping import: No data found in file '{filePath}'.");
                return; // Skip if JSON has no data
            }

            // ✅ Convert to DataTable
            DataTable dt = ConvertToDataTable(rows);

            // ✅ Bulk insert into the database
            BulkInsert(tableName, dt);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error importing JSON for table '{tableName}': {ex.Message}");
        }
    }

    private DataTable ConvertToDataTable(List<Dictionary<string, object>> rows)
    {
        DataTable dt = new DataTable();

        if (rows.Count > 0)
        {
            // ✅ Create columns dynamically based on JSON keys
            foreach (var column in rows[0].Keys)
            {
                dt.Columns.Add(column);
            }

            // ✅ Populate rows with data
            foreach (var row in rows)
            {
                DataRow dataRow = dt.NewRow();
                foreach (var column in row)
                {
                    dataRow[column.Key] = column.Value ?? DBNull.Value; // Handle null values
                }
                dt.Rows.Add(dataRow);
            }
        }

        return dt;
    }

    // Import XML to Database
    public void ImportFromXml(string tableName, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            DataTable dt = (DataTable)serializer.Deserialize(fs);
            BulkInsert(tableName, dt);
        }
    }

    // Import CSV to Database
    //public void ImportFromCsv(string tableName, string filePath)
    //{
    //    DataTable dt = new DataTable();
    //    using (var reader = new StreamReader(filePath))
    //    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
    //    {
    //        using (var dr = new CsvDataReader(csv))
    //        {
    //            dt.Load(dr);
    //        }
    //    }
    //    BulkInsert(tableName, dt);
    //}

    public void ImportFromCsv(string tableName, string filePath)
    {
        // ✅ Ensure file exists
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found at {filePath}");
        }

        DataTable dt = new DataTable();

        // ✅ Use FileStream with proper access mode
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var reader = new StreamReader(fs))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            using (var dr = new CsvDataReader(csv))
            {
                dt.Load(dr);
            }
        }

        BulkInsert(tableName, dt);
    }

    // Bulk insert data into database
    private void BulkInsert(string tableName, DataTable dataTable)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.WriteToServer(dataTable);
            }
        }
    }

    //public void ImportFromCsvTest(string tableName, string filePath)
    //{
    //    DataTable dt = new DataTable();

    //    using (var reader = new StreamReader(filePath))
    //    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
    //    {
    //        csv.Read();
    //        csv.ReadHeader();

    //        using (var dr = new CsvDataReader(csv))
    //        {
    //            dt.Load(dr);
    //        }
    //    }

    //    // ✅ Convert String Columns to DateTime
    //    ConvertDateColumns(dt, new List<string> { "assetZakatFinYearStartDate", "assetZakatFinYearEndDate" });

    //    // Bulk Insert to Database
    //    BulkInsert(tableName, dt);
    //}

    //// 🔹 Utility Method to Convert String Columns to DateTime
    //// 🔹 Convert String Columns to DateTime After Removing Read-Only Restriction
    //private void ConvertDateColumns(DataTable dt, List<string> dateColumns)
    //{
    //    foreach (string column in dateColumns)
    //    {
    //        if (dt.Columns.Contains(column))
    //        {
    //            dt.Columns[column].ReadOnly = false; // ✅ Remove Read-Only Restriction

    //            foreach (DataRow row in dt.Rows)
    //            {
    //                if (row[column] == DBNull.Value || string.IsNullOrWhiteSpace(row[column].ToString()))
    //                {
    //                    row[column] = DateTime.Now; // ✅ Default Value Instead of NULL
    //                }
    //                else if (DateTime.TryParse(row[column].ToString(), out DateTime dateValue))
    //                {
    //                    row[column] = dateValue; // ✅ Store as DateTime
    //                }
    //                else
    //                {
    //                    row[column] = DateTime.Now; // ✅ Handle Invalid Dates
    //                }
    //            }
    //        }
    //    }
    //}




    //public void ImportAssetZakatFinYear(string filePath)
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();

    //        // Define table schema (match database columns)
    //        dt.Columns.Add("assetId", typeof(long));
    //        dt.Columns.Add("assetZakatFinYearStartDate", typeof(DateTime));
    //        dt.Columns.Add("assetZakatFinYearEndDate", typeof(DateTime));
    //        dt.Columns.Add("isAssetZakatFinYearActive", typeof(bool));

    //        // Read CSV file
    //        using (var reader = new StreamReader(filePath))
    //        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
    //        {
    //            while (csv.Read())
    //            {
    //                DataRow row = dt.NewRow();

    //                row["assetId"] = csv.GetField<long>("assetId");

    //                // Convert Start and End Date (Handling Invalid Date)
    //                if (DateTime.TryParse(csv.GetField<string>("assetZakatFinYearStartDate"), out DateTime startDate))
    //                {
    //                    row["assetZakatFinYearStartDate"] = startDate;
    //                }
    //                else
    //                {
    //                    throw new Exception($"Invalid date format in assetZakatFinYearStartDate: {csv.GetField<string>("assetZakatFinYearStartDate")}");
    //                }

    //                if (DateTime.TryParse(csv.GetField<string>("assetZakatFinYearEndDate"), out DateTime endDate))
    //                {
    //                    row["assetZakatFinYearEndDate"] = endDate;
    //                }
    //                else
    //                {
    //                    throw new Exception($"Invalid date format in assetZakatFinYearEndDate: {csv.GetField<string>("assetZakatFinYearEndDate")}");
    //                }

    //                // Convert BIT (true/false) column
    //                string isActiveStr = csv.GetField<string>("isAssetZakatFinYearActive");
    //                row["isAssetZakatFinYearActive"] = isActiveStr == "1" || isActiveStr.ToLower() == "true";

    //                dt.Rows.Add(row);
    //            }
    //        }

    //        // Perform Bulk Insert
    //        BulkInsert("tbl_AssetZakatFinYear", dt);

    //        //MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show($"Error during import: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}
}
