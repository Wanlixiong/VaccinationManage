using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.BusinessEntities
{
    public class InjectionMessage
    {
        private int m_InjectionMessageID;
        private int m_InjectorID;
        private string m_InjectorName;
        private int m_VaccineID;
        private string m_VaccineName;
        private string m_InjectionMessageSite;
        private DateTime m_InjectionMessageTime;
        private string m_InjectionMessageDoctor;

        public int InjectionMessageID
        {
            get { return m_InjectionMessageID; }
            set { m_InjectionMessageID = value; }
        }

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

        public int VaccineID
        {
            get { return m_VaccineID; }
            set { m_VaccineID = value; }
        }

        public string VaccineName
        {
            get { return m_VaccineName; }
            set { m_VaccineName = value; }
        }

        public string InjectionMessageSite
        {
            get { return m_InjectionMessageSite; }
            set { m_InjectionMessageSite = value; }
        }

        public DateTime InjectionMessageTime
        {
            get { return m_InjectionMessageTime; }
            set { m_InjectionMessageTime = value; }
        }

        public string InjectionMessageDoctor
        {
            get { return m_InjectionMessageDoctor; }
            set { m_InjectionMessageDoctor = value; }
        }
    }

    public class QueryInjectionMessage
    {
        private int? m_InjectionMessageID;
        private int? m_InjectorID;
        private string m_InjectorName;
        private int? m_VaccineID;
        private string m_VaccineName;
        private string m_InjectionMessageSite;
        private DateTime? m_InjectionMessageTime;
        private string m_InjectionMessageDoctor;

        public int? InjectionMessageID
        {
            get { return m_InjectionMessageID; }
            set { m_InjectionMessageID = value; }
        }

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

        public int? VaccineID
        {
            get { return m_VaccineID; }
            set { m_VaccineID = value; }
        }

        public string VaccineName
        {
            get { return m_VaccineName; }
            set { m_VaccineName = value; }
        }

        public string InjectionMessageSite
        {
            get { return m_InjectionMessageSite; }
            set { m_InjectionMessageSite = value; }
        }

        public DateTime? InjectionMessageTime
        {
            get { return m_InjectionMessageTime; }
            set { m_InjectionMessageTime = value; }
        }

        public string InjectionMessageDoctor
        {
            get { return m_InjectionMessageDoctor; }
            set { m_InjectionMessageDoctor = value; }
        }
    }
}
