using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes storage methods to deal with
    /// <see cref="ManagerUserPicture"/> and provide public method to businesslogic.
    /// </summary>
    public interface IManagerUserPictureStorage
    {
        /// <summary>
        /// Creates new <see cref="ManagerUserPicture"/>.
        /// </summary>
        /// 
        /// <param name="pManagerUserPicture">
        /// <see cref="ManagerUserPicture"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="ManagerUserPicture"/>, containing data from input
        /// <see cref="ManagerUserPicture"/> and additional data generated from 
        /// ManagerUserCreateWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManagerUserPictureCreateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        ManagerUserPicture CreateManagerUserPicture(ManagerUserPicture pManagerUserPicture);


        /// <summary>
        /// Gets <see cref="ManagerUserPicture"/> List.
        /// </summary>
        /// 
        /// <param name="pQueryManagerUserPicture">
        /// <see cref="pQueryManagerUserPicture"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="ManagerUserPicture"/> list, containing data from read
        /// by input <see cref="QueryManagerUserPicture"/> filter conditions.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManagerUserPictureSelectWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        IList<ManagerUserPicture> ListManagerUserPicture(QueryManagerUserPicture pQueryManagerUserPicture);

    }
}
