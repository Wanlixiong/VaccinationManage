using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.BusinessEntities
{
    public class Manufacturers
    {
        private int m_ManufacturersID;
        private string m_ManufacturersName;
        private string m_ManufacturersSite;
        private string m_ManufacturersPhone;
        private DateTime m_ManufacturersDom;
        private DateTime m_ManufacturersDoe;

        public int ManufacturersID
        {
            get { return m_ManufacturersID; }
            set { m_ManufacturersID = value; }
        }

        public string ManufacturersName
        {
            get { return m_ManufacturersName; }
            set { m_ManufacturersName = value; }
        }

        public string ManufacturersSite
        {
            get { return m_ManufacturersSite; }
            set { m_ManufacturersSite = value; }
        }

        public string ManufacturersPhone
        {
            get { return m_ManufacturersPhone; }
            set { m_ManufacturersPhone = value; }
        }

        public DateTime ManufacturersDom
        {
            get { return m_ManufacturersDom; }
            set { m_ManufacturersDom = value; }
        }

        public DateTime ManufacturersDoe
        {
            get { return m_ManufacturersDoe; }
            set { m_ManufacturersDoe = value; }
        }
    }

    public class QueryManufacturers
    {
        private int? m_ManufacturersID;
        private string m_ManufacturersName;
        private string m_ManufacturersSite;
        private string m_ManufacturersPhone;
        private DateTime? m_ManufacturersDom;
        private DateTime? m_ManufacturersDoe;

        public int? ManufacturersID
        {
            get { return m_ManufacturersID; }
            set { m_ManufacturersID = value; }
        }

        public string ManufacturersName
        {
            get { return m_ManufacturersName; }
            set { m_ManufacturersName = value; }
        }

        public string ManufacturersSite
        {
            get { return m_ManufacturersSite; }
            set { m_ManufacturersSite = value; }
        }

        public string ManufacturersPhone
        {
            get { return m_ManufacturersPhone; }
            set { m_ManufacturersPhone = value; }
        }

        public DateTime? ManufacturersDom
        {
            get { return m_ManufacturersDom; }
            set { m_ManufacturersDom = value; }
        }

        public DateTime? ManufacturersDoe
        {
            get { return m_ManufacturersDoe; }
            set { m_ManufacturersDoe = value; }
        }
    }
}
