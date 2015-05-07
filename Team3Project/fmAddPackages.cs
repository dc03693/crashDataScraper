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
    //This form allows administrators to add new packages
    public partial class fmAddPackages : Form
    {
        //Sql resources
        static SqlConnection con = new SqlConnection(Program.Connectionstring);
        //Vars for validation
        bool hasContents = false, hasWeight = false, hasDeliveryDate = true;
        bool hasAdded = false, isAddToVan = false, hasVan = false;        
        //Van VIN
        List<string> vanList = new List<string>();
        string vanVIN;
        //Constructor
        public fmAddPackages()
        {
            InitializeComponent();
            //Populate combobox with van VIN numbers (a van with a driver will be making deliveries)
            con.Open();
            string vins = "SELECT VIN FROM VANS WHERE EMPID IS NOT NULL";
            SqlCommand command = new SqlCommand(vins, con);
            SqlDataReader myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                cmbVans.Items.Add(myReader[0].ToString());
                vanList.Add(myReader[0].ToString());
            }
            con.Close();
        }
        //Actions to perform when the add button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Provided all fields have valid input
            if (allFieldsNotNull())
            {
                addPackage();
                MessageBox.Show("New package added!");
                this.Dispose();
            }
            else
            {
                //Show message and highligh errors
                MessageBox.Show("Please fix the highlighted fields");
                showErrors();
            }
            
        }
        //Make sure all fields have input
        private bool allFieldsNotNull(){
            if (hasContents && hasWeight && hasDeliveryDate)
            {
                if (isAddToVan)
                {
                    if (hasVan)
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
        //Highlight all fields with invalid input
        private void showErrors(){
            //Set all labels to black first
            label1.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Black;
            //Make labels red if they have incorrect info
            if (!hasContents)
            {
                label1.ForeColor = System.Drawing.Color.Red;

            }
            if (!hasWeight)
            {
                label3.ForeColor = System.Drawing.Color.Red;

            }
            if (!hasDeliveryDate)
            {
                label4.ForeColor = System.Drawing.Color.Red;

            }
            if (isAddToVan)
            {
                if (!hasVan)
                {
                    label2.ForeColor = System.Drawing.Color.Red;

                }

            }
        }
        //Method to add package to database
        private void addPackage(){
            string newPackage;
            //execute insert sql statement with chosen package data to create a new package
            con.Open();
            if(isAddToVan){
                newPackage = "INSERT INTO PACKAGES(DATE_RECIEVED, HAS_SHIPPED, HAS_DELIVERED, WEIGHT, CONTENTS, VIN, EST_DELIVERY_DATE, DATE_SHIPPED) VALUES(@dr, 1, 0, @w, @c, @v, @ed, @sd)";
            }else{
                newPackage = "INSERT INTO PACKAGES(DATE_RECIEVED, HAS_SHIPPED, HAS_DELIVERED, WEIGHT, CONTENTS, EST_DELIVERY_DATE) VALUES(@dr, 0, 0, @w, @c, @ed)";

            }
            SqlCommand insertCommand = new SqlCommand(newPackage, con);
            insertCommand.Parameters.AddWithValue("@dr", DateTime.Today.Date);
            insertCommand.Parameters.AddWithValue("@w", numWeight.Value);
            insertCommand.Parameters.AddWithValue("@c", txtContents.Text);
            insertCommand.Parameters.AddWithValue("@ed", dtpEstDelivery.Value);
            if(isAddToVan){
                insertCommand.Parameters.AddWithValue("@v", cmbVans.SelectedItem);
                insertCommand.Parameters.AddWithValue("@sd", DateTime.Today.Date);
            }
            insertCommand.ExecuteNonQuery();
            con.Close();
            hasAdded = true;
        }
        //Actions to perform when cancel is clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Make sure the user wanted to close the from before closing
        private void fmAddPackages_FormClosing(object sender, FormClosingEventArgs e)
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
        /*
         * 
         * Methods t make sure input is valid
         *
         */
        private void txtContents_TextChanged(object sender, EventArgs e)
        {
            if (txtContents.Text.Trim() != "")
            {
                hasContents = true;
            }
            else
            {
                hasContents = false;
            }
        }

        private void numWeight_ValueChanged(object sender, EventArgs e)
        {
            if (numWeight.Value > 0)
            {
                hasWeight = true;
            }
            else
            {
                hasWeight = false;
            }
        }

        private void rbtnYes_CheckedChanged(object sender, EventArgs e)
        {
            isAddToVan = true;
            label2.Enabled = true;
            cmbVans.Enabled = true;
        }

        private void rbtnNo_CheckedChanged(object sender, EventArgs e)
        {
            isAddToVan = false;
            label2.Enabled = false;
            cmbVans.Enabled = false;
        }

        private void cmbVans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVans.SelectedIndex < 0)
            {
                hasVan = false;
                vanVIN = "";
            }
            else
            {
                hasVan = true;
                vanVIN = vanList[cmbVans.SelectedIndex];
            }
        }
        /*
         * 
         * Make sure only valid input can be placed in text boxes
         * 
         */
        private void checkIfLettNumSpace(object sender, KeyPressEventArgs e)
        {
            //0x0008 is the literal for the backspace key
            Char pressedKey = e.KeyChar;
            if (Char.IsLetter(pressedKey) || Char.IsDigit(pressedKey) || pressedKey == ',' || pressedKey == '-' || Char.IsWhiteSpace(pressedKey) || pressedKey == 0x0008)
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
