using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes storage methods to deal with
    /// <see cref="ManagerUser"/> and provide public method to businesslogic.
    /// </summary>
    public interface IManagerUserStorage
    {
        /// <summary>
        /// Creates new <see cref="ManagerUser"/>.
        /// </summary>
        /// 
        /// <param name="pManagerUser">
        /// <see cref="ManagerUser"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="ManagerUser"/>, containing data from input
        /// <see cref="ManagerUser"/> and additional data generated from 
        /// ManagerUserCreateWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManagerUserCreateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        ManagerUser CreateManagerUser(ManagerUser pManagerUser);

        /// <summary>
        /// Read <see cref="ManagerUser"/> by UserId.
        /// </summary>
        /// 
        /// <param name="pUserID">
        /// UserId: The identification of the ManagerUser.
        /// </param>
        /// 
        /// <returns> <see cref="Injector"/>, containing data from input
        /// filter conditions and additional data generated from 
        /// ManagerUserByUserIdSelectWrapper.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to InjectorByUserIdSelectWrapper. Please 
        /// see section <b>Exceptions</b> for a list of all exceptions that can  
        /// be thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception> 
        ManagerUser ReadManagerUser(int pUserID);

        /// <summary>
        /// Gets <see cref="ManagerUser"/> List.
        /// </summary>
        /// 
        /// <param name="pQueryManagerUser">
        /// <see cref="pQueryManagerUser"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="ManagerUser"/> list, containing data from read
        /// by input <see cref="QueryManagerUser"/> filter conditions.
        /// </returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManagerUserSelectWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        IList<ManagerUser> ListManagerUser(QueryManagerUser pQueryManagerUser);

        /// <summary>
        /// Update <see cref="ManagerUser"/>.
        /// </summary>
        /// 
        /// <param name="pManagerUser">
        /// <see cref="ManagerUser"/> instance holding all required data for
        /// update.
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method checks input parameters for <c>null</c> and passes the 
        /// processing to ManagerUserByUserIdUpdateWrapper. Please see 
        /// section <b>Exceptions</b> for a list of all exceptions that can be 
        /// thrown from the method.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void UpdateManagerUser(ManagerUser pManagerUser);
    }
}
