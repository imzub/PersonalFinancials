using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;
using PF_ClassLibrary.Common;

namespace PF_ClassLibrary.DataAccess
{
    public class AssetHistoryDataAccess
    {
        private AssetHistory _assetHistory;
        ExceptionLogDataAccess logger;
        EventLogDataAccess eventLogger = new EventLogDataAccess();

        // 🔹 Get All Asset History Records
        public List<AssetHistory> GetAllAssetHistory()
        {
            List<AssetHistory> assetHistories = new List<AssetHistory>();

            using (SqlConnection conn = ConnectionStringHelper.GetSqlConnection())
            {
                string query = "SELECT assetHistoryId, assetId, assetOldValue, assetNewValue, assetHistoryTimeStamp FROM tbl_AssetHistory";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        assetHistories.Add(new AssetHistory
                        {
                            AssetHistoryId = reader.GetInt64(0),
                            AssetId = reader.GetInt64(1),
                            AssetOldValue = reader.GetString(2),
                            AssetNewValue = reader.GetString(3),
                            AssetHistoryTimeStamp = reader.GetDateTime(4)
                        });
                    }
                }
            }

            return assetHistories;
        }

        // 🔹 Insert Asset History Record
        public bool InsertAssetHistory(AssetHistory assetHistory)
        {
            using (SqlConnection conn = ConnectionStringHelper.GetSqlConnection())
            {
                string query = @"
                    INSERT INTO tbl_AssetHistory (assetId, assetOldValue, assetNewValue, assetHistoryTimeStamp) 
                    VALUES (@AssetId, @AssetOldValue, @AssetNewValue, GETDATE());";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AssetId", assetHistory.AssetId);
                cmd.Parameters.AddWithValue("@AssetOldValue", assetHistory.AssetOldValue);
                cmd.Parameters.AddWithValue("@AssetNewValue", assetHistory.AssetNewValue);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    eventLogger.LogEvent(new EventLogModel
                    {
                        EventType = "Insert",
                        EventMessage = "Asset history inserted successfully.",
                        EventSource = "AssetHistoryDataAccess",
                        UserName = "System"
                    });
                }

                return rowsAffected > 0;
            }
        }

        // 🔹 Delete Asset History By ID
        public bool DeleteAssetHistoryById(long assetHistoryId)
        {
            using (SqlConnection conn = ConnectionStringHelper.GetSqlConnection())
            {
                string query = "DELETE FROM tbl_AssetHistory WHERE assetHistoryId = @AssetHistoryId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AssetHistoryId", assetHistoryId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    eventLogger.LogEvent(new EventLogModel
                    {
                        EventType = "Delete",
                        EventMessage = "Asset history deleted successfully.",
                        EventSource = "AssetHistoryDataAccess",
                        UserName = "System"
                    });
                }

                return rowsAffected > 0;
            }
        }

        // 🔹 Delete Asset History By Asset ID (For Cleanup)
        public bool DeleteAssetHistoryByAssetId(long assetId)
        {
            using (SqlConnection conn = ConnectionStringHelper.GetSqlConnection())
            {
                string query = "DELETE FROM tbl_AssetHistory WHERE assetId = @AssetId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AssetId", assetId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    eventLogger.LogEvent(new EventLogModel
                    {
                        EventType = "Delete",
                        EventMessage = "Asset history deleted successfully by asset ID.",
                        EventSource = "AssetHistoryDataAccess",
                        UserName = "System"
                    });
                }

                return rowsAffected > 0;
            }
        }

        // 🔹 Log Insert or Update Asset History
        public bool LogInsertOrUpdateAssetHistory(Asset asset, Asset oldAsset)
        {
            try
            {
                using (SqlConnection conn = ConnectionStringHelper.GetSqlConnection())
                {
                    conn.Open();

                    // 🔹 Step 1: Check if Asset Exists (for update case)
                    string checkQuery = "SELECT * FROM tbl_Assets WHERE assetId = @AssetId";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@AssetId", asset.AssetId);

                    // 🔹 Step 2: Prepare Old and New Values as Key-Value JSON-like Strings
                    string oldValues = oldAsset != null ? ConvertAssetToKeyValueString(oldAsset) : null;
                    string newValues = ConvertAssetToKeyValueString(asset);

                    // 🔹 Step 3: Insert into Asset History
                    string insertQuery = @"
                        INSERT INTO tbl_AssetHistory (assetId, assetOldValue, assetNewValue, assetHistoryTimeStamp) 
                        VALUES (@AssetId, @AssetOldValue, @AssetNewValue, GETDATE());";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@AssetId", asset.AssetId);
                    insertCmd.Parameters.AddWithValue("@AssetOldValue", oldValues ?? (object)DBNull.Value);  // NULL for new assets
                    insertCmd.Parameters.AddWithValue("@AssetNewValue", newValues);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        eventLogger.LogEvent(new EventLogModel
                        {
                            EventType = "InsertOrUpdate",
                            EventMessage = "Asset history logged successfully.",
                            EventSource = "AssetHistoryDataAccess",
                            UserName = "System"
                        });
                    }

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                logger = new ExceptionLogDataAccess();
                logger.LogException(ex);
                Console.WriteLine($"Error logging asset history: {ex.Message}");
                return false;
            }
        }

        // 🔹 Helper Method: Convert Asset Object to Key-Value String
        private string ConvertAssetToKeyValueString(Asset asset)
        {
            Dictionary<string, string> assetDetails = new Dictionary<string, string>
            {
                { "Asset Type ID", asset.AssetTypeId.ToString() },
                { "User ID", asset.UserId.ToString() },
                { "Asset Name", asset.AssetName },
                { "Asset Description", asset.AssetDesc },
                { "Asset Units", asset.AssetUnits.ToString() },
                { "Is Zakat Applicable", asset.IsAssetZakatApplicable ? "Yes" : "No" },
                { "Bought Date", asset.AssetBoughtDate.ToString("yyyy-MM-dd HH:mm:ss")},
                { "Bought Price", asset.AssetBoughtPrice.ToString() },
                { "Created Timestamp", asset.AssetTimeStamp.ToString("yyyy-MM-dd HH:mm:ss") },
                { "Is Active", asset.IsAssetActive ? "Active" : "Inactive" }
            };

            return string.Join(", ", assetDetails);
        }
    }
}
