using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class AssetZakatPaidDataAccess : BaseDataAccess
    {
        // 🔹 Get All Asset Zakat Paid Records
        public List<AssetZakatPaid> GetAllAssetZakatPaid()
        {
            string query = "SELECT * FROM tbl_AssetZakatPaid";
            DataTable dt = ExecuteQuery(query);

            List<AssetZakatPaid> assetZakatPaidList = new List<AssetZakatPaid>();

            foreach (DataRow row in dt.Rows)
            {
                assetZakatPaidList.Add(new AssetZakatPaid
                {
                    AssetZakatPaidId = Convert.ToInt64(row["assetZakatPaidId"]),
                    AssetId = Convert.ToInt64(row["assetId"]),
                    PeriodFrom = Convert.ToDateTime(row["periodFrom"]),
                    PeriodTo = Convert.ToDateTime(row["periodTo"]),
                    AmountPaid = Convert.ToDecimal(row["amountPaid"]),
                    TimeStamp = Convert.ToDateTime(row["timeStamp"]),
                    IsActive = Convert.ToBoolean(row["isActive"])
                });
            }

            return assetZakatPaidList;
        }

        // 🔹 Get Asset Zakat Paid By ID
        public AssetZakatPaid GetAssetZakatPaidById(long id)
        {
            string query = "SELECT * FROM tbl_AssetZakatPaid WHERE assetZakatPaidId = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new AssetZakatPaid
                {
                    AssetZakatPaidId = Convert.ToInt64(row["assetZakatPaidId"]),
                    AssetId = Convert.ToInt64(row["assetId"]),
                    PeriodFrom = Convert.ToDateTime(row["periodFrom"]),
                    PeriodTo = Convert.ToDateTime(row["periodTo"]),
                    AmountPaid = Convert.ToInt64(row["amountPaid"]),
                    TimeStamp = Convert.ToDateTime(row["timeStamp"]),
                    IsActive = Convert.ToBoolean(row["isActive"])
                };
            }
            return null;
        }

        // 🔹 Insert New Asset Zakat Paid Record
        public bool InsertAssetZakatPaid(AssetZakatPaid assetZakatPaid)
        {
            string query = @"
                INSERT INTO tbl_AssetZakatPaid (assetId, periodFrom, periodTo, amountPaid, timeStamp, isActive)
                VALUES (@assetId, @periodFrom, @periodTo, @amountPaid, @timeStamp, @isActive)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@assetId", assetZakatPaid.AssetId),
                new SqlParameter("@periodFrom", assetZakatPaid.PeriodFrom),
                new SqlParameter("@periodTo", assetZakatPaid.PeriodTo),
                new SqlParameter("@amountPaid", assetZakatPaid.AmountPaid),
                new SqlParameter("@timeStamp", assetZakatPaid.TimeStamp),
                new SqlParameter("@isActive", assetZakatPaid.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 🔹 Update Asset Zakat Paid Record
        public bool UpdateAssetZakatPaid(AssetZakatPaid assetZakatPaid)
        {
            string query = @"
                UPDATE tbl_AssetZakatPaid 
                SET assetId = @assetId, 
                    periodFrom = @periodFrom, 
                    periodTo = @periodTo, 
                    amountPaid = @amountPaid, 
                    timeStamp = @timeStamp, 
                    isActive = @isActive
                WHERE assetZakatPaidId = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", assetZakatPaid.AssetZakatPaidId),
                new SqlParameter("@assetId", assetZakatPaid.AssetId),
                new SqlParameter("@periodFrom", assetZakatPaid.PeriodFrom),
                new SqlParameter("@periodTo", assetZakatPaid.PeriodTo),
                new SqlParameter("@amountPaid", assetZakatPaid.AmountPaid),
                new SqlParameter("@timeStamp", assetZakatPaid.TimeStamp),
                new SqlParameter("@isActive", assetZakatPaid.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 🔹 Delete Asset Zakat Paid Record
        public bool DeleteAssetZakatPaid(long id)
        {
            string query = "DELETE FROM tbl_AssetZakatPaid WHERE assetZakatPaidId = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
