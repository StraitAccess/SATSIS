using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using ToupTek;
using System.Drawing.Imaging;


namespace CameraCapture
{
    public partial class CameraCapture : Form
    {
        //declaring global variables
        private VideoCapture capture;        //takes images from camera as image frames, "VideoCapture" changed
        string SerialPortNumber = "0";
        string text = "";
        string savepath = "";

       
        public CameraCapture()
        {
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

    }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame().ToImage<Bgr, Byte>();
            ImageFrame = ImageFrame.Resize(600,400, Emgu.CV.CvEnum.Inter.Cubic);
            CamImageBox.Image = ImageFrame;

            //Draw a horisontal line on the image
            Point xlinestart = new Point(0,1643);
            Point xlineend = new Point(4096,1643);
            LineSegment2D xline = new LineSegment2D(xlinestart, xlineend);
            Point ylinestart = new Point(2048, 0);
            Point ylineend = new Point(2048, 3286);
            LineSegment2D yline = new LineSegment2D(ylinestart, ylineend);
            ImageFrame.Draw(xline, new Bgr(Color.Red), 3);
            ImageFrame.Draw(yline, new Bgr(Color.Red), 3);

            int width = 400;
            int height = 400;
            int xstart = 2048;
            int ystart = width / 2 - height / 2; ;
            Image<Bgr, Byte> frame = capture.QueryFrame().ToImage<Bgr, Byte>();
            Rectangle rect = new Rectangle(xstart, ystart, width, height); //Determine ROI
            frame.ROI = rect; //Crop image
            Camimagebox3.Image = frame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        //btnStart_Click() function is the one that handles our "Start!" button' click 
        //event. it creates a new capture object if its not created already. e.g at first time
        //starting. once the capture is created, it checks if the capture is still in progress,
        //if so the

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                if (btnStart.Text == "Pause")
                {  //if camera is getting frames then pause the capture and set button Text to
                    // "Resume" for resuming capture
                    btnStart.Text = "Resume"; //
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Pause" for pausing capture
                    btnStart.Text = "Pause";
                    Application.Idle += ProcessFrame;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // want to save the image here
            Image<Gray, Byte> frame1 = capture.QueryFrame().ToImage<Gray, Byte>();
            Rectangle rect = new Rectangle(240, 320, 240, 320); // set the roi
            //frame1.ROI = rect; //Crop image
            frame1.Save(@"C:\Users\SAT-Wesley\Desktop\Camera program\1.jpg");
            CamImagebox2.Image = frame1;
    }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SerialPortNumber = "COM1";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 5000;
            textBoxSerial.Text = serialPort1.PortName;
        }
        
        private void btnSerial_Click(object sender, EventArgs e)
        {
            //When the serial port is chosen, all serialport properties are set
            //serialPort1.ReadTimeout = 2000;
            serialPort1.Open();
            string SerialStart = "#X!";
            string SerialReply = "";
            textBoxSerial.Text = SerialStart;
            serialPort1.Write(SerialStart);
            SerialReply = serialPort1.ReadTo("!");
            textBoxSerialReply.Text = SerialReply;
            serialPort1.Close();
         }

        private string X_inc()
        {
            serialPort1.Open();
            string WriteX = "#X!";
            string SerialReply = "#OK";
            serialPort1.Write(WriteX);
            SerialReply = serialPort1.ReadTo("!");
            serialPort1.Close();
            return textBoxSerial.Text = SerialReply; // This must change to "SerialReply"
        }

        private string Y_inc()
        {
            serialPort1.Open();
            string WriteY = "#Y!";
            string SerialReply = "#OK";
            serialPort1.Write(WriteY);
            SerialReply = serialPort1.ReadTo("!");
            serialPort1.Close();
            return textBoxSerial.Text = SerialReply; // This must change to "SerialReply"
        }

        private void ZU_inc()
        {
            serialPort1.Open();
            string WriteZ = "#U!";
            serialPort1.Write(WriteZ);
            textBoxSerial.Text = WriteZ;
            serialPort1.Close();
        }

        private void ZD_Inc()
        {
            serialPort1.Open();
            string WriteZ = "#D!";
            serialPort1.Write(WriteZ);
            textBoxSerial.Text = WriteZ;
            serialPort1.Close();
        }

        private void btnIncX_Click(object sender, EventArgs e)
        {
            X_inc();
        }

        private void btnYInc_Click(object sender, EventArgs e)
        {
            Y_inc();
        }

        private void btnZU_Click(object sender, EventArgs e)
        {
            ZU_inc();
        }

        private void btnZD_Click(object sender, EventArgs e)
        {
            ZD_Inc();
        }

