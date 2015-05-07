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
    //Form to allow administrators to add a new van
    public partial class fmAddVan : Form
    {
        //Sql resources
        static SqlConnection myConnection = new SqlConnection(Program.Connectionstring);
        //Vars
        bool hasAdded = false;
        bool isAddingDriver = false, hasGrabDrivers = false;
        //Vars for validation
        bool hasVin = false, hasMake = false, hasModel = false, hasYear = true, hasMileage = true;
        bool hasDriver = false;
        //Driver ID
        List<int> driverList = new List<int>();
        int driverID;
        //Constructor
        public fmAddVan()
        {
            InitializeComponent();
        }
        //Actions to perform when submit button is clicked
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Provided all fields have valid input
            if (allFieldsNotNull())
            {
                //Provided there is not already a van with the inputed VIN
                if (uniqueVIN())
                {
                    //Add new van and close the window
                    addVan();
                    MessageBox.Show("New van added!");
                    this.Dispose();
                }
                else
                {
                    //Show message and highlight the VIN field
                    MessageBox.Show("A van with that VIN already exists!");
                    label1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //Show message and hilight all incorrect fields
                MessageBox.Show("Please fix the highlighted fields");
                showErrors();
            }
        }
        //Actions to perform when the cancel button is clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Prompt the user before closing the form
        private void fmAddVan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!hasAdded)
            {

                if (MessageBox.Show("Are you sure you want to close this window? Data will not be saved!", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Dispose();

                }
                else
                {
                    e.Cancel = true;
                    this.Activate();
                }
            }
            else
            {
                this.Dispose();
            }
        }
        //Highlight all incorrect fields
        private void showErrors()
        {
            //Set all labels to black first
            label1.ForeColor = System.Drawing.Color.Black;
            label9.ForeColor = System.Drawing.Color.Black;
            label8.ForeColor = System.Drawing.Color.Black;
            label7.ForeColor = System.Drawing.Color.Black;
            label5.ForeColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Black;
            //Highlight all incorrect fields in red
            if (!hasVin)
            {
                label1.ForeColor = System.Drawing.Color.Red;

            }
            if (!hasMake)
            {
                label9.ForeColor = System.Drawing.Color.Red;

            }
            if (!hasModel)
            {
                label8.ForeColor = System.Drawing.Color.Red;

            }
            if (!hasYear)
            {
                label7.ForeColor = System.Drawing.Color.Red;

            }
            if (!hasMileage)
            {
                label5.ForeColor = System.Drawing.Color.Red;

            }
            if (isAddingDriver)
            {
                if (!hasDriver)
                {
                    label2.ForeColor = System.Drawing.Color.Red;

                }

            }
        }
        //Method to check if the VIN is unique
        private bool uniqueVIN()
        {
            string getVINs = "SELECT VIN FROM VANS";
            SqlCommand VINs = new SqlCommand(getVINs, myConnection);
            myConnection.Open();
            SqlDataReader myReader = VINs.ExecuteReader();
            while (myReader.Read())
            {
                if (myReader[0].ToString() == txtVin.Text)
                {
                    myConnection.Close();
                    return false;
                }
            }
            myConnection.Close();
            return true;
        }
        //Method to add van
        private void addVan()
        {
            string newVan;
            //Change our insert statement if we are adding a driver
            if (isAddingDriver)
            {
                newVan = "INSERT INTO VANS (VIN, MAKE, MODEL, YEAR, TOTAL_MILEAGE, HAS_ASSIGNED, EMPID, DATE_ASSIGNED) VALUES (@vin, @make, @model, @year, @mileage, 1, @empid, @date)";

            }
            else
            {
                newVan = "INSERT INTO VANS (VIN, MAKE, MODEL, YEAR, TOTAL_MILEAGE, HAS_ASSIGNED) VALUES (@vin, @make, @model, @year, @mileage, 0)";

            }
            //Add to vans table
            SqlCommand addNew = new SqlCommand(newVan, myConnection);
            myConnection.Open();
            addNew.Parameters.AddWithValue("@vin", txtVin.Text);
            addNew.Parameters.AddWithValue("@make", txtMake.Text);
            addNew.Parameters.AddWithValue("@model", txtModel.Text);
            addNew.Parameters.AddWithValue("@year", dtpYear.Value);
            addNew.Parameters.AddWithValue("@mileage", numMileage.Value);
            //Add driver parameters if we are adding a driver
            if (isAddingDriver)
            {
                addNew.Parameters.AddWithValue("@empid", driverID);
                addNew.Parameters.AddWithValue("@date", DateTime.Today.Date);
            }
            addNew.ExecuteNonQuery();
            myConnection.Close();
            hasAdded = true;
        }
        //Make sure all fields have vaid input
        private bool allFieldsNotNull()
        {
            if (hasVin && hasMake && hasModel && hasYear && hasMileage)
            {
                if (isAddingDriver)
                {
                    if (hasDriver)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        /*
         * 
         * Set booleans to true when proper input is in the boxes
         * 
         */
        private void txtVin_TextChanged(object sender, EventArgs e)
        {
            if(txtVin.Text.Length == 17){
                hasVin = true;
            }
            else
            {
                hasVin = false;
            }
        }

        private void txtMake_TextChanged(object sender, EventArgs e)
        {
            if (txtMake.Text.Trim() != "")
            {
                hasMake = true;
            }
            else
            {
                hasMake = false;
            }
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            if (txtModel.Text.Trim() != "")
            {
                hasModel = true;
            }
            else
            {
                hasModel = false;
            }
        }

        private void numMileage_ValueChanged(object sender, EventArgs e)
        {
            if (numMileage.Value >= 0)
            {
                hasMileage = true;
            }
            else
            {
                hasMileage = false;
            }
        }
        //If adding a driver, change values and populate combobox
        private void rbtnYes_CheckedChanged(object sender, EventArgs e)
        {
            //Grab the driver info from the database if not done already
            if (!hasGrabDrivers)
            {
                cmbDrivers.Items.Clear();
                driverList.Clear();
                myConnection.Open();
                SqlCommand drivers = new SqlCommand("SELECT F_NAME + ' ' + L_NAME AS NAME, DRIVERS_VIEW.EMPID FROM DRIVERS_VIEW LEFT JOIN VANS ON VANS.EMPID = DRIVERS_VIEW.EMPID WHERE VIN IS NULL", myConnection);
                SqlDataReader myReader = drivers.ExecuteReader();
                while (myReader.Read())
                {
                    cmbDrivers.Items.Add(myReader[0].ToString());
                    driverList.Add(Convert.ToInt32(myReader[1]));
                }
                myConnection.Close();
            }

            isAddingDriver = true;
            label2.Enabled = true;
            cmbDrivers.Enabled = true;
        }
        //If not adding a driver, change values
        private void rbtnNo_CheckedChanged(object sender, EventArgs e)
        {
            isAddingDriver = false;
            label2.Enabled = false;
            cmbDrivers.Enabled = false;
        }
        private void cmbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDrivers.SelectedIndex < 0)
            {
                hasDriver = false;
                driverID = 0;
            }
            else
            {
                hasDriver = true;
                driverID = driverList[cmbDrivers.SelectedIndex];
            }
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            if (dtpYear.Value.Year > (DateTime.Today.Year + 1) || dtpYear.Value.Year < 1950)
            {
                hasYear = false;
            }
            else
            {
                hasYear = true;
            }
        }
        /*
         * 
         * Check input to text boxes
         * 
         */
        private void checkLetterNumber(object sender, KeyPressEventArgs e)
        {
            //0x0008 is the literal for the backspace key
            Char pressedKey = e.KeyChar;
            if (Char.IsLetter(pressedKey) || Char.IsDigit(pressedKey) || pressedKey == 0x0008)
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered into the control since not a letter
                e.Handled = true;
        }
        private void checkIfLettNumSpace(object sender, KeyPressEventArgs e)
        {
            //0x0008 is the literal for the backspace key
            Char pressedKey = e.KeyChar;
            if (Char.IsLetter(pressedKey) || Char.IsDigit(pressedKey) || Char.IsWhiteSpace(pressedKey) || pressedKey == '-' || pressedKey == 0x0008)
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered into the control since not a letter
                e.Handled = true;
        }

    }
}
