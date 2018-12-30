using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes businesslogic methods to deal with
    /// <see cref="Injector"/> and provide public method to Webservice.
    /// </summary>

    public interface IInjectorManager
    {
        /// <summary>
        /// Creates new <see cref="Injector"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectorStorage"/> instance to use when creating new 
        /// <see cref="Injector"/>
        /// </param>
        /// <param name="pInjector">
        /// <see cref="Injector"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="Injector"/>, containing data from input
        /// <see cref="Injector"/> and additional data generated when 
        /// <see cref="IInjectorStorage"/> added the 
        /// <see cref="Injector"/> to storage.
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
        Injector CreateInjector(
           IInjectorStorage pStorage,
           Injector pInjector);

        /// <summary>
        /// Gets <see cref="Injector"/> List.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectorStorage"/> instance to use when creating new 
        /// <see cref="Injector"/>
        /// </param>
        /// <param name="pQueryInjector">
        /// <see cref="QueryInjector"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="Injector"/> list, containing data from read
        /// by input <see cref="QueryInjector"/> filter conditions.
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
        IList<Injector> GetInjectorList(
           IInjectorStorage pStorage,
           QueryInjector pQueryInjector);

        /// <summary>
        /// Modify <see cref="Injector"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectorStorage"/> instance to use when modifying  
        /// <see cref="Injector"/>
        /// </param>
        /// <param name="pInjector">
        /// <see cref="Injector"/> instance holding all required data for
        /// update
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method modifies <see cref="Injector"/>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void ModifyInjector(
            IInjectorStorage pStorage,
            Injector pInjector);

        /// <summary>
        /// Read <see cref="Injector"/> by InjectorId.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IInjectorStorage"/> instance to use when reading  
        /// <see cref="Injector"/>
        /// </param>
        /// <param name="pInjectorID">
        /// InjectorId: The identification of the Injector
        /// </param>
        /// 
        /// <returns> <see cref="Injector"/>, containing data from input
        /// filter conditions and additional data generated when 
        /// <see cref="IInjectorStorage"/> added the 
        /// <see cref="Injector"/> to storage.
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
        Injector ReadInjector(
           IInjectorStorage pStorage,
           int pInjectorID);
    }
}
