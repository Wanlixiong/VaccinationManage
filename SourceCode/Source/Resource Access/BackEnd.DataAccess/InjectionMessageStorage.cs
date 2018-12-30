using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.DataAccess.Wrapper;
using BackEnd.Lib;

namespace BackEnd.DataAccess
{
    public class InjectionMessageStorage : IInjectionMessageStorage
    {
        InjectionMessage IInjectionMessageStorage.CreateInjectionMessage(
            InjectionMessage pInjectionMessage)
        {
            SqlConnection conn = null;
            try
            {
                Verify.ArgumentNotNull(pInjectionMessage, "pInjectionMessage");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageSite,
                    "pInjectionMessage.InjectionMessageSite");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageDoctor,
                    "pInjectionMessage.InjectionMessageDoctor");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectorID <= 0),
                    "pInjectionMessage.InjectorID");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.VaccineID <= 0),
                    "pInjectionMessage.VaccineID");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectionMessageSite.Length == 0),
                    "pInjectionMessage.InjectionMessageSite");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectionMessageDoctor.Length == 0),
                    "pInjectionMessage.InjectionMessageDoctor");


                int? newInjectionMessageId;

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = InjectionMessageCreateWrapper.ExecuteNonQuery(
                    conn,
                    pInjectionMessage.InjectorID,
                    pInjectionMessage.InjectorName,
                    pInjectionMessage.VaccineID,
                    pInjectionMessage.VaccineName,
                    pInjectionMessage.InjectionMessageSite,
                    pInjectionMessage.InjectionMessageTime,
                    pInjectionMessage.InjectionMessageDoctor,
                    out newInjectionMessageId);

                pInjectionMessage.InjectionMessageID = Convert.ToInt32(newInjectionMessageId);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("InjectionMessage create failure!");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
                //switch (ex.GetType().FullName)
                //{
                //    case "System.ArgumentNullException":
                //        {
                //            throw new ArgumentNullException(ex.Message); 
                //        }
                //    case "System.ArgumentException":
                //        {
                //            throw new ArgumentException(ex.Message);
                //        }
                //    default:
                //        throw new Exception(ex.Message);
                //}
            }
            #region Dispose

            finally
            {
                if (conn != null)
                    conn.Dispose();
            }

            #endregion

            return pInjectionMessage;
        }

        InjectionMessage IInjectionMessageStorage.ReadInjectionMessage(int pInjectionMessageID)
        {
            InjectionMessage myInjectionMessage = null;
            SqlConnection conn = null;
            IDataReader reader = null;

            try
            {
                Verify.ArgumentNotNull(pInjectionMessageID);

                myInjectionMessage = new InjectionMessage();

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = InjectionMessageByInjectionMessageIdSelectWrapper.ExecuteReader(
                    conn,
                    pInjectionMessageID);

                if (!reader.Read())
                {
                    throw new Exception("InjectionMessage read failure!");
                }

                myInjectionMessage = DAUtil.ReadInjectionMessage(reader);

                conn.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
                //switch (ex.GetType().FullName)
                //{
                //    case "System.ArgumentNullException":
                //        {
                //            throw new ArgumentNullException(ex.Message);
                //        }
                //    case "System.ArgumentException":
                //        {
                //            throw new ArgumentException(ex.Message);
                //        }
                //    default:
                //        throw new Exception(ex.Message);
                //}
            }
            #region Dispose

            finally
            {
                if (reader != null)
                    reader.Dispose();

                if (conn != null)
                    conn.Dispose();
            }

            #endregion

            return myInjectionMessage;
        }

        IList<InjectionMessage> IInjectionMessageStorage.ListInjectionMessage(QueryInjectionMessage pQueryInjectionMessage)
        {
            List<InjectionMessage> injectionMessageList = null;
            SqlConnection conn;
            IDataReader reader;

            try
            {
                Verify.ArgumentNotNull(pQueryInjectionMessage, "pQueryInjectionMessage");

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = InjectionMessageSelectWrapper.ExecuteReader(
                    conn,
                    pQueryInjectionMessage);

                if (reader != null)
                {
                    injectionMessageList = new List<InjectionMessage>();

                    while (reader.Read())
                    {
                        InjectionMessage myInjectionMessage = DAUtil.ReadInjectionMessage(
                            reader);

                        injectionMessageList.Add(myInjectionMessage);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
                //switch (ex.GetType().FullName)
                //{
                //    case "System.ArgumentNullException":
                //        {
                //            throw new ArgumentNullException(ex.Message);
                //        }
                //    case "System.ArgumentException":
                //        {
                //            throw new ArgumentException(ex.Message);
                //        }
                //    default:
                //        throw new Exception(ex.Message);
                //}
            }

            return injectionMessageList;
        }

        void IInjectionMessageStorage.UpdateInjectionMessage(InjectionMessage pInjectionMessage)
        {
            SqlConnection conn = null;

            try
            {
                Verify.ArgumentNotNull(pInjectionMessage, "pInjectionMessage");

                Verify.ArgumentNotSpecified(
                    pInjectionMessage.InjectionMessageID <= 0,
                    "pInjectionMessage.InjectionMessageID");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageSite,
                    "pInjectionMessage.InjectionMessageSite");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageDoctor,
                    "pInjectionMessage.InjectionMessageDoctor");

                Verify.ArgumentNotSpecified(
                    pInjectionMessage.InjectorID <= 0,
                    "pInjectionMessage.InjectorID");

                Verify.ArgumentNotSpecified(
                    pInjectionMessage.VaccineID <= 0,
                    "pInjectionMessage.VaccineID");

                Verify.ArgumentNotSpecified(
                    pInjectionMessage.InjectionMessageSite.Length == 0,
                    "pInjectionMessage.InjectionMessageSite");

                Verify.ArgumentNotSpecified(
                    pInjectionMessage.InjectionMessageDoctor.Length == 0,
                    "pInjectionMessage.InjectionMessageDoctor");


                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = InjectionMessageByInjectionMessageIdUpdateWrapper
                    .ExecuteNonQuery(
                    conn,
                    pInjectionMessage.InjectionMessageID,
                    pInjectionMessage.InjectorID,
                    pInjectionMessage.VaccineID,
                    pInjectionMessage.InjectionMessageSite,
                    pInjectionMessage.InjectionMessageTime,
                    pInjectionMessage.InjectionMessageDoctor);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("InjectionMessage update failure!");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
                //switch (ex.GetType().FullName)
                //{
                //    case "System.ArgumentNullException":
                //        {
                //            throw new ArgumentNullException(ex.Message);
                //        }
                //    case "System.ArgumentException":
                //        {
                //            throw new ArgumentException(ex.Message);
                //        }
                //    default:
                //        throw new Exception(ex.Message);
                //}
            }
            #region Dispose

            finally
            {
                if (conn != null)
                    conn.Dispose();
            }

            #endregion

        }

    }
}
