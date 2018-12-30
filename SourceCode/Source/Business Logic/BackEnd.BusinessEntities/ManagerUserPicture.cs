using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.BusinessEntities
{
    public class ManagerUserPicture
    {
        private int m_UserPicID;
        private int m_UserID;
        private byte[] m_UserPic;

        public int UserPicID
        {
            get { return m_UserPicID; }
            set { m_UserPicID = value; }
        }

        public int UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }

        public byte[] UserPic
        {
            get { return m_UserPic; }
            set { m_UserPic = value; }
        }
    }

    public class QueryManagerUserPicture
    {
        private int? m_UserPicID;
        private int? m_UserID;
        private byte?[] m_UserPic;

        public int? UserPicID
        {
            get { return m_UserPicID; }
            set { m_UserPicID = value; }
        }

        public int? UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }

        public byte?[] UserPic
        {
            get { return m_UserPic; }
            set { m_UserPic = value; }
        }
    }

}