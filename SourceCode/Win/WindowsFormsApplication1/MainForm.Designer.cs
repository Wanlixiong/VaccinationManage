namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.btnVaccine = new System.Windows.Forms.Button();
            this.btnInjMessage = new System.Windows.Forms.Button();
            this.btnInjector = new System.Windows.Forms.Button();
            this.btnMan = new System.Windows.Forms.Button();
            this.btnRegUser = new System.Windows.Forms.Button();
            this.labQuit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVaccine
            // 
            this.btnVaccine.Location = new System.Drawing.Point(456, 112);
            this.btnVaccine.Name = "btnVaccine";
            this.btnVaccine.Size = new System.Drawing.Size(103, 42);
            this.btnVaccine.TabIndex = 0;
            this.btnVaccine.Text = "疫苗信息";
            this.btnVaccine.UseVisualStyleBackColor = true;
            this.btnVaccine.Click += new System.EventHandler(this.btnVaccine_Click);
            // 
            // btnInjMessage
            // 
            this.btnInjMessage.Location = new System.Drawing.Point(129, 112);
            this.btnInjMessage.Name = "btnInjMessage";
            this.btnInjMessage.Size = new System.Drawing.Size(103, 42);
            this.btnInjMessage.TabIndex = 1;
            this.btnInjMessage.Text = "疫苗接种信息";
            this.btnInjMessage.UseVisualStyleBackColor = true;
            this.btnInjMessage.Click += new System.EventHandler(this.btnInjMessage_Click);
            // 
            // btnInjector
            // 
            this.btnInjector.Location = new System.Drawing.Point(238, 112);
            this.btnInjector.Name = "btnInjector";
            this.btnInjector.Size = new System.Drawing.Size(103, 42);
            this.btnInjector.TabIndex = 2;
            this.btnInjector.Text = "接种者信息";
            this.btnInjector.UseVisualStyleBackColor = true;
            this.btnInjector.Click += new System.EventHandler(this.btnInjector_Click);
            // 
            // btnMan
            // 
            this.btnMan.Location = new System.Drawing.Point(347, 112);
            this.btnMan.Name = "btnMan";
            this.btnMan.Size = new System.Drawing.Size(103, 42);
            this.btnMan.TabIndex = 3;
            this.btnMan.Text = "供应商信息";
            this.btnMan.UseVisualStyleBackColor = true;
            this.btnMan.Click += new System.EventHandler(this.btnMan_Click);
            // 
            // btnRegUser
            // 
            this.btnRegUser.Location = new System.Drawing.Point(20, 112);
            this.btnRegUser.Name = "btnRegUser";
            this.btnRegUser.Size = new System.Drawing.Size(103, 42);
            this.btnRegUser.TabIndex = 5;
            this.btnRegUser.Text = "用户管理";
            this.btnRegUser.UseVisualStyleBackColor = true;
            this.btnRegUser.Click += new System.EventHandler(this.btnRegUser_Click);
            // 
            // labQuit
            // 
            this.labQuit.AutoSize = true;
            this.labQuit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labQuit.Location = new System.Drawing.Point(495, 31);
            this.labQuit.Name = "labQuit";
            this.labQuit.Size = new System.Drawing.Size(53, 12);
            this.labQuit.TabIndex = 17;
            this.labQuit.Text = "退出登录";
            this.labQuit.Click += new System.EventHandler(this.labQuit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.登录界面;
            this.ClientSize = new System.Drawing.Size(591, 216);
            this.Controls.Add(this.labQuit);
            this.Controls.Add(this.btnRegUser);
            this.Controls.Add(this.btnMan);
            this.Controls.Add(this.btnInjector);
            this.Controls.Add(this.btnInjMessage);
            this.Controls.Add(this.btnVaccine);
            this.Name = "MainForm";
            this.Text = "菜单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVaccine;
        private System.Windows.Forms.Button btnInjMessage;
        private System.Windows.Forms.Button btnInjector;
        private System.Windows.Forms.Button btnMan;
        private System.Windows.Forms.Button btnRegUser;
        private System.Windows.Forms.Label labQuit;
    }
}