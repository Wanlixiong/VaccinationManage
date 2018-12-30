using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.Lib;

namespace BackEnd.BusinessLogic
{
    public class ManufacturersManager : IManufacturersManager
    {
        Manufacturers IManufacturersManager.CreateManufacturers(
          IManufacturersStorage pStorage,
          Manufacturers pManufacturers)
        {
            Manufacturers response = null;

            try
            {
                #region Verify argument

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

                #endregion

                response = pStorage.CreateManufacturers(pManufacturers);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        Manufacturers IManufacturersManager.ReadManufacturers(
          IManufacturersStorage pStorage,
          int pManufacturersID)
        {
            Manufacturers response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotSpecified(
                    pManufacturersID <= 0,
                    "pManufacturersID");
                #endregion

                response =
                    pStorage.ReadManufacturers(pManufacturersID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        void IManufacturersManager.ModifyManufacturers(
            IManufacturersStorage pStorage,
            Manufacturers pManufacturers)
        {
            try
            {
                #region Verify argument

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

                #endregion

                pStorage.UpdateManufacturers(pManufacturers);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }
        }


        IList<Manufacturers> IManufacturersManager.GetManufacturersList(
             IManufacturersStorage pStorage,
             QueryManufacturers pQueryManufacturers)
        {
            IList<Manufacturers> response = null;
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotNull(pQueryManufacturers, "pQueryManufacturers");

                #endregion

                response =
                    pStorage.ListManufacturers(pQueryManufacturers);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }
    }
}