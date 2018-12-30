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

    public class InjectorStorageTests : BaseTests
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

        #region Test CreateInjector Method

        [Test]
        public void InjectorCreateSuccess()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            Assert.AreNotEqual(
                0,
                createdInjector.InjectorID,
                string.Format("Could not create Injector:{0}",
                              createdInjector.InjectorID));

            AssertInjectorItemEqual(myInjector, createdInjector);
        }

        [Test]
        //测试方法
        [ExpectedException(typeof(ArgumentNullException))]
        //这个属性其实非常有用处，它表明这个函数会抛出一个预期的异常。
        public void InjectorCreateFailureInjectorArgumentNullException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            injectorStorage.CreateInjector(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectorCreateFailureInjectorNameArgumentException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            injectorStorage.CreateInjector(myInjector);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectorCreateFailureInjectorNameArgumentNullException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                null,
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            injectorStorage.CreateInjector(myInjector);

        }


        #endregion

        #region Test ReadInjector Method

        [Test]
        public void InjectorReadSuccess()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "王某某",
                "女",
                "17733441111",
                "2",
                "2013-07-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            Assert.AreNotEqual(
                0,
                createdInjector.InjectorID,
                string.Format("Could not create Injector:{0}",
                              createdInjector.InjectorID));

            Injector readedInjector = injectorStorage.ReadInjector(
                createdInjector.InjectorID);

            AssertInjectorItemEqual(createdInjector, readedInjector);
        }


        [Test]
        [ExpectedException(ExpectedMessage = "Injector read failure!")]
        public void InjectorReadFailureInjectorIdArgumentException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            //    Injector myInjector = CreateInjectorForTest(
            //    "王某某",
            //    "女",
            //    "17733441111",
            //    "2",
            //    "2013-07-09");

            //    Injector createdInjector =
            //    injectorStorage.CreateInjector(myInjector);
            injectorStorage.ReadInjector(-1);
        }

        #endregion

        #region Test UpdateInjector Method

        [Test]
        public void InjectorUpdateSuccessOne()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            Assert.AreNotEqual(
                0,
                createdInjector.InjectorID,
                string.Format("Could not create Injector:{0}",
                              createdInjector.InjectorID));

            myInjector.InjectorName = "陈某某";

            injectorStorage.UpdateInjector(myInjector);

            Injector updatedInjector = injectorStorage.ReadInjector(
                createdInjector.InjectorID);

            AssertInjectorItemEqual(myInjector, updatedInjector);
        }


        [Test]
        public void InjectorUpdateSuccessTwo()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            Assert.AreNotEqual(
                0,
                createdInjector.InjectorID,
                string.Format("Could not create Injector:{0}",
                              createdInjector.InjectorID));

            myInjector.InjectorSex = "女";

            injectorStorage.UpdateInjector(myInjector);

            Injector updatedInjector = injectorStorage.ReadInjector(
                createdInjector.InjectorID);

            AssertInjectorItemEqual(myInjector, updatedInjector);
        }


        [Test]
        public void InjectorUpdateSuccessThree()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            Assert.AreNotEqual(
                0,
                createdInjector.InjectorID,
                string.Format("Could not create Injector:{0}",
                              createdInjector.InjectorID));

            myInjector.InjectorPhone = "17733442222";

            injectorStorage.UpdateInjector(myInjector);

            Injector updatedInjector = injectorStorage.ReadInjector(
                createdInjector.InjectorID);

            AssertInjectorItemEqual(myInjector, updatedInjector);
        }


        [Test]
        public void InjectorUpdateSuccessFour()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            Assert.AreNotEqual(
                0,
                createdInjector.InjectorID,
                string.Format("Could not create Injector:{0}",
                              createdInjector.InjectorID));

            myInjector.InjectorNumber = Convert.ToInt32("2");

            injectorStorage.UpdateInjector(myInjector);

            Injector updatedInjector = injectorStorage.ReadInjector(
                createdInjector.InjectorID);

            AssertInjectorItemEqual(myInjector, updatedInjector);
        }


        [Test]
        public void InjectorUpdateSuccessFive()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            Assert.AreNotEqual(
                0,
                createdInjector.InjectorID,
                string.Format("Could not create Injector:{0}",
                              createdInjector.InjectorID));

            myInjector.InjectorTime = Convert.ToDateTime("2013-11-13");

            injectorStorage.UpdateInjector(myInjector);

            Injector updatedInjector = injectorStorage.ReadInjector(
                createdInjector.InjectorID);

            AssertInjectorItemEqual(myInjector, updatedInjector);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectorUpdateFailureInjectorArgumentNullException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            injectorStorage.UpdateInjector(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectorUpdateFailureInjectorInjectorIdArgumentException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            injectorStorage.CreateInjector(myInjector);

            myInjector.InjectorID = -1;

            injectorStorage.UpdateInjector(myInjector);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectorUpdateFailureInjectorNameArgumentException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            injectorStorage.CreateInjector(myInjector);

            myInjector.InjectorName = "";

            injectorStorage.UpdateInjector(myInjector);

        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectorUpdateFailureInjectorNameArgumentNullException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            injectorStorage.CreateInjector(myInjector);

            myInjector.InjectorName = null;

            injectorStorage.UpdateInjector(myInjector);

        }


        [Test]
        [ExpectedException(ExpectedMessage = "Injector update failure!")]
        public void InjectorUpdateFailureInjectorIdArgumentException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector myInjector = CreateInjectorForTest(
                "李某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            injectorStorage.CreateInjector(myInjector);

            myInjector.InjectorID = int.MaxValue;

            injectorStorage.UpdateInjector(myInjector);
        }

        #endregion

        #region Test ListInjector Method

        [Test]
        public void InjectorListSuccess()
        {
            List<Injector> injectorList = new List<Injector>();

            IInjectorStorage injectorStorage = new InjectorStorage();

            Injector myInjector = CreateInjectorForTest(
                "李某某11",
                "男11",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                injectorStorage.CreateInjector(myInjector);

            injectorList.Add(createdInjector);

            myInjector = CreateInjectorForTest(
                "李某某12",
                "男11",
                "17733441111",
                "3",
                "2013-10-09");

            createdInjector =
                injectorStorage.CreateInjector(myInjector);

            injectorList.Add(createdInjector);

            myInjector = CreateInjectorForTest(
                "李某某12",
                "男12",
                "17733441111",
                "3",
                "2013-10-09");

            createdInjector =
                injectorStorage.CreateInjector(myInjector);

            injectorList.Add(createdInjector);

            myInjector = CreateInjectorForTest(
                "李某某12",
                "男12",
                "17733441112",
                "3",
                "2013-10-09");

            createdInjector =
                injectorStorage.CreateInjector(myInjector);

            injectorList.Add(createdInjector);

            myInjector = CreateInjectorForTest(
                "李某某12",
                "男12",
                "17733441112",
                "2",
                "2013-10-09");

            createdInjector =
                injectorStorage.CreateInjector(myInjector);

            injectorList.Add(createdInjector);

            myInjector = CreateInjectorForTest(
                "李某某12",
                "男12",
                "17733441112",
                "2",
                "2013-11-09");

            createdInjector =
                injectorStorage.CreateInjector(myInjector);

            injectorList.Add(createdInjector);

            QueryInjector queryInjector = new QueryInjector();

            queryInjector.InjectorID = null;
            queryInjector.InjectorName = null;
            queryInjector.InjectorSex = null;
            queryInjector.InjectorPhone = null;
            queryInjector.InjectorNumber = null;
            queryInjector.InjectorTime = null;

            IList<Injector> readedInjectorList =
                injectorStorage.ListInjector(queryInjector);

            AssertInjectorListsEqual(injectorList, readedInjectorList);

            injectorList.RemoveAt(0);

            queryInjector = new QueryInjector();

            queryInjector.InjectorID = null;
            queryInjector.InjectorName = "李某某12";
            queryInjector.InjectorSex = null;
            queryInjector.InjectorPhone = null;
            queryInjector.InjectorNumber = null;
            queryInjector.InjectorTime = null;

            readedInjectorList =
                injectorStorage.ListInjector(queryInjector);

            AssertInjectorListsEqual(injectorList, readedInjectorList);

            injectorList.RemoveAt(0);

            queryInjector = new QueryInjector();

            queryInjector.InjectorID = null;
            queryInjector.InjectorName = null;
            queryInjector.InjectorSex = "男12";
            queryInjector.InjectorPhone = null;
            queryInjector.InjectorNumber = null;
            queryInjector.InjectorTime = null;

            readedInjectorList =
                injectorStorage.ListInjector(queryInjector);

            AssertInjectorListsEqual(injectorList, readedInjectorList);

            injectorList.RemoveAt(0);

            queryInjector = new QueryInjector();

            queryInjector.InjectorID = null;
            queryInjector.InjectorName = null;
            queryInjector.InjectorSex = null;
            queryInjector.InjectorPhone = "17733441112";
            queryInjector.InjectorNumber = null;
            queryInjector.InjectorTime = null;

            readedInjectorList =
                injectorStorage.ListInjector(queryInjector);

            AssertInjectorListsEqual(injectorList, readedInjectorList);

            injectorList.RemoveAt(0);

            queryInjector = new QueryInjector();

            queryInjector.InjectorID = null;
            queryInjector.InjectorName = null;
            queryInjector.InjectorSex = null;
            queryInjector.InjectorPhone = null;
            queryInjector.InjectorNumber = Convert.ToInt32("2");
            queryInjector.InjectorTime = null;

            readedInjectorList =
                injectorStorage.ListInjector(queryInjector);

            AssertInjectorListsEqual(injectorList, readedInjectorList);

            injectorList.RemoveAt(0);

            queryInjector = new QueryInjector();

            queryInjector.InjectorID = null;
            queryInjector.InjectorName = null;
            queryInjector.InjectorSex = null;
            queryInjector.InjectorPhone = null;
            queryInjector.InjectorNumber = null;
            queryInjector.InjectorTime = Convert.ToDateTime("2013-11-09");

            readedInjectorList =
                injectorStorage.ListInjector(queryInjector);

            AssertInjectorListsEqual(injectorList, readedInjectorList);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectorListFailureInjectorArgumentNullException()
        {
            IInjectorStorage injectorStorage = new InjectorStorage();

            injectorStorage.ListInjector(null);
        }

        #endregion

        #region Private methods

        private static void AssertInjectorListsEqual(
            IList<Injector> expected,
            IList<Injector> actual)
        {
            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    for (int j = 0; j < actual.Count; j++)
                    {
                        if (expected[i].InjectorID == actual[j].InjectorID)
                        {
                            AssertInjectorItemEqual(
                                expected[i],
                                actual[j]);
                        }
                    }
                }
            }

            else
            {
                Assert.Fail("The number of Injector list  is not equal!");
            }

        }

        private static void AssertInjectorItemEqual(
            Injector pInjector,
            Injector pCreatedInjector)
        {
            Assert.AreEqual(
                pInjector.InjectorID,
                pCreatedInjector.InjectorID,
                string.Format("InjectorID isn't equal!"));
            Assert.AreEqual(
                pInjector.InjectorName,
                pCreatedInjector.InjectorName,
                string.Format("InjectorName isn't equal!"));
            Assert.AreEqual(
                pInjector.InjectorSex,
                pCreatedInjector.InjectorSex,
                string.Format("InjectorSex isn't equal!"));
            Assert.AreEqual(
                pInjector.InjectorPhone,
                pCreatedInjector.InjectorPhone,
                string.Format("InjectorPhone isn't equal!"));
            Assert.AreEqual(
                pInjector.InjectorNumber,
                pCreatedInjector.InjectorNumber,
                string.Format("InjectorNumber isn't equal!"));
            Assert.AreEqual(
                pInjector.InjectorTime,
                pCreatedInjector.InjectorTime,
                string.Format("InjectorTime isn't equal!"));
        }

        private static Injector CreateInjectorForTest(
            string pInjectorName,
            string pInjectorSex,
            string pInjectorPhone,
            string pInjectorNumber,
            string pInjectorTime)
        {
            Injector myInjector = new Injector();

            myInjector.InjectorName = pInjectorName;
            myInjector.InjectorSex = pInjectorSex;
            myInjector.InjectorPhone = pInjectorPhone;
            myInjector.InjectorNumber = Convert.ToInt32(pInjectorNumber);
            myInjector.InjectorTime = Convert.ToDateTime(pInjectorTime);

            return myInjector;
        }


        #endregion
    }
}