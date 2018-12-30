using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes businesslogic methods to deal with
    /// <see cref="Vaccine"/> and provide public method to Webservice.
    /// </summary>

    public interface IVaccineManager
    {
        /// <summary>
        /// Creates new <see cref="Vaccine"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IVaccineStorage"/> instance to use when creating new 
        /// <see cref="Vaccine"/>
        /// </param>
        /// <param name="pVaccine">
        /// <see cref="Vaccine"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="Vaccine"/>, containing data from input
        /// <see cref="Vaccine"/> and additional data generated when 
        /// <see cref="VaccineStorage"/> added the 
        /// <see cref="Vaccine"/> to storage.
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
        Vaccine CreateVaccine(
           IVaccineStorage pStorage,
           Vaccine pVaccine);

        /// <summary>
        /// Gets <see cref="Vaccine"/> List.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IVaccineStorage"/> instance to use when creating new 
        /// <see cref="Vaccine"/>
        /// </param>
        /// <param name="pQueryVaccine">
        /// <see cref="QueryVaccine"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="Vaccine"/> list, containing data from read
        /// by input <see cref="QueryVaccine"/> filter conditions.
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
        IList<Vaccine> GetVaccineList(
           IVaccineStorage pStorage,
           QueryVaccine pQueryVaccine);

        /// <summary>
        /// Modify <see cref="Vaccine"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IVaccineStorage"/> instance to use when modifying  
        /// <see cref="Vaccine"/>
        /// </param>
        /// <param name="pVaccine">
        /// <see cref="Vaccine"/> instance holding all required data for
        /// update
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method modifies <see cref="Vaccine"/>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void ModifyVaccine(
            IVaccineStorage pStorage,
            Vaccine pVaccine);

        /// <summary>
        /// Read <see cref="Vaccine"/> by VaccineId.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IVaccineStorage"/> instance to use when reading  
        /// <see cref="Vaccine"/>
        /// </param>
        /// <param name="pVaccineID">
        /// VaccineId: The identification of the Vaccine
        /// </param>
        /// 
        /// <returns> <see cref="Vaccine"/>, containing data from input
        /// filter conditions and additional data generated when 
        /// <see cref="IVaccineStorage"/> added the 
        /// <see cref="Vaccine"/> to storage.
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
        Vaccine ReadVaccine(
           IVaccineStorage pStorage,
           int pVaccineID);
    }
}
