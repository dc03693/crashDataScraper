using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Team3Project
 * CSCI 5432:  Term Project
 * 
 * Created by: Sam Bradshaw
 *             David Chapman
 *             Eddie Sleeth
 *             
 * Date Created: 4/12/2015
 * 
 * <Summary>
 * This application designed to interact with the DeliverySystem Database.
 * 
 * */
namespace Team3Project
{
    static class Program
    {
        //The connection string to be used in all forms, make sure this is changed to your conneciton string
        //Also ctrl+f "Data Source" to find all connection strings in the solution's XML files and replace them with your connection string
        public const string Connectionstring = "Data Source=DAVID-PC;Initial Catalog=DeliveryService;Integrated Security=True";
        //Bool to find out if the application is closing
        public static bool isAppClosing = false;
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fmLogIn MainLogIn = new fmLogIn();
            Application.Run(MainLogIn);
        }
    }
}
