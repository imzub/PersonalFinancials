using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class ZakatHistoryDataAccess : BaseDataAccess
    {
        // 🔹 Insert Zakat History Record
        public bool InsertZakatHistory(ZakatHistory zakatHistory)
        {
            string query = @"
                INSERT INTO tbl_ZakatHistory (assetId, assetOldValue, assetNewValue, assetHistoryTimeStamp) 
                VALUES (@assetId, @oldValue, @newValue, @timeStamp)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@assetId", zakatHistory.AssetId),
                new SqlParameter("@oldValue", zakatHistory.AssetOldValue),
                new SqlParameter("@newValue", zakatHistory.AssetNewValue),
                new SqlParameter("@timeStamp", zakatHistory.AssetHistoryTimeStamp)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 🔹 Get All Zakat History Records
        public List<ZakatHistory> GetAllZakatHistory()
        {
            string query = "SELECT * FROM tbl_ZakatHistory";
            DataTable dt = ExecuteQuery(query);

            List<ZakatHistory> zakatHistories = new List<ZakatHistory>();

            foreach (DataRow row in dt.Rows)
            {
                zakatHistories.Add(new ZakatHistory
                {
                    ZakatHistoryId = Convert.ToInt64(row["zakatHistoryId"]),
                    AssetId = Convert.ToInt64(row["assetId"]),
                    AssetOldValue = Convert.ToDecimal(row["assetOldValue"]),
                    AssetNewValue = Convert.ToDecimal(row["assetNewValue"]),
                    AssetHistoryTimeStamp = Convert.ToDateTime(row["assetHistoryTimeStamp"])
                });
            }

            return zakatHistories;
        }

        // 🔹 Get Zakat History By Asset ID
        public List<ZakatHistory> GetZakatHistoryByAssetId(long assetId)
        {
            string query = "SELECT * FROM tbl_ZakatHistory WHERE assetId = @assetId";
            SqlParameter[] parameters = { new SqlParameter("@assetId", assetId) };

            DataTable dt = ExecuteQuery(query, parameters);

            List<ZakatHistory> zakatHistories = new List<ZakatHistory>();

            foreach (DataRow row in dt.Rows)
            {
                zakatHistories.Add(new ZakatHistory
                {
                    ZakatHistoryId = Convert.ToInt64(row["zakatHistoryId"]),
                    AssetId = Convert.ToInt64(row["assetId"]),
                    AssetOldValue = Convert.ToDecimal(row["assetOldValue"]),
                    AssetNewValue = Convert.ToDecimal(row["assetNewValue"]),
                    AssetHistoryTimeStamp = Convert.ToDateTime(row["assetHistoryTimeStamp"])
                });
            }

            return zakatHistories;
        }

        // 🔹 Delete Zakat History Record
        public bool DeleteZakatHistory(long zakatHistoryId)
        {
            string query = "DELETE FROM tbl_ZakatHistory WHERE zakatHistoryId = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", zakatHistoryId) };

            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
