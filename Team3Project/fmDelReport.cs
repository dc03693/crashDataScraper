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
    public partial class fmDelReport : Form
    {
        /* fmDelReport will display the drivers packages that have delivery dates less than or equal to today.
         * The driver can then choose to print a report of their deliveries.
         * */

        //Instances of these objects are passed to this form from the previuos forms
        public fmLogIn.Employee CurrentEmployee;
        public List<fmDriver.Package> packages = new List<fmDriver.Package>();
        //String to prin the report
        String report;

        public fmDelReport()
        {
            InitializeComponent();
        }
        
        //Code used to print the document
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Graphics and the String report are used to generate the printed report
            report = CurrentEmployee.FName + " " + CurrentEmployee.LName + " Deliveries:\n\n\n";
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 24, System.Drawing.GraphicsUnit.Point);

            //Add all packages to the report
            for (int i = 0; i < packages.Count; i++)
            {
                report += "Package ID:  " + packages[i].ID.ToString()
                         + "\n" + "Weight:  " + packages[i].Weight.ToString()
                         + "\n" + "Contents:  " + packages[i].Contents.ToString()
                         + "\n" + "Est. Delivery Date:  " + packages[i].EstDelDate.ToShortDateString() + "\n################################################\n";
                Font reportFont = new Font("Arial", 18, System.Drawing.GraphicsUnit.Point);
                g.DrawString(report, reportFont, Brushes.Black, 100, 100);
            }
        }

        //Print the report document
        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Icon = Team3Project.Properties.Resources.document_print;
            printPreviewDialog1.ShowDialog();
        }

        private void fmDelReport_Load(object sender, EventArgs e)
        {
            //Window title with name of the driver
            this.Text = CurrentEmployee.FName + " " + CurrentEmployee.LName + "'s Deliveries";
            //Clear the text box on form load
            txtDeliv.Clear();
            //Add deliveries to the text box
            txtDeliv.AppendText("Todays Deliveries:\n");
            foreach (fmDriver.Package p in packages)
            {
               txtDeliv.AppendText("Package ID:  " + p.ID.ToString() + Environment.NewLine);
               txtDeliv.AppendText("Weight:  " + p.Weight.ToString() + Environment.NewLine);
               txtDeliv.AppendText("Contents:  " + p.Contents.ToString() + Environment.NewLine);
               txtDeliv.AppendText("Est. Delivery Date:  " + p.EstDelDate.ToShortDateString() + Environment.NewLine + "################################################" + Environment.NewLine + Environment.NewLine);   
            }
        }
    }
}
