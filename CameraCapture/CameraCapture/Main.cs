using Emgu.CV;
using Emgu.CV.Structure;
using SATSIS;
using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV.Stitching;
using System.IO;
using Emgu.CV.UI;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace SATSISMain
{
    //public struct CommProtocols
    //{
    //    public static string RotateY = "#Y!"; //Command to rotate the stent during the process
    //    public static string MoveX = "#X!"; //Command to move the stent during the process
    //}

    public partial class SATSISMain : Form
    {
        //Initialise the other forms

        private VideoCapture capture;        //new capturing object
        //Initialise image
        Image<Rgb, Byte> currentimage = new Image<Rgb, byte>(SATSISGlobals.CamWidth, SATSISGlobals.CamHeight);
        Image<Rgb, Byte> displayimage = new Image<Rgb, byte>(SATSISGlobals.CamHeight, SATSISGlobals.CamWidth);
        Image<Rgb, Byte> ImageFrame = new Image<Rgb, byte>(SATSISGlobals.CamHeight, SATSISGlobals.CamWidth);

        //Image<Rgb, Byte> framesavedauto = new Image<Rgb, byte>(SATSISGlobals.CamWidth, SATSISGlobals.CamHeight);

        string SerialPortNumber = "";
        //tring text = "";

        //Declare the amount of steps that should take place during the process
        //public static int ycountmax = 128; 
        //public static int xcountmax = 12;  
        int xcount = 1;
        int ycount = 1;

        //Initialise the timer
        System.Windows.Forms.Timer mytimerY = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer mytimerX = new System.Windows.Forms.Timer();
        
        String starttime = "";

        int mouseX = 0;
        int mouseY = 0;

        //Enable or disable the process, start disabled
        bool GoNow = false;

        public SATSISMain()
        {
            //////////////////////////////
            //Initialise all values here//
            //////////////////////////////
            InitializeComponent();

            //Image<Bgr, Byte> framesaved= capture.QueryFrame().ToImage<Bgr, Byte>();//capturing and rotating image
            //Image<Rgb, Byte> framesavedauto = new Image<Rgb, byte>(SATSISGlobals.xband, SATSISGlobals.yband);
            //Image<Rgb, Byte> framesavedmanual = new Image<Rgb, byte>(SATSISGlobals.CamWidth, SATSISGlobals.CamHeight);

            //Read the current savepath if it doesn't exist it will be empty
            SATSISGlobals.foldername = System.IO.File.ReadLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt").First();
            SATSISGlobals.foldername = SATSISGlobals.foldername.Replace("\n", "").Replace("\r", ""); //remove unwanted characters from savepath
            SATSISGlobals.Diam = Convert.ToDouble(File.ReadLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt").Skip(2).Take(1).First().ToString());
            SATSISGlobals.Length = Convert.ToDouble(File.ReadLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt").Skip(3).Take(1).First().ToString());
            SATSISGlobals.CalibVal = Convert.ToDouble(File.ReadLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt").Skip(4).Take(1).First().ToString());

            Savebutton.Enabled = false;

            textBox6.Text = SATSISGlobals.CalibVal.ToString();

            checkBox2.Checked = false;
            button10.Enabled = false;
            button11.Enabled = false;
            MovetoCalibbutton.Enabled = false;


            mytimerY.Interval = 1200; //Set the timer for 1 seconds.
            mytimerY.Tick += new EventHandler(StartYProcessonTick);
            mytimerY.Start();

            mytimerX.Interval = 6000; //Set the timer for 5 seconds
            mytimerX.Tick += new EventHandler(StartXProcessonTick);
            CalculateAllValues(); //Calculate the first calibration values
            SelectCamera();

            SATSISGlobals.Diamold = SATSISGlobals.Diam;

            try
            {
                InitialiseComPort();

                //hScrollBar1.Value = 0;
                //MySerialWrite("#P" + hScrollBar1.Value.ToString("D3") + "!");

                //hScrollBar1.Value = 100;
                //textBox3.Text = hScrollBar2.Value.ToString();
                //MySerialWrite("#Q" + hScrollBar2.Value.ToString("D3") + "!");
            }
            catch
            {
                MessageBox.Show("The COM Port is not available, or nothing is connected");
            }


        }

        private async void ProcessFrame(object sender, EventArgs arg)
        {
            //Functions are here: http://www.emgu.com/wiki/files/2.0.0.0/html/18b6eba7-f18b-fa87-8bf2-2acff68988cb.htm
            currentimage = capture.QueryFrame().ToImage<Rgb, Byte>();

            //displayimage = currentimage.Flip(Emgu.CV.CvEnum.FlipType.Vertical);

            //Draw a crosshair line on the image
            Point xlinestart = new Point(0, SATSISGlobals.DisplayHeight / 2);
            Point xlineend = new Point(SATSISGlobals.DisplayWidth, SATSISGlobals.DisplayHeight / 2);
            LineSegment2D xline = new LineSegment2D(xlinestart, xlineend);
            Point ylinestart = new Point(SATSISGlobals.DisplayWidth / 2, 0);
            Point ylineend = new Point(SATSISGlobals.DisplayWidth / 2, SATSISGlobals.DisplayHeight);
            LineSegment2D yline = new LineSegment2D(ylinestart, ylineend);
            Point referystart1 = new Point(SATSISGlobals.xrefplus, 0);
            Point referyend1 = new Point(SATSISGlobals.xrefplus, SATSISGlobals.DisplayHeight);
            Point referystart2 = new Point(SATSISGlobals.xrefminus, 0);
            Point referyend2 = new Point(SATSISGlobals.xrefminus, SATSISGlobals.DisplayHeight);
            LineSegment2D refery1 = new LineSegment2D(referystart1, referyend1);
            LineSegment2D refery2 = new LineSegment2D(referystart2, referyend2);

            
            displayimage = currentimage.Rotate(90, new Rgb(255, 255, 255), true).Flip(Emgu.CV.CvEnum.FlipType.Vertical);
            ImageFrame = displayimage;
            
            //draw red box
            ImageFrame.Draw(new Rectangle(SATSISGlobals.xstart, SATSISGlobals.ystart, SATSISGlobals.xband, SATSISGlobals.yband), new Rgb(Color.Red), 2);
            ImageFrame.Resize(SATSISGlobals.DisplayWidth, SATSISGlobals.DisplayHeight, Emgu.CV.CvEnum.Inter.Cubic);

            //draw yellow box
            ImageFrame.Draw(new Rectangle(300, (SATSISGlobals.CamHeight/2-300/2), 900, 300), new Rgb(Color.GreenYellow), 2);


            CamImageBox.Image = ImageFrame;

            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
        }

        

        private void SelectCamera()
        {
            //Set the camera number to the one selected via combo box
            

            Application.Idle += ProcessFrame;

            //CamNumber = int.Parse(cbCamIndex.Text);

            //Start the selected camera
            #region if capture is not created, create it now
            if (capture == null)
            {
                try
                {
                    capture = new VideoCapture(1);
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            Savebutton.Enabled = true;
            //btnStartProcess.Enabled = true;
            //string natwidth = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth).ToString();
            //string natheight = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight).ToString();
            //CamProptextBox.Text = "Native Resolution: " + natwidth + " x " + natheight + "\r\nAutoCapture Resolution: " + natwidth + " x " + SATSISGlobals.yband;
        }

        private void X_inc()
        {
            string movestepsstring = "#X" + (8000).ToString();
            MySerialWrite(movestepsstring);
        }

        private void Y_inc()
        {
            MySerialWrite("#Y!");
        }

        private void btnIncX_Click(object sender, EventArgs e)
        {
            MySerialWrite("#R!");
        }

        private void btnYInc_Click(object sender, EventArgs e)
        {
            MySerialWrite("#U!");
        }

        void StartTimer(object sender, EventArgs e)
        {

            if (GoNow == false)
                {
                    starttime = DateTime.Now.ToString();
                    GoNow = true;
                    textBox4.Text = "Starting";
                    button8.Text = "Pause";
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    GoNow = false;
                    textBox4.Text = "Paused";
                    button8.Text = "Start";
                    Application.Idle += ProcessFrame;
                }
        }

        void Stoptimer()
        {
            mytimerY.Stop();
        }

        void StartXProcessonTick(object sender, EventArgs e)
        {
            mytimerX.Stop();
            mytimerY.Start();
        }

        void StartYProcessonTick(object sender, EventArgs e)
        {
            if (GoNow == true)
            {
                SATSISGlobals.LOTNumber = LOTtextBox.Text;

                    //0. Start the timer
                    //1. Save photo
                    //2. Take photo
                    //3. Move Y
                    //4. Increment Y
                    //5. if Y is at max, move X and reset Y, increment X
                    //6. if X is at max, stop timer and whole process

                    int maxsteps = SATSISGlobals.ycountmax * SATSISGlobals.xcountmax;
                    progressBar1.Maximum = maxsteps; //Set Maximum size of the progressbar
                    int currentstep = (xcount - 1) * SATSISGlobals.ycountmax + ycount;
                    progressBar1.Value = currentstep;

                    //deleting previous X photos before starting
                    if (currentstep == 1)
                    {
                        for (int i = 1; i <= maxsteps; i++)
                        {
                            String p = SATSISGlobals.savepath + "X" + i + ".jpg";

                            if (System.IO.File.Exists(@p))
                            {
                                // Use a try block to catch IOExceptions, to
                                // handle the case of the file already being
                                // opened by another process.
                                try
                                {

                                    System.IO.File.Delete(@p);
                                }
                                catch (IOException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        } //end for
                    }
                
                serialPort1.DiscardInBuffer();//removing any info from when user moving mandrel

                //frame1 = capture.QueryFrame().ToImage<Rgb, Byte>();//.Rotate(90, new Rgb(255, 255, 255), true);
                //frame1 = frame1.Flip(Emgu.CV.CvEnum.FlipType.Vertical); //For Gray image

                Image<Rgb, Byte> framesavedauto = new Image<Rgb, byte>(SATSISGlobals.CamWidth, SATSISGlobals.CamHeight);
                framesavedauto = capture.QueryFrame().ToImage<Rgb, Byte>();//.Rotate(90, new Rgb(255, 255, 255), true);
                framesavedauto = capture.QueryFrame().ToImage<Rgb, Byte>();//.Rotate(90, new Rgb(255, 255, 255), true);
                //CamImageBox.Image = framesavedauto  .Rotate(90, new Rgb(255, 255, 255), true).Flip(Emgu.CV.CvEnum.FlipType.Vertical);

                //framesavedauto = currentimage;

                Rectangle rect = new Rectangle(SATSISGlobals.ystart, SATSISGlobals.xstart, SATSISGlobals.yband, SATSISGlobals.xband); //Determine ROI
                framesavedauto.ROI = rect; //Crop image

                //1.
                //frame1.Save(savepath + "X" + xcount + "Y" + ycount + ".jpg");
                framesavedauto.Save(SATSISGlobals.savepath + "X" + currentstep + ".jpg");

                //Collect garbage
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();

                //2.
                //frame1 = capture.QueryFrame().ToImage<Rgb, Byte>().Rotate(90, new Rgb(255, 255, 255), true).Flip(Emgu.CV.CvEnum.FlipType.Vertical); //For Gray image

                String path = SATSISGlobals.savepath + "X" + currentstep + ".jpg";
                while (!IsFileReady(path)) ;

                //3.
                Y_inc();
                while (serialPort1.ReadByte() == -1) ;//waiting for rotation to finish

                //frame1 = capture.QueryFrame().ToImage<Rgb, Byte>();

                //4.
                ycount++;

                textBox4.Text = "X" + xcount.ToString() + "Y" + ycount.ToString();

                if (ycount == SATSISGlobals.ycountmax + 1)
                {
                    mytimerY.Stop();
                    mytimerX.Start();
                    X_inc();

                    ycount = 1;
                    xcount++;

                    MySerialWrite("K");

                }

                if (xcount == SATSISGlobals.xcountmax + 1)
                {
                    Application.Idle += ProcessFrame;
                    mytimerY.Stop();
                    mytimerX.Stop();
                    textBox4.Text = "Completed";

                    Application.Idle += ProcessFrame;
                    xcount = 1;
                    
                    StartStitch(); //Start the stitch also
                }
            }
            else
            {
                ; //do nothing
            }
            
        }

        private void ResetMandrel()
        {

        }

        private void InitialiseComPort()
        {
            SerialPortNumber = "COM"+SATSISGlobals.COM;
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 5000;
            serialPort1.Open();
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            //serialPort1.Close();
        }


       
        private void Savebutton_Click(object sender, EventArgs e)
        {
            //Image<Bgr, Byte> frame = capture.QueryFrame().ToImage<Bgr, Byte>().Rotate(90, new Bgr(255, 255, 255), true).Flip(Emgu.CV.CvEnum.FlipType.Vertical);//capturing and rotating image
            Image<Bgr, Byte> frame = capture.QueryFrame().ToImage<Bgr, Byte>().Flip(Emgu.CV.CvEnum.FlipType.Vertical);//capturing and rotating image

            //Draw a horizontal line on the image
            if (checkBox1.Checked == true)
            {
                string natwidth = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth).ToString();
                string natheight = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight).ToString();
                int natwidth1 = int.Parse(natwidth);
                int natheight1 = int.Parse(natheight);
                Point xlinestart = new Point(0, natheight1/2);
                Point xlineend = new Point(natwidth1, natheight1/2);
                LineSegment2D xline = new LineSegment2D(xlinestart, xlineend);
                Point ylinestart = new Point(natwidth1/2, 0);
                Point ylineend = new Point(natwidth1 / 2, natheight1);
                LineSegment2D yline = new LineSegment2D(ylinestart, ylineend);
                frame.Draw(xline, new Bgr(Color.Red), 1);
                frame.Draw(yline, new Bgr(Color.Red), 1);


                
            }
            //Save image into file
            if (!File.Exists(SATSISGlobals.foldername + FilenameTextbox.Text + ".jpg"))//checking if filename taken
            {
                frame.Save(SATSISGlobals.foldername + FilenameTextbox.Text + ".jpg");
            }
            else
            {
                int i = 0;
                while (File.Exists(SATSISGlobals.foldername + FilenameTextbox.Text + " (" + i + ")" + ".jpg"))//finding copy that doesn't exist
                {
                    i++;
                }
                frame.Save(SATSISGlobals.foldername + FilenameTextbox.Text + " (" + i + ")" + ".jpg");
            }
            frame = frame.Rotate(90, new Bgr(255, 255, 255), true).Flip(Emgu.CV.CvEnum.FlipType.Vertical);
            Camimagebox3.Image = frame;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySerialWrite("#D!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySerialWrite("#L!");
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //currentimage = capture.QueryFrame().ToImage<Rgb, Byte>(); //For Gray image
            Rectangle rect = new Rectangle(SATSISGlobals.xstart, SATSISGlobals.ystart, SATSISGlobals.xband, SATSISGlobals.yband); //Determine ROI
            //Image<Bgr, Byte> framesavedmanual = capture.QueryFrame().ToImage<Bgr, Byte>();//capturing and rotating image
            //Image<Bgr, Byte> frame = capture.QueryFrame().ToImage<Bgr, Byte>().Rotate(90, new Bgr(255, 255, 255), true).Flip(Emgu.CV.CvEnum.FlipType.Vertical);//capturing and rotating image
            //Image<Rgb, Byte> framesavedmanual = new Image<Rgb, byte>(SATSISGlobals.CamWidth, SATSISGlobals.CamHeight);

            Image<Rgb, Byte> framesavedmanual = new Image<Rgb, byte>(SATSISGlobals.CamWidth, SATSISGlobals.CamHeight);
            framesavedmanual = currentimage.Flip(Emgu.CV.CvEnum.FlipType.Vertical);
            
            framesavedmanual.ROI = rect; //Crop image
            //framesavedmanual = framesavedmanual.Flip(Emgu.CV.CvEnum.FlipType.Vertical);
            framesavedmanual.Save(SATSISGlobals.savepath + "test" + ".jpg");
        }

        private void SATSISMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            try
            {
                serialPort1.Close();
                serialPort1.Dispose();
            }
            catch
            {

            }

            /*
              
            Writeable values are:
            Manual save path of images
            The hard coded COM port
            The last used stent diameter (mm)
            The last used stent length (mm)
            The current calibration Value (CalibVal)
            LOT number
            xcountmax
            */

            File.Delete(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt");
            string[] lines = {SATSISGlobals.savepath, "COM" + SATSISGlobals.COM, SATSISGlobals.Diam.ToString(), SATSISGlobals.Length.ToString(), SATSISGlobals.CalibVal.ToString(), SATSISGlobals.LOTNumber, SATSISGlobals.xcountmax + "" };
            System.IO.File.WriteAllLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt", lines);
        }

        private void btnYUpsmall_Click(object sender, EventArgs e)
        {
            MySerialWrite("#J!");
        }

        private void btnYDownSmall_Click(object sender, EventArgs e)
        {
            MySerialWrite("#K!");
        }

        private void btnXUpSmall_Click(object sender, EventArgs e)
        {
            MySerialWrite("#M!");
        }

        private void btnXDownSmall_Click(object sender, EventArgs e)
        {
            MySerialWrite("#N!");
        }

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    int LEDBrightness = 0;
        //    LEDBrightness = 256 - vScrollBar1.Value - 24;
        //    textBox2.Text = LEDBrightness.ToString();
        //    string WriteB = "#B" + LEDBrightness.ToString("D3") + "!";
        //    MySerialWrite(WriteB);
        //}

        private void btnCalibrate_Click(object sender, EventArgs e) 
        {
            MySerialWrite("#C!");
        }

        public void MySerialWrite(string customstring)
        {
            try
            {
                serialPort1.Write(customstring);          //write this specific line to arduino
                return;
            }
            catch
            {
                MessageBox.Show("The COM Port is not available");
            }
        }

        //private void calibrateToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    calibrate.Show();
        //}

     
        //private void button12_Click(object sender, EventArgs e)
        //{
            //ImageList<Image<Bgr, byte>> sourceImages = new ImageList<Image<Bgr, byte>>();
            //Emgu.CV.list

            //using (Stitcher stitcher = new Stitcher(false))
            //{
                //// code to display or save the result 
                //for (int i = 1; i < 128; i++)
                //{
                   // string fileN = "X" + i.ToString() + ".jpg";
                    //sourceImages.Add(new Image<Bgr, Byte>(fileN));
                //}
               // Image<Bgr, Byte> result = stitcher.Stitch(sourceImages);
                //result.Save(savepath + "StitchedResult.jpg");
            //}
        //}

        private void CalculateAllValues()
        {
            SATSISGlobals.Circ = Math.PI*SATSISGlobals.Diam;
            double TPoC = SATSISGlobals.CalibVal * SATSISGlobals.Circ; //Total pixels on circumference
            SATSISGlobals.yband = Convert.ToInt32(TPoC*1.1) / SATSISGlobals.ycountmax;
            SATSISGlobals.ystart = Convert.ToInt32((SATSISGlobals.CamHeight / 2 - SATSISGlobals.yband / 2));

            SATSISGlobals.xband = Convert.ToInt32(SATSISGlobals.CalibVal *5*1.1);
            SATSISGlobals.xstart = Convert.ToInt32((SATSISGlobals.CamWidth / 2) - Convert.ToInt32(SATSISGlobals.xband / 2));

            SATSISGlobals.xrefplus = Convert.ToInt32((((SATSISGlobals.xstart + SATSISGlobals.xband)*(SATSISGlobals.DisplayWidth))/SATSISGlobals.CamWidth));
            SATSISGlobals.xrefminus = Convert.ToInt32(SATSISGlobals.xstart*SATSISGlobals.DisplayWidth/SATSISGlobals.CamWidth);
            SATSISGlobals.xcountmax = (int)Math.Ceiling(SATSISGlobals.Length / 5.0);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int LEDBrightness = 0;
            //LEDBrightness = 256 - hScrollBar1.Value - 24;
            LEDBrightness = hScrollBar1.Value;
            textBox3.Text = LEDBrightness.ToString();
            string WriteP = "#P" + LEDBrightness.ToString("D3") + "!";
            MySerialWrite(WriteP);
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            int LEDBrightness = 0;
            LEDBrightness = hScrollBar2.Value;
            textBox5.Text = LEDBrightness.ToString();
            string WriteQ = "#Q" + LEDBrightness.ToString("D3") + "!";
            MySerialWrite(WriteQ);
        }

        private void calibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calibration calibrate = new Calibration();
            calibrate.Show();
        }

        private void FocusButton_Click(object sender, EventArgs e)
        {
            int ratio = 1600; //steps per mm: 3200 steps per revolution, 2mm lead screw
            //double movedistance = (SATSISGlobals.Diam - SATSISGlobals.Diamold)*ratio; //amount of steps to move
            string movesteps = Convert.ToInt32((SATSISGlobals.Diamold - SATSISGlobals.Diam) * ratio/2).ToString(); //devide ratio by 2, need to halve the movement. 
            //int movesteps = Math.Abs(Convert.ToInt32(movedistance));
            //string movestepsstring = movesteps.ToString();
            string movestring;
            //if (SATSISGlobals.Diam > SATSISGlobals.Diamold)
            //{
                movestring = "#F" + movesteps;
            //}
            //else
            //{
            //movestring = "#B" + movestepsstring;
            //}
            MySerialWrite(movestring);
            SATSISGlobals.Diamold = SATSISGlobals.Diam;
        }

        //private void CalculateRatio(double delta_pixels)
        //{
        //    SATSISGlobals.CalibVal = delta_pixels / 5;
        //    textBox6.Text = SATSISGlobals.CalibVal.ToString();

        //    SATSISGlobals.xband = Convert.ToInt32(SATSISGlobals.CalibVal * 5);//SATSIS.CalibVal/5
        //    SATSISGlobals.xstart = Convert.ToInt32(SATSISGlobals.CamWidth/2) - Convert.ToInt32(SATSISGlobals.xband/2);
        //    SATSISGlobals.xrefplus = (SATSISGlobals.xband + SATSISGlobals.xstart) * (SATSISGlobals.DisplayWidth / SATSISGlobals.CamWidth);
        //    SATSISGlobals.xrefminus = Convert.ToInt32((SATSISGlobals.xstart * SATSISGlobals.DisplayWidth) / SATSISGlobals.CamWidth);
        //    //SATSISGlobals.xcountmax = (int)Math.Ceiling(SATSISGlobals.Lenght / 5.0);
        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CamImageBox_DoubleClick(object sender, EventArgs e)
        {
            //come back and change to doubles to make more accurate
            //string movestepsstring = "#G" + ((mouseX-SATSISGlobals.DisplayWidth*0.5)*SATSISGlobals.CamWidth/SATSISGlobals.DisplayWidth/SATSISGlobals.CalibVal*1600).ToString()+","+ ((mouseY - SATSISGlobals.DisplayHeight*0.5)*SATSISGlobals.CamHeight/SATSISGlobals.DisplayHeight/SATSISGlobals.CalibVal*1600).ToString();
            //MySerialWrite(movestepsstring);
        }

        private void CamImageBox_Click(object sender, EventArgs e)
        {

        }

        private void CamImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX= e.Location.X;
            mouseY = e.Location.Y;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string movestepsstring = "#X" + (-5000).ToString();
            MySerialWrite(movestepsstring);
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {

        }

        public static bool IsFileReady(String sFilename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    if (inputStream.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void StartStitch()
        {
            String p = "C:\\Users\\Public\\InspectionRig\\Fused.bmp";

            if (System.IO.File.Exists(@p))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {

                    System.IO.File.Delete(@p);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            Process imageJ = new Process();

            try
            {
                imageJ.StartInfo.FileName = @"C:\\Users\\Public\\InspectionRig\\Stitching-23mm_AV_Stent.ijm";
                imageJ.Start();//opens appplication
                imageJ.Start();
                while (!IsFileReady("C:\\Users\\Public\\InspectionRig\\Fused.bmp")) ;
                //imageJ.Close();
                Process pic = new Process();
                pic.StartInfo.FileName = "C:\\Users\\Public\\InspectionRig\\Fused.bmp";
                pic.Start();//opens appplication
            }
            catch
            {
                MessageBox.Show("Stitching Failed");
            }

            try
            {
                imageJ.Close();
                imageJ.Close();
            }
            catch
            {

            }
        }

        private void MovetoCalibbutton_Click(object sender, EventArgs e)
        {
            int ratio = 1600; //steps per mm: 3200 steps per revolution, 2mm lead screw
            string movesteps = Convert.ToInt32((SATSISGlobals.Diamold - 30) * ratio / 2).ToString(); //devide ratio by 2, need to halve the movement. 
            string movestring;
            movestring = "#F" + movesteps;
            MySerialWrite(movestring);
            SATSISGlobals.Diamold = SATSISGlobals.Diam;
        }

        private void OpenPythonbutton_Click(object sender, EventArgs e)
        {
            //Open python code, or above in button9_Click_2?
        }

        private void LOTtextBox_TextChanged(object sender, EventArgs e)
        {
            SATSISGlobals.LOTNumber = LOTtextBox.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string movestepsstring = "#X" + (-16000).ToString();
            MySerialWrite(movestepsstring);
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            string movestepsstring = "#X" + (16000).ToString();
            MySerialWrite(movestepsstring);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string movestepsstring = "#F100";
            MySerialWrite(movestepsstring);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string movestepsstring = "#B100";
            MySerialWrite(movestepsstring);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button10.Enabled = true;
                button11.Enabled = true;
                MovetoCalibbutton.Enabled = true;
            }
            else
            {
                button10.Enabled = false;
                button11.Enabled = false;
                MovetoCalibbutton.Enabled = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Final step, move back to start
            string movestepsstring = "#X" + (-8000 * SATSISGlobals.xcountmax).ToString();
            MySerialWrite(movestepsstring);
            progressBar1.Value = 0;
            button8.Text = "Start";
            GoNow = false;
            mytimerY.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartStitch();
        }
    }

    public static class SATSISGlobals
    {
        //com variables
        public static int COM = 6;

        //Stent Variables
        public static double CalibVal;     //pixels/mm //543.37
        public static double Diam;              //mm
        public static double Diamold;      //mm
        public static double Circ;     //mm
        public static double Length;            //mm

        //Movement Variables
        public static int ycountmax = 160; //Steps per rotation
        public static int xcountmax = (int)Math.Ceiling(SATSISGlobals.Length / 5.0); //Steps per linear feed
        //public static double windowlength = 10;  //mm, lenght of window along stent axis

        //Declare the ROI variables
        public static int xband;// = 941; //set this, native is 4096
        public static int yband;// = 212; //set this, native is 3286
        public static int xstart;// = 1578; //start at rect here
        public static int ystart;// = 1537; // start rect here
        public static int xrefplus;// = 369; // index of reference point line of where stent should start
        public static int xrefminus;// = 231; // index of reference point line of where stent should start

        //Camera Properties

        public static int CamHeight = 3286;
        public static int CamWidth = 4096;

        //Display Window Properties
        public static int DisplayWidth = 600;
        public static int DisplayHeight = 400;

        //Savepath String
        public static string savepathtextfilelocation = System.IO.File.ReadLines(@"C:\\Users\\Public\\InspectionRig\\SavePath.txt").First();
        public static string savepath = "C:\\Users\\Public\\InspectionRig\\";
        public static string foldername = "";

        //LOT number
        public static string LOTNumber;

    }
}
