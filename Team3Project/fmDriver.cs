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
    //Form for the drivers to choose what action they would like to perform
    public partial class fmDriver : Form
    {
        public fmLogIn.Employee CurrentEmployee;
        //Creat a package object and transfer it to the fmDelReport form
        List<Package> packages = new List<Package>();
        public class Package
        {
            public int ID;
            public int Weight;
            public string Contents;
            public DateTime EstDelDate;

            public Package(int id, int wt, string ct, DateTime date) 
            {
                ID = id;
                Weight = wt;
                Contents = ct;
                EstDelDate = date;
            }
        }
        public fmDriver()
        {
            InitializeComponent();
        }

        //View Deliveries
        private void btnViewDel_Click(object sender, EventArgs e)
        {
            //Sql resources
            SqlConnection myConnection = new SqlConnection(Program.Connectionstring);
            myConnection.Open();
            //Query to find driver's packages on the driver's van that have delivery dates on or before the current date
            string myPacakges = "Select P.PACKID, P.DATE_RECIEVED, P.HAS_SHIPPED, P.DATE_SHIPPED, P.HAS_DELIVERED, P.DATE_DELIVERED, P.WEIGHT, P.CONTENTS, P.EST_DELIVERY_DATE, E.EMPID ";
                   myPacakges += "from PACKAGES P join VANS V on P.VIN = V.VIN join EMPLOYEES E on V.EMPID = E.EMPID where E.EMPID = @id and P.EST_DELIVERY_DATE <= @date";
            SqlCommand getPackages = new SqlCommand(myPacakges, myConnection);
            getPackages.Parameters.AddWithValue("@id", CurrentEmployee.ID);
            getPackages.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            SqlDataReader dp = getPackages.ExecuteReader();
            //Add packages to the drivers list of packages
            while (dp.Read())
            {
                if (dp.HasRows)
                {
                    Package current = new Package(Convert.ToInt32(dp[0]), Convert.ToInt32(dp[6]), dp[7].ToString(), Convert.ToDateTime(dp[8]));
                    packages.Add(current);
                }

                else
                {
                    MessageBox.Show("You have no packages today :(");
                }
            }
            //Transfer the CurrentEmployee and packages list to the new form
            fmDelReport report = new fmDelReport();
            report.packages = packages;
            report.CurrentEmployee = CurrentEmployee;
            report.Show();
        }

        //Log Deliveries
        private void btnLogDel_Click(object sender, EventArgs e)
        {
            fmDriverPackages editPackages = new fmDriverPackages();
            editPackages.CurrentEmployee = CurrentEmployee;
            editPackages.Show();
        }

        private void fmDriver_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "What would you like to do, " + CurrentEmployee.FName + " " + CurrentEmployee.LName + "?";
        }

        private void fmDriver_FormClosing(object sender, FormClosingEventArgs e)
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
