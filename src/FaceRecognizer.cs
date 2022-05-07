using OpenCvSharp;
using OpenCvSharp.Face;
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

namespace WinformOpenCV
{
    public partial class FaceRecognizer : Form
    {
        public FaceRecognizer()
        {
            InitializeComponent();
        }
        LBPHFaceRecognizer faceRecognizer = LBPHFaceRecognizer.Create();
        Mat mat;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label1.Text))
            {
                MessageBox.Show("请先选择模型");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog.FileName);
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                mat = new Mat(openFileDialog.FileName);
                Rect[] faces;
                Mat img_gray = new Mat();
                Cv2.CvtColor(mat, img_gray, ColorConversionCodes.BGR2GRAY);
                //Cv2.EqualizeHist() 
                CascadeClassifier cascadeClassifier = new CascadeClassifier();
                cascadeClassifier.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml"));
                faces = cascadeClassifier.DetectMultiScale(img_gray);
                if (faces.Length==0)
                {
                    MessageBox.Show("请先选择模型");
                    return;
                }
                Cv2.Rectangle(mat, faces[0], new Scalar(255, 128, 0), 2);
                int label; double confidens;
                faceRecognizer.Predict(new Mat(img_gray, faces[0]),out label,out confidens);
                if (confidens<70)
                {
                    label3.Text = label.ToString();
                }
                else
                {
                    label3.Text = "未识别";
                }
                pictureBox2.Image = Image.FromStream(mat.ToMemoryStream());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml|*.xml;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                label1.Text=(openFileDialog.FileName);
                faceRecognizer.Read(openFileDialog.FileName); 
            }
        }
    }
}
