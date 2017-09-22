using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SATSISMain;
using System.IO;

namespace SATSIS
{
    public partial class Calibration : Form
    {
        string text = "";

        public Calibration()
        {
            InitializeComponent();
            text = SATSISGlobals.savepathtextfilelocation;
            textBoxSavePath.Text = text; //Show the current savepath;
            //SATSISGlobals.savepath = textBoxSavePath.Text; //Set the variable savepath, it is public
            //SATSISGlobals.savepath = SATSISGlobals.savepath.Replace("\n", "").Replace("\r", ""); //remove unwanted characters from savepath
            textBoxOD.Text = SATSISGlobals.Diam.ToString();
            textBox6.Text = SATSISGlobals.CalibVal+"";
            comBox.SelectedIndex = SATSISGlobals.COM - 1;
            textBoxLength.Text = SATSISGlobals.Length + "";

            textBox6.Enabled = false;
       
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            
            Close();
            Dispose();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {

            //double delta_pixels;
            SATSISGlobals.savepathtextfilelocation= textBoxSavePath.Text;
            try
            {
                SATSISGlobals.Length = Convert.ToDouble(textBoxLength.Text);
            }
            catch
            {
                MessageBox.Show("Only numbers allowed for stent length");
                return;
            }
            try
            {
                if (checkBox1.Checked)
                {
                    SATSISGlobals.CalibVal = Convert.ToDouble(textBox6.Text);
                    CalculateRatio();
                }
                else
                { }
            }
            catch
            {
                MessageBox.Show("Only numbers allowed for delta_pixels");
                return;
            }
            try
            {
            SATSISGlobals.Diam = Convert.ToDouble(textBoxOD.Text);
            }
            catch
            {
                MessageBox.Show("Only numbers allowed for stent diameter");
                return;
            }


            File.Delete(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt");
            string[] lines = { SATSISGlobals.savepath, "COM" + SATSISGlobals.COM, SATSISGlobals.Diam.ToString(), SATSISGlobals.Length.ToString(), SATSISGlobals.CalibVal.ToString(), SATSISGlobals.LOTNumber, SATSISGlobals.xcountmax + "" };
            System.IO.File.WriteAllLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt", lines);

            SATSISGlobals.COM = comBox.SelectedIndex + 1;

            //File.Delete(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt");
            //string[] lines = { SATSISGlobals.savepath, "COM" + SATSISGlobals.COM, SATSISGlobals.Diam.ToString(), SATSISGlobals.Length.ToString(), SATSISGlobals.CalibVal.ToString(), SATSISGlobals.LOTNumber, SATSISGlobals.xcountmax + "" };
            //System.IO.File.WriteAllLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt", lines);

            SATSISGlobals.xcountmax = (int)Math.Ceiling(SATSISGlobals.Length / 5.0);
            Close();
        }

        private void textBoxSavePath_TextChanged(object sender, EventArgs e)
        {
            //Update the text file to save the path where photos are to be saved
            //string[] lines = { textBoxSavePath.Text };
            //System.IO.File.WriteAllLines(@"C:\Users\Public\SavePath.txt", lines);
        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void textBoxSavePath_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = @"C:\Users\Public\InspectionRig";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxSavePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        

        private void CalculateRatio()
        {

            SATSISGlobals.xband = Convert.ToInt32(SATSISGlobals.CalibVal * 5);
            SATSISGlobals.xstart = Convert.ToInt32(SATSISGlobals.CamWidth / 2) - Convert.ToInt32(SATSISGlobals.xband / 2);
            SATSISGlobals.xrefplus = Convert.ToInt32((((SATSISGlobals.xstart + SATSISGlobals.xband) * (SATSISGlobals.DisplayWidth)) / SATSISGlobals.CamWidth));
            SATSISGlobals.xrefminus = Convert.ToInt32(SATSISGlobals.xstart * SATSISGlobals.DisplayWidth / SATSISGlobals.CamWidth);
            SATSISGlobals.xcountmax = (int)Math.Ceiling(SATSISGlobals.Length / 5.0);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox6.Enabled = true;
            }
            else
            {
                textBox6.Enabled = false;
            }
        }

        private void SetCalibbutton_Click(object sender, EventArgs e)
        {
            SATSISGlobals.CalibVal = Convert.ToInt32(textBox6.Text);
         }
    }
}
