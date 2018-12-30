using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.BusinessEntities
{
    public class ManagerUser
    {
        private int m_UserID;
        private string m_UserName;
        private string m_UserPassword;
        private string m_UserSort;

        public int UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }

        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        public string UserPassword
        {
            get { return m_UserPassword; }
            set { m_UserPassword = value; }
        }

        public string UserSort
        {
            get { return m_UserSort; }
            set { m_UserSort = value; }
        }
    }

    public class QueryManagerUser
    {
        private int? m_UserID;
        private string m_UserName;
        private string m_UserPassword;
        private string m_UserSort;

        public int? UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }

        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        public string UserPassword
        {
            get { return m_UserPassword; }
            set { m_UserPassword = value; }
        }

        public string UserSort
        {
            get { return m_UserSort; }
            set { m_UserSort = value; }
        }
    }

}
