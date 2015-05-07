using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Team3Project
{
    //Form for administrators to add a new employee
    public partial class fmAddEmp : Form
    {
        //Sql resources
        static SqlConnection myConnection = new SqlConnection(Program.Connectionstring);
        //Vars
        bool hasAdded = false;
        bool isManager = false, isAdmin = false;
        //Vars for confirming info has been inputed
        bool hasFname = false, hasLname = false, hasSalary = false, hasUname = false, hasPwd = false;
        bool hasType = false, hasAdmin = false, hasLicNo = false, hasExpDate = false;
        //Admin's ID
        List<int> adminList = new List<int>();
        int adminID;
        //Constructor
        public fmAddEmp()
        {
            InitializeComponent();
        }

        private void fmAddEmp_Load(object sender, EventArgs e)
        {

        }
        //Actions to perform when submit buttin is clicked
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //If all fields have valid input
            if (allFieldsNotNull())
            {
                //If there is not another employee with the same username
                if (uniqueUsername())
                {
                    //Add new employee, then close window
                    addEmployee();
                    MessageBox.Show("New employee added!");
                    this.Dispose();
                }
                else
                {
                    //Show an error message and highlight the username field
                    MessageBox.Show("There is already a user with that username!");
                    label3.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //Show an error message and highlight all invalid fields
                MessageBox.Show("Please fix the highlighted fields");
                showErrors();
            }
        }
        //Close window when cancel is clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Before closing this window, if the employee hasn't been added yet, prompt the user for confirmation
        private void fmAddEmp_FormClosing(object sender, FormClosingEventArgs e)
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
        //Change the color of fields that have incorrect data
        private void showErrors()
        {
            //Set all labels to black text first
            label1.ForeColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Black;
            label4.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.Black;
            label8.ForeColor = System.Drawing.Color.Black;
            grpType.ForeColor = System.Drawing.Color.Black;
            lblAdmin.ForeColor = System.Drawing.Color.Black;
            label7.ForeColor = System.Drawing.Color.Black;
            label9.ForeColor = System.Drawing.Color.Black;

            //Then change them to red if they have the wrong info
            if (!hasFname)
            {
                label1.ForeColor = System.Drawing.Color.Red;
            }

            if (!hasLname)
            {
                label2.ForeColor = System.Drawing.Color.Red;

            }

            if (!hasSalary)
            {
                label4.ForeColor = System.Drawing.Color.Red;

            }

            if (!hasUname)
            {
                label3.ForeColor = System.Drawing.Color.Red;

            }

            if (!hasPwd)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                label8.ForeColor = System.Drawing.Color.Red;

            }

            if (hasType)
            {
                if (!isAdmin)
                {
                    if (!hasAdmin)
                    {
                        lblAdmin.ForeColor = System.Drawing.Color.Red;
                    }
                    if (!isManager)
                    {

                        if (!hasLicNo)
                        {
                            label7.ForeColor = System.Drawing.Color.Red;
                        }
                        if (!hasExpDate)
                        {
                            label9.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            else
            {
                grpType.ForeColor = System.Drawing.Color.Red;

            }
        }
        //Method to ensure username is unique
        private bool uniqueUsername()
        {
            //Check database for usernames that are the same as the one the user inputed
            string getUsers = "SELECT USERNAME FROM LOG_IN";
            SqlCommand users = new SqlCommand(getUsers, myConnection);
            myConnection.Open();
            SqlDataReader myReader = users.ExecuteReader();
            while (myReader.Read())
            {
                //If found, return false
                if(myReader[0].ToString() == txtUsrName.Text){
                    myConnection.Close();
                    return false;
                }
            }
            myConnection.Close();
            return true;

        }
        //Method for adding a new employee to the database
        private void addEmployee()
        {
            //Add to employees table
            string newEmp = "INSERT INTO EMPLOYEES (F_NAME, L_NAME, YEARLY_SALARY, DATE_EMPLOYED) VALUES (@fname, @lname, @salary, @date)";
            SqlCommand addNew = new SqlCommand(newEmp, myConnection);
            myConnection.Open();
            addNew.Parameters.AddWithValue("@fname", txtFName.Text);
            addNew.Parameters.AddWithValue("@lname", txtLName.Text);
            addNew.Parameters.AddWithValue("@salary", numSalary.Value);
            addNew.Parameters.AddWithValue("@date", DateTime.Today.Date);
            addNew.ExecuteNonQuery();
            myConnection.Close();
            //Get EMPID of the employee created
            int ID;
            string empIDq = "SELECT EMPID FROM EMPLOYEES ORDER BY EMPID DESC";
            SqlCommand getID = new SqlCommand(empIDq, myConnection);
            myConnection.Open();
            getID.Parameters.AddWithValue("@fname", txtFName.Text);
            getID.Parameters.AddWithValue("@lname", txtLName.Text);
            SqlDataReader myReader = getID.ExecuteReader();
            myReader.Read();
            ID = Convert.ToInt32(myReader[0]);
            myConnection.Close();
            //Add to respective role table
            if (isAdmin)
            {
                newEmp = "INSERT INTO ADMINS (EMPID) VALUES (@id)";
                addNew = new SqlCommand(newEmp, myConnection);
                myConnection.Open();
                addNew.Parameters.AddWithValue("@id", ID);
                addNew.ExecuteNonQuery();
                myConnection.Close();
            }
            else if (isManager)
            {
                newEmp = "INSERT INTO MANAGERS (EMPID, ADMINID) VALUES (@id, @aid)";
                addNew = new SqlCommand(newEmp, myConnection);
                myConnection.Open();
                addNew.Parameters.AddWithValue("@id", ID);
                addNew.Parameters.AddWithValue("@aid", adminID);
                addNew.ExecuteNonQuery();
                myConnection.Close();
            }
            else
            {
                newEmp = "INSERT INTO DRIVERS (EMPID, LICENSE_NO, LICENSE_EXP_DATE, MANAGERID) VALUES (@id, @lno, @expdate, @aid)";
                addNew = new SqlCommand(newEmp, myConnection);
                myConnection.Open();
                addNew.Parameters.AddWithValue("@id", ID);
                addNew.Parameters.AddWithValue("@lno", txtLicenseNo.Text);
                addNew.Parameters.AddWithValue("@expdate", dtpExpDate.Value);
                addNew.Parameters.AddWithValue("@aid", adminID);
                addNew.ExecuteNonQuery();
                myConnection.Close();
            }
            //Add to log-in table
            newEmp = "INSERT INTO LOG_IN (USERNAME, EMPID, PASSWORD) VALUES (@user, @id, @pass)";
            addNew = new SqlCommand(newEmp, myConnection);
            myConnection.Open();
            addNew.Parameters.AddWithValue("@user", txtUsrName.Text);
            addNew.Parameters.AddWithValue("@id", ID);
            addNew.Parameters.AddWithValue("@pass", GetMd5Hash(MD5.Create(), txtPassword.Text));
            addNew.ExecuteNonQuery();
            myConnection.Close();
            hasAdded = true;
        }
        //Makes sure there is data in all of the fields
        private bool allFieldsNotNull()
        {
            if (hasFname && hasLname && hasSalary && hasUname && hasPwd && hasType)
            {
                if (isAdmin)
                {
                    return true;
                }
                else if (hasAdmin)
                {
                    if (isManager)
                    {
                        return true;
                    }
                    else if (hasLicNo && hasExpDate)
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
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //Make sure the passwords are the same and not null
        private void checkPasswords()
        {
            if (txtPassword.Text.Trim().CompareTo(txtPwdConfirm.Text.Trim()) != 0 || txtPassword.Text.Trim() == "" || txtPassword.MaxLength > 25)
            {
                hasPwd = false;
            }
            else
            {
                hasPwd = true;
            }
        }
        //MD5 hash generator
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        /*
         * 
         * Change what fields are accessable based on radio button (role) chosen
         * 
         */
        private void rbtnDriver_CheckedChanged(object sender, EventArgs e)
        {
            isManager = false;
            isAdmin = false;
            hasType = true;

            //Change Admin section to manager info by grabbing from the MANAGERS_VIEW
            grpAdmin.Text = "Manager Info";
            lblAdmin.Text = "Manager:";
            cmbManager.Items.Clear();
            adminList.Clear();
            myConnection.Open();
            SqlCommand managers = new SqlCommand("SELECT F_NAME + ' ' + L_NAME AS NAME, EMPID FROM MANAGERS_VIEW", myConnection);
            SqlDataReader myReader = managers.ExecuteReader();
            while (myReader.Read())
            {
                cmbManager.Items.Add(myReader[0].ToString());
                adminList.Add(Convert.ToInt32(myReader[1]));
            }
            myConnection.Close();
            grpAdmin.Enabled = true;
            grpDriver.Enabled = true;
        }

        private void rbtnManager_CheckedChanged(object sender, EventArgs e)
        {
            isManager = true;
            isAdmin = false;
            hasType = true;
            //Change Admin section to admin info by grabbing from the ADMINS_VIEW
            grpAdmin.Text = "Admin Info";
            lblAdmin.Text = "Admin:";
            cmbManager.Items.Clear();
            adminList.Clear();
            myConnection.Open();
            SqlCommand admins = new SqlCommand("SELECT F_NAME + ' ' + L_NAME AS NAME, EMPID FROM ADMINS_VIEW", myConnection);
            SqlDataReader myReader = admins.ExecuteReader();
            while (myReader.Read())
            {
                cmbManager.Items.Add(myReader[0].ToString());
                adminList.Add(Convert.ToInt32(myReader[1]));
            }
            myConnection.Close();
            grpAdmin.Enabled = true;
            grpDriver.Enabled = false;
        }

        private void rbtnAdmin_CheckedChanged(object sender, EventArgs e)
        {
            isManager = false;
            isAdmin = true;
            hasType = true;
            grpAdmin.Enabled = false;
            grpDriver.Enabled = false;
        }

        /*
         * 
         * Methods for making sure the proper input is in each field
         * 
         */

        //Make sure first name is not null or too long
        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            if (txtFName.Text.Trim() != "")
            {
                hasFname = true;
            }
            else
            {
                hasFname = false;
            }


        }
        //Make sure that the last name is not null or too long
        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            if (txtLName.Text.Trim() != "" && txtLName.Text.Length < 25)
            {
                hasLname = true;
            }
            else
            {
                hasLname = false;
            }
        }
        //Make sure the username is not null
        private void txtUsrName_TextChanged(object sender, EventArgs e)
        {
            if (txtUsrName.Text.Trim() != "" && txtUsrName.Text.Length < 25)
            {
                hasUname = true;
            }
            else
            {
                hasUname = false;
            }
        }
        //Check that the passwords are the same any time either are changed
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            checkPasswords();
        }

        private void txtPwdConfirm_TextChanged(object sender, EventArgs e)
        {
            checkPasswords();
        }

        //Make sure the license number is of valid length
        private void txtLicenseNo_TextChanged(object sender, EventArgs e)
        {
            if (txtLicenseNo.Text.Length == 0)
            {
                hasLicNo = false;
            }
            else
            {
                hasLicNo = true;
            }
        }
        //Make sure the drivers license is not expired
        private void dtpExpDate_ValueChanged(object sender, EventArgs e)
        {

            if (dtpExpDate.Value < DateTime.Now)
            {
                hasExpDate = false;
            }
            else
            {
                hasExpDate = true;

            }
        }

        //Check if an admin has been chosen and get their ID from the adminList
        private void cmbManager_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbManager.SelectedIndex < 0)
            {
                hasAdmin = false;
                adminID = 0;
            }
            else
            {
                hasAdmin = true;
                adminID = adminList[cmbManager.SelectedIndex];
            }
        }
        //Make sure salary is at or above minimum wage
        private void numSalary_ValueChanged(object sender, EventArgs e)
        {
            if (numSalary.Value < 15080)
            {
                hasSalary = false;
            }
            else
            {
                hasSalary = true;
            }
        }
        /*
         * 
         * Functions to prevent invalid characters from being typed into fields 
         * 
         */
        private void checkLetter(object sender, KeyPressEventArgs e)
        {
            //0x0008 is the literal for the backspace key
            Char pressedKey = e.KeyChar;
            if (Char.IsLetter(pressedKey) || pressedKey == '-' || pressedKey == '\'' || pressedKey == 0x0008)
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered
                e.Handled = true;
        }
        private void checkNumber(object sender, KeyPressEventArgs e)
        {
            //0x0008 is the literal for the backspace key
            Char pressedKey = e.KeyChar;
            if (Char.IsDigit(pressedKey) || pressedKey == 0x0008)
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered
                e.Handled = true;
        }
        private void checkNoSpace(object sender, KeyPressEventArgs e)
        {         
            //Allow any character not a space
            //0x0008 is the literal for the backspace key
            Char pressedKey = e.KeyChar;
            if (!Char.IsWhiteSpace(pressedKey))
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered
                e.Handled = true;
        }

        /*
         * 
         * Functions to highlight the text in a field when clicked
         * 
         */
        private void numSalary_Click(object sender, EventArgs e)
        {
            numSalary.Select(0, numSalary.Text.Length);
        }

        private void txtFName_Click(object sender, EventArgs e)
        {
            txtFName.Select(0, txtFName.Text.Length);

        }

        private void txtLName_Click(object sender, EventArgs e)
        {
            txtLName.Select(0, txtLName.Text.Length);

        }

        private void txtUsrName_Click(object sender, EventArgs e)
        {
            txtUsrName.Select(0, txtUsrName.Text.Length);

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Select(0, txtPassword.Text.Length);

        }

        private void txtPwdConfirm_Click(object sender, EventArgs e)
        {
            txtPwdConfirm.Select(0, txtPwdConfirm.Text.Length);

        }

        private void txtLicenseNo_Click(object sender, EventArgs e)
        {
            txtLicenseNo.Select(0, txtLicenseNo.Text.Length);
        }




    }
}

