using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;


namespace CameraCapture
{
    public partial class CameraCapture : Form
    {
        ///////////////////////////////////////////////
        //////DECLARE ALL GLOBAL VARIABLES HERE////////
        ///////////////////////////////////////////////

        //Declaring global variables
        private VideoCapture capture;        //takes images from camera as image frames, "VideoCapture" changed
        string SerialPortNumber = "0";
        string text = "";
        string savepath = "";

        //Declare the ROI variables
        int xband = 4096; //set this, native is 4096
        int yband = 942; //set this, native is 3286
        int xstart = 0; //start at
        int ystart = 3286 / 2;

        //Declare the amount of steps that should take place during the process
        int ycountmax = 3; //Steps per rotation
        int xcountmax = 3;  //Steps per linear feed

        public CameraCapture()
        {
            //////////////////////////////
            //Initialise all values here//
            //////////////////////////////
            InitializeComponent();
            string version = System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString();
            label7.Text = "V" + version + " " + DateTime.Now.ToString();
            //SteptextBox.Text = "let's start...";
            //Read the current savepathif it doesn't exist it will be empty
            text = System.IO.File.ReadAllText(@"C:\Users\Public\SavePath.txt");
            textBoxSavePath.Text = text; //Show the current savepath;
            savepath = textBoxSavePath.Text; //Set the variable savepath, it is public
            savepath = savepath.Replace("\n", "").Replace("\r", ""); //remove unwanted characters from savepath

            Savebutton.Enabled = false;
            btnStartProcess.Enabled = false;

            vScrollBar1.Value = 0;

        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 100); //Doesn't work without the Toupcam SDK
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame().ToImage<Bgr, Byte>();
            ImageFrame = ImageFrame.Resize(600, 400, Emgu.CV.CvEnum.Inter.Cubic);
            //ImageFrame = ImageFrame.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
            ImageFrame = ImageFrame.Flip(Emgu.CV.CvEnum.FlipType.Vertical);

            CamImageBox.Image = ImageFrame;

            //Draw a crosshair line on the image
            Point xlinestart = new Point(0, 200);
            Point xlineend = new Point(600, 200);
            LineSegment2D xline = new LineSegment2D(xlinestart, xlineend);
            Point ylinestart = new Point(300, 0);
            Point ylineend = new Point(300, 400);
            LineSegment2D yline = new LineSegment2D(ylinestart, ylineend);
            ImageFrame.Draw(xline, new Bgr(Color.Red), 1);
            ImageFrame.Draw(yline, new Bgr(Color.Red), 1);

