namespace WindowsFormsApplication1
{
    partial class ManufacturersForm
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
            this.dgvManufacturers = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpManufacturersDoe = new System.Windows.Forms.DateTimePicker();
            this.dtpManufacturersDom = new System.Windows.Forms.DateTimePicker();
            this.textManufacturersPhone = new System.Windows.Forms.TextBox();
            this.textManufacturersSite = new System.Windows.Forms.TextBox();
            this.textManufacturersName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModfiy = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.labVaccine = new System.Windows.Forms.Label();
            this.labInjectionMessage = new System.Windows.Forms.Label();
            this.labInjector = new System.Windows.Forms.Label();
            this.labManufacturers = new System.Windows.Forms.Label();
            this.labQuit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManufacturers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvManufacturers
            // 
            this.dgvManufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManufacturers.Location = new System.Drawing.Point(64, 314);
            this.dgvManufacturers.Name = "dgvManufacturers";
            this.dgvManufacturers.RowTemplate.Height = 23;
            this.dgvManufacturers.Size = new System.Drawing.Size(691, 221);
            this.dgvManufacturers.TabIndex = 15;
            this.dgvManufacturers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManufacturers_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpManufacturersDoe);
            this.groupBox1.Controls.Add(this.dtpManufacturersDom);
            this.groupBox1.Controls.Add(this.textManufacturersPhone);
            this.groupBox1.Controls.Add(this.textManufacturersSite);
            this.groupBox1.Controls.Add(this.textManufacturersName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnModfiy);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(64, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 190);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "供应商信息";
            // 
            // dtpManufacturersDoe
            // 
            this.dtpManufacturersDoe.Location = new System.Drawing.Point(365, 82);
            this.dtpManufacturersDoe.Name = "dtpManufacturersDoe";
            this.dtpManufacturersDoe.Size = new System.Drawing.Size(200, 21);
            this.dtpManufacturersDoe.TabIndex = 14;
            // 
            // dtpManufacturersDom
            // 
            this.dtpManufacturersDom.Location = new System.Drawing.Point(81, 82);
            this.dtpManufacturersDom.Name = "dtpManufacturersDom";
            this.dtpManufacturersDom.Size = new System.Drawing.Size(200, 21);
            this.dtpManufacturersDom.TabIndex = 13;
            // 
            // textManufacturersPhone
            // 
            this.textManufacturersPhone.Location = new System.Drawing.Point(504, 24);
            this.textManufacturersPhone.Name = "textManufacturersPhone";
            this.textManufacturersPhone.Size = new System.Drawing.Size(168, 21);
            this.textManufacturersPhone.TabIndex = 12;
            // 
            // textManufacturersSite
            // 
            this.textManufacturersSite.Location = new System.Drawing.Point(303, 24);
            this.textManufacturersSite.Name = "textManufacturersSite";
            this.textManufacturersSite.Size = new System.Drawing.Size(138, 21);
            this.textManufacturersSite.TabIndex = 11;
            // 
            // textManufacturersName
            // 
            this.textManufacturersName.Location = new System.Drawing.Point(90, 23);
            this.textManufacturersName.Name = "textManufacturersName";
            this.textManufacturersName.Size = new System.Drawing.Size(159, 21);
            this.textManufacturersName.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "失效时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "生产时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "地址：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(466, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "电话：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "供应商名称：";
            // 
            // btnModfiy
            // 
            this.btnModfiy.Location = new System.Drawing.Point(556, 133);
            this.btnModfiy.Name = "btnModfiy";
            this.btnModfiy.Size = new System.Drawing.Size(55, 26);
            this.btnModfiy.TabIndex = 2;
            this.btnModfiy.Text = "修改";
            this.btnModfiy.UseVisualStyleBackColor = true;
            this.btnModfiy.Click += new System.EventHandler(this.btnModfiy_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(617, 133);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(55, 26);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(434, 133);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(495, 133);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(55, 26);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // labVaccine
            // 
            this.labVaccine.AutoSize = true;
            this.labVaccine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labVaccine.Location = new System.Drawing.Point(618, 26);
            this.labVaccine.Name = "labVaccine";
            this.labVaccine.Size = new System.Drawing.Size(53, 12);
            this.labVaccine.TabIndex = 11;
            this.labVaccine.Text = "疫苗信息";
            this.labVaccine.Click += new System.EventHandler(this.labVaccine_Click);
            // 
            // labInjectionMessage
            // 
            this.labInjectionMessage.AutoSize = true;
            this.labInjectionMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labInjectionMessage.Location = new System.Drawing.Point(393, 26);
            this.labInjectionMessage.Name = "labInjectionMessage";
            this.labInjectionMessage.Size = new System.Drawing.Size(77, 12);
            this.labInjectionMessage.TabIndex = 12;
            this.labInjectionMessage.Text = "接种疫苗信息";
            this.labInjectionMessage.Click += new System.EventHandler(this.labInjectionMessage_Click);
            // 
            // labInjector
            // 
            this.labInjector.AutoSize = true;
            this.labInjector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labInjector.Location = new System.Drawing.Point(476, 26);
            this.labInjector.Name = "labInjector";
            this.labInjector.Size = new System.Drawing.Size(65, 12);
            this.labInjector.TabIndex = 13;
            this.labInjector.Text = "接种疫苗者";
            this.labInjector.Click += new System.EventHandler(this.labInjector_Click);
            // 
            // labManufacturers
            // 
            this.labManufacturers.AutoSize = true;
            this.labManufacturers.Location = new System.Drawing.Point(547, 26);
            this.labManufacturers.Name = "labManufacturers";
            this.labManufacturers.Size = new System.Drawing.Size(65, 12);
            this.labManufacturers.TabIndex = 14;
            this.labManufacturers.Text = "疫苗供应商";
            // 
            // labQuit
            // 
            this.labQuit.AutoSize = true;
            this.labQuit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labQuit.Location = new System.Drawing.Point(702, 26);
            this.labQuit.Name = "labQuit";
            this.labQuit.Size = new System.Drawing.Size(53, 12);
            this.labQuit.TabIndex = 16;
            this.labQuit.Text = "退出登录";
            this.labQuit.Click += new System.EventHandler(this.labQuit_Click);
            // 
            // ManufacturersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._2;
            this.ClientSize = new System.Drawing.Size(830, 574);
            this.Controls.Add(this.labQuit);
            this.Controls.Add(this.dgvManufacturers);
            this.Controls.Add(this.labManufacturers);
            this.Controls.Add(this.labInjector);
            this.Controls.Add(this.labInjectionMessage);
            this.Controls.Add(this.labVaccine);
            this.Controls.Add(this.groupBox1);
            this.Name = "ManufacturersForm";
            this.Text = "供应商信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManufacturersForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManufacturers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManufacturers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpManufacturersDoe;
        private System.Windows.Forms.DateTimePicker dtpManufacturersDom;
        private System.Windows.Forms.TextBox textManufacturersPhone;
        private System.Windows.Forms.TextBox textManufacturersSite;
        private System.Windows.Forms.TextBox textManufacturersName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModfiy;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label labVaccine;
        private System.Windows.Forms.Label labInjectionMessage;
        private System.Windows.Forms.Label labInjector;
        private System.Windows.Forms.Label labManufacturers;
        private System.Windows.Forms.Label labQuit;
    }
}