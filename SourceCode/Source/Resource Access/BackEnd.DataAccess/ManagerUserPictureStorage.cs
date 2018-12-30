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
    public class ManagerUserPictureStorage : IManagerUserPictureStorage
    {
        ManagerUserPicture IManagerUserPictureStorage.CreateManagerUserPicture(
            ManagerUserPicture pManagerUserPicture)
        {
            SqlConnection conn = null;

            try
            {
                Verify.ArgumentNotNull(pManagerUserPicture, "pManagerUserPicture");


                Verify.ArgumentNotSpecified(
                    (pManagerUserPicture.UserID <= 0),
                    "pManagerUserPicture.UserID");


                int? newUserId;

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = ManagerUserPictureCreateWrapper.ExecuteNonQuery(
                    conn,
                    pManagerUserPicture.UserID,
                    pManagerUserPicture.UserPic,
                    out newUserId);

                pManagerUserPicture.UserPicID = Convert.ToInt32(newUserId);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("ManagerUserPicture create failure!");
                }

            }
            catch (Exception ex)
            {
                switch (ex.GetType().FullName)
                {
                    case "System.ArgumentNullException":
                        {
                            throw new ArgumentNullException(ex.Message);
                        }
                    case "System.ArgumentException":
                        {
                            throw new ArgumentException(ex.Message);
                        }
                    default:
                        throw new Exception(ex.Message);
                }
            }

            #region Dispose

            finally
            {
                if (conn != null)
                    conn.Dispose();
            }

            #endregion

            return pManagerUserPicture;
        }


        IList<ManagerUserPicture> IManagerUserPictureStorage.ListManagerUserPicture(
            QueryManagerUserPicture pQueryManagerUserPicture)
        {
            List<ManagerUserPicture> managerUserPictureList = null;
            SqlConnection conn;
            IDataReader reader;

            try
            {
                Verify.ArgumentNotNull(pQueryManagerUserPicture, "pQueryManagerUserPicture");

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = ManagerUserPictureSelectWrapper.ExecuteReader(
                    conn,
                    pQueryManagerUserPicture);

                if (reader != null)
                {
                    managerUserPictureList = new List<ManagerUserPicture>();

                    while (reader.Read())
                    {
                        ManagerUserPicture myManagerUserPicture = DAUtil.ReadManagerUserPicture(
                            reader);

                        managerUserPictureList.Add(myManagerUserPicture);
                    }

                }

                conn.Close();
            }
            catch (Exception ex)
            {
                switch (ex.GetType().FullName)
                {
                    case "System.ArgumentNullException":
                        {
                            throw new ArgumentNullException(ex.Message);
                        }
                    case "System.ArgumentException":
                        {
                            throw new ArgumentException(ex.Message);
                        }
                    default:
                        throw new Exception(ex.Message);
                }
            }

            return managerUserPictureList;
        }

    }
}
