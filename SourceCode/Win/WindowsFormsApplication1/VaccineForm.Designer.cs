namespace WindowsFormsApplication1
{
    partial class VaccineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnModfiy = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.groupVaccine = new System.Windows.Forms.GroupBox();
            this.cmbManufacturersName = new System.Windows.Forms.ComboBox();
            this.textVaccineQuantity = new System.Windows.Forms.TextBox();
            this.textVaccinePrice = new System.Windows.Forms.TextBox();
            this.textVaccineSort = new System.Windows.Forms.TextBox();
            this.textVaccineName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labVaccine = new System.Windows.Forms.Label();
            this.labInjectionMessage = new System.Windows.Forms.Label();
            this.labInjector = new System.Windows.Forms.Label();
            this.labManufacturers = new System.Windows.Forms.Label();
            this.dgvVaccine = new System.Windows.Forms.DataGridView();
            this.labQuit = new System.Windows.Forms.Label();
            this.groupVaccine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccine)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(434, 136);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(495, 136);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(55, 26);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnModfiy
            // 
            this.btnModfiy.Location = new System.Drawing.Point(556, 136);
            this.btnModfiy.Name = "btnModfiy";
            this.btnModfiy.Size = new System.Drawing.Size(55, 26);
            this.btnModfiy.TabIndex = 2;
            this.btnModfiy.Text = "修改";
            this.btnModfiy.UseVisualStyleBackColor = true;
            this.btnModfiy.Click += new System.EventHandler(this.btnModfiy_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(617, 136);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(55, 26);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // groupVaccine
            // 
            this.groupVaccine.BackColor = System.Drawing.Color.Transparent;
            this.groupVaccine.Controls.Add(this.cmbManufacturersName);
            this.groupVaccine.Controls.Add(this.textVaccineQuantity);
            this.groupVaccine.Controls.Add(this.textVaccinePrice);
            this.groupVaccine.Controls.Add(this.textVaccineSort);
            this.groupVaccine.Controls.Add(this.textVaccineName);
            this.groupVaccine.Controls.Add(this.label9);
            this.groupVaccine.Controls.Add(this.label8);
            this.groupVaccine.Controls.Add(this.label7);
            this.groupVaccine.Controls.Add(this.label6);
            this.groupVaccine.Controls.Add(this.label5);
            this.groupVaccine.Controls.Add(this.btnModfiy);
            this.groupVaccine.Controls.Add(this.btnDel);
            this.groupVaccine.Controls.Add(this.btnAdd);
            this.groupVaccine.Controls.Add(this.btnSelect);
            this.groupVaccine.Location = new System.Drawing.Point(56, 47);
            this.groupVaccine.Name = "groupVaccine";
            this.groupVaccine.Size = new System.Drawing.Size(691, 190);
            this.groupVaccine.TabIndex = 4;
            this.groupVaccine.TabStop = false;
            this.groupVaccine.Text = "疫苗信息";
            // 
            // cmbManufacturersName
            // 
            this.cmbManufacturersName.FormattingEnabled = true;
            this.cmbManufacturersName.Location = new System.Drawing.Point(483, 24);
            this.cmbManufacturersName.Name = "cmbManufacturersName";
            this.cmbManufacturersName.Size = new System.Drawing.Size(159, 20);
            this.cmbManufacturersName.TabIndex = 15;
            // 
            // textVaccineQuantity
            // 
            this.textVaccineQuantity.Location = new System.Drawing.Point(225, 86);
            this.textVaccineQuantity.Name = "textVaccineQuantity";
            this.textVaccineQuantity.Size = new System.Drawing.Size(83, 21);
            this.textVaccineQuantity.TabIndex = 14;
            // 
            // textVaccinePrice
            // 
            this.textVaccinePrice.Location = new System.Drawing.Point(60, 86);
            this.textVaccinePrice.Name = "textVaccinePrice";
            this.textVaccinePrice.Size = new System.Drawing.Size(68, 21);
            this.textVaccinePrice.TabIndex = 13;
            // 
            // textVaccineSort
            // 
            this.textVaccineSort.Location = new System.Drawing.Point(313, 24);
            this.textVaccineSort.Name = "textVaccineSort";
            this.textVaccineSort.Size = new System.Drawing.Size(79, 21);
            this.textVaccineSort.TabIndex = 11;
            // 
            // textVaccineName
            // 
            this.textVaccineName.Location = new System.Drawing.Point(79, 24);
            this.textVaccineName.Name = "textVaccineName";
            this.textVaccineName.Size = new System.Drawing.Size(159, 21);
            this.textVaccineName.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(184, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "数量：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "价格：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "类别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "供应商：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "疫苗名称：";
            // 
            // labVaccine
            // 
            this.labVaccine.AutoSize = true;
            this.labVaccine.Location = new System.Drawing.Point(614, 22);
            this.labVaccine.Name = "labVaccine";
            this.labVaccine.Size = new System.Drawing.Size(53, 12);
            this.labVaccine.TabIndex = 5;
            this.labVaccine.Text = "疫苗信息";
            // 
            // labInjectionMessage
            // 
            this.labInjectionMessage.AutoSize = true;
            this.labInjectionMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labInjectionMessage.Location = new System.Drawing.Point(389, 22);
            this.labInjectionMessage.Name = "labInjectionMessage";
            this.labInjectionMessage.Size = new System.Drawing.Size(77, 12);
            this.labInjectionMessage.TabIndex = 6;
            this.labInjectionMessage.Text = "接种疫苗信息";
            this.labInjectionMessage.Click += new System.EventHandler(this.labInjectionMessage_Click);
            // 
            // labInjector
            // 
            this.labInjector.AutoSize = true;
            this.labInjector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labInjector.Location = new System.Drawing.Point(472, 22);
            this.labInjector.Name = "labInjector";
            this.labInjector.Size = new System.Drawing.Size(65, 12);
            this.labInjector.TabIndex = 7;
            this.labInjector.Text = "接种疫苗者";
            this.labInjector.Click += new System.EventHandler(this.labInjector_Click);
            // 
            // labManufacturers
            // 
            this.labManufacturers.AutoSize = true;
            this.labManufacturers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labManufacturers.Location = new System.Drawing.Point(543, 22);
            this.labManufacturers.Name = "labManufacturers";
            this.labManufacturers.Size = new System.Drawing.Size(65, 12);
            this.labManufacturers.TabIndex = 8;
            this.labManufacturers.Text = "疫苗供应商";
            this.labManufacturers.Click += new System.EventHandler(this.labManufacturers_Click);
            // 
            // dgvVaccine
            // 
            this.dgvVaccine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccine.Location = new System.Drawing.Point(56, 298);
            this.dgvVaccine.Name = "dgvVaccine";
            this.dgvVaccine.RowTemplate.Height = 23;
            this.dgvVaccine.Size = new System.Drawing.Size(691, 221);
            this.dgvVaccine.TabIndex = 9;
            this.dgvVaccine.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVaccine_CellDoubleClick);
            // 
            // labQuit
            // 
            this.labQuit.AutoSize = true;
            this.labQuit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labQuit.Location = new System.Drawing.Point(694, 22);
            this.labQuit.Name = "labQuit";
            this.labQuit.Size = new System.Drawing.Size(53, 12);
            this.labQuit.TabIndex = 10;
            this.labQuit.Text = "退出登录";
            this.labQuit.Click += new System.EventHandler(this.labQuit_Click);
            // 
            // VaccineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._2;
            this.ClientSize = new System.Drawing.Size(830, 574);
            this.Controls.Add(this.labQuit);
            this.Controls.Add(this.dgvVaccine);
            this.Controls.Add(this.labManufacturers);
            this.Controls.Add(this.labInjector);
            this.Controls.Add(this.labInjectionMessage);
            this.Controls.Add(this.labVaccine);
            this.Controls.Add(this.groupVaccine);
            this.Name = "VaccineForm";
            this.Text = "VaccineForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VaccineForm_FormClosing);
            this.groupVaccine.ResumeLayout(false);
            this.groupVaccine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnModfiy;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.GroupBox groupVaccine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labVaccine;
        private System.Windows.Forms.Label labInjectionMessage;
        private System.Windows.Forms.Label labInjector;
        private System.Windows.Forms.Label labManufacturers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textVaccineQuantity;
        private System.Windows.Forms.TextBox textVaccinePrice;
        private System.Windows.Forms.TextBox textVaccineSort;
        private System.Windows.Forms.TextBox textVaccineName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvVaccine;
        private System.Windows.Forms.Label labQuit;
        private System.Windows.Forms.ComboBox cmbManufacturersName;
    }
}