using System;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.DataAccess;
using PF_ClassLibrary.Model;

namespace PF_ClassLibrary.Common
{
    public static class ZakatHistoryLogger
    {
        private static readonly ZakatHistoryDataAccess _zakatHistoryDataAccess = new ZakatHistoryDataAccess();

        /// <summary>
        /// Logs Zakat history when any CRUD operation is performed on zakat-related assets.
        /// </summary>
        /// <param name="assetId">The asset ID being modified.</param>
        /// <param name="oldValue">Previous asset value before modification.</param>
        /// <param name="newValue">New asset value after modification.</param>
        public static void LogZakatHistory(long assetId, decimal oldValue, decimal newValue)
        {
            try
            {
                ZakatHistory zakatHistory = new ZakatHistory
                {
                    AssetId = assetId,
                    AssetOldValue = oldValue,
                    AssetNewValue = newValue,
                    AssetHistoryTimeStamp = DateTime.Now
                };

                _zakatHistoryDataAccess.InsertZakatHistory(zakatHistory);
            }
            catch (Exception ex)
            {
                ExceptionLogDataAccess logger = new ExceptionLogDataAccess();
                logger.LogException(ex);
                // Handle logging errors (Consider logging errors into an error log file or database)
                Console.WriteLine($"Error logging Zakat history: {ex.Message}");
            }
        }
    }
}
