using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class FinancialYearDataAccess : BaseDataAccess
    {
        public List<FinancialYear> GetAllFinancialYears()
        {
            string query = "SELECT * FROM tbl_FinancialYear";
            DataTable dt = ExecuteQuery(query);

            List<FinancialYear> financialYears = new List<FinancialYear>();
            foreach (DataRow row in dt.Rows)
            {
                financialYears.Add(new FinancialYear
                {
                    FinancialYearId = Convert.ToInt64(row["financialYearId"]),
                    FinancialYearName = row["financialYearName"].ToString(),
                    FinancialYearDesc = row["financialYearDesc"].ToString(),
                    FinancialYearStartDate = Convert.ToDateTime(row["financialYearStartDate"]),
                    FinancialYearEndDate = Convert.ToDateTime(row["financialYearEndDate"])
                });
            }
            return financialYears;
        }
    }
}
