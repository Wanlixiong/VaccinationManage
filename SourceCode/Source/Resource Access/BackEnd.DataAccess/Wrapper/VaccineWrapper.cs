using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.DataAccess.Wrapper
{
    public class VaccineCreateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            string pVaccineName,
            string pVaccineSort,
            int pManufacturersID,
            Decimal? pVaccinePrice,
            int? pVaccineQuantity,
            out int? pVaccineId)
        {
            int recordsAffected;

            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spVaccineInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******      VaccineID     *******
                //output parameter is always first!
                p = new SqlParameter("@pVaccineID", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                //Direction指定参数p是输入还是输出或双向还是存储过程返回类型
                //ParameterDirection是指定参数的类型
                cmd.Parameters.Add(p);
                //给Parmeters集合添加参数

                //*******     VaccineName     *******
                object val = pVaccineName;

                p = new SqlParameter("@pVaccineName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineSort     *******
                if (pVaccineSort == null || pVaccineSort == "")
                    val = DBNull.Value;
                else
                    val = pVaccineSort;

                p = new SqlParameter("@pVaccineSort", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersID     *******
                val = pManufacturersID;

                p = new SqlParameter("@pManufacturersID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccinePrice     *******
                if (pVaccinePrice == null)
                    val = DBNull.Value;
                else
                    val = pVaccinePrice;

                p = new SqlParameter("@pVaccinePrice", SqlDbType.Decimal);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineQuantity     *******
                if (pVaccineQuantity == null)
                    val = DBNull.Value;
                else
                    val = pVaccineQuantity;

                p = new SqlParameter("@pVaccineQuantity", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);



                recordsAffected = cmd.ExecuteNonQuery();
                //cmd.ExecuteNonQuery()是一个执行语句，把值传给recordsAffected
                val = cmd.Parameters["@pVaccineID"].Value;
                pVaccineId = (int)val;

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return recordsAffected;
        }
    }

    public class VaccineByVaccineIdSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            int pVaccineID)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spVaccineSelectByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                object val = pVaccineID;
                SqlParameter p = new SqlParameter("@pVaccineID", val);
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

    public class VaccineSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            QueryVaccine pQueryVaccine)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "spVaccineSelect";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     VaccineID     *******
                object val;
                if (pQueryVaccine.VaccineID == null)
                    val = DBNull.Value;
                else
                    val = pQueryVaccine.VaccineID;

                p = new SqlParameter("@pVaccineID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineName     *******
                if (pQueryVaccine.VaccineName == null
                     || pQueryVaccine.VaccineName == "")
                    val = DBNull.Value;
                else
                    val = pQueryVaccine.VaccineName;

                p = new SqlParameter("@pVaccineName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineSort     *******
                if (pQueryVaccine.VaccineSort == null
                    || pQueryVaccine.VaccineSort == "")
                    val = DBNull.Value;
                else
                    val = pQueryVaccine.VaccineSort;

                p = new SqlParameter("@pVaccineSort", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersID     *******
                if (pQueryVaccine.ManufacturersID == null)
                    val = DBNull.Value;
                else
                    val = pQueryVaccine.ManufacturersID;

                p = new SqlParameter("@pManufacturersID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccinePrice     *******
                if (pQueryVaccine.VaccinePrice == null)
                    val = DBNull.Value;
                else
                    val = pQueryVaccine.VaccinePrice;

                p = new SqlParameter("@pVaccinePrice", SqlDbType.Decimal);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineQuantity     *******
                if (pQueryVaccine.VaccineQuantity == null)
                    val = DBNull.Value;
                else
                    val = pQueryVaccine.VaccineQuantity;

                p = new SqlParameter("@pVaccineQuantity", SqlDbType.Int);
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

    public class VaccineByVaccineIdUpdateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            int pVaccineId,
            string pVaccineName,
            string pVaccineSort,
            int pManufacturersID,
            Decimal? pVaccinePrice,
            int? pVaccineQuantity)
        {
            int recordsAffected;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spVaccineUpdateByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     VaccineId     *******
                object val = pVaccineId;

                p = new SqlParameter("@pVaccineID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineName     *******
                val = pVaccineName;

                p = new SqlParameter("@pVaccineName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineSort     *******
                if (pVaccineSort == null || pVaccineSort == "")
                    val = DBNull.Value;
                else
                    val = pVaccineSort;

                p = new SqlParameter("@pVaccineSort", SqlDbType.VarChar, 20);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     ManufacturersID     *******
                val = pManufacturersID;

                p = new SqlParameter("@pManufacturersID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccinePrice     *******
                if (pVaccinePrice == null)
                    val = DBNull.Value;
                else
                    val = pVaccinePrice;

                p = new SqlParameter("@pVaccinePrice", SqlDbType.Decimal);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineQuantity     *******
                if (pVaccineQuantity == null)
                    val = DBNull.Value;
                else
                    val = pVaccineQuantity;

                p = new SqlParameter("@pVaccineQuantity", SqlDbType.Int);
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