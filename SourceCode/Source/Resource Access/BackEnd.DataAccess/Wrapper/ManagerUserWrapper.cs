using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.DataAccess.Wrapper
{
    public class ManagerUserCreateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            string pUserName,
            string pUserPassword,
            string pUserSort,
            out int? pUserId)
        {
            int recordsAffected;

            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spManagerUserInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******      UserId     *******
                //output parameter is always first!
                p = new SqlParameter("@pUserID", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                //Direction指定参数p是输入还是输出或双向还是存储过程返回类型
                //ParameterDirection是指定参数的类型
                cmd.Parameters.Add(p);
                //给Parmeters集合添加参数

                //*******     UserName     *******
                object val = pUserName;

                p = new SqlParameter("@pUserName", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserPassword     *******
                val = pUserPassword;

                p = new SqlParameter("@pUserPassword", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserSort     *******
                if (pUserSort == null || pUserSort == "")
                    val = DBNull.Value;
                else
                    val = pUserSort;

                p = new SqlParameter("@pUserSort", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                recordsAffected = cmd.ExecuteNonQuery();
                //cmd.ExecuteNonQuery()是一个执行语句，把值传给recordsAffected
                val = cmd.Parameters["@pUserID"].Value;
                pUserId = (int)val;

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return recordsAffected;
        }
    }

    public class ManagerUserByUserIdSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            int pUserID)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spManagerUserSelectByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                object val = pUserID;
                SqlParameter p = new SqlParameter("@pUserID", val);
                cmd.Parameters.Add(p);

                reader = cmd.ExecuteReader();
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return reader;
        }
    }

    public class ManagerUserSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            QueryManagerUser pQueryManagerUser)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "spManagerUserSelect";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     UseerID     *******
                object val;
                if (pQueryManagerUser.UserID == null)
                    val = DBNull.Value;
                else
                    val = pQueryManagerUser.UserID;

                p = new SqlParameter("@pUserID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserName     *******
                if (pQueryManagerUser.UserName == null
                     || pQueryManagerUser.UserName == "")
                    val = DBNull.Value;
                else
                    val = pQueryManagerUser.UserName;

                p = new SqlParameter("@pUserName", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                ////*******     UserPassword     *******
                //if (pQueryManagerUser.UserPassword == null
                //    || pQueryManagerUser.UserPassword == "")
                //    val = DBNull.Value;
                //else
                //    val = pQueryManagerUser.UserPassword;

                //p = new SqlParameter("@pUserPassword", SqlDbType.VarChar, 50);
                //p.Direction = ParameterDirection.Input;
                //p.Value = val;
                //cmd.Parameters.Add(p);


                //*******     UserSort     *******
                if (pQueryManagerUser.UserSort == null
                    || pQueryManagerUser.UserSort == "")
                    val = DBNull.Value;
                else
                    val = pQueryManagerUser.UserSort;

                p = new SqlParameter("@pUserSort", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                reader = cmd.ExecuteReader();
            }

            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return reader;
        }
    }

    public class ManagerUserByUserIdUpdateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            int pUserId,
            string pUserName,
            string pUserPassword,
            string pUserSort)
        {
            int recordsAffected;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spManagerUserUpdateByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     UserId     *******
                object val = pUserId;

                p = new SqlParameter("@pUserID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserName     *******
                val = pUserName;

                p = new SqlParameter("@pUserName", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserPassword     *******
                val = pUserPassword;

                p = new SqlParameter("@pUserPassword", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserSort     *******
                if (pUserSort == null || pUserSort == "")
                    val = DBNull.Value;
                else
                    val = pUserSort;

                p = new SqlParameter("@pUserSort", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                recordsAffected = cmd.ExecuteNonQuery();

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return recordsAffected;
        }
    }

}
