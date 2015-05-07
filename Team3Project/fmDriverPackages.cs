using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Team3Project
{
    public partial class fmDriverPackages : Form
    {
        //Current Employee info
        public fmLogIn.Employee CurrentEmployee;

        //Sql resources
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder builder;
        public fmDriverPackages()
        {
            InitializeComponent();
        }

        /* On page load, the data grid view displays the current driver's packages 
         * that have either not been shipped or not been delivered.
         * The driver will be able to update the information from this control.
         * */
        private void fmDriverPackages_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'deliveryServiceDataSet3.PACKAGES' table. You can move, or remove it, as needed.
            this.pACKAGESTableAdapter2.Fill(this.deliveryServiceDataSet3.PACKAGES);
            //Set window width on Page Load
            this.Width = 1145;
            dataGridView1.Width = 1115;
     
            try
            {
                //Connection for datGridView
                SqlConnection con = new SqlConnection(Program.Connectionstring);
                //Connection used to poulate VINs in dropdown combobox
                SqlConnection con2 = new SqlConnection(Program.Connectionstring);
                con.Open();
                con2.Open();
                //Return packages assigned to drivers van that have either not been shipped or notbeen delivered
                adap = new SqlDataAdapter("SELECT * FROM PACKAGES WHERE VIN IN (SELECT P.VIN FROM PACKAGES P JOIN VANS V ON P.VIN = V.VIN JOIN DRIVERS D ON V.EMPID = D.EMPID WHERE D.EMPID = " + CurrentEmployee.ID + " ) AND (HAS_DELIVERED = 0 OR HAS_SHIPPED = 0)", con);
                ds = new DataSet();
                adap.Fill(ds, "My_Packages");
                dataGridView1.DataSource = ds.Tables[0];
                //Populate VIN drop down box
                SqlCommand getVins = new SqlCommand("SELECT VIN FROM VANS", con2);
                SqlDataReader vinReader = getVins.ExecuteReader();
                while (vinReader.Read())
                {
                    VIN.Items.Add(vinReader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //This button fires the Update command
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                builder = new SqlCommandBuilder(adap);
                adap.Update(ds, "My_Packages");
                MessageBox.Show("Information update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Reload data:
                //Connection for datGridView
                SqlConnection con = new SqlConnection(Program.Connectionstring);
                //Connection used to poulate VINs in dropdown combobox
                SqlConnection con2 = new SqlConnection(Program.Connectionstring);
                con.Open();
                con2.Open();
                //Return packages assigned to drivers van that have either not been shipped or notbeen delivered
                adap = new SqlDataAdapter("SELECT * FROM PACKAGES WHERE VIN IN (SELECT P.VIN FROM PACKAGES P JOIN VANS V ON P.VIN = V.VIN JOIN DRIVERS D ON V.EMPID = D.EMPID WHERE D.EMPID = " + CurrentEmployee.ID + " ) AND (HAS_DELIVERED = 0 OR HAS_SHIPPED = 0)", con);
                ds = new DataSet();
                adap.Fill(ds, "My_Packages");
                dataGridView1.DataSource = ds.Tables[0];
                //Populate VIN drop down box
                SqlCommand getVins = new SqlCommand("SELECT VIN FROM VANS", con2);
                SqlDataReader vinReader = getVins.ExecuteReader();
                while (vinReader.Read())
                {
                    VIN.Items.Add(vinReader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
