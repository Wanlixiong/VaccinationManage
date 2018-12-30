using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes businesslogic methods to deal with
    /// <see cref="InjectionMessage"/> and provide public method to Webservice.
    /// </summary>

    public interface IInjectionMessageManager
    {
        /// <summary>
        /// Creates new <see cref="InjectionMessage"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectionMessageStorage"/> instance to use when creating new 
        /// <see cref="InjectionMessage"/>
        /// </param>
        /// <param name="pInjectionMessage">
        /// <see cref="InjectionMessage"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="InjectionMessage"/>, containing data from input
        /// <see cref="InjectionMessage"/> and additional data generated when 
        /// <see cref="IInjectionMessageStorage"/> added the 
        /// <see cref="InjectionMessage"/> to storage.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to <paramref name="pStorage"/>. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        InjectionMessage CreateInjectionMessage(
           IInjectionMessageStorage pStorage,
           InjectionMessage pInjectionMessage);

        /// <summary>
        /// Gets <see cref="InjectionMessage"/> List.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectionMessageStorage"/> instance to use when creating new 
        /// <see cref="InjectionMessage"/>
        /// </param>
        /// <param name="pQueryInjectionMessage">
        /// <see cref="QueryInjectionMessage"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="InjectionMessage"/> list, containing data from read
        /// by input <see cref="QueryInjectionMessage"/> filter conditions.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to <paramref name="pStorage"/>. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        IList<InjectionMessage> GetInjectionMessageList(
           IInjectionMessageStorage pStorage,
           QueryInjectionMessage pQueryInjectionMessage);

        /// <summary>
        /// Modify <see cref="InjectionMessage"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectionMessageStorage"/> instance to use when modifying  
        /// <see cref="InjectionMessage"/>
        /// </param>
        /// <param name="pInjectionMessage">
        /// <see cref="InjectionMessage"/> instance holding all required data for
        /// update
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method modifies <see cref="InjectionMessage"/>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void ModifyInjectionMessage(
            IInjectionMessageStorage pStorage,
            InjectionMessage pInjectionMessage);

        /// <summary>
        /// Read <see cref="InjectionMessage"/> by InjectionMessageId.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectionMessageStorage"/> instance to use when reading  
        /// <see cref="InjectionMessage"/>
        /// </param>
        /// <param name="pInjectionMessageID">
        /// InjectionMessageId: The identification of the InjectionMessage
        /// </param>
        /// 
        /// <returns> <see cref="InjectionMessage"/>, containing data from input
        /// filter conditions and additional data generated when 
        /// <see cref="IInjectionMessageStorage"/> added the 
        /// <see cref="InjectionMessage"/> to storage.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to <paramref name="pStorage"/>. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception> 
        InjectionMessage ReadInjectionMessage(
           IInjectionMessageStorage pStorage,
           int pInjectionMessageID);
    }
}
