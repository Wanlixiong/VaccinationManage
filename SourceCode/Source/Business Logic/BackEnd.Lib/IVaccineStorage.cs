using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes storage methods to deal with
    /// <see cref="Vaccine"/> and provide public method to businesslogic.
    /// </summary>
    public interface IVaccineStorage
    {
        /// <summary>
        /// Creates new <see cref="Vaccine"/>.
        /// </summary>
        /// 
        /// <param name="pVaccine">
        /// <see cref="Vaccine"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="Vaccine"/>, containing data from input
        /// <see cref="Vaccine"/> and additional data generated from 
        /// VaccineCreateWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to VaccineCreateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        Vaccine CreateVaccine(Vaccine pVaccine);

        /// <summary>
        /// Read <see cref="Vaccine"/> by VaccineId.
        /// </summary>
        /// 
        /// <param name="pVaccineID">
        /// VaccineId: The identification of the Vaccine.
        /// </param>
        /// 
        /// <returns> <see cref="Vaccine"/>, containing data from input
        /// filter conditions and additional data generated from 
        /// VaccineByVaccineIdSelectWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to VaccineByVaccineIdSelectWrapper. Please 
        /// see section <b>Exceptions</b> for a list of all exceptions that can  
        /// be thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception> 
        Vaccine ReadVaccine(int pVaccineID);

        /// <summary>
        /// Gets <see cref="Vaccine"/> List.
        /// </summary>
        /// 
        /// <param name="pQueryVaccine">
        /// <see cref="pQueryVaccine"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="Vaccine"/> list, containing data from read
        /// by input <see cref="QueryVaccine"/> filter conditions.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to VaccineSelectWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        IList<Vaccine> ListVaccine(QueryVaccine pQueryVaccine);

        /// <summary>
        /// Update <see cref="Vaccine"/>.
        /// </summary>
        /// 
        /// <param name="pVaccine">
        /// <see cref="Vaccine"/> instance holding all required data for
        /// update.
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to VaccineByVaccineIdUpdateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void UpdateVaccine(Vaccine pVaccine);
    }
}
