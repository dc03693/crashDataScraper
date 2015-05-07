namespace Team3Project
{
    partial class fmManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmManager));
            this.btnVVans = new System.Windows.Forms.Button();
            this.btnAssignDrivers = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVVans
            // 
            this.btnVVans.Location = new System.Drawing.Point(26, 108);
            this.btnVVans.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVVans.Name = "btnVVans";
            this.btnVVans.Size = new System.Drawing.Size(84, 47);
            this.btnVVans.TabIndex = 1;
            this.btnVVans.Text = "Assign Packages";
            this.btnVVans.UseVisualStyleBackColor = true;
            this.btnVVans.Click += new System.EventHandler(this.btnVVans_Click);
            // 
            // btnAssignDrivers
            // 
            this.btnAssignDrivers.Location = new System.Drawing.Point(26, 40);
            this.btnAssignDrivers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAssignDrivers.Name = "btnAssignDrivers";
            this.btnAssignDrivers.Size = new System.Drawing.Size(84, 50);
            this.btnAssignDrivers.TabIndex = 2;
            this.btnAssignDrivers.Text = "Assign Drivers";
            this.btnAssignDrivers.UseVisualStyleBackColor = true;
            this.btnAssignDrivers.Click += new System.EventHandler(this.btnAssignDrivers_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnVVans);
            this.groupBox1.Controls.Add(this.btnAssignDrivers);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 186);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assign unshipped packages to vans.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Assign or unassign drivers to vans.";
            // 
            // fmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 214);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "fmManager";
            this.Text = "Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmManager_FormClosing);
            this.Load += new System.EventHandler(this.fmManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVVans;
        private System.Windows.Forms.Button btnAssignDrivers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}