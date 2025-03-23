using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.DataAccess;
using PF_ClassLibrary.Model;
using PersonalFinancials.Models;

namespace PersonalFinancials.DataAccess
{
    public class ZakatDueDataAccess : BaseDataAccess
    {
        AssetZakatFinYearDataAccess _assetZakatFinYearDataAccess;
        AssetZakatFinYear _assetZakatFinYear;
        ExceptionLogDataAccess logger;
        EventLogDataAccess eventLogger = new EventLogDataAccess();

        public void AddZakatDue(ZakatDue zakatDue)
        {
            string query = "INSERT INTO tbl_ZakatDue (zakatDueId, assetId, DueZakat, isZakatDueActive) " +
                           "VALUES (@zakatDueId, @assetId, @DueZakat, @isZakatDueActive)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@zakatDueId", zakatDue.ZakatDueId),
                new SqlParameter("@assetId", zakatDue.AssetId),
                new SqlParameter("@DueZakat", zakatDue.DueZakat),
                new SqlParameter("@isZakatDueActive", zakatDue.IsZakatDueActive)
            };

            ExecuteNonQuery(query, parameters);

            eventLogger.LogEvent(new EventLogModel
            {
                EventType = "Insert",
                EventMessage = "Zakat Due added successfully.",
                EventSource = "ZakatDueDataAccess",
                UserName = "System"
            });
        }

        public List<ZakatDue> GetAllZakatDues()
        {
            string query = "SELECT * FROM tbl_ZakatDue";
            DataTable dt = ExecuteQuery(query);

            List<ZakatDue> zakatDues = new List<ZakatDue>();
            foreach (DataRow row in dt.Rows)
            {
                zakatDues.Add(new ZakatDue
                {
                    ZakatDueId = Convert.ToInt64(row["zakatDueId"]),
                    AssetId = Convert.ToInt64(row["assetId"]),
                    DueZakat = Convert.ToDecimal(row["DueZakat"]),
                    IsZakatDueActive = Convert.ToBoolean(row["isZakatDueActive"])
                });
            }
            return zakatDues;
        }

        public List<ZakatDue> GetActiveZakatDueAssets()
        {
            List<ZakatDue> zakatDues = new List<ZakatDue>();
            try
            {
                string query = @"
            SELECT zd.zakatDueId, zd.assetId, a.assetName, zd.dueZakat 
            FROM tbl_ZakatDue zd
            INNER JOIN tbl_Assets a ON zd.assetId = a.assetId
            WHERE zd.isZakatDueActive = 1";

                DataTable dt = ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    zakatDues.Add(new ZakatDue
                    {
                        ZakatDueId = Convert.ToInt64(row["zakatDueId"]),
                        AssetId = Convert.ToInt64(row["assetId"]),
                        AssetName = row["assetName"].ToString(), // Add AssetName
                        DueZakat = Convert.ToDecimal(row["dueZakat"]),
                        IsZakatDueActive = true
                    });
                }
            }
            catch (Exception ex)
            {
                logger = new ExceptionLogDataAccess();
                logger.LogException(ex);
            }
            return zakatDues;
        }

        public bool ProcessAndSaveZakatDue()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 🔹 Step 1: Get all expired assets
                    string query = @"SELECT 
                                    azfy.assetZakatFinYearId, 
                                    azfy.assetId, 
                                    a.assetUnits, 
                                    atype.assetTypeCurrentValuePerUnit
                                FROM tbl_AssetZakatFinYear azfy
                                INNER JOIN tbl_Assets a ON azfy.assetId = a.assetId
                                INNER JOIN tbl_AssetType atype ON a.assetTypeId = atype.assetTypeId
                                WHERE 
                                    azfy.assetZakatFinYearEndDate < GETDATE()
                                    AND a.isAssetActive = 1 
                                    AND a.isAssetZakatApplicable = 1";

                    DataTable dt = ExecuteQuery(query, conn, transaction);

                    // 🔹 Step 2: Prepare zakat due entries
                    List<ZakatDue> zakatDues = new List<ZakatDue>();
                    List<int> assetZakatFinYearIds = new List<int>();

                    foreach (DataRow row in dt.Rows)
                    {
                        assetZakatFinYearIds.Add(Convert.ToInt32(row["assetZakatFinYearId"]));
                        long assetId = Convert.ToInt64(row["assetId"]);
                        decimal assetUnits = Convert.ToDecimal(row["assetUnits"]);
                        decimal currentValuePerUnit = Convert.ToDecimal(row["assetTypeCurrentValuePerUnit"]);

                        // 🔹 Step 3: Calculate Zakat Amount
                        decimal zakatAmount = (assetUnits * currentValuePerUnit) * 0.025m;

                        // 🔹 Step 4: Create ZakatDue entry
                        zakatDues.Add(new ZakatDue
                        {
                            AssetId = assetId,
                            DueZakat = zakatAmount,
                            IsZakatDueActive = true
                        });
                    }

                    // 🔹 Step 5: Batch Insert Zakat Due Entries
                    if (zakatDues.Count > 0)
                    {
                        string insertQuery = @"
                    INSERT INTO tbl_ZakatDue (assetId, DueZakat, isZakatDueActive)
                    VALUES (@assetId, @zakatAmount, @isPaid)";

                        foreach (var zakat in zakatDues)
                        {
                            SqlParameter[] parameters =
                            {
                        new SqlParameter("@assetId", zakat.AssetId),
                        new SqlParameter("@zakatAmount", zakat.DueZakat),
                        new SqlParameter("@isPaid", zakat.IsZakatDueActive)
                    };

                            ExecuteNonQuery(insertQuery, parameters, conn, transaction);
                        }
                    }

                    // 🔹 Step 6: Update financial year records for assets
                    _assetZakatFinYearDataAccess = new AssetZakatFinYearDataAccess();
                    foreach (var assetZakatFinYearId in assetZakatFinYearIds)
                    {
                        _assetZakatFinYearDataAccess.CalculateAndUpdateAssetZakatDates(assetZakatFinYearId, transaction);
                    }

                    // 🔹 Step 7: Commit Transaction if everything is successful
                    transaction.Commit();

                    eventLogger.LogEvent(new EventLogModel
                    {
                        EventType = "Process",
                        EventMessage = "Zakat Due processed and saved successfully.",
                        EventSource = "ZakatDueDataAccess",
                        UserName = "System"
                    });

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback if anything fails
                    logger = new ExceptionLogDataAccess();
                    logger.LogException(ex);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        // 🔹 Get Active Assets for Zakat (For ComboBox)
        public List<KeyValuePair<long, string>> GetActiveZakatAssets()
        {
            string query = @"
                SELECT zd.assetId, a.assetName 
                FROM tbl_ZakatDue zd
                INNER JOIN tbl_Assets a ON zd.assetId = a.assetId
                WHERE zd.isZakatDueActive = 1";

            DataTable dt = ExecuteQuery(query);
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

        // 🔹 Get Due Zakat Amount for Selected Asset
        public decimal GetDueZakatAmount(long assetId)
        {
            string query = "SELECT DueZakat FROM tbl_ZakatDue WHERE assetId = @assetId";
            SqlParameter[] parameters = { new SqlParameter("@assetId", assetId) };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["DueZakat"]);
            }

            return 0; // Return 0 if no data found
        }

        public List<ZakatDue> SearchZakatDue(long? assetId = null, string assetName = null, string userName = null, bool? isZakatDueActive = null)
        {
            List<ZakatDue> zakatDues = new List<ZakatDue>();

            try
            {
                using (SqlConnection conn = GetConnection()) // 🔹 Using BaseDataAccess Connection
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchZakatDue", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters with NULL handling
                        cmd.Parameters.AddWithValue("@AssetId", (object)assetId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@AssetName", (object)assetName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@UserName", (object)userName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsZakatDueActive", (object)isZakatDueActive ?? DBNull.Value); // 🔹 Corrected

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                zakatDues.Add(new ZakatDue
                                {
                                    ZakatDueId = Convert.ToInt64(reader["zakatDueId"]),
                                    AssetId = Convert.ToInt64(reader["assetId"]),
                                    AssetName = reader["assetName"].ToString(),
                                    UserName = reader["userName"].ToString(),
                                    DueZakat = Convert.ToDecimal(reader["dueZakat"]),
                                    IsZakatDueActive = Convert.ToBoolean(reader["isZakatDueActive"]) // 🔹 Fixed here
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger = new ExceptionLogDataAccess();
                logger.LogException(ex);
            }

            return zakatDues;
        }

    }
}
