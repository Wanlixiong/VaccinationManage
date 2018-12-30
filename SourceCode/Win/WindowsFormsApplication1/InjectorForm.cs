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
    public partial class InjectorForm : Form
    {
        public InjectorForm()
        {
            InitializeComponent();
        }

        private void InjectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void labVaccine_Click(object sender, EventArgs e)
        {
            this.Hide();
            VaccineForm vaccine = new VaccineForm();
            vaccine.ShowDialog();
        }

        private void labInjectionMessage_Click(object sender, EventArgs e)
        {
            this.Hide();
            InjectionMessageForm injectionMessage = new InjectionMessageForm();
            injectionMessage.ShowDialog();
        }

        private void labManufacturers_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManufacturersForm manufacturers = new ManufacturersForm();
            manufacturers.ShowDialog();
        }

        private void labQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector injector = new Injector();

            if (textInjectorName.Text.Trim() == "" || textInjectorSex.Text.Trim() == "" ||
                textInjectorPhone.Text.Trim() == "" || textInjectorNumber.Text.Trim() == "" ||
                dtpInjectorTime.Text.Trim() == "")
            {
                MessageBox.Show("请输入全部信息，不要有遗漏。");
            }
            else
            {
                injector.InjectorName = textInjectorName.Text.Trim();
                injector.InjectorSex = textInjectorSex.Text.Trim();
                injector.InjectorPhone = textInjectorPhone.Text.Trim();
                injector.InjectorNumber = Convert.ToInt32(textInjectorNumber.Text.Trim());
                injector.InjectorTime = Convert.ToDateTime(dtpInjectorTime.Text.Trim());

                injectorStorage.CreateInjector(injector);

                MessageBox.Show("增加成功！");

                textInjectorName.Text = "";
                textInjectorSex.Text = "";
                textInjectorPhone.Text = "";
                textInjectorNumber.Text = "";
                dtpInjectorTime.Text = "";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            IList<Injector> injectorList = new List<Injector>();

            IInjectorStorage injectorStorage = new InjectorStorage();

            QueryInjector queryInjector = new QueryInjector();

            queryInjector.InjectorName = textInjectorName.Text.Trim();
            queryInjector.InjectorSex= textInjectorSex.Text.Trim();
            queryInjector.InjectorPhone = textInjectorPhone.Text.Trim();

            injectorList = injectorStorage.ListInjector(queryInjector);

            dgvInjector.AutoGenerateColumns = true;
            dgvInjector.DataSource = injectorList;

            dgvInjector.Columns[0].Visible = false;

            dgvInjector.Columns[1].Width = 130;
            dgvInjector.Columns[2].Width = 130;
            dgvInjector.Columns[3].Width = 125;
            dgvInjector.Columns[4].Width = 130;
            dgvInjector.Columns[5].Width = 130;
        }

        private void btnModfiy_Click(object sender, EventArgs e)
        {
            IInjectorStorage injectorStorage = new InjectorStorage();
            Injector injector = new Injector();

            if (textInjectorName.Text.Trim() == "" || textInjectorSex.Text.Trim() == "" ||
                textInjectorPhone.Text.Trim() == "" || textInjectorNumber.Text.Trim() == "" ||
                dtpInjectorTime.Text.Trim() == "")
            {
                MessageBox.Show("请双击需要修改的记录！");
            }
            else
            {
                injector.InjectorName = textInjectorName.Text;
                injector.InjectorSex = textInjectorSex.Text;
                injector.InjectorPhone = textInjectorPhone.Text;
                injector.InjectorNumber = Convert.ToInt32(textInjectorNumber.Text);
                injector.InjectorTime = Convert.ToDateTime(dtpInjectorTime.Text);
                injector.InjectorID = Convert.ToInt32(dgvInjector[0, dgvInjector.CurrentCell.RowIndex].Value.ToString());

                injectorStorage.UpdateInjector(injector);

                MessageBox.Show("更新成功！");

                textInjectorName.Text = "";
                textInjectorSex.Text = "";
                textInjectorPhone.Text = "";
                textInjectorNumber.Text = "";
                dtpInjectorTime.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int InjectorID = Convert.ToInt32(dgvInjector[0, dgvInjector.CurrentCell.RowIndex].Value.ToString());

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
                        command.CommandText = "delete from Injector where InjectorID = " + InjectorID;
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

            textInjectorName.Text = "";
            textInjectorSex.Text = "";
            textInjectorPhone.Text = "";
            textInjectorNumber.Text = "";
            dtpInjectorTime.Text = "";
        }

        private void dgvInjector_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string id = dgvInjector.Rows[e.RowIndex].Cells[0].Value.ToString();

                textInjectorName.Text = dgvInjector.Rows[e.RowIndex].Cells[1].Value.ToString();

                textInjectorSex.Text = dgvInjector.Rows[e.RowIndex].Cells[2].Value.ToString();

                textInjectorPhone.Text = dgvInjector.Rows[e.RowIndex].Cells[3].Value.ToString();

                textInjectorNumber.Text = dgvInjector.Rows[e.RowIndex].Cells[4].Value.ToString();

                dtpInjectorTime.Text = dgvInjector.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

    }
}
