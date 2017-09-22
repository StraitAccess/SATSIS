namespace CameraCapture
{
    partial class CameraCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CamImageBox = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbCamIndex = new System.Windows.Forms.ComboBox();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnSerial = new System.Windows.Forms.Button();
            this.textBoxSerial = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBoxSerialReply = new System.Windows.Forms.TextBox();
            this.btnStartProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.btnCameraProperties = new System.Windows.Forms.Button();
            this.btnSerial1 = new System.Windows.Forms.Button();
            this.btnSerial2 = new System.Windows.Forms.Button();
            this.btnSerial4 = new System.Windows.Forms.Button();
            this.btnSerial3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CamImagebox2 = new Emgu.CV.UI.ImageBox();
            this.CamProptextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Camimagebox3 = new Emgu.CV.UI.ImageBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamImagebox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Camimagebox3)).BeginInit();
            this.SuspendLayout();
            // 
            // CamImageBox
            // 
            this.CamImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImageBox.Location = new System.Drawing.Point(184, 149);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(455, 365);
            this.CamImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CamImageBox.TabIndex = 2;
            this.CamImageBox.TabStop = false;
            this.CamImageBox.Click += new System.EventHandler(this.CamImageBox_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(54, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(751, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbCamIndex
            // 
            this.cbCamIndex.FormattingEnabled = true;
            this.cbCamIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cbCamIndex.Location = new System.Drawing.Point(283, 15);
            this.cbCamIndex.Name = "cbCamIndex";
            this.cbCamIndex.Size = new System.Drawing.Size(121, 21);
            this.cbCamIndex.TabIndex = 5;
            this.cbCamIndex.Text = "None";
            this.cbCamIndex.SelectedIndexChanged += new System.EventHandler(this.cbCamIndex_SelectedIndexChanged);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(66, 19);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(53, 23);
            this.btnSaveImage.TabIndex = 6;
            this.btnSaveImage.Text = "Save";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSerial
            // 
            this.btnSerial.Location = new System.Drawing.Point(12, 59);
            this.btnSerial.Name = "btnSerial";
            this.btnSerial.Size = new System.Drawing.Size(118, 23);
            this.btnSerial.TabIndex = 8;
            this.btnSerial.Text = "Check Serial Comms";
            this.btnSerial.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSerial.UseVisualStyleBackColor = true;
            this.btnSerial.Click += new System.EventHandler(this.btnSerial_Click);
            // 
            // textBoxSerial
            // 
            this.textBoxSerial.Location = new System.Drawing.Point(12, 88);
            this.textBoxSerial.Name = "textBoxSerial";
            this.textBoxSerial.Size = new System.Drawing.Size(100, 20);
            this.textBoxSerial.TabIndex = 9;
            // 
            // textBoxSerialReply
            // 
            this.textBoxSerialReply.Location = new System.Drawing.Point(12, 114);
            this.textBoxSerialReply.Name = "textBoxSerialReply";
            this.textBoxSerialReply.Size = new System.Drawing.Size(100, 20);
            this.textBoxSerialReply.TabIndex = 11;
            // 
            // btnStartProcess
            // 
            this.btnStartProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStartProcess.Location = new System.Drawing.Point(179, 59);
            this.btnStartProcess.Name = "btnStartProcess";
            this.btnStartProcess.Size = new System.Drawing.Size(84, 32);
            this.btnStartProcess.TabIndex = 17;
            this.btnStartProcess.Text = "Start!";
            this.btnStartProcess.UseVisualStyleBackColor = false;
            this.btnStartProcess.Click += new System.EventHandler(this.btnStartProcess_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Savepath (type it in)";
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(283, 40);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(225, 20);
            this.textBoxSavePath.TabIndex = 20;
            this.textBoxSavePath.TextChanged += new System.EventHandler(this.textBoxSavePath_TextChanged);
            // 
            // btnCameraProperties
            // 
            this.btnCameraProperties.Location = new System.Drawing.Point(660, 327);
            this.btnCameraProperties.Name = "btnCameraProperties";
            this.btnCameraProperties.Size = new System.Drawing.Size(148, 24);
            this.btnCameraProperties.TabIndex = 21;
            this.btnCameraProperties.Text = "GetCameraProperties";
            this.btnCameraProperties.UseVisualStyleBackColor = true;
            this.btnCameraProperties.Click += new System.EventHandler(this.btnCameraProperties_Click);
            // 
            // btnSerial1
            // 
            this.btnSerial1.Location = new System.Drawing.Point(12, 30);
            this.btnSerial1.Name = "btnSerial1";
            this.btnSerial1.Size = new System.Drawing.Size(15, 23);
            this.btnSerial1.TabIndex = 23;
            this.btnSerial1.Text = "1";
            this.btnSerial1.UseVisualStyleBackColor = true;
            this.btnSerial1.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnSerial2
            // 
            this.btnSerial2.Location = new System.Drawing.Point(29, 30);
            this.btnSerial2.Name = "btnSerial2";
            this.btnSerial2.Size = new System.Drawing.Size(15, 23);
            this.btnSerial2.TabIndex = 24;
            this.btnSerial2.Text = "2";
            this.btnSerial2.UseVisualStyleBackColor = true;
            this.btnSerial2.Click += new System.EventHandler(this.btnSerial2_Click);
            // 
            // btnSerial4
            // 
            this.btnSerial4.Location = new System.Drawing.Point(63, 30);
            this.btnSerial4.Name = "btnSerial4";
            this.btnSerial4.Size = new System.Drawing.Size(15, 23);
            this.btnSerial4.TabIndex = 26;
            this.btnSerial4.Text = "4";
            this.btnSerial4.UseVisualStyleBackColor = true;
            this.btnSerial4.Click += new System.EventHandler(this.btnSerial4_Click);
            // 
            // btnSerial3
            // 
            this.btnSerial3.Location = new System.Drawing.Point(46, 30);
            this.btnSerial3.Name = "btnSerial3";
            this.btnSerial3.Size = new System.Drawing.Size(15, 23);
            this.btnSerial3.TabIndex = 25;
            this.btnSerial3.Text = "3";
            this.btnSerial3.UseVisualStyleBackColor = true;
            this.btnSerial3.Click += new System.EventHandler(this.btnSerial3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.btnSaveImage);
            this.groupBox2.Location = new System.Drawing.Point(690, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 50);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera Testing";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Select Camera";
            // 
            // CamImagebox2
            // 
            this.CamImagebox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImagebox2.Location = new System.Drawing.Point(662, 145);
            this.CamImagebox2.Name = "CamImagebox2";
            this.CamImagebox2.Size = new System.Drawing.Size(93, 84);
            this.CamImagebox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CamImagebox2.TabIndex = 34;
            this.CamImagebox2.TabStop = false;
            // 
            // CamProptextbox
            // 
            this.CamProptextbox.Location = new System.Drawing.Point(662, 357);
            this.CamProptextbox.Multiline = true;
            this.CamProptextbox.Name = "CamProptextbox";
            this.CamProptextbox.Size = new System.Drawing.Size(171, 53);
            this.CamProptextbox.TabIndex = 35;
            this.CamProptextbox.TextChanged += new System.EventHandler(this.CamProptextbox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(692, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 9);
            this.label7.TabIndex = 36;
            this.label7.Text = "label7";
            // 
            // Camimagebox3
            // 
            this.Camimagebox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Camimagebox3.Location = new System.Drawing.Point(662, 235);
            this.Camimagebox3.Name = "Camimagebox3";
            this.Camimagebox3.Size = new System.Drawing.Size(93, 84);
            this.Camimagebox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Camimagebox3.TabIndex = 39;
            this.Camimagebox3.TabStop = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // CameraCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 514);
            this.Controls.Add(this.Camimagebox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CamProptextbox);
            this.Controls.Add(this.CamImagebox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSerial4);
            this.Controls.Add(this.btnSerial3);
            this.Controls.Add(this.btnSerial2);
            this.Controls.Add(this.btnSerial1);
            this.Controls.Add(this.btnCameraProperties);
            this.Controls.Add(this.textBoxSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStartProcess);
            this.Controls.Add(this.textBoxSerialReply);
            this.Controls.Add(this.textBoxSerial);
            this.Controls.Add(this.btnSerial);
            this.Controls.Add(this.cbCamIndex);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CamImageBox);
            this.Controls.Add(this.groupBox2);
            this.Name = "CameraCapture";
            this.Text = "Camera Output";
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CamImagebox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Camimagebox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbCamIndex;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnSerial;
        private System.Windows.Forms.TextBox textBoxSerial;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBoxSerialReply;
        private System.Windows.Forms.Button btnStartProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSavePath;
        private System.Windows.Forms.Button btnCameraProperties;
        private System.Windows.Forms.Button btnSerial1;
        private System.Windows.Forms.Button btnSerial2;
        private System.Windows.Forms.Button btnSerial4;
        private System.Windows.Forms.Button btnSerial3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private Emgu.CV.UI.ImageBox CamImagebox2;
        private System.Windows.Forms.TextBox CamProptextbox;
        private System.Windows.Forms.Label label7;
        private Emgu.CV.UI.ImageBox Camimagebox3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

