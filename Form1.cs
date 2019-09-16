using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        Capture _capture;
        Image<Bgr, byte> Frame;
        Image<Bgr, byte> FaceForSave = null;
        Image<Gray, byte> grayFrame = null;
        CascadeClassifier cascadeClassifier;
        FontFace font = new FontFace();

        EigenFaceRecognizer eigenFaceRecognizer;
        FisherFaceRecognizer fisherFaceRecognizer;
        LBPHFaceRecognizer lbphFaceRecognizer;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> nameLabels = new List<string>();
        List<int> indexLabels = new List<int>();
        int Count, NumLables;

        string alert;
        int cameraType;
        Boolean captureStatus = true;
        Boolean FaceDetectionStatus = false;
        Boolean FaceRecognitionStatus = false;

        int imgBoxH ;
        int imgBoxW ;
        int frameH,frameW;

        public Form1()
        {
            InitializeComponent();
            cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt_tree.xml");
            
        }

        private void streaming(object sender,System.EventArgs e)
        {
            Frame = _capture.QueryFrame().ToImage<Bgr, byte>();
            if(Frame.Height/4 <= 200 || Frame.Width/4 <=200)
            {
                frameH = imgBoxH;
                frameW = imgBoxW;
            }
            else
            {
                frameH = Frame.Height / 4;
                frameW = Frame.Width / 4;
            }
            var frame = Frame.Resize(imgBoxW, imgBoxH, Inter.Cubic);
            
            imgFrame.Image = frame;
        }

        private void Capture_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (FaceDetectionStatus != true)
                {
                    MessageBox.Show("กด Face Detection เพื่อค้นหาตำแหน่งหน้าก่อน");
                }
                else
                {
                    Frame = _capture.QueryFrame().ToImage<Bgr, byte>();
                    var frame = Frame.Resize(frameW, frameH, Inter.Cubic);
                    grayFrame = frame.Convert<Gray, Byte>();
                    var faces = cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 10,  Size.Empty);
                    foreach (var f in faces)
                    {
                        FaceForSave = frame.Copy(f).Convert<Bgr, Byte>().Resize(150, 150, Inter.Cubic);
                    }

                    imgCapture.Image = FaceForSave;
                    alertMessage.AppendText(alert + " Capture สำเร็จ\r\n");
                }

            }
            else
            {
                MessageBox.Show("กด Start เพื่อเริ่มการทำงานกล้อง");

            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (imgCapture.Image != null)
            {
                if (textName.Text != "")
                {
                    Count = Count + 1;
                    trainingImages.Add(FaceForSave.Convert<Gray, byte>().Resize(100, 100, Inter.Cubic));
                    nameLabels.Add(textName.Text);
                    File.WriteAllText(Application.StartupPath + "/Faces/Faces.txt", trainingImages.ToArray().Length.ToString() + ",");
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/" + textName.Text + ".bmp");
                        File.AppendAllText(Application.StartupPath + "/Faces/Faces.txt", nameLabels.ToArray()[i - 1] + ",");

                    }
                    alertMessage.AppendText(alert + textName.Text + " Add Successfully\r\n");
                    imgCapture.Image = null;
                    textName.Text = null;
                    
                }
                else
                {
                    MessageBox.Show("กรอกชื่อรูป ภาษาอังกฤษ ก่อน");
                }
            }
            else
            {
                MessageBox.Show("กด Capture ก่อน");
            }

        }
        private void FaceDetection(object sender, EventArgs e)
        {
            
            Frame = _capture.QueryFrame().ToImage<Bgr, byte>();
            var frame = Frame.Resize(frameW, frameH, Inter.Cubic);
            alertMessage.Text = frameW+":"+frameH;
            grayFrame = frame.Convert<Gray, Byte>();
            var faces = cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 10,  Size.Empty);
            foreach (var f in faces)
            {
                frame.Draw(f, new Bgr(Color.Red), 2);
                //alertMessage.Text = alert + "ทำการ Face Detection แล้ว\r\n";
            }

            imgFrame.Image = frame.Resize(imgBoxW, imgBoxH, Inter.Cubic);



        }
        private void EigenFaceRecognition(object sender, EventArgs e)
        { 
            Frame = _capture.QueryFrame().ToImage<Bgr, byte>();
            var frame = Frame.Resize(frameW, frameH, Inter.Cubic);
            grayFrame = frame.Convert<Gray, Byte>();
            var faces = cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);
            foreach (var f in faces)
            {
                
                eigenFaceRecognizer = new EigenFaceRecognizer(Count, double.PositiveInfinity);
                eigenFaceRecognizer.Train(trainingImages.ToArray(), indexLabels.ToArray());

                var result = eigenFaceRecognizer.Predict(frame.Copy(f).Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic));
                if (result.Label == -1)
                {
                    frame.Draw(f, new Bgr(Color.Red), 2);
                    frame.Draw("Unknown", new Point(f.X, f.Y - 10), font, 0.8, new Bgr(Color.Blue), 2, new LineType(), false);

                }
                else
                {
                    frame.Draw(f, new Bgr(Color.Green), 2);
                    frame.Draw(nameLabels[result.Label], new Point(f.X, f.Y - 10), font, 0.8, new Bgr(Color.Blue), 2, new LineType(), false);

                }
                alertMessage.Text = (alert + "เริ่มการ Face Recognition ด้วยวิธีการ " + RecognitionType.Text + " แล้ว \r\n" + "Distance " + result.Distance + "\r\n Faces " + faces.Length.ToString());


            }
            imgFrame.Image = frame.Resize(imgBoxW, imgBoxH, Inter.Cubic);
        }
        private void FisherFaceRecognition(object sender, EventArgs e)
        {
            Frame = _capture.QueryFrame().ToImage<Bgr, byte>();
            var frame = Frame.Resize(frameW, frameH, Inter.Cubic);
            grayFrame = frame.Convert<Gray, Byte>();
            var faces = cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);
            foreach (var f in faces)
            {
                fisherFaceRecognizer = new FisherFaceRecognizer(Count, double.PositiveInfinity);
                fisherFaceRecognizer.Train(trainingImages.ToArray(), indexLabels.ToArray());

                var result = fisherFaceRecognizer.Predict(frame.Copy(f).Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic));
                if (result.Label == -1)
                {
                    frame.Draw(f, new Bgr(Color.Red), 2);
                    frame.Draw("Unknown", new Point(f.X, f.Y - 10), font, 0.8, new Bgr(Color.Blue), 2, new LineType(), false);
                   
                }
                else
                {
                    frame.Draw(f, new Bgr(Color.Green), 2);
                    frame.Draw(nameLabels[result.Label], new Point(f.X, f.Y - 10), font, 0.8, new Bgr(Color.Blue), 2, new LineType(), false);

                }
                alertMessage.Text = (alert + "เริ่มการ Face Recognition ด้วยวิธีการ " + RecognitionType.Text + " แล้ว \r\n" + "Distance " + result.Distance + "\r\n Faces " + faces.Length.ToString());

            }

            
            imgFrame.Image = frame.Resize(imgBoxW, imgBoxH, Inter.Cubic);
        }
        private void LBPHFaceRecognition(object sender, EventArgs e)
        {
            Frame = _capture.QueryFrame().ToImage<Bgr, byte>();
            var frame = Frame.Resize(frameW, frameH, Inter.Cubic);
            grayFrame = frame.Convert<Gray, Byte>();
            var faces = cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);
            foreach(var f in faces)
            {
                lbphFaceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 400);
                lbphFaceRecognizer.Train(trainingImages.ToArray(), indexLabels.ToArray());

                var result = lbphFaceRecognizer.Predict(frame.Copy(f).Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic));
                if (result.Label == -1)
                {
                    frame.Draw(f, new Bgr(Color.Red), 2);
                    frame.Draw("Unknown", new Point(f.X, f.Y - 10), font, 0.8, new Bgr(Color.Blue), 2, new LineType(), false);

                }
                else
                {
                    frame.Draw(f, new Bgr(Color.Green), 2);
                    frame.Draw(nameLabels[result.Label], new Point(f.X, f.Y - 10), font, 0.8, new Bgr(Color.Blue), 2, new LineType(), false);

                }
                alertMessage.Text = (alert + "เริ่มการ Face Recognition ด้วยวิธีการ " + RecognitionType.Text + " แล้ว \r\n" + "Distance " + result.Distance + "\r\n Faces " + faces.Length.ToString());

            }
            imgFrame.Image = frame.Resize(imgBoxW, imgBoxH, Inter.Cubic);
        }
        private void ConnentCamera()
        {
                if(cameraType == 0)
                {
                    _capture = new Capture();
                    alertMessage.Text = alert + "เริ่มการติดต่อ  Camera \r\n" ;
                }
                else if (cameraType == 1)
                {
                    var url = "http://admin:P@ssw0rd@192.168.1.123/cgi-bin/video.cgi?msubmenu=mjpg";
                    _capture = new Capture(url);
                     alertMessage.Text = alert + "เริ่มการติดต่อ IP Camera ที่ Url" + url + "\r\n";
            }

                _capture.QueryFrame();

        }
        private void LoadData()
        {
            try
            {
                trainingImages.Clear();
                indexLabels.Clear();
                string Labelsinf = File.ReadAllText(Application.StartupPath + "/Faces/Faces.txt");
                string[] Labels = Labelsinf.Split(',');

                NumLables = Convert.ToInt16(Labels[0]);
                Count = NumLables;
                
                alertMessage.AppendText(alert + " โหลดข้อมูลสำเร็จ จำนวน " + Count + "รูป\r\n");
                for (int i = 1; i < NumLables + 1; i++)
                {
                    indexLabels.Add(i - 1);

                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/" + Labels[i] + ".bmp"));
                    nameLabels.Add(Labels[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ยังไม่มีข้อมูล ให้เพิ่มข้อมูลก่อน");
                alertMessage.AppendText(alert + "ยังไม่มีข้อมูล ให้เพิ่มข้อมูลก่อน\r\n");
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (cameraBox.Items.IndexOf(cameraBox.Text) >= 0)
            {
                if ( captureStatus)
                {
                    ConnentCamera();
                    Application.Idle += streaming;
                    alertMessage.AppendText(alert + "เริ่มต้นการทำงานของกล้องแล้ว\r\n");
                    start.Text = "Stop";
                }
                else
                {
                    Application.Idle -= streaming;
                    _capture.Dispose();
                    alertMessage.AppendText( alert + "หยุดการทำงานของกล้องแล้ว\r\n");
                    start.Text = "Start";
                    
                }
                captureStatus = !captureStatus;
            }
            else
            {

                MessageBox.Show("เลือกล้องก่อน");
            }
        }

        private void Detection_Click(object sender, EventArgs e)
        {
            if(captureStatus != true)
            {
                if (FaceDetectionStatus) {
                    detection.Text = "Face Detection";
                    Application.Idle -= new EventHandler(FaceDetection);
                    recognition.Enabled = true;
                    alertMessage.AppendText (alert + "หยุดการทำ Face Detection แล้ว\r\n");
                    imgCapture.Image = null;
                    System.Threading.Thread.Sleep(2000);
                    LoadData();
                }
                else
                {
                    Application.Idle += new EventHandler(FaceDetection);
                    detection.Text = "Stop";
                    recognition.Enabled = false;
                }

                FaceDetectionStatus = !FaceDetectionStatus;
            }
            else
            {
                MessageBox.Show("กด Start เพื่อเริ่มการทำงานของกล้องก่อน");
            }
            
            
        }

        private void Recognition_Click(object sender, EventArgs e)
        {
            if(captureStatus != true)
            {
                if (Count != 0)
                {
                    if (FaceRecognitionStatus) {
                        recognition.Text = "Face Recognition";
                        textName.Text = "";
                        detection.Enabled = true;
                        Application.Idle -= new EventHandler(EigenFaceRecognition);
                        Application.Idle -= new EventHandler(FisherFaceRecognition);
                        Application.Idle -= new EventHandler(LBPHFaceRecognition);
                    
                        RecognitionType.Text = "";
                    }
                    else
                    {
                        recognition.Text = "Stop";
                        detection.Enabled = false;
                        if (RecognitionType.Text == "EigenFaces")
                        {

                            Application.Idle += new EventHandler(EigenFaceRecognition);
                        }
                        else if (RecognitionType.Text == "FisherFaces")
                        {
                            Application.Idle += new EventHandler(FisherFaceRecognition);
                        }
                        else if (RecognitionType.Text == "LBPHFaces")
                        {
                            Application.Idle += new EventHandler(LBPHFaceRecognition);
                        }
                        else
                        {
                            
                            recognition.Text = "Face Recognition";
                            FaceRecognitionStatus = !FaceRecognitionStatus;
                            MessageBox.Show("เลือกวิธีการ Recognition ก่อน");
                        }
                    }

                    FaceRecognitionStatus = !FaceRecognitionStatus;
                }
                else
                {
                    alertMessage.Text = alert + "ยังไม่มีข้อมูล ให้เพิ่มข้อมูลก่อน\r\n";
                }
                
            }
            else
            {
                MessageBox.Show("กด Start เพื่อเริ่มการทำงานของกล้อง");
            }
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

            timer1.Start();

            timer2.Start();

            imgBoxH = imgFrame.Height;
            imgBoxW = imgFrame.Width;
        }

       
        private void CameraBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cameraType= cameraBox.Items.IndexOf(cameraBox.Text);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            pbCPU.Value = (int)pcCPU.NextValue();
            pbRAM.Value = (int)pcRAM.NextValue();
            //set the progress bar value to the label to know what is the percentage of the process.
            lblCPU.Text = pbCPU.Value + "%";
            lblRAM.Text = pbRAM.Value + "%";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            alert = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString()
          + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";

            
            
        }

        


    }
}
