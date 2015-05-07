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
    /*
     * 
     * This form allows Managers to assign drivers to vans or remove drivers from vans.
     * 
     */
    public partial class fmAssignDrivers : Form
    {
        //Sql vars
        static SqlConnection con;
        //Vars for determining what the user is trying to do
        bool isAdding = true;
        bool isRemoving = false;
        //Verification vars
        bool hasVIN = false;
        bool hasDriver = false;
        //Driver EMPID list
        List<int> driverIDs = new List<int>();
        //Initialize form, with adding drivers set as the default function
        public fmAssignDrivers()
        {
            InitializeComponent();
            showAdd();
        }
        //When cancel is clicked, close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //When update is clicked, perform the chosen action (ading or removing)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Provided the selected driver and VIN are not null
            if (hasDriver && hasVIN)
            {
                if (isAdding)
                {
                    //Add driver to van
                    //Open connection and update the vans table with the new information
                    con.Open();
                    string update = "UPDATE VANS SET TOTAL_MILEAGE = @mileage, EMPID = @emp, HAS_ASSIGNED = @ha, DATE_ASSIGNED = @da WHERE VIN = @vin";
                    SqlCommand insertCommand = new SqlCommand(update, con);
                    insertCommand.Parameters.AddWithValue("@mileage", numMiles.Value);
                    insertCommand.Parameters.AddWithValue("@vin", cmbVIN.SelectedItem);
                    insertCommand.Parameters.AddWithValue("@da", DateTime.Today.Date);
                    insertCommand.Parameters.AddWithValue("@emp", driverIDs[cmbDrivers.SelectedIndex]);
                    insertCommand.Parameters.AddWithValue("@ha", 1);
                    insertCommand.ExecuteNonQuery();
                    con.Close();
                    //Print a confirmation message, reset selections, and refresh the comboboxes
                    MessageBox.Show("Driver assigned successfully!");
                    cmbVIN.SelectedIndex = -1;
                    cmbDrivers.SelectedIndex = -1;
                    hasVIN = false;
                    hasDriver = false;
                    showAdd();
                }
                else
                {
                    //Remove driver from van
                    //Open the connection and update the vans table with new information
                    con.Open();
                    string update = "UPDATE VANS SET TOTAL_MILEAGE = @mileage, EMPID = @emp, HAS_ASSIGNED = @ha, DATE_ASSIGNED = @da WHERE VIN = @vin";
                    SqlCommand insertCommand = new SqlCommand(update, con);
                    insertCommand.Parameters.AddWithValue("@mileage", numMiles.Value);
                    insertCommand.Parameters.AddWithValue("@vin", cmbVIN.SelectedItem);
                    insertCommand.Parameters.AddWithValue("@da", DateTime.Today.Date);
                    insertCommand.Parameters.AddWithValue("@emp", DBNull.Value);
                    insertCommand.Parameters.AddWithValue("@ha", 0);
                    insertCommand.ExecuteNonQuery();
                    con.Close();
                    //Show a confirmation message, reset selections, and refresh the combo boxes
                    MessageBox.Show("Driver removed successfully!");
                    cmbVIN.SelectedIndex = -1;
                    cmbDrivers.SelectedIndex = -1;
                    hasVIN = false;
                    hasDriver = false;
                    showRemove();
                }
            }
            else
            {
                //If either driver orVIN is null, print an error message
                MessageBox.Show("Make sure you have selected both a driver and a van!");

            }
        }
        //If the selection is changed in the VIN combo box
        private void cmbVIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When removing a driver from a van, we want the van and driver to be displayed together, so we set the selected indecies to be the same
            if (isRemoving)
            {
                cmbDrivers.SelectedIndex = cmbVIN.SelectedIndex;
            }
            //If the selection is not null, set a boolean to true and show the miles for the van selected
            if (cmbVIN.SelectedIndex >= 0)
            {
                showMiles();
                hasVIN = true;
            }
            else
            {
                hasVIN = false;
            }

        }
        //If the selection is changed in the driver combobox
        private void cmbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When removing a driver from a van, we want the van and driver to be displayed together, so we set the selected indecies to be the same
            if (isRemoving)
            {
                cmbVIN.SelectedIndex = cmbDrivers.SelectedIndex;
            }
            //If the selection is not null, set a boolean to true
            if (cmbDrivers.SelectedIndex >= 0)
            {
                hasDriver = true;
            }
            else
            {
                hasDriver = false;
            }
        }
        //When the add radio is selected, update the comboboxed and change variables to let the program know what it is doing
        private void rbtnAdd_CheckedChanged(object sender, EventArgs e)
        {
            isRemoving = false;
            isAdding = true;
            numMiles.Enabled = false;
            showAdd();
        }
        //When the remove radio is selected, update the comboboxed and change variables to let the program know what it is doing
        private void rbtnRemove_CheckedChanged(object sender, EventArgs e)
        {
            isRemoving = true;
            isAdding = false;
            numMiles.Enabled = true;
            showRemove();
        }
        //Populate combo boxes with values needed to add a driver to a van
        private void showAdd()
        {
            //Open connection and clear the combobox
            con = new SqlConnection(Program.Connectionstring);
            con.Open();
            cmbVIN.Items.Clear();
            cmbDrivers.Items.Clear();
            driverIDs.Clear();
            numMiles.Minimum = 0;
            numMiles.Value = 0;
            //Populate combobox with van VIN numbers of vans without drivers
            string vins = "SELECT VIN FROM VANS WHERE EMPID IS NULL";
            SqlCommand command = new SqlCommand(vins, con);
            SqlDataReader myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                cmbVIN.Items.Add(myReader[0].ToString());
            }
            con.Close();
            //Populate combobox with the names of drivers without vans
            con.Open();
            string empid = "SELECT DRIVERS_VIEW.EMPID, F_NAME + ' ' + L_NAME FROM DRIVERS_VIEW LEFT JOIN VANS ON DRIVERS_VIEW.EMPID = VANS.EMPID WHERE VANS.EMPID IS NULL";
            command = new SqlCommand(empid, con);
            myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                driverIDs.Add(Convert.ToInt32(myReader[0]));
                cmbDrivers.Items.Add(myReader[1].ToString());
            }
            con.Close();

        }
        //Populate combo boxes with values needed to remove a driver from a van
        private void showRemove()
        {
            //Open connection and clear the combobox
            con = new SqlConnection(Program.Connectionstring);
            con.Open();
            cmbVIN.Items.Clear();
            cmbDrivers.Items.Clear();
            driverIDs.Clear();
            numMiles.Minimum = 0;
            numMiles.Value = 0;
            //Populate combobox with the names of drivers with vans
            string empid = "SELECT DRIVERS_VIEW.EMPID, F_NAME + ' ' + L_NAME FROM DRIVERS_VIEW LEFT JOIN VANS ON DRIVERS_VIEW.EMPID = VANS.EMPID WHERE VANS.EMPID IS NOT NULL ORDER BY VANS.EMPID";
            SqlCommand command = new SqlCommand(empid, con);
            SqlDataReader myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                driverIDs.Add(Convert.ToInt32(myReader[0]));
                cmbDrivers.Items.Add(myReader[1].ToString());
            }
            con.Close();
            //Populate combobox with van VIN numbers of vans with drivers
            con.Open();
            string vins = "SELECT VIN FROM VANS WHERE EMPID IS NOT NULL ORDER BY EMPID";
            command = new SqlCommand(vins, con);
            myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                cmbVIN.Items.Add(myReader[0].ToString());
            }
            con.Close();

        }
        //Update the numberupdown for mileage with the mileage of the van selected
        private void showMiles()
        {
            //Change minimum and current miles to the van's last recorded miles
            string mileage = "SELECT TOTAL_MILEAGE FROM VANS WHERE VIN = @vin";
            con.Open();
            SqlCommand command = new SqlCommand(mileage, con);
            command.Parameters.AddWithValue("@vin", cmbVIN.SelectedItem);
            SqlDataReader myReader = command.ExecuteReader();
            if (myReader.Read())
            {
                numMiles.Minimum = myReader.GetDecimal(0);
                numMiles.Value = myReader.GetDecimal(0);
            }
            con.Close();
        }

    }

}
