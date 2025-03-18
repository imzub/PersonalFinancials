using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class YearTypeDataAccess : BaseDataAccess
    {
        public List<YearType> GetAllYearTypes()
        {
            string query = "SELECT * FROM tbl_YearType";
            DataTable dt = ExecuteQuery(query);

            List<YearType> yearTypes = new List<YearType>();
            foreach (DataRow row in dt.Rows)
            {
                yearTypes.Add(new YearType
                {
                    YearTypeId = Convert.ToInt64(row["yearTypeId"]),
                    YearTypeName = row["yearTypeName"].ToString(),
                    YearTypeDesc = row["yearTypeDesc"].ToString(),
                    YearTypeDays = Convert.ToInt32(row["yearTypeDays"])
                });
            }
            return yearTypes;
        }
    }
}
