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

    public class ManufacturersStorageTests : BaseTests
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

        #region Test CreateManufacturers Method

        [Test]
        public void ManufacturersCreateSuccess()
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

            Assert.AreNotEqual(
                0,
                createdManufacturers.ManufacturersID,
                string.Format("Could not create Manufacturers:{0}",
                              createdManufacturers.ManufacturersID));

            AssertManufacturersItemEqual(myManufacturers, createdManufacturers);
        }

        [Test]
        //测试方法
        [ExpectedException(typeof(ArgumentNullException))]
        //这个属性其实非常有用处，它表明这个函数会抛出一个预期的异常。
        public void ManufacturersCreateFailureManufacturersArgumentNullException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            manufacturersStorage.CreateManufacturers(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManufacturersCreateFailureManufacturersNameArgumentException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "",
                "浙江温州1",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManufacturersCreateFailureManufacturersNameArgumentNullException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                null,
                "浙江温州2",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManufacturersCreateFailureManufacturersSiteArgumentException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商1",
                "",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManufacturersCreateFailureManufacturersSiteArgumentNullException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商2",
                null,
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

        }


        #endregion

        #region Test ReadManufacturers Method

        [Test]
        public void ManufacturersReadSuccess()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商3",
                "浙江温州3",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            Assert.AreNotEqual(
                0,
                createdManufacturers.ManufacturersID,
                string.Format("Could not create Manufacturers:{0}",
                              createdManufacturers.ManufacturersID));

            Manufacturers readedManufacturers = manufacturersStorage.ReadManufacturers(
                createdManufacturers.ManufacturersID);

            AssertManufacturersItemEqual(createdManufacturers, readedManufacturers);
        }


        [Test]
        [ExpectedException(ExpectedMessage = "Manufacturers read failure!")]
        public void ManufacturersReadFailureManufacturersIdArgumentException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            //    Manufacturers myManufacturers = CreateManufacturersForTest(
            //    "供应商3",
            //    "浙江温州3",
            //    "17733117779",
            //    "2013-06-30",
            //    "2016-06-30");

            //    Manufacturers createdManufacturers =
            //    manufacturersStorage.CreateManufacturers(myManufacturers);
            manufacturersStorage.ReadManufacturers(-1);
        }

        #endregion

        #region Test UpdateManufacturers Method

        [Test]
        public void ManufacturersUpdateSuccessOne()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            Assert.AreNotEqual(
                0,
                createdManufacturers.ManufacturersID,
                string.Format("Could not create Manufacturers:{0}",
                              createdManufacturers.ManufacturersID));

            myManufacturers.ManufacturersName = "供应商5";

            manufacturersStorage.UpdateManufacturers(myManufacturers);

            Manufacturers updatedManufacturers = manufacturersStorage.ReadManufacturers(
                createdManufacturers.ManufacturersID);

            AssertManufacturersItemEqual(myManufacturers, updatedManufacturers);
        }


        [Test]
        public void ManufacturersUpdateSuccessTwo()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            Assert.AreNotEqual(
                0,
                createdManufacturers.ManufacturersID,
                string.Format("Could not create Manufacturers:{0}",
                              createdManufacturers.ManufacturersID));

            myManufacturers.ManufacturersSite = "浙江温州5";

            manufacturersStorage.UpdateManufacturers(myManufacturers);

            Manufacturers updatedManufacturers = manufacturersStorage.ReadManufacturers(
                createdManufacturers.ManufacturersID);

            AssertManufacturersItemEqual(myManufacturers, updatedManufacturers);
        }


        [Test]
        public void ManufacturersUpdateSuccessThree()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            Assert.AreNotEqual(
                0,
                createdManufacturers.ManufacturersID,
                string.Format("Could not create Manufacturers:{0}",
                              createdManufacturers.ManufacturersID));

            myManufacturers.ManufacturersPhone = "17733117799";

            manufacturersStorage.UpdateManufacturers(myManufacturers);

            Manufacturers updatedManufacturers = manufacturersStorage.ReadManufacturers(
                createdManufacturers.ManufacturersID);

            AssertManufacturersItemEqual(myManufacturers, updatedManufacturers);
        }


        [Test]
        public void ManufacturersUpdateSuccessFour()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            Assert.AreNotEqual(
                0,
                createdManufacturers.ManufacturersID,
                string.Format("Could not create Manufacturers:{0}",
                              createdManufacturers.ManufacturersID));

            myManufacturers.ManufacturersDom = Convert.ToDateTime("2016-05-30");

            manufacturersStorage.UpdateManufacturers(myManufacturers);

            Manufacturers updatedManufacturers = manufacturersStorage.ReadManufacturers(
                createdManufacturers.ManufacturersID);

            AssertManufacturersItemEqual(myManufacturers, updatedManufacturers);
        }


        [Test]
        public void ManufacturersUpdateSuccessFive()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            Assert.AreNotEqual(
                0,
                createdManufacturers.ManufacturersID,
                string.Format("Could not create Manufacturers:{0}",
                              createdManufacturers.ManufacturersID));

            myManufacturers.ManufacturersDoe = Convert.ToDateTime("2016-06-30");

            manufacturersStorage.UpdateManufacturers(myManufacturers);

            Manufacturers updatedManufacturers = manufacturersStorage.ReadManufacturers(
                createdManufacturers.ManufacturersID);

            AssertManufacturersItemEqual(myManufacturers, updatedManufacturers);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManufacturersUpdateFailureManufacturersArgumentNullException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            manufacturersStorage.UpdateManufacturers(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManufacturersUpdateFailureManufacturersManufacturersIdArgumentException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

            myManufacturers.ManufacturersID = -1;

            manufacturersStorage.UpdateManufacturers(myManufacturers);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManufacturersUpdateFailureManufacturersNameArgumentException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

            myManufacturers.ManufacturersName = "";

            manufacturersStorage.UpdateManufacturers(myManufacturers);

        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManufacturersUpdateFailureManufacturersNameArgumentNullException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

            myManufacturers.ManufacturersName = null;

            manufacturersStorage.UpdateManufacturers(myManufacturers);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManufacturersUpdateFailureManufacturersSiteArgumentException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

            myManufacturers.ManufacturersSite = "";

            manufacturersStorage.UpdateManufacturers(myManufacturers);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManufacturersUpdateFailureManufacturersSiteArgumentNullException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

            myManufacturers.ManufacturersSite = null;

            manufacturersStorage.UpdateManufacturers(myManufacturers);

        }


        [Test]
        [ExpectedException(ExpectedMessage = "Manufacturers update failure!")]
        public void ManufacturersUpdateFailureManufacturersIdArgumentException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商4",
                "浙江温州4",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            manufacturersStorage.CreateManufacturers(myManufacturers);

            myManufacturers.ManufacturersID = int.MaxValue;

            manufacturersStorage.UpdateManufacturers(myManufacturers);
        }

        #endregion

        #region Test ListManufacturers Method

        [Test]
        public void ManufacturersListSuccess()
        {
            List<Manufacturers> manufacturersList = new List<Manufacturers>();

            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();

            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商11",
                "浙江温州11",
                "17733117711",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            manufacturersList.Add(createdManufacturers);

            myManufacturers = CreateManufacturersForTest(
                "供应商12",
                "浙江温州11",
                "17733117711",
                "2013-06-30",
                "2016-06-30");

            createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            manufacturersList.Add(createdManufacturers);

            myManufacturers = CreateManufacturersForTest(
                "供应商12",
                "浙江温州12",
                "17733117711",
                "2013-06-30",
                "2016-06-30");

            createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            manufacturersList.Add(createdManufacturers);

            myManufacturers = CreateManufacturersForTest(
                "供应商12",
                "浙江温州12",
                "17733117712",
                "2013-06-30",
                "2016-06-30");

            createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            manufacturersList.Add(createdManufacturers);

            myManufacturers = CreateManufacturersForTest(
                "供应商12",
                "浙江温州12",
                "17733117712",
                "2013-06-29",
                "2016-06-30");

            createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            manufacturersList.Add(createdManufacturers);

            myManufacturers = CreateManufacturersForTest(
                "供应商12",
                "浙江温州12",
                "17733117712",
                "2013-06-29",
                "2016-06-29");

            createdManufacturers =
                manufacturersStorage.CreateManufacturers(myManufacturers);

            manufacturersList.Add(createdManufacturers);

            QueryManufacturers queryManufacturers = new QueryManufacturers();

            queryManufacturers.ManufacturersID = null;
            queryManufacturers.ManufacturersName = null;
            queryManufacturers.ManufacturersSite = null;
            queryManufacturers.ManufacturersPhone = null;
            queryManufacturers.ManufacturersDom = null;
            queryManufacturers.ManufacturersDoe = null;

            IList<Manufacturers> readedManufacturersList =
                manufacturersStorage.ListManufacturers(queryManufacturers);

            AssertManufacturersListsEqual(manufacturersList, readedManufacturersList);

            manufacturersList.RemoveAt(0);

            queryManufacturers = new QueryManufacturers();

            queryManufacturers.ManufacturersID = null;
            queryManufacturers.ManufacturersName = "供应商12";
            queryManufacturers.ManufacturersSite = null;
            queryManufacturers.ManufacturersPhone = null;
            queryManufacturers.ManufacturersDom = null;
            queryManufacturers.ManufacturersDoe = null;

            readedManufacturersList =
                manufacturersStorage.ListManufacturers(queryManufacturers);

            AssertManufacturersListsEqual(manufacturersList, readedManufacturersList);

            manufacturersList.RemoveAt(0);

            queryManufacturers = new QueryManufacturers();

            queryManufacturers.ManufacturersID = null;
            queryManufacturers.ManufacturersName = null;
            queryManufacturers.ManufacturersSite = "浙江温州12";
            queryManufacturers.ManufacturersPhone = null;
            queryManufacturers.ManufacturersDom = null;
            queryManufacturers.ManufacturersDoe = null;

            readedManufacturersList =
                manufacturersStorage.ListManufacturers(queryManufacturers);

            AssertManufacturersListsEqual(manufacturersList, readedManufacturersList);

            manufacturersList.RemoveAt(0);

            queryManufacturers = new QueryManufacturers();

            queryManufacturers.ManufacturersID = null;
            queryManufacturers.ManufacturersName = null;
            queryManufacturers.ManufacturersSite = null;
            queryManufacturers.ManufacturersPhone = "17733117712";
            queryManufacturers.ManufacturersDom = null;
            queryManufacturers.ManufacturersDoe = null;

            readedManufacturersList =
                manufacturersStorage.ListManufacturers(queryManufacturers);

            AssertManufacturersListsEqual(manufacturersList, readedManufacturersList);

            manufacturersList.RemoveAt(0);

            queryManufacturers = new QueryManufacturers();

            queryManufacturers.ManufacturersID = null;
            queryManufacturers.ManufacturersName = null;
            queryManufacturers.ManufacturersSite = null;
            queryManufacturers.ManufacturersPhone = null;
            queryManufacturers.ManufacturersDom = Convert.ToDateTime("2013-06-29");
            queryManufacturers.ManufacturersDoe = null;

            readedManufacturersList =
                manufacturersStorage.ListManufacturers(queryManufacturers);

            AssertManufacturersListsEqual(manufacturersList, readedManufacturersList);

            manufacturersList.RemoveAt(0);

            queryManufacturers = new QueryManufacturers();

            queryManufacturers.ManufacturersID = null;
            queryManufacturers.ManufacturersName = null;
            queryManufacturers.ManufacturersSite = null;
            queryManufacturers.ManufacturersPhone = null;
            queryManufacturers.ManufacturersDom = null;
            queryManufacturers.ManufacturersDoe = Convert.ToDateTime("2016-06-29");

            readedManufacturersList =
                manufacturersStorage.ListManufacturers(queryManufacturers);

            AssertManufacturersListsEqual(manufacturersList, readedManufacturersList);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManufacturersListFailureManufacturersArgumentNullException()
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();

            manufacturersStorage.ListManufacturers(null);
        }

        #endregion

        #region Private methods

        private static void AssertManufacturersListsEqual(
            IList<Manufacturers> expected,
            IList<Manufacturers> actual)
        {
            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    for (int j = 0; j < actual.Count; j++)
                    {
                        if (expected[i].ManufacturersID == actual[j].ManufacturersID)
                        {
                            AssertManufacturersItemEqual(
                                expected[i],
                                actual[j]);
                        }
                    }
                }
            }

            else
            {
                Assert.Fail("The number of Manufacturers list  is not equal!");
            }

        }

        private static void AssertManufacturersItemEqual(
            Manufacturers pManufacturers,
            Manufacturers pCreatedManufacturers)
        {
            Assert.AreEqual(
                pManufacturers.ManufacturersID,
                pCreatedManufacturers.ManufacturersID,
                string.Format("ManufacturersID isn't equal!"));
            Assert.AreEqual(
                pManufacturers.ManufacturersName,
                pCreatedManufacturers.ManufacturersName,
                string.Format("ManufacturersName isn't equal!"));
            Assert.AreEqual(
                pManufacturers.ManufacturersSite,
                pCreatedManufacturers.ManufacturersSite,
                string.Format("ManufacturersSite isn't equal!"));
            Assert.AreEqual(
                pManufacturers.ManufacturersPhone,
                pCreatedManufacturers.ManufacturersPhone,
                string.Format("ManufacturersPhone isn't equal!"));
            Assert.AreEqual(
                pManufacturers.ManufacturersDom,
                pCreatedManufacturers.ManufacturersDom,
                string.Format("ManufacturersDom isn't equal!"));
            Assert.AreEqual(
                pManufacturers.ManufacturersDoe,
                pCreatedManufacturers.ManufacturersDoe,
                string.Format("ManufacturersDoe isn't equal!"));
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