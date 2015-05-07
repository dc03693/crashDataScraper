namespace Team3Project
{
    partial class fmAssignDrivers
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVIN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDrivers = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numMiles = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnAdd = new System.Windows.Forms.RadioButton();
            this.rbtnRemove = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(72, 272);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Van VIN:";
            // 
            // cmbVIN
            // 
            this.cmbVIN.FormattingEnabled = true;
            this.cmbVIN.Location = new System.Drawing.Point(143, 54);
            this.cmbVIN.Margin = new System.Windows.Forms.Padding(4);
            this.cmbVIN.Name = "cmbVIN";
            this.cmbVIN.Size = new System.Drawing.Size(196, 24);
            this.cmbVIN.TabIndex = 3;
            this.cmbVIN.SelectedIndexChanged += new System.EventHandler(this.cmbVIN_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Mileage:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(80, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Driver:";
            // 
            // cmbDrivers
            // 
            this.cmbDrivers.FormattingEnabled = true;
            this.cmbDrivers.Location = new System.Drawing.Point(143, 22);
            this.cmbDrivers.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDrivers.Name = "cmbDrivers";
            this.cmbDrivers.Size = new System.Drawing.Size(196, 24);
            this.cmbDrivers.TabIndex = 7;
            this.cmbDrivers.SelectedIndexChanged += new System.EventHandler(this.cmbDrivers_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(230, 272);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numMiles);
            this.groupBox1.Controls.Add(this.cmbVIN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDrivers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 126);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Van Info";
            // 
            // numMiles
            // 
            this.numMiles.Enabled = false;
            this.numMiles.Location = new System.Drawing.Point(143, 87);
            this.numMiles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMiles.Name = "numMiles";
            this.numMiles.Size = new System.Drawing.Size(196, 22);
            this.numMiles.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnRemove);
            this.groupBox2.Controls.Add(this.rbtnAdd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 118);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driver Options";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 36);
            this.label4.TabIndex = 8;
            this.label4.Text = "Would you like to add a driver to a van or remove a driver from a van?";
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.AutoSize = true;
            this.rbtnAdd.Checked = true;
            this.rbtnAdd.Location = new System.Drawing.Point(74, 77);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(54, 21);
            this.rbtnAdd.TabIndex = 11;
            this.rbtnAdd.TabStop = true;
            this.rbtnAdd.Text = "Add";
            this.rbtnAdd.UseVisualStyleBackColor = true;
            this.rbtnAdd.CheckedChanged += new System.EventHandler(this.rbtnAdd_CheckedChanged);
            // 
            // rbtnRemove
            // 
            this.rbtnRemove.AutoSize = true;
            this.rbtnRemove.Location = new System.Drawing.Point(202, 77);
            this.rbtnRemove.Name = "rbtnRemove";
            this.rbtnRemove.Size = new System.Drawing.Size(81, 21);
            this.rbtnRemove.TabIndex = 12;
            this.rbtnRemove.TabStop = true;
            this.rbtnRemove.Text = "Remove";
            this.rbtnRemove.UseVisualStyleBackColor = true;
            this.rbtnRemove.CheckedChanged += new System.EventHandler(this.rbtnRemove_CheckedChanged);
            // 
            // fmAssignDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 323);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "fmAssignDrivers";
            this.Text = "Assign Drivers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDrivers;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numMiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnRemove;
        private System.Windows.Forms.RadioButton rbtnAdd;
        private System.Windows.Forms.Label label4;
    }
}