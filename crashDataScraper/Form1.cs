using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace crashDataScraper
{
    public partial class Form1 : Form
    {
        //Variables for the Measure Select Box
        public string[] measures = { "Crashes", "Vehicle", "Age", "Driver" };
        public string[] Crashes = { "All" };
        public string[] Vehicle = { "INVOLVED_PASSENGER_VEHICLE", "INVOLVED_PASSENGER_VAN", "INVOLVED_PASSENGER_TRUCK", "INVOLVED_SUV", "INVOLVED_MOTORCYCLE", "INVOLVED_PEDESTRIAN", "INVOLVED_BICYCLE" };
        public string[] Age = { "INVOLVED_CHILD_AGED_LESS_THAN_6", "INVOLVED_CHILD_AGED_LESS_THAN_15" };
        public string[] Driver = { "INVOLVED_DRIVER_WITHOUT_SEATBELT", "INVOLVED_DRIVER_AGED_LESS_THAN_15", "INVOLVED_DRIVER_AGED_15_TO_20", "INVOLVED_DRIVER_AGED_65_PLUS" };
        //variable for the Crash Severity Select Box
        public string[] severity = { "All", "1-Fatal", "2-SeriousInjury", "3-MildInjury", "4-PropertyDamage" };
        //Variable for the Road/Intersection Select Box
        public string[] roadInt = { "-2", "1", "0", "-1" };
        //Sets the text for roadInt in the output
        public string[] roadInt_Text = { "All Locations", "At Intersection", "Not at Intersection", "Unknown" };
        //Variable for the Road of Occurence Select Box
        public string[] roadOfOccurrence = { "-2", "1", "2", "3", "-1" };
        //Sets the text for roadOfOccurence in the output
        public string[] roadOfOccurrence_Text = { "All Roadway Types", "Interstate", "State Road", "Local Road", "Unknown" };
        //Variable for the Number of Vehicles Select Box
        public string[] numOfVehicles = { "All", "Single", "Multiple" };
        public string[] numOfVehicles_Text = { "All numbers of vehicles", "Single", "Multiple" };
        //Variables for the Initial Type of Collision Select Box
        public string[] typeCollision = { "All", "1", "2", "3", "-1" };
        public string[] typeCollision_Text = { "All collision types", "Non-collision", "Collision with moving object", "Collision with fixed object", "Unknown" };
        public string[] All = { "All" };
        public string[] noneCollision = { "-2" };
        public string[] noneCollision_Text = {"All"};
        public string[] collisionWithMovingObject = { "All", "9", "14", "11", "12", "10", "7", "6", "8", "13" };
        public string[] collisionWithMovingObject_Text = { "All Moving Objects", "Animal", "Deer", "Motor Vehicle in Motion", "Motor Vehicle in Motion - In Other Roadway", "Parked Motor Vehicle", "Pedalcycle", "Pedestrian", "Railway Train", "Other Object (Not Fixed)" };
        public string[] collisionWithFixedObject = { "-2" };
        public string[] collisionWithFixedObject_Text = {"All"};
        public string[] unknown = { "-2" };
        public string[] unknown_Text = {"All"};
        //Variable for Manner of Impact Select Box
        public string[] mannerOfImpact = { "-2", "1", "2", "3", "4", "5", "6" };
        public string[] mannerOfImpact_Text = { "All", "Angle (Including T-Bone)", "Head-On", "Rear-End", "Sideswipe - Opposite Direction", "Sideswipe - Same Direction", "Not Applicable" };
        //Variable for Time of Day Select Box
        public string[] timeOfDay = { "All", "1", "2", "3", "4", "5", "6", "7", "8" };
        public string[] timeOfDay_Text = { "All Crash Times", "12:00am-2:59am", "3:00am-5:59am", "6:00am-8:59am", "9:00am-11:59am", "12:00pm-2:59pm", "3:00pm-5:59pm", "6:00pm-8:59pm", "9:00pm-11:59pm" };
        //Variable for Day of Week Select Box
        public string[] dayOfWeek = { "All", "1", "2", "3", "4", "5", "6", "7" };
        public string[] dayOfWeek_Text = { "All Days", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        //Variable for Contributing Factors Select Box
        public string[] contributingFactors = { "All", "CF_CHANGED_LANES_IMPROPERLY", "CF_DISREGARDED_STOP_SIGN", "CF_DRIVER_LOST_CONTROL", "CF_EXCEEDED_SPEED_LIMIT", "CF_FAILED_TO_YIELD", "CF_FOLLOWED_TO0_CLOSE", "CF_OBJECT_OR_ANIMAL", "CF_TOO_FAST_FOR_CONDITIONS", "CF_WEATHER_CONDITIONS", "CF_WRONG_SIDE_OF_ROAD" };
        //Variable for Outside Light Select Box
        public string[] outsideLight = { "-2", "3", "1", "2", "4", "5", "-1" };
        public string[] outsideLight_Text = { "All Light Conditions", "Dawn", "Daylight", "Dusk", "Dark - Lighted", "Dark - Not Lighted", "Unknown" };
        //Variable for Surface Condition Select Box
        public string[] surfaceConditions = { "-2", "1", "4", "6", "9", "7", "8", "3", "2", "5", "-1" };
        public string[] surfaceConditions_Text = { "All Surface Conditions", "Dry", "Icy", "Mud", "Oil", "Sand", "Slush", "Snowy", "Wet", "Other", "Unknown" };
        //Variable for Weather Conditions Select Box
        public string[] weatherConditions = { "-2", "1", "2", "6", "3", "5", "4", "7", "-1" };
        public string[] weatherConditions_Text = { "All Weather Conditions", "Clear", "Cloudy", "Fog", "Rain", "Sleet", "Snow", "Other", "Unknow" };
        
        
        //This method determines the values of s13 based on s12
        public string[] getMeasures(string s12)
        {
            if (s12 == "Crashes") return Crashes;
            else if (s12 == "Vehicle") return Vehicle;
            else if (s12 == "Age") return Age;
            else if (s12 == "Driver") return Driver;
            else return null;
        }

        //This method determines the values of s15 based on s14
        public string[] getTypeCollision(string s14)
        {
            if (s14 == "All") return All;
            else if (s14 == "1") return noneCollision;
            else if (s14 == "2") return collisionWithMovingObject;
            else if (s14 == "3") return collisionWithFixedObject;
            else if (s14 == "-1") return unknown;
            else return null;
        }

        public string[] getTypeCollision_Text(string s14)
        {
            if (s14 == "All") return All;
            else if (s14 == "1") return noneCollision_Text;
            else if (s14 == "2") return collisionWithMovingObject_Text;
            else if (s14 == "3") return collisionWithFixedObject_Text;
            else if (s14 == "-1") return unknown_Text;
            else return null;
        }
        //Write the data to a file
        public void writeData(string var_values)
        {
            HtmlElement div = webBrowser1.Document.GetElementById("Table_Filter");
            string results = div.InnerHtml;
            HtmlElement table = webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_gvResult");
            HtmlElementCollection th = table.GetElementsByTagName("th");
            HtmlElementCollection td = table.GetElementsByTagName("td");
            if (table == null) return;
            if (div == null) return;
            using (StreamWriter sw = File.AppendText("data.txt"))
            {
                int count = 0;
                foreach (HtmlElement d in td)
                {

                    if (count < 7)
                    {
                        sw.Write(d.InnerText + ";");
                        textBoxData.AppendText(d.InnerText + ";");
                        count++;

                    }
                    else
                    {
                        sw.Write(d.InnerText + ";" + var_values + Environment.NewLine);
                        textBoxData.AppendText(d.InnerText + ";" + var_values + Environment.NewLine);
                        count = 0;

                    }
                }
            }
        }

        public int getLoopCount(int s)
        {
            string[] loops = File.ReadAllLines("Loop_Counter.txt");
            return Convert.ToInt32(loops[s]);
        }

        public void writeLoopCount(int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8, int s9, int s10, int s11, int s12, int s13, int s14, int s15, int nPages)
        {
            string[] loops = {Convert.ToString(s1),Convert.ToString(s2),Convert.ToString(s3),Convert.ToString(s4),Convert.ToString(s5),Convert.ToString(s6),Convert.ToString(s7),Convert.ToString(s8),Convert.ToString(s9),Convert.ToString(s10),Convert.ToString(s11),Convert.ToString(s12),Convert.ToString(s13),Convert.ToString(s14),Convert.ToString(s15),Convert.ToString(nPages)};
            File.WriteAllLines("Loop_Counter.txt", loops);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int nPages;
            try
            {
                nPages = getLoopCount(15);
                for (int s1=getLoopCount(0);s1<=weatherConditions.Length-1;s1++)
                {
                    for (int s2 = getLoopCount(1); s2 <= surfaceConditions.Length - 1; s2++)
                    {
                        for (int s3 = getLoopCount(2); s3 <= outsideLight.Length - 1; s3++)
                        {
                            for (int s4=getLoopCount(3);s4<=contributingFactors.Length-1;s4++)
                            {
                                for (int s5 = getLoopCount(4); s5 <= dayOfWeek.Length - 1; s5++)
                                {
                                    for (int s6 = getLoopCount(5); s6 <= timeOfDay.Length - 1; s6++)
                                    {
                                        for (int s7 = getLoopCount(6); s7 <= mannerOfImpact.Length - 1; s7++)
                                        {
                                            for (int s8 = getLoopCount(7); s8 <= numOfVehicles.Length - 1; s8++)
                                            {
                                                for (int s9 = getLoopCount(8); s9 <= roadOfOccurrence.Length - 1; s9++)
                                                {
                                                    for (int s10 = getLoopCount(9); s10 <= roadInt.Length - 1; s10++)
                                                    {
                                                        for (int s11 = getLoopCount(10); s11 <= severity.Length - 1; s11++)
                                                        {
                                                            for (int s12 = getLoopCount(11); s12 <= measures.Length - 1; s12++)
                                                            {
                                                                //Call getMeasures to get values for measures
                                                                for (int s13 = getLoopCount(12); s13 <= getMeasures(measures[s12]).Length - 1; s13++ )
                                                                {
                                                                    for (int s14 = getLoopCount(13); s14 <=typeCollision.Length - 1; s14++)
                                                                    {
                                                                        //Call getTypeCollision to get values for typeColllision
                                                                        for (int s15 = getLoopCount(14); s15 <= getTypeCollision(typeCollision[s14]).Length - 1; s15++ )
                                                                        {

                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_WEATHER_CONDITION").SetAttribute("value", weatherConditions[s1]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_ROAD_SURFACE_CONDITION").SetAttribute("value", surfaceConditions[s2]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_AMBIENT_LIGHT").SetAttribute("value", outsideLight[s3]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_boo_Contributing_Factors").SetAttribute("value", contributingFactors[s4]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_Day_Of_Week").SetAttribute("value", dayOfWeek[s5]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_THREE_HOUR_TIME_GROUP").SetAttribute("value", timeOfDay[s6]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_Manner_Of_Impact").SetAttribute("value", mannerOfImpact[s7]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_rul_Number_Of_Vehicles").SetAttribute("value", numOfVehicles[s8]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_Road_Of_Occurrence").SetAttribute("value", roadOfOccurrence[s9]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_Road_Intersection").SetAttribute("value", roadInt[s10]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_rul_Severity").SetAttribute("value", severity[s11]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sel_Measure_CLASS").SetAttribute("value", measures[s12]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_boo_Measures").SetAttribute("value", getMeasures(measures[s12])[s13]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_INITIAL_CRASH_EVENT_CLASS").SetAttribute("value", typeCollision[s14]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_INITIAL_CRASH_EVENT").SetAttribute("value", getTypeCollision(typeCollision[s14])[s15]);
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_gua").SetAttribute("value", "Every");
                                                                            webBrowser1.Document.GetElementById("ctl00_bodyContentPlaceHolderMain_sdp_tua").SetAttribute("value", "-2");
                                                                            string var_values = weatherConditions_Text[s1] + ";" + surfaceConditions_Text[s2] + ";" + outsideLight_Text[s3] + ";" + contributingFactors[s4] + ";" + dayOfWeek_Text[s5] + ";" + timeOfDay_Text[s6] + ";" + mannerOfImpact_Text[s7] + ";" + numOfVehicles_Text[s8] + ";" + roadOfOccurrence_Text[s9] + ";" + roadInt_Text[s10] + ";" + severity[s11] + ";" + measures[s12] + ";" +  getMeasures(measures[s12])[s13] + ";" + typeCollision_Text[s14] + ";" + getTypeCollision_Text(typeCollision[s14])[s15];
                                                                            //Record loop count
                                                                            writeLoopCount(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, nPages);
                                                                            //Get the page
                                                                            webBrowser1.Document.GetElementById("ctl00$bodyContentPlaceHolderMain$imgSubmit").InvokeMember("click");
                                                                           
                                                                            

                                                                            //Wait until the page loads
                                                                            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                                                                            {
                                                                                Application.DoEvents();
                                                                            }

                                                                            // Wait 30 more seconds
                                                                            timer1.Interval = 30000;
                                                                            timer1.Enabled = true;
                                                                            while (timer1.Enabled) Application.DoEvents();
                                                                            //Write the data to a file
                                                                            try
                                                                            {
                                                                                writeData(var_values);
                                                                            }
                                                                            catch { }

                                                                            //write the data to a file

                                                                            nPages++;
                                                                            textBox1.Text = "" + nPages;
                                                                            textBox1.Refresh();

                                                                            

                                                                        }//End s15 Loop
                                                                    }//End s14 Loop
                                                                }//End s13 Loop
                                                            }//End s12 Loop
                                                        }//End s11 Loop
                                                    }//End s10 Loop
                                                }//End s9 Loop
                                            }//End s8 Loop
                                        }//End s7 Loop
                                    }//End s6 Loop
                                }//End s5 Loop
                            }//End s4 Loop
                        }//End s3 Loop
                    }//End s2 Loop
                }//End s1 Loop
            }//End Try
                    
            catch
            {
                webBrowser1.Navigate("http://oasis.state.ga.us/oasis/crash/qryCrash.aspx");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btnShowFile_Click(object sender, EventArgs e)
        {
            textBoxFile.Clear();
            string[] fileContent = File.ReadAllLines("Loop_Counter.txt");
            foreach (string t in fileContent)
            {
                textBoxFile.AppendText(t);
            }
            
        } //End of btnShowFile_Click event handler
        
    }//End Form 1 partial class
}
