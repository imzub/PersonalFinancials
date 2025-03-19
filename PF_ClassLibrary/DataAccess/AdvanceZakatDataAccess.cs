using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;

namespace PF_ClassLibrary.DataAccess
{
    public class AdvanceZakatDataAccess : BaseDataAccess
    {
        private EventLogDataAccess eventLogger = new EventLogDataAccess();

        // Insert Advance Zakat
        public bool InsertAdvanceZakat(AdvanceZakat zakat)
        {
            string query = @"INSERT INTO tbl_AdvanceZakat 
                            (advZakatIn, advZakatOut, advZakatBalance, assetId, advZakatPaidTo, advZakatPaidDate, 
                             isAdvZakatPaid, isActive, comments, timestamp) 
                            VALUES (@AdvZakatIn, @AdvZakatOut, @AdvZakatBalance, @AssetId, @AdvZakatPaidTo, 
                                    @AdvZakatPaidDate, @IsAdvZakatPaid, @IsActive, @Comments, @Timestamp)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@AdvZakatIn", zakat.AdvZakatIn),
                new SqlParameter("@AdvZakatOut", zakat.AdvZakatOut),
                new SqlParameter("@AdvZakatBalance", zakat.AdvZakatBalance),
                new SqlParameter("@AssetId", zakat.AssetId ?? (object)DBNull.Value),
                new SqlParameter("@AdvZakatPaidTo", (object)zakat.AdvZakatPaidTo ?? DBNull.Value),
                new SqlParameter("@AdvZakatPaidDate", zakat.AdvZakatPaidDate),
                new SqlParameter("@IsAdvZakatPaid", zakat.IsAdvZakatPaid),
                new SqlParameter("@IsActive", zakat.IsActive),
                new SqlParameter("@Comments", (object)zakat.Comments ?? DBNull.Value),
                new SqlParameter("@Timestamp", (object)zakat.Timestamp ?? DBNull.Value)
            };

            bool result = ExecuteNonQuery(query, parameters) > 0;

            if (result)
            {
                eventLogger.LogEvent(new EventLogModel
                {
                    EventType = "Insert",
                    EventMessage = "Advance Zakat inserted successfully.",
                    EventSource = "AdvanceZakatDataAccess",
                    UserName = "System"
                });
            }

            return result;
        }

        // Update Advance Zakat
        public bool UpdateAdvanceZakat(AdvanceZakat zakat)
        {
            string query = @"UPDATE tbl_AdvanceZakat 
                             SET advZakatIn = @AdvZakatIn, advZakatOut = @AdvZakatOut, advZakatBalance = @AdvZakatBalance,
                                 assetId = @AssetId, advZakatPaidTo = @AdvZakatPaidTo, advZakatPaidDate = @AdvZakatPaidDate,
                                 isAdvZakatPaid = @IsAdvZakatPaid, isActive = @IsActive, comments = @Comments, timestamp = @Timestamp
                             WHERE advZakatId = @AdvZakatId";

            SqlParameter[] parameters =
            {
                new SqlParameter("@AdvZakatId", zakat.AdvZakatId),
                new SqlParameter("@AdvZakatIn", zakat.AdvZakatIn),
                new SqlParameter("@AdvZakatOut", zakat.AdvZakatOut),
                new SqlParameter("@AdvZakatBalance", zakat.AdvZakatBalance),
                new SqlParameter("@AssetId", zakat.AssetId ?? (object)DBNull.Value),
                new SqlParameter("@AdvZakatPaidTo", (object)zakat.AdvZakatPaidTo ?? DBNull.Value),
                new SqlParameter("@AdvZakatPaidDate", zakat.AdvZakatPaidDate),
                new SqlParameter("@IsAdvZakatPaid", zakat.IsAdvZakatPaid),
                new SqlParameter("@IsActive", zakat.IsActive),
                new SqlParameter("@Comments", (object)zakat.Comments ?? DBNull.Value),
                new SqlParameter("@Timestamp", (object)zakat.Timestamp ?? DBNull.Value)
            };

            bool result = ExecuteNonQuery(query, parameters) > 0;

            if (result)
            {
                eventLogger.LogEvent(new EventLogModel
                {
                    EventType = "Update",
                    EventMessage = "Advance Zakat updated successfully.",
                    EventSource = "AdvanceZakatDataAccess",
                    UserName = "System"
                });
            }

            return result;
        }

