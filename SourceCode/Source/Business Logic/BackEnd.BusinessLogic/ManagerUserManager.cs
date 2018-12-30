using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.Lib;

namespace BackEnd.BusinessLogic
{
    public class ManagerUserManager : IManagerUserManager
    {
        ManagerUser IManagerUserManager.CreateManagerUser(
          IManagerUserStorage pStorage,
          ManagerUser pManagerUser)
        {
            ManagerUser response = null;

            try
            {
                #region Verify argument

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

                #endregion

                response = pStorage.CreateManagerUser(pManagerUser);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        ManagerUser IManagerUserManager.ReadManagerUser(
          IManagerUserStorage pStorage,
          int pUserID)
        {
            ManagerUser response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotSpecified(
                    pUserID <= 0,
                    "pUserID");
                #endregion

                response =
                    pStorage.ReadManagerUser(pUserID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        void IManagerUserManager.ModifyManagerUser(
            IManagerUserStorage pStorage,
            ManagerUser pManagerUser)
        {
            try
            {
                #region Verify argument

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

                #endregion

                pStorage.UpdateManagerUser(pManagerUser);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }
        }


        IList<ManagerUser> IManagerUserManager.GetManagerUserList(
             IManagerUserStorage pStorage,
             QueryManagerUser pQueryManagerUser)
        {
            IList<ManagerUser> response = null;
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotNull(pQueryManagerUser, "pQueryManagerUser");

                #endregion

                response =
                    pStorage.ListManagerUser(pQueryManagerUser);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }
    }
}