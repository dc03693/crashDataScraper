namespace Team3Project
{
    partial class fmAddEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAddEmp));
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnDriver = new System.Windows.Forms.RadioButton();
            this.rbtnManager = new System.Windows.Forms.RadioButton();
            this.rbtnAdmin = new System.Windows.Forms.RadioButton();
            this.txtUsrName = new System.Windows.Forms.TextBox();
            this.grpBasic = new System.Windows.Forms.GroupBox();
            this.numSalary = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPwdConfirm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.grpDriver = new System.Windows.Forms.GroupBox();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLicenseNo = new System.Windows.Forms.TextBox();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.cmbManager = new System.Windows.Forms.ComboBox();
            this.grpAdmin = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).BeginInit();
            this.grpType.SuspendLayout();
            this.grpDriver.SuspendLayout();
            this.grpAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(146, 19);
            this.txtFName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFName.MaxLength = 25;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(178, 22);
            this.txtFName.TabIndex = 0;
            this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
            this.txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkLetter);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(146, 44);
            this.txtLName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLName.MaxLength = 25;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(178, 22);
            this.txtLName.TabIndex = 1;
            this.txtLName.TextChanged += new System.EventHandler(this.txtLName_TextChanged);
            this.txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkLetter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Yearly Salary:";
            // 
            // rbtnDriver
            // 
            this.rbtnDriver.AutoSize = true;
            this.rbtnDriver.Location = new System.Drawing.Point(11, 32);
            this.rbtnDriver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnDriver.Name = "rbtnDriver";
            this.rbtnDriver.Size = new System.Drawing.Size(67, 21);
            this.rbtnDriver.TabIndex = 11;
            this.rbtnDriver.TabStop = true;
            this.rbtnDriver.Text = "Driver";
            this.rbtnDriver.UseVisualStyleBackColor = true;
            this.rbtnDriver.CheckedChanged += new System.EventHandler(this.rbtnDriver_CheckedChanged);
            // 
            // rbtnManager
            // 
            this.rbtnManager.AutoSize = true;
            this.rbtnManager.Location = new System.Drawing.Point(101, 32);
            this.rbtnManager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnManager.Name = "rbtnManager";
            this.rbtnManager.Size = new System.Drawing.Size(85, 21);
            this.rbtnManager.TabIndex = 12;
            this.rbtnManager.TabStop = true;
            this.rbtnManager.Text = "Manager";
            this.rbtnManager.UseVisualStyleBackColor = true;
            this.rbtnManager.CheckedChanged += new System.EventHandler(this.rbtnManager_CheckedChanged);
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.Location = new System.Drawing.Point(212, 32);
            this.rbtnAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(112, 21);
            this.rbtnAdmin.TabIndex = 13;
            this.rbtnAdmin.TabStop = true;
            this.rbtnAdmin.Text = "Administrator";
            this.rbtnAdmin.UseVisualStyleBackColor = true;
            this.rbtnAdmin.CheckedChanged += new System.EventHandler(this.rbtnAdmin_CheckedChanged);
            // 
            // txtUsrName
            // 
            this.txtUsrName.Location = new System.Drawing.Point(146, 96);
            this.txtUsrName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsrName.MaxLength = 25;
            this.txtUsrName.Name = "txtUsrName";
            this.txtUsrName.Size = new System.Drawing.Size(178, 22);
            this.txtUsrName.TabIndex = 14;
            this.txtUsrName.TextChanged += new System.EventHandler(this.txtUsrName_TextChanged);
            this.txtUsrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNoSpace);
            // 
            // grpBasic
            // 
            this.grpBasic.Controls.Add(this.numSalary);
            this.grpBasic.Controls.Add(this.label8);
            this.grpBasic.Controls.Add(this.txtPwdConfirm);
            this.grpBasic.Controls.Add(this.label6);
            this.grpBasic.Controls.Add(this.txtPassword);
            this.grpBasic.Controls.Add(this.label3);
            this.grpBasic.Controls.Add(this.txtFName);
            this.grpBasic.Controls.Add(this.txtUsrName);
            this.grpBasic.Controls.Add(this.txtLName);
            this.grpBasic.Controls.Add(this.label1);
            this.grpBasic.Controls.Add(this.label2);
            this.grpBasic.Controls.Add(this.label4);
            this.grpBasic.Location = new System.Drawing.Point(12, 11);
            this.grpBasic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBasic.Name = "grpBasic";
            this.grpBasic.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBasic.Size = new System.Drawing.Size(355, 184);
            this.grpBasic.TabIndex = 15;
            this.grpBasic.TabStop = false;
            this.grpBasic.Text = "Basic Info";
            // 
            // numSalary
            // 
            this.numSalary.DecimalPlaces = 2;
            this.numSalary.Location = new System.Drawing.Point(146, 70);
            this.numSalary.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSalary.Name = "numSalary";
            this.numSalary.Size = new System.Drawing.Size(178, 22);
            this.numSalary.TabIndex = 20;
            this.numSalary.ValueChanged += new System.EventHandler(this.numSalary_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Confirm Password:";
            // 
            // txtPwdConfirm
            // 
            this.txtPwdConfirm.Location = new System.Drawing.Point(146, 148);
            this.txtPwdConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPwdConfirm.MaxLength = 25;
            this.txtPwdConfirm.Name = "txtPwdConfirm";
            this.txtPwdConfirm.Size = new System.Drawing.Size(178, 22);
            this.txtPwdConfirm.TabIndex = 18;
            this.txtPwdConfirm.UseSystemPasswordChar = true;
            this.txtPwdConfirm.TextChanged += new System.EventHandler(this.txtPwdConfirm_TextChanged);
            this.txtPwdConfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNoSpace);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(146, 122);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 22);
            this.txtPassword.TabIndex = 16;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNoSpace);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "User Name:";
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.rbtnDriver);
            this.grpType.Controls.Add(this.rbtnManager);
            this.grpType.Controls.Add(this.rbtnAdmin);
            this.grpType.Location = new System.Drawing.Point(12, 200);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(355, 77);
            this.grpType.TabIndex = 16;
            this.grpType.TabStop = false;
            this.grpType.Text = "Employee Type";
            // 
            // grpDriver
            // 
            this.grpDriver.Controls.Add(this.dtpExpDate);
            this.grpDriver.Controls.Add(this.label9);
            this.grpDriver.Controls.Add(this.label7);
            this.grpDriver.Controls.Add(this.txtLicenseNo);
            this.grpDriver.Enabled = false;
            this.grpDriver.Location = new System.Drawing.Point(12, 353);
            this.grpDriver.Name = "grpDriver";
            this.grpDriver.Size = new System.Drawing.Size(355, 88);
            this.grpDriver.TabIndex = 17;
            this.grpDriver.TabStop = false;
            this.grpDriver.Text = "Driver License Info";
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.Checked = false;
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpDate.Location = new System.Drawing.Point(146, 47);
            this.dtpExpDate.MinDate = new System.DateTime(2015, 4, 12, 0, 0, 0, 0);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new System.Drawing.Size(178, 22);
            this.dtpExpDate.TabIndex = 20;
            this.dtpExpDate.ValueChanged += new System.EventHandler(this.dtpExpDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Expiration Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "License Number:";
            // 
            // txtLicenseNo
            // 
            this.txtLicenseNo.Location = new System.Drawing.Point(146, 20);
            this.txtLicenseNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLicenseNo.MaxLength = 9;
            this.txtLicenseNo.Name = "txtLicenseNo";
            this.txtLicenseNo.Size = new System.Drawing.Size(178, 22);
            this.txtLicenseNo.TabIndex = 18;
            this.txtLicenseNo.TextChanged += new System.EventHandler(this.txtLicenseNo_TextChanged);
            this.txtLicenseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkNumber);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(63, 21);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(68, 17);
            this.lblAdmin.TabIndex = 23;
            this.lblAdmin.Text = "Manager:";
            // 
            // cmbManager
            // 
            this.cmbManager.FormattingEnabled = true;
            this.cmbManager.Location = new System.Drawing.Point(146, 21);
            this.cmbManager.Name = "cmbManager";
            this.cmbManager.Size = new System.Drawing.Size(178, 24);
            this.cmbManager.TabIndex = 24;
            this.cmbManager.SelectionChangeCommitted += new System.EventHandler(this.cmbManager_SelectionChangeCommitted);
            // 
            // grpAdmin
            // 
            this.grpAdmin.Controls.Add(this.cmbManager);
            this.grpAdmin.Controls.Add(this.lblAdmin);
            this.grpAdmin.Enabled = false;
            this.grpAdmin.Location = new System.Drawing.Point(12, 283);
            this.grpAdmin.Name = "grpAdmin";
            this.grpAdmin.Size = new System.Drawing.Size(355, 64);
            this.grpAdmin.TabIndex = 18;
            this.grpAdmin.TabStop = false;
            this.grpAdmin.Text = "Manager Info";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(78, 447);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 28);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fmAddEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 487);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grpAdmin);
            this.Controls.Add(this.grpDriver);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.grpBasic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "fmAddEmp";
            this.Text = "Add Employee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmAddEmp_FormClosing);
            this.Load += new System.EventHandler(this.fmAddEmp_Load);
            this.grpBasic.ResumeLayout(false);
            this.grpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).EndInit();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.grpDriver.ResumeLayout(false);
            this.grpDriver.PerformLayout();
            this.grpAdmin.ResumeLayout(false);
            this.grpAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnDriver;
        private System.Windows.Forms.RadioButton rbtnManager;
        private System.Windows.Forms.RadioButton rbtnAdmin;
        private System.Windows.Forms.TextBox txtUsrName;
        private System.Windows.Forms.GroupBox grpBasic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPwdConfirm;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.GroupBox grpDriver;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLicenseNo;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.ComboBox cmbManager;
        private System.Windows.Forms.GroupBox grpAdmin;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numSalary;
    }
}