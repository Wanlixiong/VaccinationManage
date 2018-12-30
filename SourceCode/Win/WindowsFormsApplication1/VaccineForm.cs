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
    public partial class VaccineForm : Form
    {
        public VaccineForm()
        {
            InitializeComponent();
        }

        private void VaccineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
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
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine vaccine = new Vaccine();            

            if (textVaccineName.Text.Trim() == "" || textVaccineSort.Text.Trim() == ""
               || cmbManufacturersName.Text.Trim() == "" || textVaccinePrice.Text.Trim() == ""
               || textVaccineQuantity.Text.Trim() == "")
            {
                MessageBox.Show("请输入全部信息，不要有遗漏。");
            }
            else
            {
                vaccine.VaccineName = textVaccineName.Text.Trim();
                vaccine.VaccineSort = textVaccineSort.Text.Trim();
                vaccine.ManufacturersID = Convert.ToInt32(cmbManufacturersName.SelectedValue.ToString());    //SelectedValue取后台的ID
                vaccine.VaccinePrice = Convert.ToDecimal(textVaccinePrice.Text.Trim());
                vaccine.VaccineQuantity = Convert.ToInt32(textVaccineQuantity.Text.Trim());

                vaccineStorage.CreateVaccine(vaccine);

                MessageBox.Show("增加成功！");

                textVaccineName.Text = "";
                textVaccineSort.Text = "";
                cmbManufacturersName.Text = "";
                textVaccinePrice.Text = "";
                textVaccineQuantity.Text = "";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            IList<Vaccine> vaccineList = new List<Vaccine>();

            IVaccineStorage vaccineStorage = new VaccineStorage();

            IManufacturersStorage manufacturersStorage = new ManufacturersStorage();

            QueryVaccine queryVaccine = new QueryVaccine();

            if (cmbManufacturersName.Text.Trim() == "")
            {
                queryVaccine.VaccineName = textVaccineName.Text.Trim();
                queryVaccine.VaccineSort = textVaccineSort.Text.Trim();
            }
            else
            {
                queryVaccine.VaccineName = textVaccineName.Text.Trim();
                queryVaccine.VaccineSort = textVaccineSort.Text.Trim();
                queryVaccine.ManufacturersID = Convert.ToInt32(cmbManufacturersName.SelectedValue.ToString());
            }

            vaccineList = vaccineStorage.ListVaccine(queryVaccine);

            foreach (Vaccine vaccine in vaccineList)                 //对vaccineList数组遍历
            {
                vaccine.ManufacturersName = (manufacturersStorage.ReadManufacturers(vaccine.ManufacturersID)).ManufacturersName;
            }

            dgvVaccine.AutoGenerateColumns = true;
            dgvVaccine.DataSource = vaccineList;

            dgvVaccine.Columns[0].Visible = false;
            dgvVaccine.Columns[3].Visible = false;

            dgvVaccine.Columns[1].Width = 130;
            dgvVaccine.Columns[2].Width = 130;
            dgvVaccine.Columns[4].Width = 130;
            dgvVaccine.Columns[5].Width = 130;
            dgvVaccine.Columns[6].Width = 130;                       
        }

        private void btnModfiy_Click(object sender, EventArgs e)
        {
            IVaccineStorage vaccineStorage = new VaccineStorage();
            Vaccine vaccine = new Vaccine();

            if (textVaccineName.Text.Trim() == "" || textVaccineSort.Text.Trim() == ""
               || cmbManufacturersName.Text.Trim() == "" || textVaccinePrice.Text.Trim() == ""
               || textVaccineQuantity.Text.Trim() == "")
            {
                MessageBox.Show("请双击需要修改的记录！");
            }
            else
            {
                vaccine.VaccineName = textVaccineName.Text;
                vaccine.VaccineSort = textVaccineSort.Text;
                vaccine.ManufacturersID = Convert.ToInt32(cmbManufacturersName.SelectedValue.ToString());
                vaccine.VaccinePrice = Convert.ToDecimal(textVaccinePrice.Text.Trim());
                vaccine.VaccineQuantity = Convert.ToInt32(textVaccineQuantity.Text.Trim());
                vaccine.VaccineID = Convert.ToInt32(dgvVaccine[0, dgvVaccine.CurrentCell.RowIndex].Value.ToString());

                vaccineStorage.UpdateVaccine(vaccine);

                MessageBox.Show("更新成功！");

                textVaccineName.Text = "";
                textVaccineSort.Text = "";
                cmbManufacturersName.Text = "";
                textVaccinePrice.Text = "";
                textVaccineQuantity.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int VaccineID = Convert.ToInt32(dgvVaccine[0, dgvVaccine.CurrentCell.RowIndex].Value.ToString());

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
                        command.CommandText = "delete from Vaccine where VaccineID = " + VaccineID;
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

            textVaccineName.Text = "";
            textVaccineSort.Text = "";
            cmbManufacturersName.Text = "";
            textVaccinePrice.Text = "";
            textVaccineQuantity.Text = "";
        }

        private void dgvVaccine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string id = dgvVaccine.Rows[e.RowIndex].Cells[0].Value.ToString();

                textVaccineName.Text = dgvVaccine.Rows[e.RowIndex].Cells[1].Value.ToString();

                textVaccineSort.Text = dgvVaccine.Rows[e.RowIndex].Cells[2].Value.ToString();

                cmbManufacturersName.Text = dgvVaccine.Rows[e.RowIndex].Cells[6].Value.ToString();

                textVaccinePrice.Text = dgvVaccine.Rows[e.RowIndex].Cells[4].Value.ToString();

                textVaccineQuantity.Text = dgvVaccine.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        //数据源动态绑定
        private void VaccineForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
