using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class AssetZakatFinYearDataAccess : BaseDataAccess
    {
        AssetZakatFinYear _assetZakatFinYear;
        // 🔹 Get All Asset Zakat Financial Years
        public List<AssetZakatFinYear> GetAllAssetZakatFinYears()
        {
            string query = "SELECT az.*, a.assetName FROM tbl_AssetZakatFinYear az\r\n  INNER JOIN tbl_Assets a on az.assetId = a.assetId";
            DataTable dt = ExecuteQuery(query);

            List<AssetZakatFinYear> assetZakatFinYears = new List<AssetZakatFinYear>();
            foreach (DataRow row in dt.Rows)
            {
                assetZakatFinYears.Add(new AssetZakatFinYear
                {
                    AssetZakatFinYearId = Convert.ToInt64(row["assetZakatFinYearId"]),
                    AssetId = Convert.ToInt64(row["assetId"]),
                    AssetZakatFinYearStartDate = Convert.ToDateTime(row["assetZakatFinYearStartDate"]),
                    AssetZakatFinYearEndDate = Convert.ToDateTime(row["assetZakatFinYearEndDate"]),
                    IsAssetZakatFinYearActive = Convert.ToBoolean(row["isAssetZakatFinYearActive"]),
                    AssetName = Convert.ToString(row["assetName"])
                });
            }
            return assetZakatFinYears;
        }

        // 🔹 Get Asset Zakat Financial Year By ID
        public AssetZakatFinYear GetAssetZakatFinYearById(long id)
        {
            string query = "SELECT * FROM tbl_AssetZakatFinYear WHERE assetZakatFinYearId = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new AssetZakatFinYear
                {
                    AssetZakatFinYearId = Convert.ToInt64(row["assetZakatFinYearId"]),
                    AssetId = Convert.ToInt64(row["assetId"]),
                    AssetZakatFinYearStartDate = Convert.ToDateTime(row["assetZakatFinYearStartDate"]),
                    AssetZakatFinYearEndDate = Convert.ToDateTime(row["assetZakatFinYearEndDate"]),
                    IsAssetZakatFinYearActive = Convert.ToBoolean(row["isAssetZakatFinYearActive"])
                };
            }
            return null;
        }

        // 🔹 Insert New Asset Zakat Financial Year
        public bool InsertAssetZakatFinYear(AssetZakatFinYear assetZakatFinYear)
        {
            string query = @"
                INSERT INTO tbl_AssetZakatFinYear (assetId, assetZakatFinYearStartDate, assetZakatFinYearEndDate, isAssetZakatFinYearActive)
                VALUES (@assetId, @startDate, @endDate, @isActive)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@assetId", assetZakatFinYear.AssetId),
                new SqlParameter("@startDate", assetZakatFinYear.AssetZakatFinYearStartDate),
                new SqlParameter("@endDate", assetZakatFinYear.AssetZakatFinYearEndDate),
                new SqlParameter("@isActive", assetZakatFinYear.IsAssetZakatFinYearActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 🔹 Update Asset Zakat Financial Year
        public bool UpdateAssetZakatFinYear(AssetZakatFinYear assetZakatFinYear)
        {
            string query = @"
                UPDATE tbl_AssetZakatFinYear 
                SET assetId = @assetId, 
                    assetZakatFinYearStartDate = @startDate, 
                    assetZakatFinYearEndDate = @endDate, 
                    isAssetZakatFinYearActive = @isActive
                WHERE assetZakatFinYearId = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", assetZakatFinYear.AssetZakatFinYearId),
                new SqlParameter("@assetId", assetZakatFinYear.AssetId),
                new SqlParameter("@startDate", assetZakatFinYear.AssetZakatFinYearStartDate),
                new SqlParameter("@endDate", assetZakatFinYear.AssetZakatFinYearEndDate),
                new SqlParameter("@isActive", assetZakatFinYear.IsAssetZakatFinYearActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
        public bool UpdateAssetZakatFinYearDates(AssetZakatFinYear assetZakatFinYear, SqlTransaction transaction)
        {
            string query = @"
                UPDATE tbl_AssetZakatFinYear 
                SET assetZakatFinYearStartDate = @startDate, 
                    assetZakatFinYearEndDate = @endDate                    
                WHERE assetZakatFinYearId = @assetZakatFinYearId and assetId = @assetId";

            SqlParameter[] parameters =
            {
                new SqlParameter("@assetZakatFinYearId", assetZakatFinYear.AssetZakatFinYearId),
                new SqlParameter("@assetId", assetZakatFinYear.AssetId),
                new SqlParameter("@startDate", assetZakatFinYear.AssetZakatFinYearStartDate),
                new SqlParameter("@endDate", assetZakatFinYear.AssetZakatFinYearEndDate)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool CalculateAndUpdateAssetZakatDates(int assetZakatFinYearId, SqlTransaction transaction)
        {
            _assetZakatFinYear = new AssetZakatFinYear();
            _assetZakatFinYear = GetAssetZakatFinYearById(assetZakatFinYearId);

            //set new dates for same asset for next year zakat calculation.
            _assetZakatFinYear.AssetZakatFinYearStartDate = _assetZakatFinYear.AssetZakatFinYearEndDate.AddDays(1);
            _assetZakatFinYear.AssetZakatFinYearEndDate = _assetZakatFinYear.AssetZakatFinYearStartDate.AddDays(354);

            return UpdateAssetZakatFinYearDates(_assetZakatFinYear, transaction);
        }

        // 🔹 Delete Asset Zakat Financial Year By ID
        public bool DeleteAssetZakatFinYear(long id)
        {
            string query = "DELETE FROM tbl_AssetZakatFinYear WHERE assetZakatFinYearId = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public List<KeyValuePair<long, string>> GetAssetListForComboBox()
        {
            string query = "GetAssetListForZakatFinYear"; // Stored Procedure Name
            SqlParameter[] parameters = null; // No parameters required

            DataTable dt = ExecuteQuery(query, parameters); // Call ExecuteQuery method

            List<KeyValuePair<long, string>> assetList = new List<KeyValuePair<long, string>>();

            foreach (DataRow row in dt.Rows)
            {
                assetList.Add(new KeyValuePair<long, string>(
                    Convert.ToInt64(row["assetId"]),
                    row["assetName"].ToString()
                ));
            }

            return assetList;
        }

        public List<KeyValuePair<long, string>> GetAssetsNotInZakatFinYear()
        {
            string query = "GetAssetsNotInZakatFinYear"; // Stored Procedure Name

            DataTable dt = ExecuteQuery(query); // Execute the stored procedure

            List<KeyValuePair<long, string>> assetList = new List<KeyValuePair<long, string>>();

            foreach (DataRow row in dt.Rows)
            {
                assetList.Add(new KeyValuePair<long, string>(
                    Convert.ToInt64(row["assetId"]),    // Asset ID
                    row["assetName"].ToString()        // Asset Name
                ));
            }

            return assetList;
        }

        public List<Asset> GetAssetsNotInZakatFinYearWithDetails()
        {
            string query = "GetAssetsNotInZakatFinYearWithDetails"; // Stored Procedure Name
            SqlParameter[] parameters = null;

            DataTable dt = ExecuteQuery(query, parameters); // Execute stored procedure

            List<Asset> assets = new List<Asset>();

            foreach (DataRow row in dt.Rows)
            {
                assets.Add(new Asset
                {
                    AssetId = Convert.ToInt64(row["assetId"]),
                    AssetBoughtDate = Convert.ToDateTime(row["assetBoughtDate"]), // Ensure 'boughtDate' exists in tbl_assets
                    AssetName = row["assetName"].ToString(),
                    ZakatApplicableFromDate = Convert.ToDateTime(row["assetZakatApplicableFromDate"])
                    // Add other required columns here
                });                                                                                                                                                                             
            }
            return assets;
        }
    }
}
