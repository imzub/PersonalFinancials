using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class AssetDataAccess : BaseDataAccess
    {
        public DataTable GetAssetCategorySum()
        {
            string query = "EXEC sp_GetAssetCategorySum"; // Call stored procedure
            return ExecuteQuery(query); // Fetch result as DataTable
        }

        public bool InsertAsset(Asset asset)
        {
            string query = @"INSERT INTO tbl_Assets 
                    (assetTypeId, userId, assetName, assetDesc, assetUnits, isAssetZakatApplicable, 
                    assetBoughtDate, assetBoughtPrice, isAssetActive, assetTimeStamp, assetZakatApplicableFromDate) 
                    VALUES 
                    (@AssetTypeId, @UserId, @AssetName, @AssetDesc, @AssetUnits, @IsAssetZakatApplicable, 
                    @AssetBoughtDate, @AssetBoughtPrice, @IsAssetActive, @AssetTimeStamp, @assetZakatApplicableFromDate)";

            SqlParameter[] parameters = {
        new SqlParameter("@AssetTypeId", SqlDbType.BigInt) { Value = asset.AssetTypeId },
        new SqlParameter("@UserId", SqlDbType.BigInt) { Value = asset.UserId },
        new SqlParameter("@AssetName", SqlDbType.NVarChar, 255) { Value = asset.AssetName },
        new SqlParameter("@AssetDesc", SqlDbType.NVarChar, 255) { Value = asset.AssetDesc },
        new SqlParameter("@AssetUnits", SqlDbType.Decimal) { Value = asset.AssetUnits },
        new SqlParameter("@IsAssetZakatApplicable", SqlDbType.Bit) { Value = asset.IsAssetZakatApplicable },
        new SqlParameter("@AssetBoughtDate", SqlDbType.DateTime) { Value = asset.AssetBoughtDate },
        new SqlParameter("@AssetBoughtPrice", SqlDbType.Decimal) { Value = asset.AssetBoughtPrice },
        new SqlParameter("@IsAssetActive", SqlDbType.Bit) { Value = asset.IsAssetActive },
        new SqlParameter("@AssetTimeStamp", SqlDbType.DateTime) { Value = asset.AssetTimeStamp },
        new SqlParameter("@assetZakatApplicableFromDate", SqlDbType.DateTime) {Value = asset.ZakatApplicableFromDate }
             };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable GetAllAssets()
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllAssets", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public bool UpdateAsset(Asset asset)
        {
            bool isUpdated = false;
            string query = @"
                            UPDATE tbl_Assets 
                            SET assetTypeId = @assetTypeId, 
                                userId = @userId, 
                                assetName = @assetName, 
                                assetDesc = @assetDesc, 
                                assetUnits = @assetUnits, 
                                isAssetZakatApplicable = @isAssetZakatApplicable, 
                                assetBoughtDate = @assetBoughtDate, 
                                assetBoughtPrice = @assetBoughtPrice, 
                                assetTimeStamp = @assetTimeStamp, 
                                isAssetActive = @isAssetActive,
                                assetZakatApplicableFromDate = @assetZakatApplicableFromDate
                            WHERE assetId = @assetId";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction sqlTransaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn, sqlTransaction))
                        {
                            cmd.Parameters.AddWithValue("@assetId", asset.AssetId);
                            cmd.Parameters.AddWithValue("@assetTypeId", asset.AssetTypeId);
                            cmd.Parameters.AddWithValue("@userId", asset.UserId);
                            cmd.Parameters.AddWithValue("@assetName", (object)asset.AssetName ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@assetDesc", (object)asset.AssetDesc ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@assetUnits", asset.AssetUnits);
                            cmd.Parameters.AddWithValue("@isAssetZakatApplicable", asset.IsAssetZakatApplicable ? 1 : 0);
                            cmd.Parameters.AddWithValue("@assetBoughtDate", asset.AssetBoughtDate);
                            cmd.Parameters.AddWithValue("@assetBoughtPrice", asset.AssetBoughtPrice);
                            cmd.Parameters.AddWithValue("@assetTimeStamp", asset.AssetTimeStamp);
                            cmd.Parameters.AddWithValue("@isAssetActive", asset.IsAssetActive ? 1 : 0);
                            cmd.Parameters.AddWithValue("@assetZakatApplicableFromDate", asset.ZakatApplicableFromDate);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            isUpdated = (rowsAffected > 0);

                            if (isUpdated)
                            {
                                AssetZakatFinYearDataAccess assetZakatFinYearDataAccess = new AssetZakatFinYearDataAccess();
                                isUpdated = assetZakatFinYearDataAccess.UpdateAssetStatus(asset.AssetId, asset.IsAssetActive, sqlTransaction);
                            }
                        }

                        if (isUpdated)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        Console.WriteLine($"Error updating asset: {ex.Message}");
                        return false;
                    }
                }
            }
            return isUpdated;
        }

        public Asset GetAssetById(long assetId)
        {
            Asset asset = null;
            string query = "SELECT * FROM tbl_Assets WHERE assetId = @assetId";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@assetId", assetId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            asset = new Asset
                            {
                                AssetId = Convert.ToInt64(reader["assetId"]),
                                AssetTypeId = Convert.ToInt64(reader["assetTypeId"]),
                                UserId = Convert.ToInt64(reader["userId"]),
                                AssetName = reader["assetName"].ToString(),
                                AssetDesc = reader["assetDesc"].ToString(),
                                AssetUnits = Convert.ToDecimal(reader["assetUnits"]),
                                IsAssetZakatApplicable = Convert.ToBoolean(reader["isAssetZakatApplicable"]),
                                AssetBoughtDate = Convert.ToDateTime(reader["assetBoughtDate"]),
                                AssetBoughtPrice = Convert.ToInt64(reader["assetBoughtPrice"]),
                                AssetTimeStamp = Convert.ToDateTime(reader["assetTimeStamp"]),
                                IsAssetActive = Convert.ToBoolean(reader["isAssetActive"]),
                                ZakatApplicableFromDate = reader["assetZakatApplicableFromDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["assetZakatApplicableFromDate"])
                            };
                        }
                    }
                }
            }
            return asset;
        }
        public List<Asset> GetAllAssetNameId()
        {
            List<Asset> assets = new List<Asset>();
            try
            {
                string query = "SELECT assetId, assetName FROM tbl_Assets WHERE isAssetActive = 1";
                DataTable dt = ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    assets.Add(new Asset
                    {
                        AssetId = Convert.ToInt64(row["assetId"]),
                        AssetName = row["assetName"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching asset names and IDs: " + ex.Message);
            }
            return assets;
        }
    }
}
