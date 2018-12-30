using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.Lib;

namespace BackEnd.BusinessLogic
{
    public class InjectionMessageManager:IInjectionMessageManager
    {
        InjectionMessage IInjectionMessageManager.CreateInjectionMessage(
          IInjectionMessageStorage pStorage,
          InjectionMessage pInjectionMessage)
        {
            InjectionMessage response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pInjectionMessage, "pInjectionMessage");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectorID,
                    "pInjectionMessage.InjectorID");

                Verify.ArgumentNotNull(
                    pInjectionMessage.VaccineID,
                    "pInjectionMessage.VaccineID");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageSite,
                    "pInjectionMessage.InjectionMessageSite");


                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageDoctor,
                    "pInjectionMessage.InjectionMessageDoctor");



                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectorID <= 0),
                    "pInjectionMessage.InjectorID");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.VaccineID <= 0),
                    "pInjectionMessage.VaccineID");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectionMessageSite.Length == 0),
                    "pInjectionMessage.InjectionMessageSite");


                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectionMessageDoctor.Length == 0),
                    "pInjectionMessage.InjectionMessageDoctor");

                #endregion

                response = pStorage.CreateInjectionMessage(pInjectionMessage);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        InjectionMessage IInjectionMessageManager.ReadInjectionMessage(
          IInjectionMessageStorage pStorage,
          int pInjectionMessageID)
        {
            InjectionMessage response = null;

            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotSpecified(
                    pInjectionMessageID <= 0,
                    "pInjectionMessageID");
                #endregion

                response =
                    pStorage.ReadInjectionMessage(pInjectionMessageID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }


        void IInjectionMessageManager.ModifyInjectionMessage(
            IInjectionMessageStorage pStorage,
            InjectionMessage pInjectionMessage)
        {
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pInjectionMessage, "pInjectionMessage");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectorID,
                    "pInjectionMessage.InjectorID");

                Verify.ArgumentNotNull(
                    pInjectionMessage.VaccineID,
                    "pInjectionMessage.VaccineID");

                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageSite,
                    "pInjectionMessage.InjectionMessageSite");


                Verify.ArgumentNotNull(
                    pInjectionMessage.InjectionMessageDoctor,
                    "pInjectionMessage.InjectionMessageDoctor");



                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectorID <= 0),
                    "pInjectionMessage.InjectorID");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.VaccineID <= 0),
                    "pInjectionMessage.VaccineID");

                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectionMessageSite.Length == 0),
                    "pInjectionMessage.InjectionMessageSite");


                Verify.ArgumentNotSpecified(
                    (pInjectionMessage.InjectionMessageDoctor.Length == 0),
                    "pInjectionMessage.InjectionMessageDoctor");

                #endregion

                pStorage.UpdateInjectionMessage(pInjectionMessage);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }
        }


        IList<InjectionMessage> IInjectionMessageManager.GetInjectionMessageList(
             IInjectionMessageStorage pStorage,
             QueryInjectionMessage pQueryInjectionMessage)
        {
            IList<InjectionMessage> response = null;
            try
            {
                #region Verify argument

                Verify.ArgumentNotNull(pStorage, "pStorage");
                Verify.ArgumentNotNull(pQueryInjectionMessage, "pQueryInjectionMessage");

                #endregion

                response =
                    pStorage.ListInjectionMessage(pQueryInjectionMessage);
            }
            catch (Exception ex)
            {
                ExceptionHandler.DealWithException(ex);
            }

            return response;

        }
    }
}
