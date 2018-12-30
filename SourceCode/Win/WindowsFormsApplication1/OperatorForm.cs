using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    public partial class OperatorForm : Form
    {
        public OperatorForm()
        {
            InitializeComponent();
        }

        private void OperatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManagerUser managerUser = new ManagerUser();

            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            if (textUserName.Text.Trim() == "" || textUserPassword.Text.Trim() == ""
               || cmbUserSort.Text == "")
            {
                MessageBox.Show("请输入全部信息，不要有遗漏。");
            }
            else
            {
                managerUser.UserName = textUserName.Text.Trim();
                managerUser.UserPassword = textUserPassword.Text.Trim();
                managerUser.UserSort = cmbUserSort.Text.Trim();

                switch (cmbUserSort.SelectedIndex)
                {
                    case 1:
                        managerUser.UserSort = "系统管理员";
                        break;
                    case 2:
                        managerUser.UserSort = "系统操作员";
                        break;
                    default:
                        managerUser.UserSort = null;
                        break;
                }

                managerUserStorage.CreateManagerUser(managerUser);

                MessageBox.Show("增加成功！");

                textUserName.Text = "";
                textUserPassword.Text = "";
                cmbUserSort.Text = "";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            IList<ManagerUser> managerUserList = new List<ManagerUser>();

            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            QueryManagerUser queryManagerUser = new QueryManagerUser();
            if (textUserPassword.Text.Trim() != "")
            {
                MessageBox.Show("无法通过密码查询！");
            }
            else
            {
                if (cmbUserSort.Text.Trim() == "" ||
                cmbUserSort.Text.Trim() == "全部")
                {
                    queryManagerUser.UserName = textUserName.Text.Trim();
                }
                else
                {
                    queryManagerUser.UserName = textUserName.Text.Trim();
                    queryManagerUser.UserSort = cmbUserSort.Text.Trim();
                }

                managerUserList = managerUserStorage.ListManagerUser(queryManagerUser);

                dgvManagerUser.AutoGenerateColumns = false;
                DataTable dt = new DataTable();

                dt.Columns.Add("UserID", typeof(System.Int32));
                dt.Columns.Add("UserName", typeof(System.String));
                dt.Columns.Add("UserPassword", typeof(System.String));
                dt.Columns.Add("UserSort", typeof(System.String));

                dgvManagerUser.DataSource = managerUserList;

                foreach (ManagerUser user in managerUserList)
                {
                    dt.Rows.Add(
                        user.UserID,
                        user.UserName,
                        user.UserPassword,
                        user.UserSort);
                }

                BindingSource source = new BindingSource();

                source.DataSource = dt;
                dgvManagerUser.DataSource = source;

            }
        }
        private void btnModfiy_Click(object sender, EventArgs e)
        {
            IManagerUserStorage managerUserStorage = new ManagerUserStorage();

            ManagerUser managerUser = new ManagerUser();

            if (textUserName.Text.Trim() == "" || textUserPassword.Text.Trim() == ""
               || cmbUserSort.Text == "")
            {
                MessageBox.Show("请双击选择需要修改的记录！");
            }
            else
            {
                managerUser.UserName = textUserName.Text;
                managerUser.UserPassword = textUserPassword.Text;
                managerUser.UserSort = cmbUserSort.Text;
                managerUser.UserID = Convert.ToInt32(dgvManagerUser[0, dgvManagerUser.CurrentCell.RowIndex].Value.ToString());

                managerUserStorage.UpdateManagerUser(managerUser);

                MessageBox.Show("更新成功！");

                textUserName.Text = "";
                textUserPassword.Text = "";
                cmbUserSort.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvManagerUser[0, dgvManagerUser.CurrentCell.RowIndex].Value.ToString());

            string connectionString = ConfigurationManager.ConnectionStrings["DEFAULT"].ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand command;
                        command = new SqlCommand("", conn, trans);
                        command.CommandText = "delete from ManagerUser where UserID = " + UserID;
                        command.ExecuteNonQuery();

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

            MessageBox.Show("删除成功！");

            textUserName.Text = "";
            textUserPassword.Text = "";
            cmbUserSort.Text = "";
        }

        private void dgvManagerUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string id = dgvManagerUser.Rows[e.RowIndex].Cells[0].Value.ToString();

                textUserName.Text =
                    dgvManagerUser.Rows[e.RowIndex].Cells[1].Value.ToString();

                textUserPassword.Text =
                    dgvManagerUser.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (dgvManagerUser.Rows[e.RowIndex].Cells[3]
                    .Value.ToString() == "系统管理员")
                {
                    cmbUserSort.SelectedIndex = 1;
                }
                else
                {
                    cmbUserSort.SelectedIndex = 2;
                }
            }
        }      

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
