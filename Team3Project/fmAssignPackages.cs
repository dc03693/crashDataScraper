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
    //Form for managers to add packages to vans
    public partial class fmAssignPackages : Form
    {
        //Sql vars
        static SqlConnection con;
        //PackageID list
        List<int> packIDs = new List<int>();
        
        public fmAssignPackages()
        {
            InitializeComponent();
            con = new SqlConnection(Program.Connectionstring);
            con.Open();
            //Populate comboboxes with unsent packages and vans with drivers
            string packages = "SELECT PACKID, EST_DELIVERY_DATE FROM PACKAGES WHERE HAS_SHIPPED = 0 ORDER BY EST_DELIVERY_DATE ASC";
            SqlCommand com = new SqlCommand(packages, con);
            SqlDataReader myReader = com.ExecuteReader();
            while(myReader.Read()){
                packIDs.Add(Convert.ToInt32(myReader[0]));
                cmbPackages.Items.Add("Package ID: " + myReader[0].ToString() + "   Est Delivery: " + (Convert.ToDateTime(myReader[1])).ToString("dd-mm-yyyy"));
            }
            con.Close();
            con.Open();
            string vins = "SELECT VIN FROM VANS WHERE EMPID IS NOT NULL";
            com = new SqlCommand(vins, con);
            myReader = com.ExecuteReader();
            while (myReader.Read())
            {
                cmbVans.Items.Add(myReader[0].ToString());
            }
            con.Close();
        }
        //Actions to perform when the add button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ///Make sure both a package and a van is selected
            if(cmbPackages.SelectedIndex < 0 || cmbVans.SelectedIndex < 0){
                MessageBox.Show("Make sure you have selected both a package and a van!");
            }
            else
            {
                //Update package in database
                con.Open();
                string update = "UPDATE PACKAGES SET VIN = @vin, HAS_SHIPPED = 1, DATE_SHIPPED = @ds WHERE PACKID = @pid";
                SqlCommand updateCom = new SqlCommand(update, con);
                updateCom.Parameters.AddWithValue("@vin", cmbVans.SelectedItem);
                updateCom.Parameters.AddWithValue("@ds", DateTime.Today.Date);
                updateCom.Parameters.AddWithValue("@pid", packIDs[cmbPackages.SelectedIndex]);
                updateCom.ExecuteNonQuery();
                con.Close();
                //Update package combobox (removing the package we just put on the van)
                cmbPackages.Items.Clear();
                con.Open();
                string packages = "SELECT PACKID, EST_DELIVERY_DATE FROM PACKAGES WHERE HAS_SHIPPED = 0 ORDER BY EST_DELIVERY_DATE ASC";
                SqlCommand com = new SqlCommand(packages, con);
                SqlDataReader myReader = com.ExecuteReader();
                while (myReader.Read())
                {
                    packIDs.Add(Convert.ToInt32(myReader[0]));
                    cmbPackages.Items.Add("Package ID: " + myReader[0].ToString() + "   Est Delivery: " + (Convert.ToDateTime(myReader[1])).ToString("dd-mm-yyyy"));
                }
                con.Close();
                cmbPackages.SelectedIndex = -1;
                cmbVans.SelectedIndex = -1;
                MessageBox.Show("Package added to van!");
            }
        }
        //Close window when cancel is clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
