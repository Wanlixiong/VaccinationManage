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

    public class ManagerUserStorageTests : BaseTests
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

        #region Test CreateManagerUser Method

        [Test]
        public void ManagerUserCreateSuccess()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户1",
                "123456",
                "系统管理员");

            ManagerUser createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            Assert.AreNotEqual(
                0,
                createdManagerUser.UserID,
                string.Format("Could not create ManagerUser:{0}",
                              createdManagerUser.UserID));

            AssertManagerUserItemEqual(myManagerUser, createdManagerUser);
        }


        [Test]
        //测试方法
        [ExpectedException(typeof(ArgumentNullException))]
        //这个属性其实非常有用处，它表明这个函数会抛出一个预期的异常。
        public void ManagerUserCreateFailureManagerUserArgumentNullException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            managerUserStorage.CreateManagerUser(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManagerUserCreateFailureUserNameArgumentException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "",
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManagerUserCreateFailureUserNameArgumentNullException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                null,
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManagerUserStorageCreateFailureUserPasswordArgumentException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户2",
                "",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManagerUserCreateFailureUserPasswordArgumentNullException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户3",
                null,
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

        }


        #endregion

        #region Test ReadManagerUser Method

        [Test]
        public void ManagerUserReadSuccess()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户4",
                "123456",
                "系统管理员");

            ManagerUser createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            Assert.AreNotEqual(
                0,
                createdManagerUser.UserID,
                string.Format("Could not create ManagerUser:{0}",
                              createdManagerUser.UserID));

            ManagerUser readedManagerUser = managerUserStorage.ReadManagerUser(
                createdManagerUser.UserID);

            AssertManagerUserItemEqual(createdManagerUser, readedManagerUser);
        }


        [Test]
        [ExpectedException(ExpectedMessage = "ManagerUser read failure!")]
        public void ManagerUserReadFailureUserIdArgumentException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            //ManagerUser myManagerUser = CreateManagerUserForTest(
            //    "用户5",
            //    "123456",
            //    "系统管理员");

            //ManagerUser createdManagerUser =
            //managerUserStorage.CreateManagerUser(myManagerUser);
            managerUserStorage.ReadManagerUser(-1);
        }

        #endregion

        #region Test UpdateManagerUser Method

        [Test]
        public void ManagerUserUpdateSuccessOne()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户5",
                "123456",
                "系统管理员");

            ManagerUser createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            Assert.AreNotEqual(
                0,
                createdManagerUser.UserID,
                string.Format("Could not create ManagerUser:{0}",
                              createdManagerUser.UserID));

            myManagerUser.UserName = "用户3344";

            managerUserStorage.UpdateManagerUser(myManagerUser);

            ManagerUser updatedManagerUser = managerUserStorage.ReadManagerUser(
                createdManagerUser.UserID);

            AssertManagerUserItemEqual(myManagerUser, updatedManagerUser);
        }


        [Test]
        public void ManagerUserUpdateSuccessTwo()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户5",
                "123456",
                "系统管理员");

            ManagerUser createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            Assert.AreNotEqual(
                0,
                createdManagerUser.UserID,
                string.Format("Could not create ManagerUser:{0}",
                              createdManagerUser.UserID));

            myManagerUser.UserPassword = "654321";

            managerUserStorage.UpdateManagerUser(myManagerUser);

            ManagerUser updatedManagerUser = managerUserStorage.ReadManagerUser(
                createdManagerUser.UserID);

            AssertManagerUserItemEqual(myManagerUser, updatedManagerUser);
        }


        [Test]
        public void ManagerUserUpdateSuccessThree()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户5",
                "123456",
                "系统管理员");

            ManagerUser createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            Assert.AreNotEqual(
                0,
                createdManagerUser.UserID,
                string.Format("Could not create ManagerUser:{0}",
                              createdManagerUser.UserID));

            myManagerUser.UserSort = "系统操作员";

            managerUserStorage.UpdateManagerUser(myManagerUser);

            ManagerUser updatedManagerUser = managerUserStorage.ReadManagerUser(
                createdManagerUser.UserID);

            AssertManagerUserItemEqual(myManagerUser, updatedManagerUser);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManagerUserUpdateFailureManagerUserArgumentNullException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            managerUserStorage.UpdateManagerUser(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManagerUserUpdateFailureUserUserIdArgumentException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户6",
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

            myManagerUser.UserID = -1;

            managerUserStorage.UpdateManagerUser(myManagerUser);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManagerUserUpdateFailureUserNameArgumentException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户6",
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

            myManagerUser.UserName = "";

            managerUserStorage.UpdateManagerUser(myManagerUser);

        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManagerUserUpdateFailureUserNameArgumentNullException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户6",
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

            myManagerUser.UserName = null;

            managerUserStorage.UpdateManagerUser(myManagerUser);

        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ManagerUserUpdateFailureUserPasswordArgumentException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户6",
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

            myManagerUser.UserPassword = "";

            managerUserStorage.UpdateManagerUser(myManagerUser);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManagerUserUpdateFailureUserPasswordArgumentNullException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户6",
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

            myManagerUser.UserPassword = null;

            managerUserStorage.UpdateManagerUser(myManagerUser);

        }


        [Test]
        [ExpectedException(ExpectedMessage = "ManagerUser update failure!")]
        public void ManagerUserUpdateFailureUserIdArgumentException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户6",
                "123456",
                "系统管理员");

            managerUserStorage.CreateManagerUser(myManagerUser);

            myManagerUser.UserID = int.MaxValue;

            managerUserStorage.UpdateManagerUser(myManagerUser);
        }

        #endregion

        #region Test ListManagerUser Method

        [Test]
        public void ManagerUserListSuccess()
        {
            List<ManagerUser> managerUserList = new List<ManagerUser>();

            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            ManagerUser myManagerUser = CreateManagerUserForTest(
                "用户7",
                "123456",
                "系统管理员");

            ManagerUser createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            managerUserList.Add(createdManagerUser);

            myManagerUser = CreateManagerUserForTest(
                "用户8",
                "123456",
                "系统操作员");

            createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            managerUserList.Add(createdManagerUser);

            myManagerUser = CreateManagerUserForTest(
                "用户9",
                "123456",
                "系统操作员");

            createdManagerUser =
                managerUserStorage.CreateManagerUser(myManagerUser);

            managerUserList.Add(createdManagerUser);

            QueryManagerUser queryManagerUser = new QueryManagerUser();

            queryManagerUser.UserID = null;
            queryManagerUser.UserName = null;
            queryManagerUser.UserPassword = null;
            queryManagerUser.UserSort = null;

            IList<ManagerUser> readedManagerUserList =
                managerUserStorage.ListManagerUser(queryManagerUser);

            AssertManagerUserListsEqual(managerUserList, readedManagerUserList);

            managerUserList.RemoveAt(0);

            queryManagerUser = new QueryManagerUser();

            queryManagerUser.UserID = null;
            queryManagerUser.UserName = null;
            queryManagerUser.UserPassword = null;
            queryManagerUser.UserSort = "系统操作员";

            readedManagerUserList =
                managerUserStorage.ListManagerUser(queryManagerUser);

            AssertManagerUserListsEqual(managerUserList, readedManagerUserList);

            managerUserList.RemoveAt(0);

            queryManagerUser = new QueryManagerUser();

            queryManagerUser.UserID = null;
            queryManagerUser.UserName = "用户9";
            queryManagerUser.UserPassword = null;
            queryManagerUser.UserSort = null;

            readedManagerUserList =
                managerUserStorage.ListManagerUser(queryManagerUser);

            AssertManagerUserListsEqual(managerUserList, readedManagerUserList);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ManagerUserListFailureManagerUserArgumentNullException()
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            managerUserStorage.ListManagerUser(null);
        }

        #endregion

        #region Private methods

        private static void AssertManagerUserListsEqual(
            IList<ManagerUser> expected,
            IList<ManagerUser> actual)
        {
            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    for (int j = 0; j < actual.Count; j++)
                    {
                        if (expected[i].UserID == actual[j].UserID)
                        {
                            AssertManagerUserItemEqual(
                                expected[i],
                                actual[j]);
                        }
                    }
                }
            }

            else
            {
                Assert.Fail("The number of ManagerUser list  is not equal!");
            }

        }

        private static void AssertManagerUserItemEqual(
            ManagerUser pManagerUser,
            ManagerUser pCreatedManagerUser)
        {
            Assert.AreEqual(
                pManagerUser.UserID,
                pCreatedManagerUser.UserID,
                string.Format("UserID isn't equal!"));
            Assert.AreEqual(
                pManagerUser.UserName,
                pCreatedManagerUser.UserName,
                string.Format("UserName isn't equal!"));
            Assert.AreEqual(
                pManagerUser.UserPassword,
                pCreatedManagerUser.UserPassword,
                string.Format("UserPassword isn't equal!"));
            Assert.AreEqual(
                pManagerUser.UserSort,
                pCreatedManagerUser.UserSort,
                string.Format("UserSort isn't equal!"));
        }

        private static ManagerUser CreateManagerUserForTest(
            string pUserName,
            string pUserPassword,
            string pUserSort)
        {
            ManagerUser myManagerUser = new ManagerUser();

            myManagerUser.UserName = pUserName;
            myManagerUser.UserPassword = pUserPassword;
            myManagerUser.UserSort = pUserSort;

            return myManagerUser;
        }

        #endregion
    }
}
