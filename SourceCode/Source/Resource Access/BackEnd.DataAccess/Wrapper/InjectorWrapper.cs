using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.DataAccess.Wrapper
{
    public class InjectorCreateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            string pInjectorName,
            string pInjectorSex,
            string pInjectorPhone,
            int? pInjectorNumber,
            DateTime? pInjectorTime,
            out int? pInjectorId)
        {
            int recordsAffected;

            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spInjectorInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******      InjectorId     *******
                //output parameter is always first!
                p = new SqlParameter("@pInjectorID", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                //Direction指定参数p是输入还是输出或双向还是存储过程返回类型
                //ParameterDirection是指定参数的类型
                cmd.Parameters.Add(p);
                //给Parmeters集合添加参数

                //*******     InjectorName     *******
                object val = pInjectorName;

                p = new SqlParameter("@pInjectorName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorSex     *******
                if (pInjectorSex == null || pInjectorSex == "")
                    val = DBNull.Value;
                else
                    val = pInjectorSex;

                p = new SqlParameter("@pInjectorSex", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorPhone     *******
                if (pInjectorPhone == null || pInjectorPhone == "")
                    val = DBNull.Value;
                else
                    val = pInjectorPhone;

                p = new SqlParameter("@pInjectorPhone", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorNumber     *******
                if (pInjectorNumber == null)
                    val = DBNull.Value;
                else
                    val = pInjectorNumber;

                p = new SqlParameter("@pInjectorNumber", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorTime     *******
                if (pInjectorTime == null)
                    val = DBNull.Value;
                else
                    val = pInjectorTime;

                p = new SqlParameter("@pInjectorTime", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);



                recordsAffected = cmd.ExecuteNonQuery();
                //cmd.ExecuteNonQuery()是一个执行语句，把值传给recordsAffected
                val = cmd.Parameters["@pInjectorID"].Value;
                pInjectorId = (int)val;

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return recordsAffected;
        }
    }

    public class InjectorByInjectorIdSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            int pInjectorID)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spInjectorSelectByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                object val = pInjectorID;
                SqlParameter p = new SqlParameter("@pInjectorID", val);
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

    public class InjectorSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            QueryInjector pQueryInjector)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "spInjectorSelect";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     InjectorID     *******
                object val;
                if (pQueryInjector.InjectorID == null)
                    val = DBNull.Value;
                else
                    val = pQueryInjector.InjectorID;

                p = new SqlParameter("@pInjectorID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorName     *******
                if (pQueryInjector.InjectorName == null
                     || pQueryInjector.InjectorName == "")
                    val = DBNull.Value;
                else
                    val = pQueryInjector.InjectorName;

                p = new SqlParameter("@pInjectorName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorSex     *******
                if (pQueryInjector.InjectorSex == null
                    || pQueryInjector.InjectorSex == "")
                    val = DBNull.Value;
                else
                    val = pQueryInjector.InjectorSex;

                p = new SqlParameter("@pInjectorSex", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorPhone     *******
                if (pQueryInjector.InjectorPhone == null
                    || pQueryInjector.InjectorPhone == "")
                    val = DBNull.Value;
                else
                    val = pQueryInjector.InjectorPhone;

                p = new SqlParameter("@pInjectorPhone", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorNumber     *******
                if (pQueryInjector.InjectorNumber == null)
                    val = DBNull.Value;
                else
                    val = pQueryInjector.InjectorNumber;

                p = new SqlParameter("@pInjectorNumber", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorTime     *******
                if (pQueryInjector.InjectorTime == null)
                    val = DBNull.Value;
                else
                    val = pQueryInjector.InjectorTime;

                p = new SqlParameter("@pInjectorTime", SqlDbType.DateTime);
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

    public class InjectorByInjectorIdUpdateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            int pInjectorId,
            string pInjectorName,
            string pInjectorSex,
            string pInjectorPhone,
            int? pInjectorNumber,
            DateTime? pInjectorTime)
        {
            int recordsAffected;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spInjectorUpdateByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     InjectorID     *******
                object val = pInjectorId;

                p = new SqlParameter("@pInjectorID", SqlDbType.Int);

                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorName     *******
                val = pInjectorName;

                p = new SqlParameter("@pInjectorName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorSex     *******
                if (pInjectorSex == null || pInjectorSex == "")
                    val = DBNull.Value;
                else
                    val = pInjectorSex;

                p = new SqlParameter("@pInjectorSex", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorPhone     *******
                if (pInjectorPhone == null || pInjectorPhone == "")
                    val = DBNull.Value;
                else
                    val = pInjectorPhone;

                p = new SqlParameter("@pInjectorPhone", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorNumber     *******
                if (pInjectorNumber == null)
                    val = DBNull.Value;
                else
                    val = pInjectorNumber;

                p = new SqlParameter("@pInjectorNumber", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorTime     *******
                if (pInjectorTime == null)
                    val = DBNull.Value;
                else
                    val = pInjectorTime;

                p = new SqlParameter("@pInjectorTime", SqlDbType.DateTime);
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