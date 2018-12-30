using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes businesslogic methods to deal with
    /// <see cref="Manufacturers"/> and provide public method to Webservice.
    /// </summary>

    public interface IManufacturersManager
    {
        /// <summary>
        /// Creates new <see cref="Manufacturers"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManufacturersStorage"/> instance to use when creating new 
        /// <see cref="Manufacturers"/>
        /// </param>
        /// <param name="pManufacturers">
        /// <see cref="Manufacturers"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="Manufacturers"/>, containing data from input
        /// <see cref="Manufacturers"/> and additional data generated when 
        /// <see cref="IManufacturersStorage"/> added the 
        /// <see cref="Manufacturers"/> to storage.
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
        Manufacturers CreateManufacturers(
           IManufacturersStorage pStorage,
           Manufacturers pManufacturers);

        /// <summary>
        /// Gets <see cref="Manufacturers"/> List.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManufacturersStorage"/> instance to use when creating new 
        /// <see cref="Manufacturers"/>
        /// </param>
        /// <param name="pQueryManufacturers">
        /// <see cref="QueryManufacturers"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="Manufacturers"/> list, containing data from read
        /// by input <see cref="QueryManufacturers"/> filter conditions.
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
        IList<Manufacturers> GetManufacturersList(
           IManufacturersStorage pStorage,
           QueryManufacturers pQueryManufacturers);

        /// <summary>
        /// Modify <see cref="Manufacturers"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManufacturersStorage"/> instance to use when modifying  
        /// <see cref="Manufacturers"/>
        /// </param>
        /// <param name="pManufacturers">
        /// <see cref="Manufacturers"/> instance holding all required data for
        /// update
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method modifies <see cref="Manufacturers"/>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void ModifyManufacturers(
            IManufacturersStorage pStorage,
            Manufacturers pManufacturers);

        /// <summary>
        /// Read <see cref="Manufacturers"/> by ManufacturersId.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManufacturersStorage"/> instance to use when reading  
        /// <see cref="Manufacturers"/>
        /// </param>
        /// <param name="pManufacturersID">
        /// ManufacturersId: The identification of the Manufacturers
        /// </param>
        /// 
        /// <returns> <see cref="Manufacturers"/>, containing data from input
        /// filter conditions and additional data generated when 
        /// <see cref="IManufacturersStorage"/> added the 
        /// <see cref="Manufacturers"/> to storage.
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
        Manufacturers ReadManufacturers(
           IManufacturersStorage pStorage,
           int pManufacturersID);
    }
}
