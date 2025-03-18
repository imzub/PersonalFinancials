using PF_ClassLibrary.Model;
using System.Data;
using System.Data.SqlClient;

namespace PF_ClassLibrary.Services
{
    public class Calculations
    {
        public ZakatSummary GetZakatSummary()
        {
            ZakatSummary zakatSummary = new ZakatSummary();

            using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetZakatSummary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If data exists
                        {
                            zakatSummary.TotalActiveDueZakat = reader.GetDecimal(0);
                            zakatSummary.BalanceZakat = reader.GetDecimal(1);
                        }
                    }
                }
            }
            return zakatSummary;
        }
    }
}
