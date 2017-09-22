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
            this.button1 = new System.Windows.Forms.Button();
            this.cbCamIndex = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnStartProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.btnSerial1 = new System.Windows.Forms.Button();
            this.btnSerial2 = new System.Windows.Forms.Button();
            this.btnSerial4 = new System.Windows.Forms.Button();
            this.btnSerial3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Camimagebox3 = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CamProptextBox = new System.Windows.Forms.TextBox();
            this.Savebutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Camimagebox3)).BeginInit();
            this.SuspendLayout();
            // 
            // CamImageBox
            // 
            this.CamImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImageBox.Location = new System.Drawing.Point(232, 12);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(600, 400);
            this.CamImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CamImageBox.TabIndex = 2;
            this.CamImageBox.TabStop = false;
            this.CamImageBox.Click += new System.EventHandler(this.CamImageBox_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(747, 431);
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
            this.cbCamIndex.Location = new System.Drawing.Point(97, 51);
            this.cbCamIndex.Name = "cbCamIndex";
            this.cbCamIndex.Size = new System.Drawing.Size(60, 21);
            this.cbCamIndex.TabIndex = 5;
            this.cbCamIndex.Text = "None";
            this.cbCamIndex.SelectedIndexChanged += new System.EventHandler(this.cbCamIndex_SelectedIndexChanged);
            // 
            // btnStartProcess
            // 
            this.btnStartProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStartProcess.Location = new System.Drawing.Point(309, 418);
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
            this.label2.Location = new System.Drawing.Point(8, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Savepath";
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(67, 134);
            this.textBoxSavePath.Multiline = true;
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(145, 49);
            this.textBoxSavePath.TabIndex = 20;
            this.textBoxSavePath.TextChanged += new System.EventHandler(this.textBoxSavePath_TextChanged);
            // 
            // btnSerial1
            // 
            this.btnSerial1.Location = new System.Drawing.Point(97, 12);
            this.btnSerial1.Name = "btnSerial1";
            this.btnSerial1.Size = new System.Drawing.Size(15, 23);
            this.btnSerial1.TabIndex = 23;
            this.btnSerial1.Text = "1";
            this.btnSerial1.UseVisualStyleBackColor = true;
            this.btnSerial1.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnSerial2
            // 
            this.btnSerial2.Location = new System.Drawing.Point(112, 12);
            this.btnSerial2.Name = "btnSerial2";
            this.btnSerial2.Size = new System.Drawing.Size(15, 23);
            this.btnSerial2.TabIndex = 24;
            this.btnSerial2.Text = "2";
            this.btnSerial2.UseVisualStyleBackColor = true;
            this.btnSerial2.Click += new System.EventHandler(this.btnSerial2_Click);
            // 
            // btnSerial4
            // 
            this.btnSerial4.Location = new System.Drawing.Point(142, 12);
            this.btnSerial4.Name = "btnSerial4";
            this.btnSerial4.Size = new System.Drawing.Size(15, 23);
            this.btnSerial4.TabIndex = 26;
            this.btnSerial4.Text = "4";
            this.btnSerial4.UseVisualStyleBackColor = true;
            this.btnSerial4.Click += new System.EventHandler(this.btnSerial4_Click);
            // 
            // btnSerial3
            // 
            this.btnSerial3.Location = new System.Drawing.Point(127, 12);
            this.btnSerial3.Name = "btnSerial3";
            this.btnSerial3.Size = new System.Drawing.Size(15, 23);
            this.btnSerial3.TabIndex = 25;
            this.btnSerial3.Text = "3";
            this.btnSerial3.UseVisualStyleBackColor = true;
            this.btnSerial3.Click += new System.EventHandler(this.btnSerial3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Select Camera";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(694, 496);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 9);
            this.label7.TabIndex = 36;
            this.label7.Text = "label7";
            // 
            // Camimagebox3
            // 
            this.Camimagebox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Camimagebox3.Location = new System.Drawing.Point(34, 244);
            this.Camimagebox3.Name = "Camimagebox3";
            this.Camimagebox3.Size = new System.Drawing.Size(150, 100);
            this.Camimagebox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Camimagebox3.TabIndex = 39;
            this.Camimagebox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Select COM Port:";
            // 
            // CamProptextBox
            // 
            this.CamProptextBox.Location = new System.Drawing.Point(18, 78);
            this.CamProptextBox.Multiline = true;
            this.CamProptextBox.Name = "CamProptextBox";
            this.CamProptextBox.Size = new System.Drawing.Size(208, 41);
            this.CamProptextBox.TabIndex = 42;
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(11, 189);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(108, 23);
            this.Savebutton.TabIndex = 43;
            this.Savebutton.Text = "Manual Save";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 218);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 44;
            this.textBox1.Text = "Enter file name";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(410, 422);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(140, 23);
            this.progressBar1.TabIndex = 45;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(666, 431);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 46;
            this.btnStart.Text = "button2";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(67, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 47;
            this.button2.Text = "Y+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnYInc_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(67, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 23);
            this.button3.TabIndex = 48;
            this.button3.Text = "Y-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(96, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "X+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnIncX_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(38, 398);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "X-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(163, 51);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 23);
            this.button6.TabIndex = 51;
            this.button6.Text = "Show";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.LargeChange = 25;
            this.vScrollBar1.Location = new System.Drawing.Point(211, 212);
            this.vScrollBar1.Maximum = 256;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 200);
            this.vScrollBar1.TabIndex = 52;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(195, 421);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(46, 20);
            this.textBox2.TabIndex = 53;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(140, 192);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 17);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.Text = "Red Line";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(248, 482);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 55;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(426, 451);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 56;
            // 
            // CameraCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 514);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.CamProptextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Camimagebox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSerial4);
            this.Controls.Add(this.btnSerial3);
            this.Controls.Add(this.btnSerial2);
            this.Controls.Add(this.btnSerial1);
            this.Controls.Add(this.textBoxSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStartProcess);
            this.Controls.Add(this.cbCamIndex);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CamImageBox);
            this.Name = "CameraCapture";
            this.Text = "Camera Output";
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Camimagebox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbCamIndex;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnStartProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSavePath;
        private System.Windows.Forms.Button btnSerial1;
        private System.Windows.Forms.Button btnSerial2;
        private System.Windows.Forms.Button btnSerial4;
        private System.Windows.Forms.Button btnSerial3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private Emgu.CV.UI.ImageBox Camimagebox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CamProptextBox;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}

