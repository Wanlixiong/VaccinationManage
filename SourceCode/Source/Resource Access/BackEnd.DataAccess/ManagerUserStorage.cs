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
    public class ManagerUserStorage : IManagerUserStorage
    {
        ManagerUser IManagerUserStorage.CreateManagerUser(
            ManagerUser pManagerUser)
        {
            SqlConnection conn = null;

            try
            {
                Verify.ArgumentNotNull(pManagerUser, "pManagerUser");

                Verify.ArgumentNotNull(
                    pManagerUser.UserName,
                    "pManagerUser.UserName");

                Verify.ArgumentNotNull(
                    pManagerUser.UserPassword,
                    "pManagerUser.UserPassword");


                Verify.ArgumentNotSpecified(
                    (pManagerUser.UserName.Length == 0),
                    "pManagerUser.UserName");

                Verify.ArgumentNotSpecified(
                    (pManagerUser.UserPassword.Length == 0),
                    "pManagerUser.UserPassword");


                int? newUserId;

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = ManagerUserCreateWrapper.ExecuteNonQuery(
                    conn,
                    pManagerUser.UserName,
                    pManagerUser.UserPassword,
                    pManagerUser.UserSort,
                    out newUserId);

                pManagerUser.UserID = Convert.ToInt32(newUserId);


                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("ManagerUser create failure!");
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

            return pManagerUser;
        }

        ManagerUser IManagerUserStorage.ReadManagerUser(int pUserId)
        {
            ManagerUser myManagerUser = null;
            SqlConnection conn = null;
            IDataReader reader = null;

            try
            {
                Verify.ArgumentNotNull(pUserId);

                myManagerUser = new ManagerUser();

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = ManagerUserByUserIdSelectWrapper.ExecuteReader(
                    conn,
                    pUserId);

                if (!reader.Read())
                {
                    throw new Exception("ManagerUser read failure!");
                }

                myManagerUser = DAUtil.ReadManagerUser(reader);

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

            #region Dispose

            finally
            {
                if (reader != null)
                    reader.Dispose();

                if (conn != null)
                    conn.Dispose();
            }

            #endregion

            return myManagerUser;
        }

        IList<ManagerUser> IManagerUserStorage.ListManagerUser(
            QueryManagerUser pQueryManagerUser)
        {
            List<ManagerUser> managerUserList = null;
            SqlConnection conn;
            IDataReader reader;

            try
            {
                Verify.ArgumentNotNull(pQueryManagerUser, "pQueryManagerUser");

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                reader = ManagerUserSelectWrapper.ExecuteReader(
                    conn,
                    pQueryManagerUser);

                if (reader != null)
                {
                    managerUserList = new List<ManagerUser>();

                    while (reader.Read())
                    {
                        ManagerUser myManagerUser = DAUtil.ReadManagerUser(
                            reader);

                        managerUserList.Add(myManagerUser);
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

            return managerUserList;
        }

        void IManagerUserStorage.UpdateManagerUser(ManagerUser pManagerUser)
        {
            SqlConnection conn = null;

            try
            {
                Verify.ArgumentNotNull(pManagerUser, "pManagerUser");

                Verify.ArgumentNotSpecified(
                    pManagerUser.UserID <= 0,
                    "pManagerUser.UserID");

                Verify.ArgumentNotNull(
                    pManagerUser.UserName,
                    "pManagerUser.UserName");

                Verify.ArgumentNotSpecified(
                    (pManagerUser.UserName.Length == 0),
                    "pManagerUser.UserName");

                Verify.ArgumentNotNull(
                    pManagerUser.UserPassword,
                    "pManagerUser.UserPassword");

                Verify.ArgumentNotSpecified(
                    (pManagerUser.UserPassword.Length == 0),
                    "pManagerUser.UserPassword");

                conn = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString());

                conn.Open();

                int recordsAffected = ManagerUserByUserIdUpdateWrapper
                    .ExecuteNonQuery(
                    conn,
                    pManagerUser.UserID,
                    pManagerUser.UserName,
                    pManagerUser.UserPassword,
                    pManagerUser.UserSort);

                conn.Close();

                if (recordsAffected == 0)
                {
                    throw new Exception("ManagerUser update failure!");
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
        }
    
    }
}
