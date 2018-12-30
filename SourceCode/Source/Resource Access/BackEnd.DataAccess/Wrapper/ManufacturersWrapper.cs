using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.DataAccess.Wrapper
{
    public class ManufacturersCreateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            string pManufacturersName,
            string pManufacturersSite,
            string pManufacturersPhone,
            DateTime pManufacturersDom,
            DateTime pManufacturersDoe,
            out int? pManufacturersId)
        {
            int recordsAffected;

            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spManufacturersInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******      ManufacturersId     *******
                //output parameter is always first!
                p = new SqlParameter("@pManufacturersID", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                //Direction指定参数p是输入还是输出或双向还是存储过程返回类型
                //ParameterDirection是指定参数的类型
                cmd.Parameters.Add(p);
                //给Parmeters集合添加参数

                //*******     ManufacturersName     *******
                object val = pManufacturersName;

                p = new SqlParameter("@pManufacturersName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersSite     *******
                val = pManufacturersSite;

                p = new SqlParameter("@pManufacturersSite", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersPhone     *******
                if (pManufacturersPhone == null || pManufacturersPhone == "")
                    val = DBNull.Value;
                else
                    val = pManufacturersPhone;

                p = new SqlParameter("@pManufacturersPhone", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersDom     *******
                if (pManufacturersDom == null)
                    val = DBNull.Value;
                else
                    val = pManufacturersDom;

                p = new SqlParameter("@pManufacturersDom", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersDoe     *******
                if (pManufacturersDoe == null)
                    val = DBNull.Value;
                else
                    val = pManufacturersDoe;

                p = new SqlParameter("@pManufacturersDoe", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);



                recordsAffected = cmd.ExecuteNonQuery();
                //cmd.ExecuteNonQuery()是一个执行语句，把值传给recordsAffected
                val = cmd.Parameters["@pManufacturersID"].Value;
                pManufacturersId = (int)val;

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return recordsAffected;
        }
    }

    public class ManufacturersByManufacturersIdSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            int pManufacturersID)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spManufacturersSelectByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                object val = pManufacturersID;
                SqlParameter p = new SqlParameter("@pManufacturersID", val);
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

    public class ManufacturersSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            QueryManufacturers pQueryManufacturers)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "spManufacturersSelect";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     ManufacturersID     *******
                object val;
                if (pQueryManufacturers.ManufacturersID == null)
                    val = DBNull.Value;
                else
                    val = pQueryManufacturers.ManufacturersID;

                p = new SqlParameter("@pManufacturersID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersName     *******
                if (pQueryManufacturers.ManufacturersName == null
                     || pQueryManufacturers.ManufacturersName == "")
                    val = DBNull.Value;
                else
                    val = pQueryManufacturers.ManufacturersName;

                p = new SqlParameter("@pManufacturersName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersSite     *******
                if (pQueryManufacturers.ManufacturersSite == null
                    || pQueryManufacturers.ManufacturersSite == "")
                    val = DBNull.Value;
                else
                    val = pQueryManufacturers.ManufacturersSite;

                p = new SqlParameter("@pManufacturersSite", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersPhone     *******
                if (pQueryManufacturers.ManufacturersPhone == null
                    || pQueryManufacturers.ManufacturersPhone == "")
                    val = DBNull.Value;
                else
                    val = pQueryManufacturers.ManufacturersPhone;

                p = new SqlParameter("@pManufacturersPhone", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersDom     *******
                if (pQueryManufacturers.ManufacturersDom == null)
                    val = DBNull.Value;
                else
                    val = pQueryManufacturers.ManufacturersDom;

                p = new SqlParameter("@pManufacturersDom", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersDoe     *******
                if (pQueryManufacturers.ManufacturersDoe == null)
                    val = DBNull.Value;
                else
                    val = pQueryManufacturers.ManufacturersDoe;

                p = new SqlParameter("@pManufacturersDoe", SqlDbType.DateTime);
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

    public class ManufacturersByManufacturersIdUpdateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            int pManufacturersId,
            string pManufacturersName,
            string pManufacturersSite,
            string pManufacturersPhone,
            DateTime pManufacturersDom,
            DateTime pManufacturersDoe)
        {
            int recordsAffected;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spManufacturersUpdateByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     ManufacturersId     *******
                object val = pManufacturersId;

                p = new SqlParameter("@pManufacturersID", SqlDbType.Int);

                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersName     *******
                val = pManufacturersName;

                p = new SqlParameter("@pManufacturersName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersSite     *******
                val = pManufacturersSite;

                p = new SqlParameter("@pManufacturersSite", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersPhone     *******
                if (pManufacturersPhone == null || pManufacturersPhone == "")
                    val = DBNull.Value;
                else
                    val = pManufacturersPhone;

                p = new SqlParameter("@pManufacturersPhone", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersDom     *******
                if (pManufacturersDom == null)
                    val = DBNull.Value;
                else
                    val = pManufacturersDom;

                p = new SqlParameter("@pManufacturersDom", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersDoe     *******
                if (pManufacturersDoe == null)
                    val = DBNull.Value;
                else
                    val = pManufacturersDoe;

                p = new SqlParameter("@pManufacturersDoe", SqlDbType.DateTime);
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
