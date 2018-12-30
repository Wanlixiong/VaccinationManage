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

    public class InjectionMessageStorageTests : BaseTests
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

        #region getInjectorID

        public static int getInjectorID()
        {
            IInjectorStorage pInjectorStorage = new InjectorStorage();

            Injector myInjector = CreateInjectorForTest(
                "沈某某",
                "男",
                "17733441111",
                "3",
                "2013-10-09");

            Injector createdInjector =
                pInjectorStorage.CreateInjector(myInjector);

            return createdInjector.InjectorID;
        }

        #endregion

        #region getVaccineID

        public static int getVaccineID()
        {
            IManufacturersStorage pManufacturersStorage = new ManufacturersStorage();
            Manufacturers myManufacturers = CreateManufacturersForTest(
                "供应商",
                "浙江温州",
                "17733117779",
                "2013-06-30",
                "2016-06-30");

            Manufacturers createdManufacturers =
                pManufacturersStorage.CreateManufacturers(myManufacturers);


            IVaccineStorage pVaccineStorage = new VaccineStorage();
            Vaccine myVaccine = CreateVaccineForTest(
                "狂犬疫苗",
                "处方",
                createdManufacturers.ManufacturersID,
                "68.00",
                "45");

            Vaccine createdVaccine =
                pVaccineStorage.CreateVaccine(myVaccine);

            return createdVaccine.VaccineID;
        }

        #endregion

        #region Test CreateInjectionMessage Method

        [Test]
        public void InjectionMessageCreateSuccess()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            Assert.AreNotEqual(
                0,
                createdInjectionMessage.InjectionMessageID,
                string.Format("Could not create InjectionMessage:{0}",
                              createdInjectionMessage.InjectionMessageID));

            AssertInjectionMessageItemEqual(myInjectionMessage, createdInjectionMessage);
        }

        [Test]
        //测试方法
        [ExpectedException(typeof(ArgumentNullException))]
        //这个属性其实非常有用处，它表明这个函数会抛出一个预期的异常。
        public void InjectionMessageCreateFailureInjectionMessageArgumentNullException()
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            injectionMessageStorage.CreateInjectionMessage(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageCreateFailureInjectorIDArgumentException()
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                -1,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            injectionMessageStorage.CreateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageCreateFailureVaccineIDArgumentException()
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                getInjectorID(),
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                -1,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            injectionMessageStorage.CreateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageCreateFailureInjectionMessageSiteArgumentException()
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "",
                "2016-03-30",
                "陈医生");

            injectionMessageStorage.CreateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectionMessageCreateFailureInjectionMessageSiteArgumentNullException()
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                null,
                "2016-03-30",
                "陈医生");

            injectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageCreateFailureInjectionMessageDoctorArgumentException()
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "");

            injectionMessageStorage.CreateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectionMessageCreateFailureInjectionMessageDoctorArgumentNullException()
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                null);

            injectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

        }


        #endregion

        #region Test ReadInjectionMessage Method

        [Test]
        public void InjectionMessageReadSuccess()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            Assert.AreNotEqual(
                0,
                createdInjectionMessage.InjectionMessageID,
                string.Format("Could not create InjectionMessage:{0}",
                              createdInjectionMessage.InjectionMessageID));

            InjectionMessage readedInjectionMessage = pInjectionMessageStorage.ReadInjectionMessage(
                createdInjectionMessage.InjectionMessageID);

            AssertInjectionMessageItemEqual(createdInjectionMessage, readedInjectionMessage);
        }


        [Test]
        [ExpectedException(ExpectedMessage = "InjectionMessage read failure!")]
        public void InjectionMessageReadFailureInjectionMessageIdArgumentException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            //InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
            //    getInjectorID(),
            //    getVaccineID(),
            //    "某某人民医院",
            //    "2016-03-30",
            //    "陈医生");

            //InjectionMessage createdInjectionMessage =
            //    pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);
            pInjectionMessageStorage.ReadInjectionMessage(-1);
        }

        #endregion

        #region Test UpdateInjectionMessage Method

        [Test]
        public void InjectionMessageUpdateSuccessOne()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            Assert.AreNotEqual(
                0,
                createdInjectionMessage.InjectionMessageID,
                string.Format("Could not create InjectionMessage:{0}",
                              createdInjectionMessage.InjectionMessageID));

            myInjectionMessage.InjectorID = getInjectorID();
            myInjectionMessage.InjectorName = pInjectorStorage.ReadInjector(myInjectionMessage.InjectorID).InjectorName;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

            InjectionMessage updatedInjectionMessage = pInjectionMessageStorage.ReadInjectionMessage(
                createdInjectionMessage.InjectionMessageID);

            AssertInjectionMessageItemEqual(myInjectionMessage, updatedInjectionMessage);
        }


        [Test]
        public void InjectionMessageUpdateSuccessTwo()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            Assert.AreNotEqual(
                0,
                createdInjectionMessage.InjectionMessageID,
                string.Format("Could not create InjectionMessage:{0}",
                              createdInjectionMessage.InjectionMessageID));

            myInjectionMessage.VaccineID = getVaccineID();
            myInjectionMessage.VaccineName = pVaccineStorage.ReadVaccine(myInjectionMessage.VaccineID).VaccineName;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

            InjectionMessage updatedInjectionMessage = pInjectionMessageStorage.ReadInjectionMessage(
                createdInjectionMessage.InjectionMessageID);

            AssertInjectionMessageItemEqual(myInjectionMessage, updatedInjectionMessage);
        }


        [Test]
        public void InjectionMessageUpdateSuccessThree()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            Assert.AreNotEqual(
                0,
                createdInjectionMessage.InjectionMessageID,
                string.Format("Could not create InjectionMessage:{0}",
                              createdInjectionMessage.InjectionMessageID));

            myInjectionMessage.InjectionMessageSite = "某某县中医院";

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

            InjectionMessage updatedInjectionMessage = pInjectionMessageStorage.ReadInjectionMessage(
                createdInjectionMessage.InjectionMessageID);

            AssertInjectionMessageItemEqual(myInjectionMessage, updatedInjectionMessage);
        }


        [Test]
        public void InjectionMessageUpdateSuccessFour()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            Assert.AreNotEqual(
                0,
                createdInjectionMessage.InjectionMessageID,
                string.Format("Could not create InjectionMessage:{0}",
                              createdInjectionMessage.InjectionMessageID));

            myInjectionMessage.InjectionMessageTime = Convert.ToDateTime("2016-04-15");

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

            InjectionMessage updatedInjectionMessage = pInjectionMessageStorage.ReadInjectionMessage(
                createdInjectionMessage.InjectionMessageID);

            AssertInjectionMessageItemEqual(myInjectionMessage, updatedInjectionMessage);
        }


        [Test]
        public void InjectionMessageUpdateSuccessFive()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            Assert.AreNotEqual(
                0,
                createdInjectionMessage.InjectionMessageID,
                string.Format("Could not create InjectionMessage:{0}",
                              createdInjectionMessage.InjectionMessageID));

            myInjectionMessage.InjectionMessageDoctor = "欧阳医生";

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

            InjectionMessage updatedInjectionMessage = pInjectionMessageStorage.ReadInjectionMessage(
                createdInjectionMessage.InjectionMessageID);

            AssertInjectionMessageItemEqual(myInjectionMessage, updatedInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectionMessageUpdateFailureInjectionMessageArgumentNullException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            pInjectionMessageStorage.UpdateInjectionMessage(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageUpdateFailureInjectionMessageInjectionMessageIdArgumentException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.InjectionMessageID = -1;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageUpdateFailureInjectorIDArgumentException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.InjectorID = -1;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageUpdateFailureVaccineIDArgumentException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.VaccineID = -1;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageUpdateFailureInjectionMessageSiteArgumentException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.InjectionMessageSite = "";

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectionMessageUpdateFailureInjectionMessageSiteArgumentNullException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.InjectionMessageSite = null;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InjectionMessageUpdateFailureInjectionMessageDoctorArgumentException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.InjectionMessageDoctor = "";

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectionMessageUpdateFailureInjectionMessageDoctorArgumentNullException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.InjectionMessageDoctor = null;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);

        }


        [Test]
        [ExpectedException(ExpectedMessage = "InjectionMessage update failure!")]
        public void InjectionMessageUpdateFailureInjectionMessageIdArgumentException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            myInjectionMessage.InjectionMessageID = int.MaxValue;

            pInjectionMessageStorage.UpdateInjectionMessage(myInjectionMessage);
        }

        #endregion

        #region Test ListInjectionMessage Method

        [Test]
        public void InjectionMessageListSuccess()
        {
            List<InjectionMessage> injectionMessageList = new List<InjectionMessage>();

            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();
            IInjectorStorage pInjectorStorage = new InjectorStorage();
            IVaccineStorage pVaccineStorage = new VaccineStorage();

            int pgetInjectorID = getInjectorID();
            int pgetVaccineID = getVaccineID();

            InjectionMessage myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            InjectionMessage createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            injectionMessageList.Add(createdInjectionMessage);

            pgetInjectorID = getInjectorID();

            myInjectionMessage = CreateInjectionMessageForTest(
                pgetInjectorID,
                pInjectorStorage.ReadInjector(pgetInjectorID).InjectorName,
                createdInjectionMessage.VaccineID,
                pVaccineStorage.ReadVaccine(createdInjectionMessage.VaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            injectionMessageList.Add(createdInjectionMessage);

            pgetVaccineID = getVaccineID();

            myInjectionMessage = CreateInjectionMessageForTest(
                createdInjectionMessage.InjectorID,
                pInjectorStorage.ReadInjector(createdInjectionMessage.InjectorID).InjectorName,
                pgetVaccineID,
                pVaccineStorage.ReadVaccine(pgetVaccineID).VaccineName,
                "某某人民医院",
                "2016-03-30",
                "陈医生");

            createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            injectionMessageList.Add(createdInjectionMessage);

            myInjectionMessage = CreateInjectionMessageForTest(
                createdInjectionMessage.InjectorID,
                pInjectorStorage.ReadInjector(createdInjectionMessage.InjectorID).InjectorName,
                createdInjectionMessage.VaccineID,
                pVaccineStorage.ReadVaccine(createdInjectionMessage.VaccineID).VaccineName,
                "海口市中医院",
                "2016-03-30",
                "陈医生");

            createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            injectionMessageList.Add(createdInjectionMessage);

            myInjectionMessage = CreateInjectionMessageForTest(
                createdInjectionMessage.InjectorID,
                pInjectorStorage.ReadInjector(createdInjectionMessage.InjectorID).InjectorName,
                createdInjectionMessage.VaccineID,
                pVaccineStorage.ReadVaccine(createdInjectionMessage.VaccineID).VaccineName,
                "海口市中医院",
                "2016-04-25",
                "陈医生");

            createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            injectionMessageList.Add(createdInjectionMessage);

            myInjectionMessage = CreateInjectionMessageForTest(
                createdInjectionMessage.InjectorID,
                pInjectorStorage.ReadInjector(createdInjectionMessage.InjectorID).InjectorName,
                createdInjectionMessage.VaccineID,
                pVaccineStorage.ReadVaccine(createdInjectionMessage.VaccineID).VaccineName,
                "海口市中医院",
                "2016-04-25",
                "欧阳医生");

            createdInjectionMessage =
                pInjectionMessageStorage.CreateInjectionMessage(myInjectionMessage);

            injectionMessageList.Add(createdInjectionMessage);

            QueryInjectionMessage queryInjectionMessage = new QueryInjectionMessage();

            queryInjectionMessage.InjectionMessageID = null;
            queryInjectionMessage.InjectorID = null;
            queryInjectionMessage.VaccineID = null;
            queryInjectionMessage.InjectionMessageSite = null;
            queryInjectionMessage.InjectionMessageTime = null;
            queryInjectionMessage.InjectionMessageDoctor = null;

            IList<InjectionMessage> readedInjectionMessageList =
                pInjectionMessageStorage.ListInjectionMessage(queryInjectionMessage);

            AssertInjectionMessageListsEqual(injectionMessageList, readedInjectionMessageList);

            injectionMessageList.RemoveAt(0);

            queryInjectionMessage = new QueryInjectionMessage();

            queryInjectionMessage.InjectionMessageID = null;
            queryInjectionMessage.InjectorID = createdInjectionMessage.InjectorID;
            queryInjectionMessage.VaccineID = null;
            queryInjectionMessage.InjectionMessageSite = null;
            queryInjectionMessage.InjectionMessageTime = null;
            queryInjectionMessage.InjectionMessageDoctor = null;

            readedInjectionMessageList =
                pInjectionMessageStorage.ListInjectionMessage(queryInjectionMessage);

            AssertInjectionMessageListsEqual(injectionMessageList, readedInjectionMessageList);

            injectionMessageList.RemoveAt(0);

            queryInjectionMessage = new QueryInjectionMessage();

            queryInjectionMessage.InjectionMessageID = null;
            queryInjectionMessage.InjectorID = null;
            queryInjectionMessage.VaccineID = createdInjectionMessage.VaccineID;
            queryInjectionMessage.InjectionMessageSite = null;
            queryInjectionMessage.InjectionMessageTime = null;
            queryInjectionMessage.InjectionMessageDoctor = null;

            readedInjectionMessageList =
                pInjectionMessageStorage.ListInjectionMessage(queryInjectionMessage);

            AssertInjectionMessageListsEqual(injectionMessageList, readedInjectionMessageList);

            injectionMessageList.RemoveAt(0);

            queryInjectionMessage = new QueryInjectionMessage();

            queryInjectionMessage.InjectionMessageID = null;
            queryInjectionMessage.InjectorID = null;
            queryInjectionMessage.VaccineID = null;
            queryInjectionMessage.InjectionMessageSite = "海口市中医院";
            queryInjectionMessage.InjectionMessageTime = null;
            queryInjectionMessage.InjectionMessageDoctor = null;

            readedInjectionMessageList =
                pInjectionMessageStorage.ListInjectionMessage(queryInjectionMessage);

            AssertInjectionMessageListsEqual(injectionMessageList, readedInjectionMessageList);

            injectionMessageList.RemoveAt(0);

            queryInjectionMessage = new QueryInjectionMessage();

            queryInjectionMessage.InjectionMessageID = null;
            queryInjectionMessage.InjectorID = null;
            queryInjectionMessage.VaccineID = null;
            queryInjectionMessage.InjectionMessageSite = null;
            queryInjectionMessage.InjectionMessageTime = Convert.ToDateTime("2016-04-25");
            queryInjectionMessage.InjectionMessageDoctor = null;

            readedInjectionMessageList =
                pInjectionMessageStorage.ListInjectionMessage(queryInjectionMessage);

            AssertInjectionMessageListsEqual(injectionMessageList, readedInjectionMessageList);

            injectionMessageList.RemoveAt(0);

            queryInjectionMessage = new QueryInjectionMessage();

            queryInjectionMessage.InjectionMessageID = null;
            queryInjectionMessage.InjectorID = null;
            queryInjectionMessage.VaccineID = null;
            queryInjectionMessage.InjectionMessageSite = null;
            queryInjectionMessage.InjectionMessageTime = null;
            queryInjectionMessage.InjectionMessageDoctor = "欧阳医生";

            readedInjectionMessageList =
                pInjectionMessageStorage.ListInjectionMessage(queryInjectionMessage);

            AssertInjectionMessageListsEqual(injectionMessageList, readedInjectionMessageList);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InjectionMessageListFailureInjectionMessageArgumentNullException()
        {
            IInjectionMessageStorage pInjectionMessageStorage = new InjectionMessageStorage();

            pInjectionMessageStorage.ListInjectionMessage(null);
        }

        #endregion

        #region Private methods

        private static void AssertInjectionMessageListsEqual(
            IList<InjectionMessage> expected,
            IList<InjectionMessage> actual)
        {
            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    for (int j = 0; j < actual.Count; j++)
                    {
                        if (expected[i].InjectionMessageID == actual[j].InjectionMessageID)
                        {
                            AssertInjectionMessageItemEqual(
                                expected[i],
                                actual[j]);
                        }
                    }
                }
            }

            else
            {
                Assert.Fail("The number of InjectionMessage list  is not equal!");
            }

        }

        private static void AssertInjectionMessageItemEqual(
            InjectionMessage pInjectionMessage,
            InjectionMessage pCreatedInjectionMessage)
        {
            Assert.AreEqual(
                pInjectionMessage.InjectionMessageID,
                pCreatedInjectionMessage.InjectionMessageID,
                string.Format("InjectionMessageID isn't equal!"));
            Assert.AreEqual(
                pInjectionMessage.InjectorID,
                pCreatedInjectionMessage.InjectorID,
                string.Format("InjectorID isn't equal!"));
            Assert.AreEqual(
                pInjectionMessage.VaccineID,
                pCreatedInjectionMessage.VaccineID,
                string.Format("VaccineID isn't equal!"));
            Assert.AreEqual(
                pInjectionMessage.InjectionMessageSite,
                pCreatedInjectionMessage.InjectionMessageSite,
                string.Format("InjectionMessageSite isn't equal!"));
            Assert.AreEqual(
                pInjectionMessage.InjectionMessageTime,
                pCreatedInjectionMessage.InjectionMessageTime,
                string.Format("InjectionMessageTime isn't equal!"));
            Assert.AreEqual(
                pInjectionMessage.InjectionMessageDoctor,
                pCreatedInjectionMessage.InjectionMessageDoctor,
                string.Format("InjectionMessageDoctor isn't equal!"));
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

        private static InjectionMessage CreateInjectionMessageForTest(
            int pInjectorID,
            string pInjectorName,
            int pVaccineID,
            string pVaccineName,
            string pInjectionMessageSite,
            string pInjectionMessageTime,
            string pInjectionMessageDoctor)
        {
            InjectionMessage myInjectionMessage = new InjectionMessage();

            myInjectionMessage.InjectorID = pInjectorID;
            myInjectionMessage.InjectorName = pInjectorName;
            myInjectionMessage.VaccineID = pVaccineID;
            myInjectionMessage.VaccineName = pVaccineName;
            myInjectionMessage.InjectionMessageSite = pInjectionMessageSite;
            myInjectionMessage.InjectionMessageTime = Convert.ToDateTime(pInjectionMessageTime);
            myInjectionMessage.InjectionMessageDoctor = pInjectionMessageDoctor;

            return myInjectionMessage;
        }

        #endregion
    }
}
