namespace WindowsFormsApp1
{
    partial class Form1
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
            this.capture = new System.Windows.Forms.Button();
            this.imgFrame = new Emgu.CV.UI.ImageBox();
            this.name = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.imgCapture = new Emgu.CV.UI.ImageBox();
            this.save = new System.Windows.Forms.Button();
            this.detection = new System.Windows.Forms.Button();
            this.recognition = new System.Windows.Forms.Button();
            this.cameraBox = new System.Windows.Forms.ComboBox();
            this.RecognitionType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.alertMessage = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pcCPU = new System.Diagnostics.PerformanceCounter();
            this.pcRAM = new System.Diagnostics.PerformanceCounter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRAM = new System.Windows.Forms.Label();
            this.lblCPU = new System.Windows.Forms.Label();
            this.pbRAM = new System.Windows.Forms.ProgressBar();
            this.pbCPU = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRAM)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // capture
            // 
            this.capture.Location = new System.Drawing.Point(153, 274);
            this.capture.Name = "capture";
            this.capture.Size = new System.Drawing.Size(101, 31);
            this.capture.TabIndex = 2;
            this.capture.Text = "Capture";
            this.capture.UseVisualStyleBackColor = true;
            this.capture.Click += new System.EventHandler(this.Capture_Click);
            // 
            // imgFrame
            // 
            this.imgFrame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.imgFrame.Location = new System.Drawing.Point(12, 63);
            this.imgFrame.Name = "imgFrame";
            this.imgFrame.Size = new System.Drawing.Size(450, 420);
            this.imgFrame.TabIndex = 2;
            this.imgFrame.TabStop = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(59, 37);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(32, 24);
            this.name.TabIndex = 3;
            this.name.Text = "ชื่อ";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(107, 41);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(213, 22);
            this.textName.TabIndex = 4;
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(342, 489);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(120, 32);
            this.start.TabIndex = 5;
            this.start.Text = "Start Camera";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // imgCapture
            // 
            this.imgCapture.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imgCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture.Location = new System.Drawing.Point(123, 90);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(150, 150);
            this.imgCapture.TabIndex = 2;
            this.imgCapture.TabStop = false;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(260, 274);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(101, 31);
            this.save.TabIndex = 6;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // detection
            // 
            this.detection.Location = new System.Drawing.Point(21, 273);
            this.detection.Name = "detection";
            this.detection.Size = new System.Drawing.Size(126, 32);
            this.detection.TabIndex = 7;
            this.detection.Text = "Face Detecion";
            this.detection.UseVisualStyleBackColor = true;
            this.detection.Click += new System.EventHandler(this.Detection_Click);
            // 
            // recognition
            // 
            this.recognition.Location = new System.Drawing.Point(167, 75);
            this.recognition.Name = "recognition";
            this.recognition.Size = new System.Drawing.Size(153, 32);
            this.recognition.TabIndex = 8;
            this.recognition.Text = "Face Recognition";
            this.recognition.UseVisualStyleBackColor = true;
            this.recognition.Click += new System.EventHandler(this.Recognition_Click);
            // 
            // cameraBox
            // 
            this.cameraBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraBox.FormattingEnabled = true;
            this.cameraBox.Items.AddRange(new object[] {
            "กล้อง Camera",
            "กล้อง Samsung IP Camers"});
            this.cameraBox.Location = new System.Drawing.Point(106, 496);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(217, 21);
            this.cameraBox.TabIndex = 9;
            this.cameraBox.Text = "เลือกกล้อง";
            this.cameraBox.SelectedIndexChanged += new System.EventHandler(this.CameraBox_SelectedIndexChanged);
            // 
            // RecognitionType
            // 
            this.RecognitionType.FormattingEnabled = true;
            this.RecognitionType.Items.AddRange(new object[] {
            "EigenFaces",
            "FisherFaces",
            "LBPHFaces"});
            this.RecognitionType.Location = new System.Drawing.Point(63, 35);
            this.RecognitionType.Name = "RecognitionType";
            this.RecognitionType.Size = new System.Drawing.Size(257, 24);
            this.RecognitionType.TabIndex = 11;
            this.RecognitionType.Text = "เลือก Algorithm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.detection);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.imgCapture);
            this.groupBox1.Controls.Add(this.capture);
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(481, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 338);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "บันทึกการตรวจจับใบหน้า";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.recognition);
            this.groupBox2.Controls.Add(this.RecognitionType);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(481, 398);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 123);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "การรู้จำใบหน้า";
            // 
            // alertMessage
            // 
            this.alertMessage.Location = new System.Drawing.Point(12, 547);
            this.alertMessage.Name = "alertMessage";
            this.alertMessage.Size = new System.Drawing.Size(450, 150);
            this.alertMessage.TabIndex = 14;
            this.alertMessage.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pcCPU
            // 
            this.pcCPU.CategoryName = "Processor";
            this.pcCPU.CounterName = "% Processor Time";
            this.pcCPU.InstanceName = "_Total";
            // 
            // pcRAM
            // 
            this.pcRAM.CategoryName = "Memory";
            this.pcRAM.CounterName = "% Committed Bytes in Use";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRAM);
            this.groupBox3.Controls.Add(this.lblCPU);
            this.groupBox3.Controls.Add(this.pbRAM);
            this.groupBox3.Controls.Add(this.pbCPU);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(481, 538);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 159);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Monitor";
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(345, 89);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(16, 16);
            this.lblRAM.TabIndex = 5;
            this.lblRAM.Text = "0";
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(345, 53);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(16, 16);
            this.lblCPU.TabIndex = 4;
            this.lblCPU.Text = "0";
            // 
            // pbRAM
            // 
            this.pbRAM.Location = new System.Drawing.Point(107, 89);
            this.pbRAM.Name = "pbRAM";
            this.pbRAM.Size = new System.Drawing.Size(232, 23);
            this.pbRAM.TabIndex = 3;
            // 
            // pbCPU
            // 
            this.pbCPU.Location = new System.Drawing.Point(107, 43);
            this.pbCPU.Name = "pbCPU";
            this.pbCPU.Size = new System.Drawing.Size(232, 23);
            this.pbCPU.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "RAM Usage :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU Usage :";
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "แจ้งเตือน";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 706);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.alertMessage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cameraBox);
            this.Controls.Add(this.start);
            this.Controls.Add(this.imgFrame);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Face Detection";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRAM)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button capture;
        private Emgu.CV.UI.ImageBox imgFrame;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button start;
        private Emgu.CV.UI.ImageBox imgCapture;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button detection;
        private System.Windows.Forms.Button recognition;
        private System.Windows.Forms.ComboBox cameraBox;
        private System.Windows.Forms.ComboBox RecognitionType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox alertMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Diagnostics.PerformanceCounter pcCPU;
        private System.Diagnostics.PerformanceCounter pcRAM;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbRAM;
        private System.Windows.Forms.ProgressBar pbCPU;
        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label3;
    }
}

