using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes storage methods to deal with
    /// <see cref="Manufacturers"/> and provide public method to businesslogic.
    /// </summary>
    public interface IManufacturersStorage
    {
        /// <summary>
        /// Creates new <see cref="Manufacturers"/>.
        /// </summary>
        /// 
        /// <param name="pManufacturers">
        /// <see cref="Manufacturers"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="Manufacturers"/>, containing data from input
        /// <see cref="Manufacturers"/> and additional data generated from 
        /// ManufacturersCreateWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManufacturersCreateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        Manufacturers CreateManufacturers(Manufacturers pManufacturers);

        /// <summary>
        /// Read <see cref="Manufacturers"/> by ManufacturersId.
        /// </summary>
        /// 
        /// <param name="pManufacturersID">
        /// ManufacturersId: The identification of the Manufacturers.
        /// </param>
        /// 
        /// <returns> <see cref="Manufacturers"/>, containing data from input
        /// filter conditions and additional data generated from 
        /// ManufacturersByManufacturersIdSelectWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManufacturersByManufacturersIdSelectWrapper. Please 
        /// see section <b>Exceptions</b> for a list of all exceptions that can  
        /// be thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception> 
        Manufacturers ReadManufacturers(int pManufacturersID);

        /// <summary>
        /// Gets <see cref="Manufacturers"/> List.
        /// </summary>
        /// 
        /// <param name="pQueryManufacturers">
        /// <see cref="pQueryManufacturers"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="Manufacturers"/> list, containing data from read
        /// by input <see cref="QueryManufacturers"/> filter conditions.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManufacturersSelectWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        IList<Manufacturers> ListManufacturers(QueryManufacturers pQueryManufacturers);

        /// <summary>
        /// Update <see cref="Manufacturers"/>.
        /// </summary>
        /// 
        /// <param name="pManufacturers">
        /// <see cref="Manufacturers"/> instance holding all required data for
        /// update.
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManufacturersByManufacturersIdUpdateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void UpdateManufacturers(Manufacturers pManufacturers);
    }
}
