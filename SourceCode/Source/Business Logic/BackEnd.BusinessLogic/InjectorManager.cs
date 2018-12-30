using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.Lib;

namespace BackEnd.BusinessLogic
{
    public class InjectorManager : IInjectorManager
    {
        Injector IInjectorManager.CreateInjector(
          IInjectorStorage pStorage,
          Injector pInjector)
        {
            Injector response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pInjector, "pInjector");

                Verify.ArgumentNotNull(
                    pInjector.InjectorName,
                    "pInjector.InjectorName");

                Verify.ArgumentNotSpecified(
                    (pInjector.InjectorName.Length == 0),
                    "pInjector.InjectorName");

                #endregion

                response = pStorage.CreateInjector(pInjector);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        Injector IInjectorManager.ReadInjector(
          IInjectorStorage pStorage,
          int pInjectorID)
        {
            Injector response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotSpecified(
                    pInjectorID <= 0,
                    "pInjectorID");
                #endregion

                response =
                    pStorage.ReadInjector(pInjectorID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        void IInjectorManager.ModifyInjector(
            IInjectorStorage pStorage,
            Injector pInjector)
        {
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pInjector, "pInjector");

                Verify.ArgumentNotNull(
                    pInjector.InjectorName,
                    "pInjector.InjectorName");



                Verify.ArgumentNotSpecified(
                    (pInjector.InjectorName.Length == 0),
                    "pInjector.InjectorName");

                #endregion

                pStorage.UpdateInjector(pInjector);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }
        }


        IList<Injector> IInjectorManager.GetInjectorList(
             IInjectorStorage pStorage,
             QueryInjector pQueryInjector)
        {
            IList<Injector> response = null;
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotNull(pQueryInjector, "pQueryInjector");

                #endregion

                response =
                    pStorage.ListInjector(pQueryInjector);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }
    }
}