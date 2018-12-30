using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackEnd.BusinessEntities;
using BackEnd.Lib;
using BackEnd.BusinessLogic;
using BackEnd.DataAccess;


namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IList<ManagerUser> managerUserList = new List<ManagerUser>();
            //IManagerUserManager managerUserManager = new ManagerUserManager();    /*IManagerUserManager用于处理逻辑，界面可不使用*/
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();
            QueryManagerUser queryManagerUser = new QueryManagerUser();

            if (txtUserName.Text.Trim() == "" || txtUserPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名和密码");
            }
            else
            {
                queryManagerUser.UserID = null;     /*对应数据库中的查询存储过程*/
                queryManagerUser.UserName = txtUserName.Text.Trim();
                queryManagerUser.UserPassword = txtUserPassword.Text.Trim();
                queryManagerUser.UserSort = null;

                /*managerUserList = managerUserManager.GetManagerUserList(  //对应上述的managerUserManager
                    managerUserStorage,
                    queryManagerUser);*/
                managerUserList = managerUserStorage.ListManagerUser(   /*调用managerUserList，将集合（数组）取到*/
                    queryManagerUser);


                if (managerUserList.Count == 1) /*一条记录符合，跳转到主界面*/
                {
                    this.Hide();
                    MainForm mainFrom = new MainForm();
                    mainFrom.ShowDialog();
                }
                else
                {
                    MessageBox.Show("账号或密码不正确");
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
