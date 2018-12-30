using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.Lib;

namespace BackEnd.BusinessLogic
{
    public class ManagerUserPictureManager : IManagerUserPictureManager
    {
        ManagerUserPicture IManagerUserPictureManager.CreateManagerUserPicture(
          IManagerUserPictureStorage pStorage,
          ManagerUserPicture pManagerUserPicture)
        {
            ManagerUserPicture response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pManagerUserPicture, "pManagerUserPicture");

                Verify.ArgumentNotSpecified(
                    (pManagerUserPicture.UserID <= 0),
                    "pManagerUserPicture.UserID");

                #endregion

                response = pStorage.CreateManagerUserPicture(pManagerUserPicture);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        IList<ManagerUserPicture> IManagerUserPictureManager.GetManagerUserPictureList(
             IManagerUserPictureStorage pStorage,
             QueryManagerUserPicture pQueryManagerUserPicture)
        {
            IList<ManagerUserPicture> response = null;
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotNull(pQueryManagerUserPicture, "pQueryManagerUserPicture");

                #endregion

                response =
                    pStorage.ListManagerUserPicture(pQueryManagerUserPicture);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }
    }
}