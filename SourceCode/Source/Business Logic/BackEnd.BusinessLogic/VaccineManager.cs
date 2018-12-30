using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.Lib;

namespace BackEnd.BusinessLogic
{
    public class VaccineManager : IVaccineManager
    {
        Vaccine IVaccineManager.CreateVaccine(
          IVaccineStorage pStorage,
          Vaccine pVaccine)
        {
            Vaccine response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pVaccine, "pVaccine");

                Verify.ArgumentNotNull(
                    pVaccine.VaccineName,
                    "pVaccine.VaccineName");

                Verify.ArgumentNotNull(
                    pVaccine.ManufacturersID,
                    "pVaccine.ManufacturersID");


                Verify.ArgumentNotSpecified(
                    (pVaccine.VaccineName.Length == 0),
                    "pVaccine.VaccineName");

                Verify.ArgumentNotSpecified(
                    (pVaccine.ManufacturersID <= 0),
                    "pVaccine.ManufacturersID");

                #endregion

                response = pStorage.CreateVaccine(pVaccine);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        Vaccine IVaccineManager.ReadVaccine(
          IVaccineStorage pStorage,
          int pVaccineID)
        {
            Vaccine response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotSpecified(
                    pVaccineID <= 0,
                    "pVaccineID");
                #endregion

                response =
                    pStorage.ReadVaccine(pVaccineID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        void IVaccineManager.ModifyVaccine(
            IVaccineStorage pStorage,
            Vaccine pVaccine)
        {
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pVaccine, "pVaccine");

                Verify.ArgumentNotNull(
                    pVaccine.VaccineName,
                    "pVaccine.VaccineName");

                Verify.ArgumentNotNull(
                    pVaccine.ManufacturersID,
                    "pVaccine.ManufacturersID");


                Verify.ArgumentNotSpecified(
                    (pVaccine.VaccineName.Length == 0),
                    "pVaccine.VaccineName");

                Verify.ArgumentNotSpecified(
                    (pVaccine.ManufacturersID <= 0),
                    "pVaccine.ManufacturersID");

                #endregion

                pStorage.UpdateVaccine(pVaccine);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }
        }


        IList<Vaccine> IVaccineManager.GetVaccineList(
             IVaccineStorage pStorage,
             QueryVaccine pQueryVaccine)
        {
            IList<Vaccine> response = null;
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotNull(pQueryVaccine, "pQueryVaccine");

                #endregion

                response =
                    pStorage.ListVaccine(pQueryVaccine);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }
    }
}