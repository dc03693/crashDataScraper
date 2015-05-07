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
    //Form for the manager to choose what actions to perform
    public partial class fmManager : Form
    {
        public fmLogIn.Employee CurrentEmployee;
        public fmManager()
        {
            InitializeComponent();
        }
        //Populate groupbox's text field with the current user's name
        private void fmManager_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "What would you like to do, " + CurrentEmployee.FName + " " + CurrentEmployee.LName + "?";
        }
        //Open a new form for assigning drivers to vans
        private void btnAssignDrivers_Click(object sender, EventArgs e)
        {
            fmAssignDrivers assignDrivers = new fmAssignDrivers();
            assignDrivers.Show();
        }
        //Open a new form for assigninp packages to vans
        private void btnVVans_Click(object sender, EventArgs e)
        {
            fmAssignPackages assignPackages = new fmAssignPackages();
            assignPackages.Show();
        }
        //Make sure the user wants to exit the application
        private void fmManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.isAppClosing)
            {
                if (MessageBox.Show("Are you sure you want to close the appliction?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.isAppClosing = true;
                    Application.Exit();

                }
                else
                {
                    e.Cancel = true;
                    this.Activate();
                }
            }
        }
    }
}