        private void btnStartProcess_Click(object sender, EventArgs e)
        {   //Here the complete process is run. Y for 320 step, X for 1 step, Y for 320 steps
            //string savepath = textBoxSavePath.Text;

            int ycount = 0;
            int xcount = 0;
            int ycountmax = 320;
            int xcountmax = 2;
            string yreturnvalue = "";
            string xreturnvalue = "";

            //Set the region of interest size by pixels
            int width = 4096; //set this, native is 4096x3286
            int height = 40; //set this
            int xstart = 0;
            int ystart = width / 2 - height / 2; ;
            Rectangle rect = new Rectangle(xstart, ystart, width, height); //Determine ROI

            for (xcount = 0; xcount < xcountmax; xcount++)
            {
                for (ycount = 0; ycount < ycountmax; ycount++)
                {
                    //For each count we should:
                    //1. Take a photo
                    //2. Crop the photo
                    //3. Store the photo
                    //4. Send command to move an increment
                    //5. Wait for return value that motor has moved, if not then break
                    //6. Repeat loop


                    //Step 1
                    //This step should ideally be done outside of the loop, along with the cropping ROI
                    
                    //old method
                    //Mat frame = new Mat();
                    //capture.Retrieve(frame, 0);
                    //imageBox1.Image = frame; 

                    //new method
                    Image<Gray, Byte> frame1 = capture.QueryFrame().ToImage<Gray, Byte>();
                    Image<Gray, Byte> frame2 = capture.QueryFrame().ToImage<Gray, Byte>();
                    
                    //Step 2
                    frame1.ROI = rect; //Crop image

                    //Step 3
                    frame1.Save(savepath + "X" + xcount + "Y" + ycount + ".jpg");
                    CamImageBox.Image = frame1;
                    CamImagebox2.Image = frame2;
                    string stepphoto = "X" + xcount + "Y" + ycount;
                    //SteptextBox.Text = stepphoto.ToString();


                    //Step 4
                    yreturnvalue = Y_inc();

                    //Step 5
                    if (yreturnvalue == "#OK")
                    {;}
                    else
                    {break;}
                    
                } //end ycount
                xreturnvalue = X_inc();
                if (xreturnvalue == "#OK")
                {;}
                else
                {break;}
            } //end xcount
        } //The main loop

        private void btnCameraProperties_Click(object sender, EventArgs e)
        {
            
            Image<Rgb, Byte> frame1 = capture.QueryFrame().ToImage<Rgb, Byte>();
            Image<Rgb, Byte> frame2 = capture.QueryFrame().ToImage<Rgb, Byte>();
            int width = 4096;
            int height = 200;
            int xstart = 0;
            int ystart = width / 2 - height / 2; ;
            Rectangle rect = new Rectangle(xstart, ystart, width, height); //Determine ROI
            frame1.ROI = rect; //Crop image
            CamImagebox2.Image = frame1;
            frame1.Save(savepath + "TestPhoto.jpg");

            
            string camexposure = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure).ToString();
            string camautoexp = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.AutoExposure).ToString();
            string camfps = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps).ToString();
            string camtemp = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Temperature).ToString();
            string camiso = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.IsoSpeed).ToString();
            string cambright = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness).ToString();
            string camsatu = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Staturation).ToString();
            string camsettings = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Settings).ToString();
            string camsharp = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Sharpness).ToString();
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure,)

            //frame1.Save(@"C:\Users\SAT-Wesley\Desktop\New folder\Photo.jpg");
            CamProptextbox.Text = "Native Res:" + frame2.Width.ToString() + "x" + frame2.Height.ToString() + "...Cropped Res:" + frame1.Width.ToString() + "x" + frame1.Height.ToString() + "...YStart" + ystart + "...Exposure:" + camexposure + "...FSP" + camfps + "...Temp" + camtemp + "...ISO:"+camiso;
            MessageBox.Show("Native Res: " + frame2.Width.ToString() + "x" + frame2.Height.ToString() + "\nCropped Res: " + frame1.Width.ToString() + "x" + frame1.Height.ToString() + "\nYStart " + ystart + "\nExposure: " + camexposure + "\nFSP: " + camfps + "\nISO: " + camiso + "\nAutoExposure" + camautoexp + "\nBrightness: " + cambright + "\nSaturation: " + camsatu + "\nSettings: " + camsettings + "\nSharpness: " + camsharp);
        }

        private void btnSerial2_Click(object sender, EventArgs e)
        {
            SerialPortNumber = "COM2";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 5000;
            textBoxSerial.Text = serialPort1.PortName;
        }

        private void btnSerial3_Click(object sender, EventArgs e)
        {
            SerialPortNumber = "COM3";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 5000;
            textBoxSerial.Text = serialPort1.PortName;
        }

        private void btnSerial4_Click(object sender, EventArgs e)
        {
            SerialPortNumber = "COM4";
            serialPort1.PortName = SerialPortNumber;
            serialPort1.ReadTimeout = 5000;
            textBoxSerial.Text = serialPort1.PortName;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CamProptextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            string Brightness = "#L";
            //int scrollbarvalue = vScrollBar1.Value;
            //scrollbarvalue = Math.Abs(scrollbarvalue);
            //Brightness = Brightness + scrollbarvalue.ToString("D3") + "!";
            //textBoxBrightness.Text = Brightness;
            serialPort1.Open();
            serialPort1.Write(Brightness);
            serialPort1.Close();
        }

        private void textBoxSavePath_TextChanged(object sender, EventArgs e)
        {
            string[] lines = { textBoxSavePath.Text };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\Users\Public\SavePath.txt", lines);


        }
   
        private void CamImageBox_Click(object sender, EventArgs e)
        {
            ;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness, 50);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Staturation, 10);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.IsoSpeed, 100);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Sharpness, -100000);

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
