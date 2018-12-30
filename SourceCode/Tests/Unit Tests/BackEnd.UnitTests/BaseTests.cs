using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using NUnit.Framework;

namespace BackEnd.UnitTests
{
    public abstract class BaseTests
    {
        private readonly string[] m_ClearSQLString =
            {
                "DELETE FROM [ManagerUser]",
                "DELETE FROM [InjectionMessage]",
                "DELETE FROM [Injector]",
                "DELETE FROM [Vaccine]",
                "DELETE FROM [Manufacturers]",
                
            };

        [SetUp]
        //这个属性用来修饰方法，表明它会在每一个测试方法运行之前运行。
        //那么可以用它来重设一些变量，是每个方法在运行之前都有良好的初值。

        public virtual void SetUp()
        {
            ClearData();
        }

        [TestFixtureTearDown]
        //这个属性也是用于修饰方法，它会在所有测试方法运行完毕以后运行。
        //你可以用它来释放一些资源。
        //在所有测试方法运行完之后运行

        public virtual void Dispose()
        {
            ClearData();
            //释放一些资源

        }

        private void ClearData()
        {
            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["DEFAULT"].ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < m_ClearSQLString.Length; i++)
                        {
                            SqlCommand command;
                            command = new SqlCommand("", conn, trans);
                            command.CommandText = m_ClearSQLString[i];
                            command.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
