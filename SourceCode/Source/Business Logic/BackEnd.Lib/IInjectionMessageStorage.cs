using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes storage methods to deal with
    /// <see cref="InjectionMessage"/> and provide public method to businesslogic.
    /// </summary>
    public interface IInjectionMessageStorage
    {
        /// <summary>
        /// Creates new <see cref="InjectionMessage"/>.
        /// </summary>
        /// 
        /// <param name="pInjectionMessage">
        /// <see cref="InjectionMessage"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="InjectionMessage"/>, containing data from input
        /// <see cref="InjectionMessage"/> and additional data generated from 
        /// InjectionMessageCreateWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectionMessageCreateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        InjectionMessage CreateInjectionMessage(InjectionMessage pInjectionMessage);

        /// <summary>
        /// Read <see cref="InjectionMessage"/> by InjectionMessageId.
        /// </summary>
        /// 
        /// <param name="pInjectionMessageID">
        /// InjectionMessageId: The identification of the InjectionMessage.
        /// </param>
        /// 
        /// <returns> <see cref="InjectionMessage"/>, containing data from input
        /// filter conditions and additional data generated from 
        /// InjectionMessageByInjectionMessageIdSelectWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectionMessageByInjectionMessageIdSelectWrapper. Please 
        /// see section <b>Exceptions</b> for a list of all exceptions that can  
        /// be thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception> 
        InjectionMessage ReadInjectionMessage(int pInjectionMessageID);

        /// <summary>
        /// Gets <see cref="InjectionMessage"/> List.
        /// </summary>
        /// 
        /// <param name="pQueryInjectionMessage">
        /// <see cref="pQueryInjectionMessage"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="InjectionMessage"/> list, containing data from read
        /// by input <see cref="QueryInjectionMessage"/> filter conditions.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectionMessageSelectWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        IList<InjectionMessage> ListInjectionMessage(QueryInjectionMessage pQueryInjectionMessage);

        /// <summary>
        /// Update <see cref="InjectionMessage"/>.
        /// </summary>
        /// 
        /// <param name="pInjectionMessage">
        /// <see cref="InjectionMessage"/> instance holding all required data for
        /// update.
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectionMessageByInjectionMessageIdUpdateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void UpdateInjectionMessage(InjectionMessage pInjectionMessage);
    }
}