        // Delete Advance Zakat
        public bool DeleteAdvanceZakat(long advZakatId)
        {
            string query = "DELETE FROM tbl_AdvanceZakat WHERE advZakatId = @AdvZakatId";

            SqlParameter[] parameters =
            {
                new SqlParameter("@AdvZakatId", advZakatId)
            };

            bool result = ExecuteNonQuery(query, parameters) > 0;

            if (result)
            {
                eventLogger.LogEvent(new EventLogModel
                {
                    EventType = "Delete",
                    EventMessage = "Advance Zakat deleted successfully.",
                    EventSource = "AdvanceZakatDataAccess",
                    UserName = "System"
                });
            }

            return result;
        }

        // Get Advance Zakat by ID
        public AdvanceZakat GetAdvanceZakatById(long advZakatId)
        {
            string query = "SELECT * FROM tbl_AdvanceZakat WHERE advZakatId = @AdvZakatId";

            SqlParameter[] parameters =
            {
                new SqlParameter("@AdvZakatId", advZakatId)
            };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return ConvertToAdvanceZakat(dt.Rows[0]);
            }

            return null;
        }

        // Get All Advance Zakat
        public List<AdvanceZakat> GetAllAdvanceZakat()
        {
            string query = "SELECT * FROM tbl_AdvanceZakat";
            DataTable dt = ExecuteQuery(query);

            List<AdvanceZakat> zakatList = new List<AdvanceZakat>();
            foreach (DataRow row in dt.Rows)
            {
                zakatList.Add(ConvertToAdvanceZakat(row));
            }

            return zakatList;
        }

        // Convert DataRow to AdvanceZakat Model
        private AdvanceZakat ConvertToAdvanceZakat(DataRow row)
        {
            return new AdvanceZakat
            {
                AdvZakatId = Convert.ToInt64(row["advZakatId"]),
                AdvZakatIn = Convert.ToDecimal(row["advZakatIn"]),
                AdvZakatOut = Convert.ToDecimal(row["advZakatOut"]),
                AdvZakatBalance = Convert.ToDecimal(row["advZakatBalance"]),
                AssetId = row["assetId"] != DBNull.Value ? Convert.ToInt64(row["assetId"]) : (long?)null,
                AdvZakatPaidTo = row["advZakatPaidTo"] != DBNull.Value ? row["advZakatPaidTo"].ToString() : null,
                AdvZakatPaidDate = Convert.ToDateTime(row["advZakatPaidDate"]),
                IsAdvZakatPaid = Convert.ToBoolean(row["isAdvZakatPaid"]),
                IsActive = Convert.ToBoolean(row["isActive"]),
                Comments = row["comments"] != DBNull.Value ? row["comments"].ToString() : null,
                Timestamp = row["timestamp"] != DBNull.Value ? Convert.ToDateTime(row["timestamp"]) : (DateTime?)null
            };
        }

        public bool PayAdvanceZakat(AdvanceZakat zakat)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 🔹 Step 1: Calculate updated Advance Zakat Balance
                    decimal updatedAdvZakatBalance = GetAdvanceZakatBalance() + zakat.AdvZakatIn;

                    // 🔹 Step 2: Insert new Advance Zakat record
                    string insertQuery = @"
                INSERT INTO tbl_AdvanceZakat 
                (advZakatIn, advZakatOut, advZakatBalance, assetId, advZakatPaidTo, advZakatPaidDate, 
                 isAdvZakatPaid, isActive, comments) 
                VALUES 
                (@AdvZakatIn, 0, @AdvZakatBalance, @AssetId, @AdvZakatPaidTo, 
                 @AdvZakatPaidDate, @IsAdvZakatPaid, @IsActive, @Comments);
                
                SELECT SCOPE_IDENTITY();"; // Get the newly inserted ID

                    SqlParameter[] insertParams =
                    {
                new SqlParameter("@AdvZakatIn", zakat.AdvZakatIn),
                new SqlParameter("@AdvZakatBalance", updatedAdvZakatBalance),
                new SqlParameter("@AssetId", zakat.AssetId ?? (object)DBNull.Value),
                new SqlParameter("@AdvZakatPaidTo", (object)zakat.AdvZakatPaidTo ?? DBNull.Value),
                new SqlParameter("@AdvZakatPaidDate", zakat.AdvZakatPaidDate),
                new SqlParameter("@IsAdvZakatPaid", true),
                new SqlParameter("@IsActive", true), // Mark new record as active
                new SqlParameter("@Comments", (object)zakat.Comments ?? DBNull.Value)
            };

                    object result = ExecuteScalar(insertQuery, insertParams, transaction);

                    if (result != null && int.TryParse(result.ToString(), out int newAdvZakatId))
                    {
                        // 🔹 Step 3: Deactivate Previous Active Records
                        string updatePreviousQuery = @"
                    UPDATE tbl_AdvanceZakat 
                    SET isActive = 0 
                    WHERE advZakatId < @NewAdvZakatId AND isActive = 1"; // Deactivate old active records

                        SqlParameter[] updateParams =
                        {
                    new SqlParameter("@NewAdvZakatId", newAdvZakatId)
                };

                        ExecuteNonQuery(updatePreviousQuery, updateParams, conn, transaction);

                        // 🔹 Step 4: Commit Transaction (Success)
                        transaction.Commit();

                        eventLogger.LogEvent(new EventLogModel
                        {
                            EventType = "Pay",
                            EventMessage = "Advance Zakat paid successfully.",
                            EventSource = "AdvanceZakatDataAccess",
                            UserName = "System"
                        });

                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback if any error occurs
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

        public decimal GetAdvanceZakatBalance()
        {
            string query = @"
                SELECT TOP 1 az.advZakatBalance 
                FROM tbl_AdvanceZakat az 
                WHERE az.isActive = 1 
                ORDER BY az.advZakatId DESC"; // Get the last entered row

            DataTable dt = ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["advZakatBalance"]);
            }

            return 0m; // Return 0 if no active record found
        }
        private ExceptionLogDataAccess logger = new ExceptionLogDataAccess();

        public bool SetoffAdvanceZakat(AdvanceZakat advanceZakat)
        {
            try
            {
                decimal currentAdvZakatBalance = GetAdvanceZakatBalance(); // Get latest balance
                decimal updatedAdvZakatBalance = currentAdvZakatBalance - advanceZakat.AdvZakatOut; // Reduce balance

                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 🔹 **Step 1: Mark Previous Active Record as Inactive**
                            string deactivateQuery = @"
                        UPDATE tbl_AdvanceZakat 
                        SET isActive = 0 
                        WHERE isActive = 1";

                            SqlCommand deactivateCmd = new SqlCommand(deactivateQuery, conn, transaction);
                            deactivateCmd.ExecuteNonQuery();

                            // 🔹 **Step 2: Insert New Setoff Record**
                            string insertQuery = @"
                        INSERT INTO tbl_AdvanceZakat 
                        (advZakatIn, advZakatOut, advZakatBalance, assetId, advZakatPaidTo, advZakatPaidDate, 
                         isAdvZakatPaid, isActive,  timestamp) 
                        VALUES 
                        (@AdvZakatIn, @AdvZakatOut, @AdvZakatBalance, @AssetId, NULL, GETDATE(), 
                         0, 1, GETDATE())";

                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);
                            insertCmd.Parameters.AddWithValue("@AdvZakatIn", 0m); // No income, only setoff
                            insertCmd.Parameters.AddWithValue("@AdvZakatOut", advanceZakat.AdvZakatOut); // Setoff amount
                            insertCmd.Parameters.AddWithValue("@AdvZakatBalance", updatedAdvZakatBalance); // New balance
                            insertCmd.Parameters.AddWithValue("@AssetId", (object)advanceZakat.AssetId ?? DBNull.Value);

                            insertCmd.ExecuteNonQuery();

                            // 🔹 **Step 3: Mark the Asset in Zakat Due Table as Inactive**
                            string updateZakatDueQuery = @"
                                UPDATE tbl_ZakatDue 
                                SET isZakatDueActive = 0 
                                WHERE zakatDueId = @zakatDueId";

                            SqlCommand updateZakatDueCmd = new SqlCommand(updateZakatDueQuery, conn, transaction);
                            updateZakatDueCmd.Parameters.AddWithValue("@zakatDueId", (object)advanceZakat.ZakatDueId ?? DBNull.Value);
                            updateZakatDueCmd.ExecuteNonQuery();

                            transaction.Commit(); // ✅ Commit Transaction

                            eventLogger.LogEvent(new EventLogModel
                            {
                                EventType = "Setoff",
                                EventMessage = "Advance Zakat setoff successfully.",
                                EventSource = "AdvanceZakatDataAccess",
                                UserName = "System"
                            });

                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // ❌ Rollback on error
                            logger.LogException(ex);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                return false;
            }
        }
    }
}
