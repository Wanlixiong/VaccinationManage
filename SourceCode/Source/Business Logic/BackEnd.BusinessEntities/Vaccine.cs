using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.BusinessEntities
{
    public class Vaccine
    {
        private int m_VaccineID;
        private string m_VaccineName;
        private string m_VaccineSort;
        private int m_ManufacturersID;
        private decimal m_VaccinePrice;
        private int m_VaccineQuantity;
        private string m_ManufacturersName;

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

        public string VaccineSort
        {
            get { return m_VaccineSort; }
            set { m_VaccineSort = value; }
        }

        public int ManufacturersID
        {
            get { return m_ManufacturersID; }
            set { m_ManufacturersID = value; }
        }

        public decimal VaccinePrice
        {
            get { return m_VaccinePrice; }
            set { m_VaccinePrice = value; }
        }

        public int VaccineQuantity
        {
            get { return m_VaccineQuantity; }
            set { m_VaccineQuantity = value; }
        }

        public string ManufacturersName
        {
            get { return m_ManufacturersName; }
            set { m_ManufacturersName = value; }
        }
    }

    public class QueryVaccine
    {
        private int? m_VaccineID;
        private string m_VaccineName;
        private string m_VaccineSort;
        private int? m_ManufacturersID;
        private decimal? m_VaccinePrice;
        private int? m_VaccineQuantity;
        private string m_ManufacturersName;

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

        public string VaccineSort
        {
            get { return m_VaccineSort; }
            set { m_VaccineSort = value; }
        }

        public int? ManufacturersID
        {
            get { return m_ManufacturersID; }
            set { m_ManufacturersID = value; }
        }

        public decimal? VaccinePrice
        {
            get { return m_VaccinePrice; }
            set { m_VaccinePrice = value; }
        }

        public int? VaccineQuantity
        {
            get { return m_VaccineQuantity; }
            set { m_VaccineQuantity = value; }
        }

        public string ManufacturersName
        {
            get { return m_ManufacturersName; }
            set { m_ManufacturersName = value; }
        }
    }
}
