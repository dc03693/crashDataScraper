using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3Project
{
    //Form for administrators to choose which action they would like to perform
    public partial class fmAdmin : Form
    {
        public fmLogIn.Employee CurrentEmployee;
        //Constructor
        public fmAdmin()
        {
            InitializeComponent();
        }
        //Prompt the user before closing the window
        private void fmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.isAppClosing)
            {
                //The program will exit when this window closes
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
        //When the form opens, update the groupbox label with the user's name
        private void fmAdmin_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "What would you like to do, " + CurrentEmployee.FName + " " + CurrentEmployee.LName + "?";
        }
        //Open a new window to add an employee
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            fmAddEmp addEmp = new fmAddEmp();
            addEmp.Show();
        }
        //Open a new window to add a new van
        private void btnAddVan_Click(object sender, EventArgs e)
        {
            fmAddVan addVan = new fmAddVan();
            addVan.Show();
        }
        //Open a new window to add a new package
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            fmAddPackages addPackage = new fmAddPackages();
            addPackage.Show();
        }
    }
}
