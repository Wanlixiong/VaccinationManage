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
    public class VaccineStorage : IVaccineStorage
    {
        Vaccine IVaccineStorage.CreateVaccine(
            Vaccine pVaccine)
        {
            SqlConnection conn = null;
            try
            {
                Verify.ArgumentNotNull(pVaccine, "pVaccine");

                Verify.ArgumentNotNull(
                    pVaccine.VaccineName,
                    "pVaccine.VaccineName");


                Verify.ArgumentNotSpecified(
                    (pVaccine.VaccineName.Length == 0),
                    "pVaccine.VaccineName");

                Verify.ArgumentNotSpecified(
                    (pVaccine.ManufacturersID <= 0),
                    "pVaccine.ManufacturersID");

                int? newVaccineId;

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = VaccineCreateWrapper.ExecuteNonQuery(
                    conn,
                    pVaccine.VaccineName,
                    pVaccine.VaccineSort,
                    pVaccine.ManufacturersID,
                    pVaccine.VaccinePrice,
                    pVaccine.VaccineQuantity,
                    out newVaccineId);

                pVaccine.VaccineID = Convert.ToInt32(newVaccineId);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("Vaccine create failure!");
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

            return pVaccine;
        }

        Vaccine IVaccineStorage.ReadVaccine(int pVaccineID)
        {
            Vaccine myVaccine = null;
            SqlConnection conn = null;
            IDataReader reader = null;

            try
            {
                Verify.ArgumentNotNull(pVaccineID);

                myVaccine = new Vaccine();

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = VaccineByVaccineIdSelectWrapper.ExecuteReader(
                    conn,
                    pVaccineID);

                if (!reader.Read())
                {
                    throw new Exception("Vaccine read failure!");
                }

                myVaccine = DAUtil.ReadVaccine(reader);

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

            return myVaccine;
        }

        IList<Vaccine> IVaccineStorage.ListVaccine(QueryVaccine pQueryVaccine)
        {
            List<Vaccine> vaccineList = null;
            SqlConnection conn;
            IDataReader reader;

            try
            {
                Verify.ArgumentNotNull(pQueryVaccine, "pQueryVaccine");

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = VaccineSelectWrapper.ExecuteReader(
                    conn,
                    pQueryVaccine);

                if (reader != null)
                {
                    vaccineList = new List<Vaccine>();

                    while (reader.Read())
                    {
                        Vaccine myVaccine = DAUtil.ReadVaccine(
                            reader);

                        vaccineList.Add(myVaccine);
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

            return vaccineList;
        }

        void IVaccineStorage.UpdateVaccine(Vaccine pVaccine)
        {
            SqlConnection conn = null;

            try
            {
                Verify.ArgumentNotNull(pVaccine, "pVaccine");

                Verify.ArgumentNotSpecified(
                    pVaccine.VaccineID <= 0,
                    "pVaccine.VaccineID");

                Verify.ArgumentNotNull(
                    pVaccine.VaccineName,
                    "pVaccine.VaccineName");

                Verify.ArgumentNotSpecified(
                    pVaccine.VaccineName.Length == 0,
                    "pVaccine.VaccineName");

                Verify.ArgumentNotSpecified(
                    pVaccine.ManufacturersID <= 0,
                    "pVaccine.ManufacturersID");


                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = VaccineByVaccineIdUpdateWrapper
                    .ExecuteNonQuery(
                    conn,
                    pVaccine.VaccineID,
                    pVaccine.VaccineName,
                    pVaccine.VaccineSort,
                    pVaccine.ManufacturersID,
                    pVaccine.VaccinePrice,
                    pVaccine.VaccineQuantity);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("Vaccine update failure!");
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
