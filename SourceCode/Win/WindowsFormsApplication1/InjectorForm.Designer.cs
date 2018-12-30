namespace WindowsFormsApplication1
{
    partial class InjectorForm
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
            this.dgvInjector = new System.Windows.Forms.DataGridView();
            this.labManufacturers = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labInjectionMessage = new System.Windows.Forms.Label();
            this.labVaccine = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpInjectorTime = new System.Windows.Forms.DateTimePicker();
            this.textInjectorNumber = new System.Windows.Forms.TextBox();
            this.textInjectorPhone = new System.Windows.Forms.TextBox();
            this.textInjectorSex = new System.Windows.Forms.TextBox();
            this.textInjectorName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModfiy = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.labQuit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInjector)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInjector
            // 
            this.dgvInjector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInjector.Location = new System.Drawing.Point(64, 304);
            this.dgvInjector.Name = "dgvInjector";
            this.dgvInjector.RowTemplate.Height = 23;
            this.dgvInjector.Size = new System.Drawing.Size(691, 221);
            this.dgvInjector.TabIndex = 15;
            this.dgvInjector.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInjector_CellDoubleClick);
            // 
            // labManufacturers
            // 
            this.labManufacturers.AutoSize = true;
            this.labManufacturers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labManufacturers.Location = new System.Drawing.Point(549, 30);
            this.labManufacturers.Name = "labManufacturers";
            this.labManufacturers.Size = new System.Drawing.Size(65, 12);
            this.labManufacturers.TabIndex = 14;
            this.labManufacturers.Text = "疫苗供应商";
            this.labManufacturers.Click += new System.EventHandler(this.labManufacturers_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "疫苗接种者";
            // 
            // labInjectionMessage
            // 
            this.labInjectionMessage.AutoSize = true;
            this.labInjectionMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labInjectionMessage.Location = new System.Drawing.Point(395, 30);
            this.labInjectionMessage.Name = "labInjectionMessage";
            this.labInjectionMessage.Size = new System.Drawing.Size(77, 12);
            this.labInjectionMessage.TabIndex = 12;
            this.labInjectionMessage.Text = "接种疫苗信息";
            this.labInjectionMessage.Click += new System.EventHandler(this.labInjectionMessage_Click);
            // 
            // labVaccine
            // 
            this.labVaccine.AutoSize = true;
            this.labVaccine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labVaccine.Location = new System.Drawing.Point(618, 30);
            this.labVaccine.Name = "labVaccine";
            this.labVaccine.Size = new System.Drawing.Size(53, 12);
            this.labVaccine.TabIndex = 11;
            this.labVaccine.Text = "疫苗信息";
            this.labVaccine.Click += new System.EventHandler(this.labVaccine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpInjectorTime);
            this.groupBox1.Controls.Add(this.textInjectorNumber);
            this.groupBox1.Controls.Add(this.textInjectorPhone);
            this.groupBox1.Controls.Add(this.textInjectorSex);
            this.groupBox1.Controls.Add(this.textInjectorName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnModfiy);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(64, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 190);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接种人信息";
            // 
            // dtpInjectorTime
            // 
            this.dtpInjectorTime.Location = new System.Drawing.Point(308, 82);
            this.dtpInjectorTime.Name = "dtpInjectorTime";
            this.dtpInjectorTime.Size = new System.Drawing.Size(200, 21);
            this.dtpInjectorTime.TabIndex = 14;
            // 
            // textInjectorNumber
            // 
            this.textInjectorNumber.Location = new System.Drawing.Point(79, 82);
            this.textInjectorNumber.Name = "textInjectorNumber";
            this.textInjectorNumber.Size = new System.Drawing.Size(68, 21);
            this.textInjectorNumber.TabIndex = 13;
            // 
            // textInjectorPhone
            // 
            this.textInjectorPhone.Location = new System.Drawing.Point(401, 24);
            this.textInjectorPhone.Name = "textInjectorPhone";
            this.textInjectorPhone.Size = new System.Drawing.Size(159, 21);
            this.textInjectorPhone.TabIndex = 12;
            // 
            // textInjectorSex
            // 
            this.textInjectorSex.Location = new System.Drawing.Point(217, 24);
            this.textInjectorSex.Name = "textInjectorSex";
            this.textInjectorSex.Size = new System.Drawing.Size(79, 21);
            this.textInjectorSex.TabIndex = 11;
            // 
            // textInjectorName
            // 
            this.textInjectorName.Location = new System.Drawing.Point(57, 24);
            this.textInjectorName.Name = "textInjectorName";
            this.textInjectorName.Size = new System.Drawing.Size(86, 21);
            this.textInjectorName.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(184, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "上一次接种疫苗时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "接种次数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "性别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "联系电话：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "姓名：";
            // 
            // btnModfiy
            // 
            this.btnModfiy.Location = new System.Drawing.Point(556, 131);
            this.btnModfiy.Name = "btnModfiy";
            this.btnModfiy.Size = new System.Drawing.Size(55, 26);
            this.btnModfiy.TabIndex = 2;
            this.btnModfiy.Text = "修改";
            this.btnModfiy.UseVisualStyleBackColor = true;
            this.btnModfiy.Click += new System.EventHandler(this.btnModfiy_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(617, 131);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(55, 26);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(434, 131);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(495, 131);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(55, 26);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // labQuit
            // 
            this.labQuit.AutoSize = true;
            this.labQuit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labQuit.Location = new System.Drawing.Point(702, 30);
            this.labQuit.Name = "labQuit";
            this.labQuit.Size = new System.Drawing.Size(53, 12);
            this.labQuit.TabIndex = 16;
            this.labQuit.Text = "退出登录";
            this.labQuit.Click += new System.EventHandler(this.labQuit_Click);
            // 
            // InjectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._2;
            this.ClientSize = new System.Drawing.Size(830, 574);
            this.Controls.Add(this.labQuit);
            this.Controls.Add(this.dgvInjector);
            this.Controls.Add(this.labManufacturers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labInjectionMessage);
            this.Controls.Add(this.labVaccine);
            this.Controls.Add(this.groupBox1);
            this.Name = "InjectorForm";
            this.Text = "接种人信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InjectorForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInjector)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInjector;
        private System.Windows.Forms.Label labManufacturers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labInjectionMessage;
        private System.Windows.Forms.Label labVaccine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpInjectorTime;
        private System.Windows.Forms.TextBox textInjectorNumber;
        private System.Windows.Forms.TextBox textInjectorPhone;
        private System.Windows.Forms.TextBox textInjectorSex;
        private System.Windows.Forms.TextBox textInjectorName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModfiy;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label labQuit;
    }
}