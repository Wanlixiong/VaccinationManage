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
    public partial class InjectionMessageForm : Form
    {
        public InjectionMessageForm()
        {
            InitializeComponent();
        }

        private void InjectionMessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void labVaccine_Click(object sender, EventArgs e)
        {
            this.Hide();
            VaccineForm vaccine = new VaccineForm();
            vaccine.ShowDialog();
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
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            InjectionMessage injectionMessage = new InjectionMessage();

            if (cmbInjectorName.Text.Trim() == "" || cmbVaccineName.Text.Trim() == ""
               || textInjectionMessageSite.Text.Trim() == "" || dtpInjectionMessageTime.Text.Trim() == ""
               || textInjectionMessageDoctor.Text.Trim() == "")
            {
                MessageBox.Show("请输入全部信息，不要有遗漏。");
            }
            else
            {
                injectionMessage.InjectorID = Convert.ToInt32(cmbInjectorName.SelectedValue.ToString());
                injectionMessage.VaccineID = Convert.ToInt32(cmbVaccineName.SelectedValue.ToString());
                injectionMessage.InjectionMessageSite = textInjectionMessageSite.Text.Trim();
                injectionMessage.InjectionMessageTime = Convert.ToDateTime(dtpInjectionMessageTime.Text.Trim());
                injectionMessage.InjectionMessageDoctor = textInjectionMessageDoctor.Text.Trim();

                injectionMessageStorage.CreateInjectionMessage(injectionMessage);

                MessageBox.Show("增加成功！");

                cmbInjectorName.Text = "";
                cmbVaccineName.Text = "";
                textInjectionMessageSite.Text = "";
                dtpInjectionMessageTime.Text = "";
                textInjectionMessageDoctor.Text = "";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            IList<InjectionMessage> injectionMessageList = new List<InjectionMessage>();

            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();

            IInjectorStorage injectorStorage = new InjectorStorage();

            IVaccineStorage vaccineStorage = new VaccineStorage();

            QueryInjectionMessage queryInjectionMessage = new QueryInjectionMessage();

            #region pspselect
            if (cmbInjectorName.Text.Trim() != "" && cmbVaccineName.Text.Trim() != "")
            {
                queryInjectionMessage.InjectorID = Convert.ToInt32(cmbInjectorName.SelectedValue.ToString());
                queryInjectionMessage.VaccineID = Convert.ToInt32(cmbVaccineName.SelectedValue.ToString());
                queryInjectionMessage.InjectionMessageSite = textInjectionMessageSite.Text.Trim();
                queryInjectionMessage.InjectionMessageDoctor = textInjectionMessageDoctor.Text.Trim();
            }
            else if (cmbInjectorName.Text.Trim() == "" && cmbVaccineName.Text.Trim() != "")
            {
                queryInjectionMessage.VaccineID = Convert.ToInt32(cmbVaccineName.SelectedValue.ToString());
                queryInjectionMessage.InjectionMessageSite = textInjectionMessageSite.Text.Trim();
                queryInjectionMessage.InjectionMessageDoctor = textInjectionMessageDoctor.Text.Trim();
            }
            else if (cmbInjectorName.Text.Trim() != "" && cmbVaccineName.Text.Trim() == "")
            {
                queryInjectionMessage.InjectorID = Convert.ToInt32(cmbInjectorName.SelectedValue.ToString());
                queryInjectionMessage.InjectionMessageSite = textInjectionMessageSite.Text.Trim();
                queryInjectionMessage.InjectionMessageDoctor = textInjectionMessageDoctor.Text.Trim();
            }
            else
            {
                queryInjectionMessage.InjectionMessageSite = textInjectionMessageSite.Text.Trim();
                queryInjectionMessage.InjectionMessageDoctor = textInjectionMessageDoctor.Text.Trim();
            }
            #endregion

            injectionMessageList = injectionMessageStorage.ListInjectionMessage(queryInjectionMessage);

            foreach (InjectionMessage injectionMessage in injectionMessageList)                 //对injectionMessageList数组遍历
            {
                injectionMessage.InjectorName = (injectorStorage.ReadInjector(injectionMessage.InjectorID)).InjectorName;
                injectionMessage.VaccineName = (vaccineStorage.ReadVaccine(injectionMessage.VaccineID)).VaccineName;
            }

            dgvInjectionMessage.AutoGenerateColumns = true;
            dgvInjectionMessage.DataSource = injectionMessageList;

            dgvInjectionMessage.Columns[0].Visible = false;
            dgvInjectionMessage.Columns[1].Visible = false;
            dgvInjectionMessage.Columns[3].Visible = false;

            dgvInjectionMessage.Columns[2].Width = 130;
            dgvInjectionMessage.Columns[4].Width = 130;
            dgvInjectionMessage.Columns[5].Width = 130;
            dgvInjectionMessage.Columns[6].Width = 130;
            dgvInjectionMessage.Columns[7].Width = 130;

        }

        private void btnModfiy_Click(object sender, EventArgs e)
        {
            IInjectionMessageStorage injectionMessageStorage = new InjectionMessageStorage();
            InjectionMessage injectionMessage = new InjectionMessage();

            if (cmbInjectorName.Text.Trim() == "" || cmbVaccineName.Text.Trim() == ""
               || textInjectionMessageSite.Text.Trim() == "" || dtpInjectionMessageTime.Text.Trim() == ""
               || textInjectionMessageDoctor.Text.Trim() == "")
            {
                MessageBox.Show("请双击需要修改的记录！");
            }
            else
            {
                injectionMessage.InjectorID = Convert.ToInt32(cmbInjectorName.SelectedValue.ToString());
                injectionMessage.VaccineID = Convert.ToInt32(cmbVaccineName.SelectedValue.ToString());
                injectionMessage.InjectionMessageSite = textInjectionMessageSite.Text;
                injectionMessage.InjectionMessageTime = Convert.ToDateTime(dtpInjectionMessageTime.Text.Trim());
                injectionMessage.InjectionMessageDoctor = textInjectionMessageDoctor.Text;
                injectionMessage.InjectionMessageID = Convert.ToInt32(dgvInjectionMessage[0, dgvInjectionMessage.CurrentCell.RowIndex].Value.ToString());

                injectionMessageStorage.UpdateInjectionMessage(injectionMessage);

                MessageBox.Show("更新成功！");

                cmbInjectorName.Text = "";
                cmbVaccineName.Text = "";
                textInjectionMessageSite.Text = "";
                dtpInjectionMessageTime.Text = "";
                textInjectionMessageDoctor.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int InjectionMessageID = Convert.ToInt32(dgvInjectionMessage[0, dgvInjectionMessage.CurrentCell.RowIndex].Value.ToString());

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
                        command.CommandText = "delete from InjectionMessage where InjectionMessageID = " + InjectionMessageID;
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

            cmbInjectorName.Text = "";
            cmbVaccineName.Text = "";
            textInjectionMessageSite.Text = "";
            dtpInjectionMessageTime.Text = "";
            textInjectionMessageDoctor.Text = "";
        }

        private void dgvInjectionMessage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string id = dgvInjectionMessage.Rows[e.RowIndex].Cells[0].Value.ToString();

                cmbInjectorName.Text = dgvInjectionMessage.Rows[e.RowIndex].Cells[2].Value.ToString();

                cmbVaccineName.Text = dgvInjectionMessage.Rows[e.RowIndex].Cells[4].Value.ToString();

                textInjectionMessageSite.Text = dgvInjectionMessage.Rows[e.RowIndex].Cells[5].Value.ToString();

                dtpInjectionMessageTime.Text = dgvInjectionMessage.Rows[e.RowIndex].Cells[6].Value.ToString();

                textInjectionMessageDoctor.Text = dgvInjectionMessage.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        //数据源动态绑定
        private void InjectionMessageForm_Load(object sender, EventArgs e)
        {
            IList<Injector> injectorList = new List<Injector>();
            IInjectorStorage injectorStorage = new InjectorStorage();
            QueryInjector queryInjector = new QueryInjector();

            IList<Vaccine> vaccineList = new List<Vaccine>();
            IVaccineStorage vaccineStorage = new VaccineStorage();
            QueryVaccine queryVaccine = new QueryVaccine();

            injectorList = injectorStorage.ListInjector(queryInjector);
            vaccineList = vaccineStorage.ListVaccine(queryVaccine);

            cmbInjectorName.DataSource = injectorList;
            DataTable dtInjector = new DataTable();

            cmbVaccineName.DataSource = vaccineList;
            DataTable dtVaccine = new DataTable();

            dtInjector.Columns.Add("InjectorID", typeof(System.Int32));
            dtInjector.Columns.Add("InjectorName", typeof(System.String));

            dtVaccine.Columns.Add("VaccineID", typeof(System.Int32));
            dtVaccine.Columns.Add("VaccineName", typeof(System.String));

            foreach (Injector pInjectorlist in injectorList)
            {
                dtInjector.Rows.Add(
                    pInjectorlist.InjectorID,
                    pInjectorlist.InjectorName
                    );
            }

            foreach (Vaccine pVaccinelist in vaccineList)
            {
                dtVaccine.Rows.Add(
                    pVaccinelist.VaccineID,
                    pVaccinelist.VaccineName
                    );
            }

            cmbInjectorName.DisplayMember = Convert.ToString(dtInjector.Columns[1]);
            cmbInjectorName.ValueMember = Convert.ToString(dtInjector.Columns[0]);

            cmbVaccineName.DisplayMember = Convert.ToString(dtVaccine.Columns[1]);
            cmbVaccineName.ValueMember = Convert.ToString(dtVaccine.Columns[0]);

            cmbInjectorName.Text = "";
            cmbVaccineName.Text = "";
        }

    }
}
