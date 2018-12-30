using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.BusinessEntities
{
    public class Injector
    {
        private int m_InjectorID;
        private string m_InjectorName;
        private string m_InjectorSex;
        private string m_InjectorPhone;
        private int m_InjectorNumber;
        private DateTime m_InjectorTime;

        public int InjectorID
        {
            get { return m_InjectorID; }
            set { m_InjectorID = value; }
        }

        public string InjectorName
        {
            get { return m_InjectorName; }
            set { m_InjectorName = value; }
        }

        public string InjectorSex
        {
            get { return m_InjectorSex; }
            set { m_InjectorSex = value; }
        }

        public string InjectorPhone
        {
            get { return m_InjectorPhone; }
            set { m_InjectorPhone = value; }
        }

        public int InjectorNumber
        {
            get { return m_InjectorNumber; }
            set { m_InjectorNumber = value; }
        }

        public DateTime InjectorTime
        {
            get { return m_InjectorTime; }
            set { m_InjectorTime = value; }
        }
    }

    public class QueryInjector
    {
        private int? m_InjectorID;
        private string m_InjectorName;
        private string m_InjectorSex;
        private string m_InjectorPhone;
        private int? m_InjectorNumber;
        private DateTime? m_InjectorTime;

        public int? InjectorID
        {
            get { return m_InjectorID; }
            set { m_InjectorID = value; }
        }

        public string InjectorName
        {
            get { return m_InjectorName; }
            set { m_InjectorName = value; }
        }

        public string InjectorSex
        {
            get { return m_InjectorSex; }
            set { m_InjectorSex = value; }
        }

        public string InjectorPhone
        {
            get { return m_InjectorPhone; }
            set { m_InjectorPhone = value; }
        }

        public int? InjectorNumber
        {
            get { return m_InjectorNumber; }
            set { m_InjectorNumber = value; }
        }

        public DateTime? InjectorTime
        {
            get { return m_InjectorTime; }
            set { m_InjectorTime = value; }
        }
    }
}
