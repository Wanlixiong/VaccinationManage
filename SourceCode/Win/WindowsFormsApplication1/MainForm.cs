using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnVaccine_Click(object sender, EventArgs e)
        {
            this.Hide();
            VaccineForm mainFrom = new VaccineForm();
            mainFrom.ShowDialog();
        }

        private void btnInjMessage_Click(object sender, EventArgs e)
        {
            this.Hide();
            InjectionMessageForm mainFrom = new InjectionMessageForm();
            mainFrom.ShowDialog();
        }

        private void btnInjector_Click(object sender, EventArgs e)
        {
            this.Hide();
            InjectorForm mainFrom = new InjectorForm();
            mainFrom.ShowDialog();
        }

        private void btnMan_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManufacturersForm mainFrom = new ManufacturersForm();
            mainFrom.ShowDialog();
        }        

        private void btnRegUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            OperatorForm operatorForm = new OperatorForm();
            operatorForm.ShowDialog();
        }

        private void labQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
