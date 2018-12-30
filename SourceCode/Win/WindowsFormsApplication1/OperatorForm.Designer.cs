namespace WindowsFormsApplication1
{
    partial class OperatorForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnModfiy = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbUserSort = new System.Windows.Forms.ComboBox();
            this.textUserPassword = new System.Windows.Forms.TextBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvManagerUser = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerUser)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnModfiy);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cmbUserSort);
            this.groupBox1.Controls.Add(this.textUserPassword);
            this.groupBox1.Controls.Add(this.textUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户管理";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(163, 305);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnModfiy
            // 
            this.btnModfiy.Location = new System.Drawing.Point(25, 305);
            this.btnModfiy.Name = "btnModfiy";
            this.btnModfiy.Size = new System.Drawing.Size(75, 23);
            this.btnModfiy.TabIndex = 8;
            this.btnModfiy.Text = "修改";
            this.btnModfiy.UseVisualStyleBackColor = true;
            this.btnModfiy.Click += new System.EventHandler(this.btnModfiy_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(163, 247);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 247);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbUserSort
            // 
            this.cmbUserSort.FormattingEnabled = true;
            this.cmbUserSort.Items.AddRange(new object[] {
            "全部",
            "系统管理员",
            "系统操作员"});
            this.cmbUserSort.Location = new System.Drawing.Point(84, 159);
            this.cmbUserSort.Name = "cmbUserSort";
            this.cmbUserSort.Size = new System.Drawing.Size(138, 20);
            this.cmbUserSort.TabIndex = 5;
            // 
            // textUserPassword
            // 
            this.textUserPassword.Location = new System.Drawing.Point(84, 118);
            this.textUserPassword.Name = "textUserPassword";
            this.textUserPassword.PasswordChar = '*';
            this.textUserPassword.Size = new System.Drawing.Size(138, 21);
            this.textUserPassword.TabIndex = 4;
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(84, 78);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(138, 21);
            this.textUserName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "职务：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // dgvManagerUser
            // 
            this.dgvManagerUser.AllowUserToAddRows = false;
            this.dgvManagerUser.AllowUserToDeleteRows = false;
            this.dgvManagerUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvManagerUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagerUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName,
            this.UserPassword,
            this.UserSort});
            this.dgvManagerUser.Location = new System.Drawing.Point(299, 49);
            this.dgvManagerUser.Name = "dgvManagerUser";
            this.dgvManagerUser.ReadOnly = true;
            this.dgvManagerUser.RowHeadersWidth = 21;
            this.dgvManagerUser.RowTemplate.Height = 23;
            this.dgvManagerUser.Size = new System.Drawing.Size(344, 403);
            this.dgvManagerUser.TabIndex = 0;
            this.dgvManagerUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagerUser_CellDoubleClick);
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "用户ID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "用户名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 110;
            // 
            // UserPassword
            // 
            this.UserPassword.DataPropertyName = "UserPassword";
            this.UserPassword.HeaderText = "用户密码";
            this.UserPassword.Name = "UserPassword";
            this.UserPassword.ReadOnly = true;
            // 
            // UserSort
            // 
            this.UserSort.DataPropertyName = "UserSort";
            this.UserSort.HeaderText = "用户职称";
            this.UserSort.Name = "UserSort";
            this.UserSort.ReadOnly = true;
            this.UserSort.Width = 110;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(546, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "退出登录";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(470, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "返回菜单";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // OperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.内界面;
            this.ClientSize = new System.Drawing.Size(656, 468);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvManagerUser);
            this.Controls.Add(this.groupBox1);
            this.Name = "OperatorForm";
            this.Text = "OperatorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperatorForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnModfiy;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbUserSort;
        private System.Windows.Forms.TextBox textUserPassword;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvManagerUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}