using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.DataAccess.Wrapper
{
    public class ManagerUserPictureCreateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            int pUserID,
            byte[] pUserPic,
            out int? pUserPicId)
        {
            int recordsAffected;

            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spManagerUserPictureInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******      UserPicID     *******
                //output parameter is always first!
                p = new SqlParameter("@pUserPicID", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                //Direction指定参数p是输入还是输出或双向还是存储过程返回类型
                //ParameterDirection是指定参数的类型
                cmd.Parameters.Add(p);
                //给Parmeters集合添加参数

                //*******     UserID     *******
                object val = pUserID;

                p = new SqlParameter("@pUserID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserSort     *******
                if (pUserPic == null)
                    val = DBNull.Value;
                else
                    val = pUserPic;

                p = new SqlParameter("@pUserPic", SqlDbType.Image);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                recordsAffected = cmd.ExecuteNonQuery();
                //cmd.ExecuteNonQuery()是一个执行语句，把值传给recordsAffected
                val = cmd.Parameters["@pUserPicID"].Value;
                pUserPicId = (int)val;

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return recordsAffected;
        }
    }


    public class ManagerUserPictureSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            QueryManagerUserPicture pQueryManagerUserPicture)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "spManagerUserPictureSelect";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     UserPicID     *******
                object val;
                if (pQueryManagerUserPicture.UserPicID == null)
                    val = DBNull.Value;
                else
                    val = pQueryManagerUserPicture.UserPicID;

                p = new SqlParameter("@pUserPicID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     UserID     *******
                if (pQueryManagerUserPicture.UserID == null)
                    val = DBNull.Value;
                else
                    val = pQueryManagerUserPicture.UserID;

                p = new SqlParameter("@pUserID", SqlDbType.Int);
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

}
