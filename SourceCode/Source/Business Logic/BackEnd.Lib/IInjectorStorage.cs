using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes storage methods to deal with
    /// <see cref="Injector"/> and provide public method to businesslogic.
    /// </summary>
    public interface IInjectorStorage
    {
        /// <summary>
        /// Creates new <see cref="Injector"/>.
        /// </summary>
        /// 
        /// <param name="pInjector">
        /// <see cref="Injector"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="Injector"/>, containing data from input
        /// <see cref="Injector"/> and additional data generated from 
        /// InjectorCreateWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectorCreateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        Injector CreateInjector(Injector pInjector);

        /// <summary>
        /// Read <see cref="Injector"/> by InjectorId.
        /// </summary>
        /// 
        /// <param name="pInjectorID">
        /// InjectorId: The identification of the Injector.
        /// </param>
        /// 
        /// <returns> <see cref="Injector"/>, containing data from input
        /// filter conditions and additional data generated from 
        /// InjectorByInjectorIdSelectWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectorByInjectorIdSelectWrapper. Please 
        /// see section <b>Exceptions</b> for a list of all exceptions that can  
        /// be thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception> 
        Injector ReadInjector(int pInjectorID);

        /// <summary>
        /// Gets <see cref="Injector"/> List.
        /// </summary>
        /// 
        /// <param name="pQueryInjector">
        /// <see cref="pQueryInjector"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="Injector"/> list, containing data from read
        /// by input <see cref="QueryInjector"/> filter conditions.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectorSelectWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        IList<Injector> ListInjector(QueryInjector pQueryInjector);

        /// <summary>
        /// Update <see cref="Injector"/>.
        /// </summary>
        /// 
        /// <param name="pInjector">
        /// <see cref="Injector"/> instance holding all required data for
        /// update.
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectorByInjectorIdUpdateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void UpdateInjector(Injector pInjector);
    }
}
