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
using System.Security.Cryptography;

namespace Team3Project
{
    
    public partial class fmLogIn : Form
    {
        //Set the maximum number of attempts that user has to log in
        public const int maxAttempts = 3;
        public int attempts = 0;
        public bool hasMaxAttempts = false;
/*Employee class:
 * 
 * The Employee object CurrentEmployee will be used to save the employee's data.
 * Each form will contain a CurrentEmployee, so their information can be passed
 * across forms.
 * 
 */

        //Class to hold employee information
        Employee CurrentEmployee = new Employee();
        public class Employee
        {
            public int ID;
            public string FName;
            public string LName;
            public double Salary;
            public DateTime EmpDate;
            public Employee()
            {
            }
        }

        public fmLogIn()
        {
            InitializeComponent();
        }
        
        //Login button
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //Increment attempts
            attempts++;
            if (attempts < maxAttempts)
            {
                //Record the input from the text boxes
                string userName = txtUsrName.Text;
                string password = txtPassword.Text;
                //Hash the password
                MD5 hasher = MD5.Create();
                string hashedPass = GetMd5Hash(hasher, password);

                //Establish connection and create a query.
                SqlConnection myConnection = new SqlConnection(Program.Connectionstring);
                myConnection.Open();

                //Used to check the username and password
                string login = "SELECT * FROM LOG_IN WHERE USERNAME = @usrnm AND PASSWORD = @pass";
                //Used to create CurrentEmployee
                string allEmp = "SELECT * FROM EMPLOYEES WHERE EMPID=";

                //Add user inputs to the values of the LogQuery
                SqlCommand LogQuery = new SqlCommand(login, myConnection);
                LogQuery.Parameters.AddWithValue("@usrnm", userName);
                LogQuery.Parameters.AddWithValue("@pass", hashedPass);

                //Read data
                SqlDataReader dr = LogQuery.ExecuteReader();
                //Check to see if the rows exist in the table
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        /*This block of code is used to find the Employee from the Employee database.
                         * The de reader executes the query to search for the Employee based of the ID.
                         */
                        SqlConnection myConnection2 = new SqlConnection(Program.Connectionstring);
                        myConnection2.Open();
                        //Set the ID number of the Employee from the Log_In table reader.
                        int idnum = Convert.ToInt32(dr[2]);
                        //Use idnum to find Employee in EMPLOYEES table.
                        SqlCommand getEmployee = new SqlCommand(allEmp + idnum.ToString(), myConnection2);
                        SqlDataReader de = getEmployee.ExecuteReader();
                        //Reader records the record of the employee
                        while (de.Read())
                        {
                            CurrentEmployee.ID = idnum;
                            CurrentEmployee.FName = de[1].ToString();
                            CurrentEmployee.LName = de[2].ToString();
                            CurrentEmployee.Salary = Convert.ToDouble(de[3]);
                            CurrentEmployee.EmpDate = Convert.ToDateTime(de[4]);
                        }
                        //Show validate window
                        MessageBox.Show("Login Successful."
                                        + Environment.NewLine
                                        + "Welcome " + CurrentEmployee.FName + " " + CurrentEmployee.LName
                                        + Environment.NewLine
                                        + "Click OK to continue", "Validated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        myConnection2.Close();
                    }
                    //Close the connection
                    myConnection.Close();


                    /*The following block distingushes Employee types
                    * There is a check for Admins, Managers, and Drivers
                    * Depen
                    * 
                    */
                    myConnection.Open();
                    //Administrator check
                    string allAdmin = "SELECT * FROM ADMINS_VIEW WHERE EMPID = @id";
                    SqlCommand CheckAdmin = new SqlCommand(allAdmin, myConnection);
                    CheckAdmin.Parameters.AddWithValue("@id", CurrentEmployee.ID);
                    SqlDataReader da = CheckAdmin.ExecuteReader();


                    //Manager check
                    SqlConnection myConnection3 = new SqlConnection(Program.Connectionstring);
                    myConnection3.Open();
                    string allManager = "SELECT * FROM MANAGERS_VIEW WHERE EMPID = @id";
                    SqlCommand CheckManager = new SqlCommand(allManager, myConnection3);
                    CheckManager.Parameters.AddWithValue("@id", CurrentEmployee.ID);
                    SqlDataReader dm = CheckManager.ExecuteReader();

                    //Driver Check
                    SqlConnection myConnection4 = new SqlConnection(Program.Connectionstring);
                    myConnection4.Open();
                    string allDriver = "SELECT * FROM DRIVERS_VIEW WHERE EMPID = @id";
                    SqlCommand CheckDriver = new SqlCommand(allDriver, myConnection4);
                    CheckDriver.Parameters.AddWithValue("@id", CurrentEmployee.ID);
                    SqlDataReader dd = CheckDriver.ExecuteReader();

                    //Check all readers for data.
                    if (da.HasRows)
                    {
                        fmAdmin adminWindow = new fmAdmin();
                        adminWindow.CurrentEmployee = CurrentEmployee;
                        adminWindow.Show();
                        diableControls();
                        this.Hide();
                    }
                    else if (dm.HasRows)
                    {
                        fmManager managerWindow = new fmManager();
                        managerWindow.CurrentEmployee = CurrentEmployee;
                        managerWindow.Show();
                        diableControls();
                        this.Hide();

                    }
                    else if (dd.HasRows)
                    {
                        fmDriver driverWindow = new fmDriver();
                        driverWindow.CurrentEmployee = CurrentEmployee;
                        driverWindow.Show();
                        diableControls();
                        this.Hide();

                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult shutDown = MessageBox.Show("Sorry, the information you have provided is incorrect.  The Application will now shut down."
                                + Environment.NewLine
                                + "If the problem persists, please contact your System Administrator.", "Shutting Down", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                hasMaxAttempts = true;
                Application.Exit();
            }
        }

/*The following block creates a secure password for the user.
 * by using the MD5 hash, the user's literal password is not save in the database
 */

        //Method that hashes the password
        public static string GetMd5Hash(MD5 md5Hash, string input)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void fmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        //Prevent user from entering data after login
        public void diableControls()
        {
            this.txtUsrName.Enabled = false;
            this.txtPassword.Enabled = false;
            this.btnLogIn.Enabled = false;
        }
        //Simulate clicking the log-in button when enter is pressed
        private void enterAccept(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                btnLogIn.PerformClick();            
            }
        }

     }
}
