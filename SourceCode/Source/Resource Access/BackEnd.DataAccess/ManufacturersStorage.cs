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
    public class ManufacturersStorage : IManufacturersStorage
    {
        Manufacturers IManufacturersStorage.CreateManufacturers(
            Manufacturers pManufacturers)
        {
            SqlConnection conn = null;
            try
            {
                Verify.ArgumentNotNull(pManufacturers, "pManufacturers");

                Verify.ArgumentNotNull(
                    pManufacturers.ManufacturersName,
                    "pManufacturers.ManufacturersName");

                Verify.ArgumentNotNull(
                    pManufacturers.ManufacturersSite,
                    "pManufacturers.ManufacturersSite");


                Verify.ArgumentNotSpecified(
                    (pManufacturers.ManufacturersName.Length == 0),
                    "pManufacturers.ManufacturersName");

                Verify.ArgumentNotSpecified(
                    (pManufacturers.ManufacturersSite.Length == 0),
                    "pManufacturers.ManufacturersSite");


                int? newManufacturersId;

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = ManufacturersCreateWrapper.ExecuteNonQuery(
                    conn,
                    pManufacturers.ManufacturersName,
                    pManufacturers.ManufacturersSite,
                    pManufacturers.ManufacturersPhone,
                    pManufacturers.ManufacturersDom,
                    pManufacturers.ManufacturersDoe,
                    out newManufacturersId);

                pManufacturers.ManufacturersID = Convert.ToInt32(newManufacturersId);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("Manufacturers create failure!");
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

            return pManufacturers;
        }

        Manufacturers IManufacturersStorage.ReadManufacturers(int pManufacturersID)
        {
            Manufacturers myManufacturers = null;
            SqlConnection conn = null;
            IDataReader reader = null;

            try
            {
                Verify.ArgumentNotNull(pManufacturersID);

                myManufacturers = new Manufacturers();

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = ManufacturersByManufacturersIdSelectWrapper.ExecuteReader(
                    conn,
                    pManufacturersID);

                if (!reader.Read())
                {
                    throw new Exception("Manufacturers read failure!");
                }

                myManufacturers = DAUtil.ReadManufacturers(reader);

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

            return myManufacturers;
        }

        IList<Manufacturers> IManufacturersStorage.ListManufacturers(QueryManufacturers pQueryManufacturers)
        {
            List<Manufacturers> manufacturersList = null;
            SqlConnection conn;
            IDataReader reader;

            try
            {
                Verify.ArgumentNotNull(pQueryManufacturers, "pQueryManufacturers");

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = ManufacturersSelectWrapper.ExecuteReader(
                    conn,
                    pQueryManufacturers);

                if (reader != null)
                {
                    manufacturersList = new List<Manufacturers>();

                    while (reader.Read())
                    {
                        Manufacturers myManufacturers = DAUtil.ReadManufacturers(
                            reader);

                        manufacturersList.Add(myManufacturers);
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

            return manufacturersList;
        }

        void IManufacturersStorage.UpdateManufacturers(Manufacturers pManufacturers)
        {
            SqlConnection conn = null;

            try
            {
                Verify.ArgumentNotNull(pManufacturers, "pManufacturers");

                Verify.ArgumentNotSpecified(
                    pManufacturers.ManufacturersID <= 0,
                    "pManufacturers.ManufacturersID");

                Verify.ArgumentNotNull(
                    pManufacturers.ManufacturersName,
                    "pManufacturers.ManufacturersName");

                Verify.ArgumentNotNull(
                    pManufacturers.ManufacturersSite,
                    "pManufacturers.ManufacturersSite");


                Verify.ArgumentNotSpecified(
                    pManufacturers.ManufacturersName.Length == 0,
                    "pManufacturers.ManufacturersName");

                Verify.ArgumentNotSpecified(
                    pManufacturers.ManufacturersSite.Length == 0,
                    "pManufacturers.ManufacturersSite");


                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = ManufacturersByManufacturersIdUpdateWrapper
                    .ExecuteNonQuery(
                    conn,
                    pManufacturers.ManufacturersID,
                    pManufacturers.ManufacturersName,
                    pManufacturers.ManufacturersSite,
                    pManufacturers.ManufacturersPhone,
                    pManufacturers.ManufacturersDom,
                    pManufacturers.ManufacturersDoe);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("Manufacturers update failure!");
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
