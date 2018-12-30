using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.DataAccess.Wrapper
{
    public class InjectionMessageCreateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            int pInjectorID,
            string pInjectorName,
            int pVaccineID,
            string pVaccineName,
            string pInjectionMessageSite,
            DateTime pInjectionMessageTime,
            string pInjectionMessageDoctor,
            out int? pInjectionMessageId)
        {
            int recordsAffected;

            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spInjectionMessageInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******      InjectionMessageID     *******
                //output parameter is always first!
                p = new SqlParameter("@pInjectionMessageID", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                //Direction指定参数p是输入还是输出或双向还是存储过程返回类型
                //ParameterDirection是指定参数的类型
                cmd.Parameters.Add(p);
                //给Parmeters集合添加参数

                //*******     InjectorID     *******
                object val = pInjectorID;

                p = new SqlParameter("@pInjectorID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineID     *******
                val = pVaccineID;

                p = new SqlParameter("@pVaccineID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageSite     *******
                val = pInjectionMessageSite;

                p = new SqlParameter("@pInjectionMessageSite", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageTime     *******
                if (pInjectionMessageTime == null)
                    val = DBNull.Value;
                else
                    val = pInjectionMessageTime;

                p = new SqlParameter("@pInjectionMessageTime", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageDoctor     *******
                val = pInjectionMessageDoctor;

                p = new SqlParameter("@pInjectionMessageDoctor", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                recordsAffected = cmd.ExecuteNonQuery();
                //cmd.ExecuteNonQuery()是一个执行语句，把值传给recordsAffected
                val = cmd.Parameters["@pInjectionMessageID"].Value;
                pInjectionMessageId = (int)val;

            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
            return recordsAffected;
        }
    }

    public class InjectionMessageByInjectionMessageIdSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            int pInjectionMessageID)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spInjectionMessageSelectByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                object val = pInjectionMessageID;
                SqlParameter p = new SqlParameter("@pInjectionMessageID", val);
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

    public class InjectionMessageSelectWrapper
    {
        public static SqlDataReader ExecuteReader(
            SqlConnection connection,
            QueryInjectionMessage pQueryInjectionMessage)
        {
            SqlDataReader reader;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();

                cmd.CommandText = "spInjectionMessageSelect";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     InjectionMessageID     *******
                object val;
                if (pQueryInjectionMessage.InjectionMessageID == null)
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.InjectionMessageID;

                p = new SqlParameter("@pInjectionMessageID", SqlDbType.Int);

                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorID     *******
                if (pQueryInjectionMessage.InjectorID == null)
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.InjectorID;

                p = new SqlParameter("@pInjectorID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorName     *******
                if (pQueryInjectionMessage.InjectorName == null
                    || pQueryInjectionMessage.InjectorName == "")
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.InjectorName;

                p = new SqlParameter("@pInjectorName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineID     *******
                if (pQueryInjectionMessage.VaccineID == null)
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.VaccineID;

                p = new SqlParameter("@pVaccineID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineName     *******
                if (pQueryInjectionMessage.VaccineName == null
                    || pQueryInjectionMessage.VaccineName == "")
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.VaccineName;

                p = new SqlParameter("@pVaccineName", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageSite     *******
                if (pQueryInjectionMessage.InjectionMessageSite == null
                    || pQueryInjectionMessage.InjectionMessageSite == "")
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.InjectionMessageSite;

                p = new SqlParameter("@pInjectionMessageSite", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineName     *******
                if (pQueryInjectionMessage.InjectionMessageTime == null)
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.InjectionMessageTime;

                p = new SqlParameter("@pInjectionMessageTime", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageDoctor     *******
                if (pQueryInjectionMessage.InjectionMessageDoctor == null
                    || pQueryInjectionMessage.InjectionMessageDoctor == "")
                    val = DBNull.Value;
                else
                    val = pQueryInjectionMessage.InjectionMessageDoctor;

                p = new SqlParameter("@pInjectionMessageDoctor", SqlDbType.VarChar, 50);
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

    public class InjectionMessageByInjectionMessageIdUpdateWrapper
    {
        public static int ExecuteNonQuery(
            SqlConnection connection,
            int pInjectionMessageId,
            int pInjectorID,
            int pVaccineID,
            string pInjectionMessageSite,
            DateTime pInjectionMessageTime,
            string pInjectionMessageDoctor)
        {
            int recordsAffected;
            SqlCommand cmd = null;
            SqlParameter p;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "spInjectionMessageUpdateByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                //*******     InjectionMessageId     *******
                object val = pInjectionMessageId;

                p = new SqlParameter("@pInjectionMessageID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectorID     *******
                val = pInjectorID;

                p = new SqlParameter("@pInjectorID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     VaccineID     *******
                val = pVaccineID;

                p = new SqlParameter("@pVaccineID", SqlDbType.Int);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageSite     *******
                val = pInjectionMessageSite;

                p = new SqlParameter("@pInjectionMessageSite", SqlDbType.VarChar, 50);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageTime     *******
                if (pInjectionMessageTime == null)
                    val = DBNull.Value;
                else
                    val = pInjectionMessageTime;

                p = new SqlParameter("@pInjectionMessageTime", SqlDbType.DateTime);
                p.Direction = ParameterDirection.Input;
                p.Value = val;
                cmd.Parameters.Add(p);

                //*******     InjectionMessageDoctor     *******
                val = pInjectionMessageDoctor;

                p = new SqlParameter("@pInjectionMessageDoctor", SqlDbType.VarChar, 50);
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
