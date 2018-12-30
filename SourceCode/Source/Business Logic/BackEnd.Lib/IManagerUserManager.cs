using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.Lib
{
    /// <summary>
    /// This class includes businesslogic methods to deal with
    /// <see cref="ManagerUser"/> and provide public method to Webservice.
    /// </summary>

    public interface IManagerUserManager
    {
        /// <summary>
        /// Creates new <see cref="ManagerUser"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManagerUserStorage"/> instance to use when creating new 
        /// <see cref="ManagerUser"/>
        /// </param>
        /// <param name="pManagerUser">
        /// <see cref="ManagerUser"/> instance holding all required data for
        /// creation
        /// </param>
        /// 
        /// <returns>New <see cref="ManagerUser"/>, containing data from input
        /// <see cref="ManagerUser"/> and additional data generated when 
        /// <see cref="IManagerUserStorage"/> added the 
        /// <see cref="ManagerUser"/> to storage.
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
        ManagerUser CreateManagerUser(
           IManagerUserStorage pStorage,
           ManagerUser pManagerUser);

        /// <summary>
        /// Gets <see cref="ManagerUser"/> List.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManagerUserStorage"/> instance to use when creating new 
        /// <see cref="ManagerUser"/>
        /// </param>
        /// <param name="pQueryManagerUser">
        /// <see cref="QueryManagerUser"/> instance holding all required data
        /// for list.
        /// </param>
        /// 
        /// <returns> <see cref="ManagerUser"/> list, containing data from read
        /// by input <see cref="QueryManagerUser"/> filter conditions.
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
        IList<ManagerUser> GetManagerUserList(
           IManagerUserStorage pStorage,
           QueryManagerUser pQueryManagerUser);

        /// <summary>
        /// Modify <see cref="ManagerUser"/>.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManagerUserStorage"/> instance to use when modifying  
        /// <see cref="ManagerUser"/>
        /// </param>
        /// <param name="pManagerUser">
        /// <see cref="ManagerUser"/> instance holding all required data for
        /// update
        /// </param>
        /// 
        /// <returns></returns>
        /// 
        /// <remarks>
        /// This method modifies <see cref="ManagerUser"/>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">When any of input parameters
        /// is <c>not specified</c></exception> 
        /// <exception cref="ArgumentNullException">When any of input parameters
        /// is <c>null</c></exception>
        void ModifyManagerUser(
            IManagerUserStorage pStorage,
            ManagerUser pManagerUser);

        /// <summary>
        /// Read <see cref="ManagerUser"/> by UserId.
        /// </summary>
        /// 
        /// <param name="pStorage">
        /// <see cref="IManagerUserStorage"/> instance to use when reading  
        /// <see cref="ManagerUser"/>
        /// </param>
        /// <param name="pManagerUserID">
        /// UserId: The identification of the ManagerUser
        /// </param>
        /// 
        /// <returns> <see cref="ManagerUser"/>, containing data from input
        /// filter conditions and additional data generated when 
        /// <see cref="IManagerUserStorage"/> added the 
        /// <see cref="ManagerUser"/> to storage.
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
        ManagerUser ReadManagerUser(
           IManagerUserStorage pStorage,
           int pUserID);
    }
}
