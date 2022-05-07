using OpenCvSharp;
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
using OpenCvSharp.Internal;

namespace WinformOpenCV
{
    public partial class FaceDetect : Form
    {
        public FaceDetect()
        {
            InitializeComponent();
        }
        Mat mat;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog.FileName);
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                mat = new Mat(openFileDialog.FileName);
                Rect[] faces;
                Mat img_gray=new Mat();
                Cv2.CvtColor(mat, img_gray, ColorConversionCodes.BGR2GRAY);
                //Cv2.EqualizeHist() 
                CascadeClassifier cascadeClassifier = new CascadeClassifier();
                cascadeClassifier.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml"));
                faces = cascadeClassifier.DetectMultiScale(img_gray);
                for (int i = 0; i < faces.Length; i++)
                {
                    Cv2.Rectangle(mat, faces[i], new Scalar(255, 128, 0), 2);
                }
                pictureBox2.Image = Image.FromStream(mat.ToMemoryStream());
            }
        }
    }
}