            //int width = 400;
            //int height = 400;
            //int xstart = 2048;
            //int ystart = width / 2 - height / 2; ;
            //Image<Bgr, Byte> frame = capture.QueryFrame().ToImage<Bgr, Byte>();
            //Rectangle rect = new Rectangle(xstart, ystart, width, height); //Determine ROI
            //frame.ROI = rect; //Crop image
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                if (btnStart.Text == "Pause")
                {  //if camera is getting frames then pause the capture and set button Text to
                    // "Resume" for resuming capture
                    btnStart.Text = "Resume"; //
                    //Application.Idle -= ProcessFrame;
                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Pause" for pausing capture
                    btnStart.Text = "Pause";
                    //Application.Idle += ProcessFrame;
                }

            }
        }

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }

        private void cbCamIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set the camera number to the one selected via combo box
            int CamNumber = 0;
            CamNumber = int.Parse(cbCamIndex.Text);

            //Start the selected camera
            #region if capture is not created, create it now
            if (capture == null)
            {
                try
                {
                    capture = new VideoCapture(CamNumber);
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            //Start showing the stream from camera
            btnStart_Click(sender, e); btnStart.Enabled = true;   //enable the button for pause/resume

            Savebutton.Enabled = true;
            btnStartProcess.Enabled = true;
            string natwidth = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth).ToString();
            string natheight = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight).ToString();
            CamProptextBox.Text = "Native Resolution: " + natwidth + " x " + natheight + "\r\nAutoCapture Resolution: " + natwidth + " x " + yband;
        }

        private string X_inc()
        {
            serialPort1.Open();  //open serialport
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            string WriteX = "#X!";  //write this specific line to arduino
            string SerialReplyx = "";
            serialPort1.Write(WriteX);
            //textBox4.Text = WriteX;
            SerialReplyx = serialPort1.ReadTo("!");
            //SerialReplyx = "#OKX";
            serialPort1.Close();
            return SerialReplyx; // This must change to "SerialReply"
        }

        private string Y_inc()
        {
            serialPort1.Open();
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            string WriteY = "#Y!";
            string SerialReplyy = "";
            serialPort1.Write(WriteY);
            //textBox4.Text = WriteY;
            SerialReplyy = serialPort1.ReadTo("!");
            //SerialReplyy = "#OKY";
            serialPort1.Close();
            return SerialReplyy; // This must change to "SerialReply"
        }

        private void btnIncX_Click(object sender, EventArgs e)
        {
            serialPort1.Open();  //open serialport
            string WriteX = "#R!";  //write this specific line to arduino
            string SerialReply = "";
            serialPort1.Write(WriteX);
            SerialReply = serialPort1.ReadTo("!");
            serialPort1.Close();
        }

        private void btnYInc_Click(object sender, EventArgs e)
        {
            serialPort1.Open();  //open serialport
            string WriteX = "#U!";  //write this specific line to arduino
            //string SerialReply = "";
            serialPort1.Write(WriteX);
            //SerialReply = serialPort1.ReadTo("!");
            serialPort1.Close();
        }

        private void btnStartProcess_Click(object sender, EventArgs e)
        {   //Here the complete process is run. Y for 320 step, X for 1 step, Y for 320 steps
            serialPort1.Open();
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            serialPort1.Close();

            textBox4.Text = "Running";
            Application.Idle -= ProcessFrame; //Pause the Main window

            int maxsteps = ycountmax * xcountmax;
            string smaxsteps = maxsteps.ToString();
            progressBar1.Maximum = maxsteps; //Set Maximum size of the progressbar
            string yreturnvalue = "";

            for (int ycount = 1; ycount <= ycountmax; ycount++)
            {
                for (int xcount = 1; xcount <= xcountmax; xcount++)
                {
                
                    //For each count we should:
                    //1. Take a photo
                    //2. Crop the photo
                    //3. Store the photo
                    //4. Send command to move an increment
                    //5. Wait for return value that motor has moved, if not then break the loop
                    //6. Repeat loop

                    //Step 1
                    Image<Rgb, Byte> frame1 = capture.QueryFrame().ToImage<Rgb, Byte>(); //For Gray image
                    
                    //Step 2
                    Rectangle rect = new Rectangle(xstart, ystart, xband, yband); //Determine ROI
                    frame1.ROI = rect; //Crop image
                                        
                    //Step 3
                    frame1.Save(savepath + "X" + xcount + "Y" + ycount + ".jpg");
                    textBox4.Text = "X" + xcount + "Y" + ycount;

                    //System.Threading.Thread.Sleep(2000);
                    //frame1.Dispose();

                    DialogResult dialogresult = MessageBox.Show("X:" + xcount + "   Y:" + ycount, "", MessageBoxButtons.YesNo);
                    if (dialogresult == DialogResult.Yes)
                    {;}
                    else
                    {break;}

                    //Step 4
                    yreturnvalue = Y_inc();

                    //Randomly update the progressbar
                    int currentstep = (xcount - 1) * ycountmax + ycount;
                    progressBar1.Value = currentstep;

                    //Clear garbage collection
                    GC.Collect(GC.MaxGeneration);
                    GC.WaitForPendingFinalizers();

                    //Step 5
                    if (yreturnvalue == "#OKY")
                    {;}
                    else
                    { break; }

                } //end ycount

                string xreturnvalue = X_inc();
                if (xreturnvalue == "#OKX")
                { ; }
                else
                {break;}

            } //end xcount

            textBox4.Text = "Stopped";
            Application.Idle += ProcessFrame; //Resume the Main window

        } //The main loop ends here
    
        private void button2_Click_1(object sender, EventArgs e)
        {
            SerialPortNumber = "COM1";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 5000;
        }

        private void btnSerial2_Click(object sender, EventArgs e)
        {
            SerialPortNumber = "COM2";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 5000;
        }

        private void btnSerial3_Click(object sender, EventArgs e)
        {
            SerialPortNumber = "COM3";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 15000;
            serialPort1.Open();
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            serialPort1.Close();

        }

        private void btnSerial4_Click(object sender, EventArgs e)
        {
            SerialPortNumber = "COM4";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 20000;
        }
       
        private void textBoxSavePath_TextChanged(object sender, EventArgs e)
        {
            //Update the text file to save the path where photos are to be saved
            string[] lines = { textBoxSavePath.Text };
            System.IO.File.WriteAllLines(@"C:\Users\Public\SavePath.txt", lines);
        }

        private void CamImageBox_Click(object sender, EventArgs e)
        {
            ;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            ;
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> frame = capture.QueryFrame().ToImage<Bgr, Byte>();
            frame = frame.Flip(Emgu.CV.CvEnum.FlipType.Vertical);
            //Un-comment below lines to crop image
            //Rectangle rect = new Rectangle(xstart, ystart, xband, yband); //Determine ROI
            //frame.ROI = rect; //Crop image

            //Draw a horisontal line on the image
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
                frame.Save(savepath + textBox1.Text + ".jpg");
                frame.Draw(xline, new Bgr(Color.Red), 20); //Make lines darker on the display screen
                frame.Draw(yline, new Bgr(Color.Red), 20);
                Camimagebox3.Image = frame;
            }
            else
            {
                frame.Save(savepath + textBox1.Text + ".jpg");
                Camimagebox3.Image = frame;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Idle += ProcessFrame;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            serialPort1.Open();
            int LEDBrightness = 0;
            LEDBrightness = 256 - vScrollBar1.Value - 24;
            textBox2.Text = LEDBrightness.ToString();
            string WriteB = "#B" + LEDBrightness.ToString("D3") +"!";
            serialPort1.Write(WriteB);
            serialPort1.Close();
            //textBoxSavePath.Text = WriteB;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Open();  //open serialport
            string WriteX = "#D!";  //write this specific line to arduino
            //string SerialReply = "";
            serialPort1.Write(WriteX);
            //SerialReply = serialPort1.ReadTo("!");
            serialPort1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Open();  //open serialport
            string WriteX = "#L!";  //write this specific line to arduino
            //string SerialReply = "";
            serialPort1.Write(WriteX);
            //SerialReply = serialPort1.ReadTo("!");
            serialPort1.Close();
        }
    }
}
