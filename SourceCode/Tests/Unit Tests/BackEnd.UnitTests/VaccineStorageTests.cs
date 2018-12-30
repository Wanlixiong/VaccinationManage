using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.BusinessEntities;
using BackEnd.DataAccess;
using BackEnd.Lib;
using NUnit.Framework;

namespace BackEnd.UnitTests
{
    [TestFixture]

    public class VaccineStorageTests : BaseTests
    {
        #region Init
        //#region 是 C# 预处理器指令。
        //#region 是一个分块预处理命令，它主要是用于编辑器代码的分块，
        //在编译时会被自动删除。

        [SetUp]
        //这个属性用来修饰方法，表明它会在每一个测试方法运行之前运行。
        //那么可以用它来重设一些变量，是每个方法在运行之前都有良好的初值。
        public override void SetUp()
        {
            base.SetUp();
        }


        [TestFixtureSetUp]
        //这个属性通常用来修饰一个方法，表明这个方法先于所有测试方法之前运行，
        //类似于构造函数,那么我们可以用来初始化一些对象等

        public virtual void SetUpFixture()
        {

        }

        #endregion

        #region getManufacturersID

        private static int getManufacturersID()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商",
                "浙江温州",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            return createdManufacturers.ManufacturersID;
        }


        #endregion

        #region getManufacturersIDtwo

