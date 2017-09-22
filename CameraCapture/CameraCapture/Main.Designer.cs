using Emgu.CV.UI;
namespace SATSISMain
{
    partial class SATSISMain
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Savebutton = new System.Windows.Forms.Button();
            this.FilenameTextbox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.btnXDownSmall = new System.Windows.Forms.Button();
            this.btnXUpSmall = new System.Windows.Forms.Button();
            this.btnYUpsmall = new System.Windows.Forms.Button();
            this.btnYDownSmall = new System.Windows.Forms.Button();
            this.Camimagebox3 = new Emgu.CV.UI.ImageBox();
            this.ManualImages = new System.Windows.Forms.GroupBox();
            this.FocusButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LOTtextBox = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.MovetoCalibbutton = new System.Windows.Forms.Button();
            this.OpenPythonbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Camimagebox3)).BeginInit();
            this.ManualImages.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // CamImageBox
            // 
            this.CamImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.CamImageBox.Location = new System.Drawing.Point(218, 6);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(600, 400);
            this.CamImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CamImageBox.TabIndex = 2;
            this.CamImageBox.TabStop = false;
            this.CamImageBox.Click += new System.EventHandler(this.CamImageBox_Click);
            this.CamImageBox.DoubleClick += new System.EventHandler(this.CamImageBox_DoubleClick);
            this.CamImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CamImageBox_MouseMove);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM0";
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(2, 43);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(57, 49);
            this.Savebutton.TabIndex = 43;
            this.Savebutton.Text = "Manual Save";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // FilenameTextbox
            // 
            this.FilenameTextbox.Location = new System.Drawing.Point(3, 17);
            this.FilenameTextbox.Name = "FilenameTextbox";
            this.FilenameTextbox.Size = new System.Drawing.Size(166, 20);
            this.FilenameTextbox.TabIndex = 44;
            this.FilenameTextbox.Text = "Enter file name";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(238, 53);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(72, 23);
            this.progressBar1.TabIndex = 45;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(67, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 23);
            this.button2.TabIndex = 47;
            this.button2.Text = "Y++";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnYInc_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(67, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 23);
            this.button3.TabIndex = 48;
            this.button3.Text = "Y- -";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(130, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "X++";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnIncX_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "X- -";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(52, 17);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.Text = "Line?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(163, 54);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 20);
            this.textBox4.TabIndex = 56;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(20, 53);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(137, 23);
            this.button8.TabIndex = 58;
            this.button8.Text = "Start";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.StartTimer);
            // 
            // btnXDownSmall
            // 
            this.btnXDownSmall.Location = new System.Drawing.Point(36, 67);
            this.btnXDownSmall.Name = "btnXDownSmall";
            this.btnXDownSmall.Size = new System.Drawing.Size(29, 23);
            this.btnXDownSmall.TabIndex = 61;
            this.btnXDownSmall.Text = "X-";
            this.btnXDownSmall.UseVisualStyleBackColor = true;
            this.btnXDownSmall.Click += new System.EventHandler(this.btnXDownSmall_Click);
            // 
            // btnXUpSmall
            // 
            this.btnXUpSmall.Location = new System.Drawing.Point(102, 67);
            this.btnXUpSmall.Name = "btnXUpSmall";
            this.btnXUpSmall.Size = new System.Drawing.Size(28, 23);
            this.btnXUpSmall.TabIndex = 62;
            this.btnXUpSmall.Text = "X+";
            this.btnXUpSmall.UseVisualStyleBackColor = true;
            this.btnXUpSmall.Click += new System.EventHandler(this.btnXUpSmall_Click);
            // 
            // btnYUpsmall
            // 
            this.btnYUpsmall.Location = new System.Drawing.Point(69, 44);
            this.btnYUpsmall.Name = "btnYUpsmall";
            this.btnYUpsmall.Size = new System.Drawing.Size(30, 23);
            this.btnYUpsmall.TabIndex = 63;
            this.btnYUpsmall.Text = "Y+";
            this.btnYUpsmall.UseVisualStyleBackColor = true;
            this.btnYUpsmall.Click += new System.EventHandler(this.btnYUpsmall_Click);
            // 
            // btnYDownSmall
            // 
            this.btnYDownSmall.Location = new System.Drawing.Point(69, 92);
            this.btnYDownSmall.Name = "btnYDownSmall";
            this.btnYDownSmall.Size = new System.Drawing.Size(30, 23);
            this.btnYDownSmall.TabIndex = 64;
            this.btnYDownSmall.Text = "Y-";
            this.btnYDownSmall.UseVisualStyleBackColor = true;
            this.btnYDownSmall.Click += new System.EventHandler(this.btnYDownSmall_Click);
            // 
            // Camimagebox3
            // 
            this.Camimagebox3.Location = new System.Drawing.Point(60, 43);
            this.Camimagebox3.Name = "Camimagebox3";
            this.Camimagebox3.Size = new System.Drawing.Size(118, 79);
            this.Camimagebox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Camimagebox3.TabIndex = 2;
            this.Camimagebox3.TabStop = false;
            // 
            // ManualImages
            // 
            this.ManualImages.Controls.Add(this.Savebutton);
            this.ManualImages.Controls.Add(this.checkBox1);
            this.ManualImages.Controls.Add(this.FilenameTextbox);
            this.ManualImages.Controls.Add(this.Camimagebox3);
            this.ManualImages.Location = new System.Drawing.Point(12, 91);
            this.ManualImages.Name = "ManualImages";
            this.ManualImages.Size = new System.Drawing.Size(184, 133);
            this.ManualImages.TabIndex = 71;
            this.ManualImages.TabStop = false;
            this.ManualImages.Text = "Manual Image Saving";
            // 
            // FocusButton
            // 
            this.FocusButton.Location = new System.Drawing.Point(7, 27);
            this.FocusButton.Name = "FocusButton";
            this.FocusButton.Size = new System.Drawing.Size(70, 39);
            this.FocusButton.TabIndex = 77;
            this.FocusButton.Text = "Re-focus";
            this.FocusButton.UseVisualStyleBackColor = true;
            this.FocusButton.Click += new System.EventHandler(this.FocusButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.hScrollBar2);
            this.groupBox1.Controls.Add(this.hScrollBar1);
            this.groupBox1.Location = new System.Drawing.Point(12, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 100);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lighting";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(144, 73);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(35, 20);
            this.textBox5.TabIndex = 76;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(144, 31);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 20);
            this.textBox3.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Back Lighting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Front Lighting";
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.LargeChange = 25;
            this.hScrollBar2.Location = new System.Drawing.Point(6, 76);
            this.hScrollBar2.Maximum = 256;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(132, 17);
            this.hScrollBar2.TabIndex = 1;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Enabled = false;
            this.hScrollBar1.LargeChange = 25;
            this.hScrollBar1.Location = new System.Drawing.Point(5, 34);
            this.hScrollBar1.Maximum = 256;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(133, 17);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.btnXDownSmall);
            this.groupBox2.Controls.Add(this.btnXUpSmall);
            this.groupBox2.Controls.Add(this.btnYUpsmall);
            this.groupBox2.Controls.Add(this.btnYDownSmall);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 146);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Movement";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(107, 102);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(59, 39);
            this.button9.TabIndex = 79;
            this.button9.Text = "Right 10mm";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_2);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(2, 102);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(59, 39);
            this.button6.TabIndex = 78;
            this.button6.Text = "Left 10mm";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 74;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calibrationToolStripMenuItem
            // 
            this.calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            this.calibrationToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.calibrationToolStripMenuItem.Text = "Setup";
            this.calibrationToolStripMenuItem.Click += new System.EventHandler(this.calibrationToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.LOTtextBox);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Location = new System.Drawing.Point(220, 412);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 85);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Main Process";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(249, 20);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(48, 23);
            this.button12.TabIndex = 61;
            this.button12.Text = "Reset";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "LOT#:";
            // 
            // LOTtextBox
            // 
            this.LOTtextBox.Location = new System.Drawing.Point(57, 20);
            this.LOTtextBox.Name = "LOTtextBox";
            this.LOTtextBox.Size = new System.Drawing.Size(175, 20);
            this.LOTtextBox.TabIndex = 59;
            this.LOTtextBox.Text = "A001/00/00";
            this.LOTtextBox.TextChanged += new System.EventHandler(this.LOTtextBox_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(67, 13);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(35, 20);
            this.textBox6.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Pixels/mm";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.MovetoCalibbutton);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Location = new System.Drawing.Point(553, 412);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 85);
            this.groupBox4.TabIndex = 76;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calibration";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(108, 15);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(58, 17);
            this.checkBox2.TabIndex = 72;
            this.checkBox2.Text = "unlock";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(120, 39);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 37);
            this.button11.TabIndex = 71;
            this.button11.Text = "Z-";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(9, 39);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 37);
            this.button10.TabIndex = 70;
            this.button10.Text = "Z+";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // MovetoCalibbutton
            // 
            this.MovetoCalibbutton.Location = new System.Drawing.Point(62, 39);
            this.MovetoCalibbutton.Name = "MovetoCalibbutton";
            this.MovetoCalibbutton.Size = new System.Drawing.Size(52, 37);
            this.MovetoCalibbutton.TabIndex = 69;
            this.MovetoCalibbutton.Text = "Calib Pos";
            this.MovetoCalibbutton.UseVisualStyleBackColor = true;
            this.MovetoCalibbutton.Click += new System.EventHandler(this.MovetoCalibbutton_Click);
            // 
            // OpenPythonbutton
            // 
            this.OpenPythonbutton.Location = new System.Drawing.Point(725, 451);
            this.OpenPythonbutton.Name = "OpenPythonbutton";
            this.OpenPythonbutton.Size = new System.Drawing.Size(100, 26);
            this.OpenPythonbutton.TabIndex = 78;
            this.OpenPythonbutton.Text = "Run Python Code";
            this.OpenPythonbutton.UseVisualStyleBackColor = true;
            this.OpenPythonbutton.Click += new System.EventHandler(this.OpenPythonbutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(725, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 80;
            this.button1.Text = "Rerun Stitch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SATSISMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 509);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FocusButton);
            this.Controls.Add(this.OpenPythonbutton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ManualImages);
            this.Controls.Add(this.CamImageBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SATSISMain";
            this.Text = "SATSIS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SATSISMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Camimagebox3)).EndInit();
            this.ManualImages.ResumeLayout(false);
            this.ManualImages.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.TextBox FilenameTextbox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnXDownSmall;
        private System.Windows.Forms.Button btnXUpSmall;
        private System.Windows.Forms.Button btnYUpsmall;
        private System.Windows.Forms.Button btnYDownSmall;
        private Emgu.CV.UI.ImageBox Camimagebox3;
        private System.Windows.Forms.GroupBox ManualImages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button FocusButton;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LOTtextBox;
        private System.Windows.Forms.Button MovetoCalibbutton;
        private System.Windows.Forms.Button OpenPythonbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button12;
    }
}

