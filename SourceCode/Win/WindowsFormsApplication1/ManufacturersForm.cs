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
    public partial class ManufacturersForm : Form
    {
        public ManufacturersForm()
        {
            InitializeComponent();
        }

        private void ManufacturersForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void labInjector_Click(object sender, EventArgs e)
        {
            this.Hide();
            InjectorForm injector = new InjectorForm();
            injector.ShowDialog();
        }

        private void labQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers manufacturers = new Manufacturers();

            if (textManufacturersName.Text.Trim() == "" || textManufacturersSite.Text.Trim() == "" ||
                textManufacturersPhone.Text.Trim() == "" || dtpManufacturersDom.Text.Trim() == "" ||
                dtpManufacturersDoe.Text.Trim() == "")
            {
                MessageBox.Show("请输入全部信息，不要有遗漏。");
            }
            else
            {
                manufacturers.ManufacturersName = textManufacturersName.Text.Trim();
                manufacturers.ManufacturersSite = textManufacturersSite.Text.Trim();
                manufacturers.ManufacturersPhone = textManufacturersPhone.Text.Trim();
                manufacturers.ManufacturersDom = Convert.ToDateTime(dtpManufacturersDom.Text.Trim());
                manufacturers.ManufacturersDoe = Convert.ToDateTime(dtpManufacturersDoe.Text.Trim());

                manufacturersStorage.CreateManufacturers(manufacturers);

                MessageBox.Show("增加成功！");

                textManufacturersName.Text = "";
                textManufacturersSite.Text = "";
                textManufacturersPhone.Text = "";
                dtpManufacturersDom.Text = "";
                dtpManufacturersDoe.Text = "";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            IList<Manufacturers> manufacturersList = new List<Manufacturers>();

            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();

            QueryManufacturers queryManufacturers = new QueryManufacturers();

            queryManufacturers.ManufacturersName = textManufacturersName.Text.Trim();
            queryManufacturers.ManufacturersSite = textManufacturersSite.Text.Trim();
            queryManufacturers.ManufacturersPhone = textManufacturersPhone.Text.Trim();

            manufacturersList = manufacturersStorage.ListManufacturers(queryManufacturers);

            dgvManufacturers.AutoGenerateColumns = true;
            dgvManufacturers.DataSource = manufacturersList;

            dgvManufacturers.Columns[0].Visible = false;

            dgvManufacturers.Columns[1].Width = 130;
            dgvManufacturers.Columns[2].Width = 130;
            dgvManufacturers.Columns[3].Width = 125;
            dgvManufacturers.Columns[4].Width = 130;
            dgvManufacturers.Columns[5].Width = 130;
        }

        private void btnModfiy_Click(object sender, EventArgs e)
        {
            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();
            Manufacturers manufacturers = new Manufacturers();

            if (textManufacturersName.Text.Trim() == "" || textManufacturersSite.Text.Trim() == "" ||
                textManufacturersPhone.Text.Trim() == "" || dtpManufacturersDom.Text.Trim() == "" ||
                dtpManufacturersDoe.Text.Trim() == "")
            {
                MessageBox.Show("请双击需要修改的记录！");
            }
            else
            {
                manufacturers.ManufacturersName = textManufacturersName.Text;
                manufacturers.ManufacturersSite = textManufacturersSite.Text;
                manufacturers.ManufacturersPhone = textManufacturersPhone.Text;
                manufacturers.ManufacturersDom = Convert.ToDateTime(dtpManufacturersDom.Text);
                manufacturers.ManufacturersDoe = Convert.ToDateTime(dtpManufacturersDoe.Text);
                manufacturers.ManufacturersID = Convert.ToInt32(dgvManufacturers[0, dgvManufacturers.CurrentCell.RowIndex].Value.ToString());

                manufacturersStorage.UpdateManufacturers(manufacturers);

                MessageBox.Show("更新成功！");

                textManufacturersName.Text = "";
                textManufacturersSite.Text = "";
                textManufacturersPhone.Text = "";
                dtpManufacturersDom.Text = "";
                dtpManufacturersDoe.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int ManufacturersID = Convert.ToInt32(dgvManufacturers[0, dgvManufacturers.CurrentCell.RowIndex].Value.ToString());

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
                        command.CommandText = "delete from Manufacturers where ManufacturersID = " + ManufacturersID;
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

            textManufacturersName.Text = "";
            textManufacturersSite.Text = "";
            textManufacturersPhone.Text = "";
            dtpManufacturersDom.Text = "";
            dtpManufacturersDoe.Text = "";
        }

        private void dgvManufacturers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string id = dgvManufacturers.Rows[e.RowIndex].Cells[0].Value.ToString();

                textManufacturersName.Text = dgvManufacturers.Rows[e.RowIndex].Cells[1].Value.ToString();

                textManufacturersSite.Text = dgvManufacturers.Rows[e.RowIndex].Cells[2].Value.ToString();

                textManufacturersPhone.Text = dgvManufacturers.Rows[e.RowIndex].Cells[3].Value.ToString();

                dtpManufacturersDom.Text = dgvManufacturers.Rows[e.RowIndex].Cells[4].Value.ToString();

                dtpManufacturersDoe.Text = dgvManufacturers.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

    }
}