        private static int getManufacturersIDtwo()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商21",
                "浙江温州21",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            return createdManufacturers.ManufacturersID;
        }


        #endregion

        #region Test CreateVaccine Method

        [Test]
        public void VaccineCreateSuccess()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗",
                "处方",
                getManufacturersID(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            Assert.AreNotEqual(
                0,
                createdVaccine.VaccineID,
                string.Format("Could not create Vaccine:{0}",
                              createdVaccine.VaccineID));

            AssertVaccineItemEqual(myVaccine, createdVaccine);
        }

        [Test]
        //测试方法
        [ExpectedException(typeof(ArgumentNullException))]
        //这个属性其实非常有用处，它表明这个函数会抛出一个预期的异常。
        public void VaccineCreateFailureVaccineArgumentNullException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            vaccineStorage.CreateVaccine(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VaccineCreateFailureVaccineNameArgumentException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "",
                "处方",
                getManufacturersID(),
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VaccineCreateFailureVaccineNameArgumentNullException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                null,
                "处方",
                getManufacturersID(),
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VaccineCreateFailureManufacturersIDArgumentException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗",
                "处方",
                -1,
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);
        }


        #endregion

        #region Test ReadVaccine Method

        [Test]
        public void VaccineReadSuccess()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗",
                "处方",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            Assert.AreNotEqual(
                0,
                createdVaccine.VaccineID,
                string.Format("Could not create Vaccine:{0}",
                              createdVaccine.VaccineID));

            Vaccine readedVaccine = vaccineStorage.ReadVaccine(
                createdVaccine.VaccineID);

            AssertVaccineItemEqual(createdVaccine, readedVaccine);
        }


        [Test]
        [ExpectedException(ExpectedMessage = "Vaccine read failure!")]
        public void VaccineReadFailureVaccineIdArgumentException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            //    Vaccine myVaccine = CreateVaccineForTest(
            //    "狂犬疫苗",
            //    "处方",
            //    getManufacturersIDtwo(),
            //    "68.00",
            //    "45");

            //    Vaccine createdVaccine =
            //    vaccineStorage.CreateVaccine(myVaccine);
            vaccineStorage.ReadVaccine(-1);
        }

        #endregion

        #region Test UpdateVaccine Method

        [Test]
        public void VaccineUpdateSuccessOne()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            Assert.AreNotEqual(
                0,
                createdVaccine.VaccineID,
                string.Format("Could not create Vaccine:{0}",
                              createdVaccine.VaccineID));

            myVaccine.VaccineName = "狂犬疫苗2";

            vaccineStorage.UpdateVaccine(myVaccine);

            Vaccine updatedVaccine = vaccineStorage.ReadVaccine(
                createdVaccine.VaccineID);

            AssertVaccineItemEqual(myVaccine, updatedVaccine);
        }


        [Test]
        public void VaccineUpdateSuccessTwo()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            Assert.AreNotEqual(
                0,
                createdVaccine.VaccineID,
                string.Format("Could not create Vaccine:{0}",
                              createdVaccine.VaccineID));

            myVaccine.VaccineSort = "处方334";

            vaccineStorage.UpdateVaccine(myVaccine);

            Vaccine updatedVaccine = vaccineStorage.ReadVaccine(
                createdVaccine.VaccineID);

            AssertVaccineItemEqual(myVaccine, updatedVaccine);
        }


        [Test]
        public void VaccineUpdateSuccessThree()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersID(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            Assert.AreNotEqual(
                0,
                createdVaccine.VaccineID,
                string.Format("Could not create Vaccine:{0}",
                              createdVaccine.VaccineID));

            myVaccine.ManufacturersID = getManufacturersIDtwo();

            vaccineStorage.UpdateVaccine(myVaccine);

            Vaccine updatedVaccine = vaccineStorage.ReadVaccine(
                createdVaccine.VaccineID);

            AssertVaccineItemEqual(myVaccine, updatedVaccine);
        }


        [Test]
        public void VaccineUpdateSuccessFour()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            Assert.AreNotEqual(
                0,
                createdVaccine.VaccineID,
                string.Format("Could not create Vaccine:{0}",
                              createdVaccine.VaccineID));

            myVaccine.VaccinePrice = Convert.ToDecimal("72.80");

            vaccineStorage.UpdateVaccine(myVaccine);

            Vaccine updatedVaccine = vaccineStorage.ReadVaccine(
                createdVaccine.VaccineID);

            AssertVaccineItemEqual(myVaccine, updatedVaccine);
        }


        [Test]
        public void VaccineUpdateSuccessFive()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            Assert.AreNotEqual(
                0,
                createdVaccine.VaccineID,
                string.Format("Could not create Vaccine:{0}",
                              createdVaccine.VaccineID));

            myVaccine.VaccineQuantity = Convert.ToInt32("60");

            vaccineStorage.UpdateVaccine(myVaccine);

            Vaccine updatedVaccine = vaccineStorage.ReadVaccine(
                createdVaccine.VaccineID);

            AssertVaccineItemEqual(myVaccine, updatedVaccine);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VaccineUpdateFailureVaccineArgumentNullException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            vaccineStorage.UpdateVaccine(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VaccineUpdateFailureVaccineVaccineIdArgumentException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);

            myVaccine.VaccineID = -1;

            vaccineStorage.UpdateVaccine(myVaccine);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VaccineUpdateFailureVaccineNameArgumentException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);

            myVaccine.VaccineName = "";

            vaccineStorage.UpdateVaccine(myVaccine);

        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VaccineUpdateFailureVaccineNameArgumentNullException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);

            myVaccine.VaccineName = null;

            vaccineStorage.UpdateVaccine(myVaccine);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VaccineUpdateFailureManufacturersIdArgumentException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);

            myVaccine.ManufacturersID = -1;

            vaccineStorage.UpdateVaccine(myVaccine);
        }


        [Test]
        [ExpectedException(ExpectedMessage = "Vaccine update failure!")]
        public void VaccineUpdateFailureVaccineIdArgumentException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗1",
                "处方1",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            vaccineStorage.CreateVaccine(myVaccine);

            myVaccine.VaccineID = int.MaxValue;

            vaccineStorage.UpdateVaccine(myVaccine);
        }

        #endregion

        #region Test ListVaccine Method

        [Test]
        public void VaccineListSuccess()
        {
            List<Vaccine> vaccineList = new List<Vaccine>();

            IVaccineStorage vaccineStorage = new VaccineStorage();

            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗11",
                "处方11",
                getManufacturersID(),
                "68.00",
                "45");

            Vaccine createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            vaccineList.Add(createdVaccine);

            myVaccine = CreateVaccineForTest(
                "狂犬疫苗12",
                "处方11",
                createdVaccine.ManufacturersID,
                "68.00",
                "45");

            createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            vaccineList.Add(createdVaccine);

            myVaccine = CreateVaccineForTest(
                "狂犬疫苗12",
                "处方12",
                createdVaccine.ManufacturersID,
                "68.00",
                "45");

            createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            vaccineList.Add(createdVaccine);

            myVaccine = CreateVaccineForTest(
                "狂犬疫苗12",
                "处方12",
                getManufacturersIDtwo(),
                "68.00",
                "45");

            createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            vaccineList.Add(createdVaccine);

            myVaccine = CreateVaccineForTest(
                "狂犬疫苗12",
                "处方12",
                createdVaccine.ManufacturersID,
                "72.80",
                "45");

            createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            vaccineList.Add(createdVaccine);

            myVaccine = CreateVaccineForTest(
                "狂犬疫苗12",
                "处方12",
                createdVaccine.ManufacturersID,
                "72.80",
                "60");

            createdVaccine =
                vaccineStorage.CreateVaccine(myVaccine);

            vaccineList.Add(createdVaccine);

            QueryVaccine queryVaccine = new QueryVaccine();

            queryVaccine.VaccineID = null;
            queryVaccine.VaccineName = null;
            queryVaccine.VaccineSort = null;
            queryVaccine.ManufacturersID = null;
            queryVaccine.VaccinePrice = null;
            queryVaccine.VaccineQuantity = null;

            IList<Vaccine> readedVaccineList =
                vaccineStorage.ListVaccine(queryVaccine);

            AssertVaccineListsEqual(vaccineList, readedVaccineList);

            vaccineList.RemoveAt(0);

            queryVaccine = new QueryVaccine();

            queryVaccine.VaccineID = null;
            queryVaccine.VaccineName = "狂犬疫苗12";
            queryVaccine.VaccineSort = null;
            queryVaccine.ManufacturersID = null;
            queryVaccine.VaccinePrice = null;
            queryVaccine.VaccineQuantity = null;

            readedVaccineList =
                vaccineStorage.ListVaccine(queryVaccine);

            AssertVaccineListsEqual(vaccineList, readedVaccineList);

            vaccineList.RemoveAt(0);

            queryVaccine = new QueryVaccine();

            queryVaccine.VaccineID = null;
            queryVaccine.VaccineName = null;
            queryVaccine.VaccineSort = "处方12";
            queryVaccine.ManufacturersID = null;
            queryVaccine.VaccinePrice = null;
            queryVaccine.VaccineQuantity = null;

            readedVaccineList =
                vaccineStorage.ListVaccine(queryVaccine);

            AssertVaccineListsEqual(vaccineList, readedVaccineList);

            vaccineList.RemoveAt(0);

            queryVaccine = new QueryVaccine();

            queryVaccine.VaccineID = null;
            queryVaccine.VaccineName = null;
            queryVaccine.VaccineSort = null;
            queryVaccine.ManufacturersID = createdVaccine.ManufacturersID;
            queryVaccine.VaccinePrice = null;
            queryVaccine.VaccineQuantity = null;

            readedVaccineList =
                vaccineStorage.ListVaccine(queryVaccine);

            AssertVaccineListsEqual(vaccineList, readedVaccineList);

            vaccineList.RemoveAt(0);

            queryVaccine = new QueryVaccine();

            queryVaccine.VaccineID = null;
            queryVaccine.VaccineName = null;
            queryVaccine.VaccineSort = null;
            queryVaccine.ManufacturersID = null;
            queryVaccine.VaccinePrice = Convert.ToDecimal("72.80");
            queryVaccine.VaccineQuantity = null;

            readedVaccineList =
                vaccineStorage.ListVaccine(queryVaccine);

            AssertVaccineListsEqual(vaccineList, readedVaccineList);

            vaccineList.RemoveAt(0);

            queryVaccine = new QueryVaccine();

            queryVaccine.VaccineID = null;
            queryVaccine.VaccineName = null;
            queryVaccine.VaccineSort = null;
            queryVaccine.ManufacturersID = null;
            queryVaccine.VaccinePrice = null;
            queryVaccine.VaccineQuantity = Convert.ToInt32("60");

            readedVaccineList =
                vaccineStorage.ListVaccine(queryVaccine);

            AssertVaccineListsEqual(vaccineList, readedVaccineList);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VaccineListFailureVaccineArgumentNullException()
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();

            vaccineStorage.ListVaccine(null);
        }

        #endregion

        #region Private methods

        private static void AssertVaccineListsEqual(
            IList<Vaccine> expected,
            IList<Vaccine> actual)
        {
            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    for (int j = 0; j < actual.Count; j++)
                    {
                        if (expected[i].VaccineID == actual[j].VaccineID)
                        {
                            AssertVaccineItemEqual(
                                expected[i],
                                actual[j]);
                        }
                    }
                }
            }

            else
            {
                Assert.Fail("The number of Vaccine list  is not equal!");
            }

        }

        private static void AssertVaccineItemEqual(
            Vaccine pVaccine,
            Vaccine pCreatedVaccine)
        {
            Assert.AreEqual(
                pVaccine.VaccineID,
                pCreatedVaccine.VaccineID,
                string.Format("VaccineID isn't equal!"));
            Assert.AreEqual(
                pVaccine.VaccineName,
                pCreatedVaccine.VaccineName,
                string.Format("VaccineName isn't equal!"));
            Assert.AreEqual(
                pVaccine.VaccineSort,
                pCreatedVaccine.VaccineSort,
                string.Format("VaccineSort isn't equal!"));
            Assert.AreEqual(
                pVaccine.ManufacturersID,
                pCreatedVaccine.ManufacturersID,
                string.Format("ManufacturersID isn't equal!"));
            Assert.AreEqual(
                pVaccine.VaccinePrice,
                pCreatedVaccine.VaccinePrice,
                string.Format("VaccinePrice isn't equal!"));
            Assert.AreEqual(
                pVaccine.VaccineQuantity,
                pCreatedVaccine.VaccineQuantity,
                string.Format("VaccineQuantity isn't equal!"));
        }

        private static Vaccine CreateVaccineForTest(
            string pVaccineName,
            string pVaccineSort,
            int pManufacturersID,
            string pVaccinePrice,
            string pVaccineQuantity)
        {
            Vaccine myVaccine = new Vaccine();

            myVaccine.VaccineName = pVaccineName;
            myVaccine.VaccineSort = pVaccineSort;
            myVaccine.ManufacturersID = pManufacturersID;
            myVaccine.VaccinePrice = Convert.ToDecimal(pVaccinePrice);
            myVaccine.VaccineQuantity = Convert.ToInt32(pVaccineQuantity);

            return myVaccine;
        }

        private static Manufacturers CreateManufacturersForTest(
            string pManufacturersName,
            string pManufacturersSite,
            string pManufacturersPhone,
            string pManufacturersDom,
            string pManufacturersDoe)
        {
            Manufacturers myManufacturers = new Manufacturers();

            myManufacturers.ManufacturersName = pManufacturersName;
            myManufacturers.ManufacturersSite = pManufacturersSite;
            myManufacturers.ManufacturersPhone = pManufacturersPhone;
            myManufacturers.ManufacturersDom = Convert.ToDateTime(pManufacturersDom);
            myManufacturers.ManufacturersDoe = Convert.ToDateTime(pManufacturersDoe);

            return myManufacturers;
        }


        #endregion
    }
}