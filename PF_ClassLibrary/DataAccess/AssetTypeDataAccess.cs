using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class AssetTypeDataAccess : BaseDataAccess
    {
        // 🔹 Get all asset types
        // 🔹 Fetch All Asset Types
        public List<AssetType> GetAllAssetTypes()
        {
            List<AssetType> assetTypes = new List<AssetType>();

            using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                string query = "SELECT assetTypeId, assetTypeName, assetTypeDesc, assetTypeCurrentValuePerUnit FROM tbl_AssetType";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssetType assetType = new AssetType
                            {
                                AssetTypeId = Convert.ToInt64(reader["assetTypeId"]),
                                AssetTypeName = reader["assetTypeName"].ToString(),
                                AssetTypeDesc = reader["assetTypeDesc"].ToString(),
                                AssetTypeCurrentValuePerUnit = Convert.ToDecimal(reader["assetTypeCurrentValuePerUnit"])
                            };

                            assetTypes.Add(assetType);
                        }
                    }
                }
            }

            return assetTypes;
        }



        // 🔹 Get asset type by ID
        public AssetType GetAssetTypeById(long assetTypeId)
        {
            AssetType assetType = null;
            string query = "SELECT * FROM tbl_AssetType WHERE assetTypeId = @assetTypeId";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@assetTypeId", assetTypeId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            assetType = new AssetType
                            {
                                AssetTypeId = Convert.ToInt64(reader["assetTypeId"]),
                                AssetTypeName = reader["assetTypeName"].ToString(),
                                AssetTypeDesc = reader["assetTypeDesc"].ToString(),
                                AssetTypeCurrentValuePerUnit = Convert.ToDecimal(reader["assetTypeCurrentValuePerUnit"])
                            };
                        }
                    }
                }
            }
            return assetType;
        }

        // 🔹 Add new asset type
        public bool AddAssetType(AssetType assetType)
        {
            bool isInserted = false;
            string query = @"
                INSERT INTO tbl_AssetType (assetTypeName, assetTypeDesc, assetTypeCurrentValuePerUnit)
                VALUES (@assetTypeName, @assetTypeDesc, @assetTypeCurrentValuePerUnit)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@assetTypeName", assetType.AssetTypeName);
                    cmd.Parameters.AddWithValue("@assetTypeDesc", assetType.AssetTypeDesc);
                    cmd.Parameters.AddWithValue("@assetTypeCurrentValuePerUnit", assetType.AssetTypeCurrentValuePerUnit);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    isInserted = (rowsAffected > 0);
                }
            }
            return isInserted;
        }

        // 🔹 Update asset type
        public bool UpdateAssetType(AssetType assetType)
        {
            bool isUpdated = false;
            string query = @"
                UPDATE tbl_AssetType 
                SET assetTypeName = @assetTypeName, 
                    assetTypeDesc = @assetTypeDesc, 
                    assetTypeCurrentValuePerUnit = @assetTypeCurrentValuePerUnit
                WHERE assetTypeId = @assetTypeId";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@assetTypeId", assetType.AssetTypeId);
                    cmd.Parameters.AddWithValue("@assetTypeName", assetType.AssetTypeName);
                    cmd.Parameters.AddWithValue("@assetTypeDesc", assetType.AssetTypeDesc);
                    cmd.Parameters.AddWithValue("@assetTypeCurrentValuePerUnit", assetType.AssetTypeCurrentValuePerUnit);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    isUpdated = (rowsAffected > 0);
                }
            }
            return isUpdated;
        }

        // 🔹 Delete asset type
        public bool DeleteAssetType(long assetTypeId)
        {
            bool isDeleted = false;
            string query = "DELETE FROM tbl_AssetType WHERE assetTypeId = @assetTypeId";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@assetTypeId", assetTypeId);
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    isDeleted = (rowsAffected > 0);
                }
            }
            return isDeleted;
        }

        public bool UpdateAssetTypeRatePerUnit(AssetType assetType)
        {
            if (assetType.AssetTypeCurrentValuePerUnit > 0 && !string.IsNullOrEmpty(assetType.AssetTypeName))
            {
                string metalUpdateQuery = @"
                UPDATE tbl_AssetType 
                SET assetTypeCurrentValuePerUnit = @assetTypeCurrentValuePerUnit
                WHERE assetTypeId = @assetTypeId and assetTypeName = @assetTypeName";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(metalUpdateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@assetTypeCurrentValuePerUnit", assetType.AssetTypeCurrentValuePerUnit);
                        cmd.Parameters.AddWithValue("@assetTypeName", assetType.AssetTypeName);
                        cmd.Parameters.AddWithValue("@assetTypeId", assetType.AssetTypeId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (rowsAffected > 0) ? true : false;
                    }
                }
            }

            return false;
        }
    }
}
