namespace Team3Project
{
    partial class fmDriverPackages
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmDriverPackages));
            this.pACKAGESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryServiceDataSet = new Team3Project.DeliveryServiceDataSet();
            this.pACKAGESTableAdapter = new Team3Project.DeliveryServiceDataSetTableAdapters.PACKAGESTableAdapter();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.myPackages = new Team3Project.MyPackages();
            this.pACKAGESBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pACKAGESTableAdapter1 = new Team3Project.MyPackagesTableAdapters.PACKAGESTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pACKIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATERECIEVEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hASSHIPPEDDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dATESHIPPEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hASDELIVEREDDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dATEDELIVEREDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wEIGHTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cONTENTSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eSTDELIVERYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIN = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.deliveryServiceDataSet3 = new Team3Project.DeliveryServiceDataSet3();
            this.pACKAGESBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.pACKAGESTableAdapter2 = new Team3Project.DeliveryServiceDataSet3TableAdapters.PACKAGESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pACKAGESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACKAGESBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACKAGESBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // pACKAGESBindingSource
            // 
            this.pACKAGESBindingSource.DataMember = "PACKAGES";
            this.pACKAGESBindingSource.DataSource = this.deliveryServiceDataSet;
            // 
            // deliveryServiceDataSet
            // 
            this.deliveryServiceDataSet.DataSetName = "DeliveryServiceDataSet";
            this.deliveryServiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pACKAGESTableAdapter
            // 
            this.pACKAGESTableAdapter.ClearBeforeFill = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1581, 479);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 62);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update Info";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // myPackages
            // 
            this.myPackages.DataSetName = "MyPackages";
            this.myPackages.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pACKAGESBindingSource1
            // 
            this.pACKAGESBindingSource1.DataMember = "PACKAGES";
            this.pACKAGESBindingSource1.DataSource = this.myPackages;
            // 
            // pACKAGESTableAdapter1
            // 
            this.pACKAGESTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pACKIDDataGridViewTextBoxColumn,
            this.dATERECIEVEDDataGridViewTextBoxColumn,
            this.hASSHIPPEDDataGridViewCheckBoxColumn,
            this.dATESHIPPEDDataGridViewTextBoxColumn,
            this.hASDELIVEREDDataGridViewCheckBoxColumn,
            this.dATEDELIVEREDDataGridViewTextBoxColumn,
            this.wEIGHTDataGridViewTextBoxColumn,
            this.cONTENTSDataGridViewTextBoxColumn,
            this.eSTDELIVERYDATEDataGridViewTextBoxColumn,
            this.VIN});
            this.dataGridView1.DataSource = this.pACKAGESBindingSource2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1650, 461);
            this.dataGridView1.TabIndex = 0;
            // 
            // pACKIDDataGridViewTextBoxColumn
            // 
            this.pACKIDDataGridViewTextBoxColumn.DataPropertyName = "PACKID";
            this.pACKIDDataGridViewTextBoxColumn.HeaderText = "PACKID";
            this.pACKIDDataGridViewTextBoxColumn.Name = "pACKIDDataGridViewTextBoxColumn";
            this.pACKIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pACKIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // dATERECIEVEDDataGridViewTextBoxColumn
            // 
            this.dATERECIEVEDDataGridViewTextBoxColumn.DataPropertyName = "DATE_RECIEVED";
            this.dATERECIEVEDDataGridViewTextBoxColumn.HeaderText = "DATE_RECIEVED";
            this.dATERECIEVEDDataGridViewTextBoxColumn.Name = "dATERECIEVEDDataGridViewTextBoxColumn";
            // 
            // hASSHIPPEDDataGridViewCheckBoxColumn
            // 
            this.hASSHIPPEDDataGridViewCheckBoxColumn.DataPropertyName = "HAS_SHIPPED";
            this.hASSHIPPEDDataGridViewCheckBoxColumn.HeaderText = "HAS_SHIPPED";
            this.hASSHIPPEDDataGridViewCheckBoxColumn.Name = "hASSHIPPEDDataGridViewCheckBoxColumn";
            // 
            // dATESHIPPEDDataGridViewTextBoxColumn
            // 
            this.dATESHIPPEDDataGridViewTextBoxColumn.DataPropertyName = "DATE_SHIPPED";
            this.dATESHIPPEDDataGridViewTextBoxColumn.HeaderText = "DATE_SHIPPED";
            this.dATESHIPPEDDataGridViewTextBoxColumn.Name = "dATESHIPPEDDataGridViewTextBoxColumn";
            // 
            // hASDELIVEREDDataGridViewCheckBoxColumn
            // 
            this.hASDELIVEREDDataGridViewCheckBoxColumn.DataPropertyName = "HAS_DELIVERED";
            this.hASDELIVEREDDataGridViewCheckBoxColumn.HeaderText = "HAS_DELIVERED";
            this.hASDELIVEREDDataGridViewCheckBoxColumn.Name = "hASDELIVEREDDataGridViewCheckBoxColumn";
            // 
            // dATEDELIVEREDDataGridViewTextBoxColumn
            // 
            this.dATEDELIVEREDDataGridViewTextBoxColumn.DataPropertyName = "DATE_DELIVERED";
            this.dATEDELIVEREDDataGridViewTextBoxColumn.HeaderText = "DATE_DELIVERED";
            this.dATEDELIVEREDDataGridViewTextBoxColumn.Name = "dATEDELIVEREDDataGridViewTextBoxColumn";
            this.dATEDELIVEREDDataGridViewTextBoxColumn.Width = 110;
            // 
            // wEIGHTDataGridViewTextBoxColumn
            // 
            this.wEIGHTDataGridViewTextBoxColumn.DataPropertyName = "WEIGHT";
            this.wEIGHTDataGridViewTextBoxColumn.HeaderText = "WEIGHT";
            this.wEIGHTDataGridViewTextBoxColumn.Name = "wEIGHTDataGridViewTextBoxColumn";
            this.wEIGHTDataGridViewTextBoxColumn.Width = 75;
            // 
            // cONTENTSDataGridViewTextBoxColumn
            // 
            this.cONTENTSDataGridViewTextBoxColumn.DataPropertyName = "CONTENTS";
            this.cONTENTSDataGridViewTextBoxColumn.HeaderText = "CONTENTS";
            this.cONTENTSDataGridViewTextBoxColumn.Name = "cONTENTSDataGridViewTextBoxColumn";
            this.cONTENTSDataGridViewTextBoxColumn.Width = 130;
            // 
            // eSTDELIVERYDATEDataGridViewTextBoxColumn
            // 
            this.eSTDELIVERYDATEDataGridViewTextBoxColumn.DataPropertyName = "EST_DELIVERY_DATE";
            this.eSTDELIVERYDATEDataGridViewTextBoxColumn.HeaderText = "EST_DELIVERY_DATE";
            this.eSTDELIVERYDATEDataGridViewTextBoxColumn.Name = "eSTDELIVERYDATEDataGridViewTextBoxColumn";
            this.eSTDELIVERYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.eSTDELIVERYDATEDataGridViewTextBoxColumn.Width = 170;
            // 
            // VIN
            // 
            this.VIN.DataPropertyName = "VIN";
            this.VIN.HeaderText = "VIN";
            this.VIN.Name = "VIN";
            this.VIN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VIN.Width = 120;
            // 
            // deliveryServiceDataSet3
            // 
            this.deliveryServiceDataSet3.DataSetName = "DeliveryServiceDataSet3";
            this.deliveryServiceDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pACKAGESBindingSource2
            // 
            this.pACKAGESBindingSource2.DataMember = "PACKAGES";
            this.pACKAGESBindingSource2.DataSource = this.deliveryServiceDataSet3;
            // 
            // pACKAGESTableAdapter2
            // 
            this.pACKAGESTableAdapter2.ClearBeforeFill = true;
            // 
            // fmDriverPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1678, 579);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmDriverPackages";
            this.Text = "Your Packages";
            this.Load += new System.EventHandler(this.fmDriverPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pACKAGESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACKAGESBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryServiceDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pACKAGESBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DeliveryServiceDataSet deliveryServiceDataSet;
        private System.Windows.Forms.BindingSource pACKAGESBindingSource;
        private DeliveryServiceDataSetTableAdapters.PACKAGESTableAdapter pACKAGESTableAdapter;
        private System.Windows.Forms.Button btnUpdate;
        private MyPackages myPackages;
        private System.Windows.Forms.BindingSource pACKAGESBindingSource1;
        private MyPackagesTableAdapters.PACKAGESTableAdapter pACKAGESTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pACKIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATERECIEVEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hASSHIPPEDDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATESHIPPEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hASDELIVEREDDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATEDELIVEREDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wEIGHTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cONTENTSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSTDELIVERYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn VIN;
        private DeliveryServiceDataSet3 deliveryServiceDataSet3;
        private System.Windows.Forms.BindingSource pACKAGESBindingSource2;
        private DeliveryServiceDataSet3TableAdapters.PACKAGESTableAdapter pACKAGESTableAdapter2;
    }
}