using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackEnd.BusinessEntities;

namespace BackEnd.DataAccess
{
    public class DAUtil
    {
        public static ManagerUser ReadManagerUser(IDataReader reader)
        {
            ManagerUser itm = new ManagerUser();

            itm.UserID = ReadInt(reader, "UserID");
            itm.UserName = ReadValue<string>(reader, "UserName");
            itm.UserPassword = ReadValue<string>(reader, "UserPassword");
            itm.UserSort = ReadValue<string>(reader, "UserSort");

            return itm;
        }

        public static ManagerUserPicture ReadManagerUserPicture(IDataReader reader)
        {
            ManagerUserPicture itm = new ManagerUserPicture();

            itm.UserPicID = ReadInt(reader, "UserPicID");
            itm.UserID = ReadInt(reader, "UserID");
            itm.UserPic = ReadValue<byte[]>(reader, "UserPic");

            return itm;
        }

        public static InjectionMessage ReadInjectionMessage(IDataReader reader)
        {
            InjectionMessage itm = new InjectionMessage();

            itm.InjectionMessageID = ReadInt(reader, "InjectionMessageID");
            itm.InjectorID = ReadInt(reader, "InjectorID");
            itm.InjectorName = ReadValue<string>(reader, "InjectorName");
            itm.VaccineID = ReadInt(reader, "VaccineID");
            itm.VaccineName = ReadValue<string>(reader, "VaccineName");
            itm.InjectionMessageSite = ReadValue<string>(reader, "InjectionMessageSite");
            itm.InjectionMessageTime = ReadDateTime(reader, "InjectionMessageTime");
            itm.InjectionMessageDoctor = ReadValue<string>(reader, "InjectionMessageDoctor");

            return itm;
        }

        public static Injector ReadInjector(IDataReader reader)
        {
            Injector itm = new Injector();

            itm.InjectorID = ReadInt(reader, "InjectorID");
            itm.InjectorName = ReadValue<string>(reader, "InjectorName");
            itm.InjectorSex = ReadValue<string>(reader, "InjectorSex");
            itm.InjectorPhone = ReadValue<string>(reader, "InjectorPhone");
            itm.InjectorNumber = ReadInt(reader, "InjectorNumber");
            itm.InjectorTime = ReadDateTime(reader, "InjectorTime");

            return itm;
        }

        public static Manufacturers ReadManufacturers(IDataReader reader)
        {
            Manufacturers itm = new Manufacturers();

            itm.ManufacturersID = ReadInt(reader, "ManufacturersID");
            itm.ManufacturersName = ReadValue<string>(reader, "ManufacturersName");
            itm.ManufacturersSite = ReadValue<string>(reader, "ManufacturersSite");
            itm.ManufacturersPhone = ReadValue<string>(reader, "ManufacturersPhone");
            itm.ManufacturersDom = ReadDateTime(reader, "ManufacturersDom");
            itm.ManufacturersDoe = ReadDateTime(reader, "ManufacturersDoe");

            return itm;
        }

        public static Vaccine ReadVaccine(IDataReader reader)
        {
            Vaccine itm = new Vaccine();

            itm.VaccineID = ReadInt(reader, "VaccineID");
            itm.VaccineName = ReadValue<string>(reader, "VaccineName");
            itm.VaccineSort = ReadValue<string>(reader, "VaccineSort");
            itm.ManufacturersID = ReadInt(reader, "ManufacturersID");
            itm.VaccinePrice = ReadValue<decimal>(reader, "VaccinePrice");
            itm.VaccineQuantity = ReadInt(reader, "VaccineQuantity");


            return itm;
        }

        #region Privates

        private static T ReadValue<T>(IDataReader reader, string name)
        {
            object o = reader[name];

            if (Convert.IsDBNull(o) && (default(T) == null))
                return default(T);
            else if (Convert.IsDBNull(o) && (default(T) != null))
                throw new Exception("Invalid value in column [" + name + "]!");
            else
                return (T)o;
        }

        private static int ReadInt(IDataReader reader, string name)
        {
            return Convert.ToInt32(ReadValue<int>(reader, name));
        }

        private static float ReadFloat(IDataReader reader, string name)
        {

            return ReadValue<float>(reader, name);

        }

        private static int? ReadNullableInt(IDataReader reader, string name)
        {
            if (Convert.IsDBNull(reader[name]))
                return null;

            return ReadInt(reader, name);
        }

        private static DateTime ReadDateTime(IDataReader reader, string name)
        {
            return Convert.ToDateTime(ReadValue<DateTime>(reader, name));
        }

        private static DateTime? ReadNullableDateTime(IDataReader reader, string name)
        {
            if (Convert.IsDBNull(reader[name]))
                return null;

            return ReadDateTime(reader, name);
        }

        #endregion
    }
}
