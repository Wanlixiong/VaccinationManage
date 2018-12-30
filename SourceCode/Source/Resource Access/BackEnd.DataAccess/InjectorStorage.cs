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
    public class InjectorStorage : IInjectorStorage
    {
        Injector IInjectorStorage.CreateInjector(
            Injector pInjector)
        {
            SqlConnection conn = null;
            try
            {
                Verify.ArgumentNotNull(pInjector, "pInjector");

                Verify.ArgumentNotNull(
                    pInjector.InjectorName,
                    "pInjector.InjectorName");


                Verify.ArgumentNotSpecified(
                    (pInjector.InjectorName.Length == 0),
                    "pInjector.InjectorName");

                int? newInjectorId;

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = InjectorCreateWrapper.ExecuteNonQuery(
                    conn,
                    pInjector.InjectorName,
                    pInjector.InjectorSex,
                    pInjector.InjectorPhone,
                    pInjector.InjectorNumber,
                    pInjector.InjectorTime,
                    out newInjectorId);

                pInjector.InjectorID = Convert.ToInt32(newInjectorId);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("Injector create failure!");
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

            return pInjector;
        }

        Injector IInjectorStorage.ReadInjector(int pInjectorID)
        {
            Injector myInjector = null;
            SqlConnection conn = null;
            IDataReader reader = null;

            try
            {
                Verify.ArgumentNotNull(pInjectorID);

                myInjector = new Injector();

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = InjectorByInjectorIdSelectWrapper.ExecuteReader(
                    conn,
                    pInjectorID);

                if (!reader.Read())
                {
                    throw new Exception("Injector read failure!");
                }

                myInjector = DAUtil.ReadInjector(reader);

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

            return myInjector;
        }

        IList<Injector> IInjectorStorage.ListInjector(QueryInjector pQueryInjector)
        {
            List<Injector> injectorList = null;
            SqlConnection conn;
            IDataReader reader;

            try
            {
                Verify.ArgumentNotNull(pQueryInjector, "pQueryInjector");

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = InjectorSelectWrapper.ExecuteReader(
                    conn,
                    pQueryInjector);

                if (reader != null)
                {
                    injectorList = new List<Injector>();

                    while (reader.Read())
                    {
                        Injector myInjector = DAUtil.ReadInjector(
                            reader);

                        injectorList.Add(myInjector);
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

            return injectorList;
        }

        void IInjectorStorage.UpdateInjector(Injector pInjector)
        {
            SqlConnection conn = null;

            try
            {
                Verify.ArgumentNotNull(pInjector, "pInjector");

                Verify.ArgumentNotSpecified(
                    pInjector.InjectorID <= 0,
                    "pInjector.InjectorID");

                Verify.ArgumentNotNull(
                    pInjector.InjectorName,
                    "pInjector.InjectorName");

                Verify.ArgumentNotSpecified(
                    pInjector.InjectorName.Length == 0,
                    "pInjector.InjectorName");


                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = InjectorByInjectorIdUpdateWrapper
                    .ExecuteNonQuery(
                    conn,
                    pInjector.InjectorID,
                    pInjector.InjectorName,
                    pInjector.InjectorSex,
                    pInjector.InjectorPhone,
                    pInjector.InjectorNumber,
                    pInjector.InjectorTime);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("Injector update failure!");
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
