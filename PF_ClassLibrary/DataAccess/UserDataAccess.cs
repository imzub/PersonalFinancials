using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PF_ClassLibrary.Model;

namespace PersonalFinancials.DataAccess
{
    public class UserDataAccess : BaseDataAccess
    {
        public void AddUser(User user)
        {
            string query = "INSERT INTO tbl_Users (userId, userName, userDOB) " +
                           "VALUES (@userId, @userName, @userDOB)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@userId", user.UserId),
                new SqlParameter("@userName", user.UserName),
                new SqlParameter("@userDOB", user.UserDOB)
            };

            ExecuteNonQuery(query, parameters);
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM tbl_Users";
            DataTable dt = ExecuteQuery(query);

            List<User> users = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt64(row["userId"]),
                    UserName = row["userName"].ToString(),
                    UserDOB = Convert.ToDateTime(row["userDOB"])
                });
            }
            return users;
        }
    }
}
