using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.DataAccess;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class ZakatPaidDataAccess : BaseDataAccess
    {
        public bool InsertOrUpdateZakatPaid(ZakatPaid zakatPaid)
        {
            string query;
            SqlParameter[] parameters;

            if (zakatPaid.ZakatPaidId > 0) // Update existing record
            {
                query = @"UPDATE tbl_ZakatPaid 
                  SET assetId = @assetId, zakatPaidTo = @zakatPaidTo, zakatPaidAmount = @zakatPaidAmount, 
                      zakatPaidDate = @zakatPaidDate, isZakatDueUpdated = @isZakatDueUpdated
                  WHERE zakatPaidId = @zakatPaidId";

                parameters = new SqlParameter[]
                {
            new SqlParameter("@zakatPaidId", zakatPaid.ZakatPaidId),
            new SqlParameter("@assetId", zakatPaid.AssetId),
            new SqlParameter("@zakatPaidTo", zakatPaid.ZakatPaidTo),
            new SqlParameter("@zakatPaidAmount", zakatPaid.ZakatPaidAmount),
            new SqlParameter("@zakatPaidDate", zakatPaid.ZakatPaidDate),
            new SqlParameter("@isZakatDueUpdated", zakatPaid.IsZakatDueUpdated)
                };
            }
            else // Insert new record
            {
                query = @"INSERT INTO tbl_ZakatPaid (assetId, zakatPaidTo, zakatPaidAmount, zakatPaidDate, isZakatDueUpdated) 
                  VALUES (@assetId, @zakatPaidTo, @zakatPaidAmount, @zakatPaidDate, @isZakatDueUpdated)";

                parameters = new SqlParameter[]
                {
            new SqlParameter("@assetId", zakatPaid.AssetId),
            new SqlParameter("@zakatPaidTo", zakatPaid.ZakatPaidTo),
            new SqlParameter("@zakatPaidAmount", zakatPaid.ZakatPaidAmount),
            new SqlParameter("@zakatPaidDate", zakatPaid.ZakatPaidDate),
            new SqlParameter("@isZakatDueUpdated", zakatPaid.IsZakatDueUpdated)
                };
            }

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable GetAllZakatPaidRecords()
        {
            try
            {
                string query = @"SELECT zp.zakatPaidId, zp.assetId, a.assetName, zp.zakatPaidTo, zp.zakatPaidAmount, 
                                        zp.zakatPaidDate, zp.isZakatDueUpdated
                                 FROM tbl_ZakatPaid zp
                                 INNER JOIN tbl_Assets a ON zp.assetId = a.assetId";

                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching Zakat Paid records: " + ex.Message);
            }
        }

        public ZakatPaid GetZakatPaidById(long zakatPaidId)
        {
            try
            {
                string query = @"SELECT zakatPaidId, assetId, zakatPaidTo, zakatPaidAmount, zakatPaidDate, isZakatDueUpdated 
                         FROM tbl_ZakatPaid WHERE zakatPaidId = @zakatPaidId";

                SqlParameter[] parameters = { new SqlParameter("@zakatPaidId", zakatPaidId) };

                DataTable dt = ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    return new ZakatPaid
                    {
                        ZakatPaidId = Convert.ToInt64(row["zakatPaidId"]),
                        AssetId = Convert.ToInt64(row["assetId"]),
                        ZakatPaidTo = row["zakatPaidTo"].ToString(),
                        ZakatPaidAmount = Convert.ToDecimal(row["zakatPaidAmount"]),
                        ZakatPaidDate = Convert.ToDateTime(row["zakatPaidDate"]),
                        IsZakatDueUpdated = Convert.ToBoolean(row["isZakatDueUpdated"])
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Zakat Paid details: " + ex.Message);
            }
        }
    }
}
