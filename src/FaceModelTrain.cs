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
    public partial class FaceModelTrain : Form
    {
        public FaceModelTrain()
        {
            InitializeComponent();
        }

        List<Mat> faces = new List<Mat>();
        List<int> labels = new List<int>();
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Mat mat = new Mat(openFileDialog.FileName);
                Rect[] detectFaces;
                Mat img_gray = new Mat();
                Cv2.CvtColor(mat, img_gray, ColorConversionCodes.BGR2GRAY);
                //Cv2.EqualizeHist() 
                CascadeClassifier cascadeClassifier = new CascadeClassifier();
                cascadeClassifier.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml"));
                detectFaces = cascadeClassifier.DetectMultiScale(img_gray);
                if (detectFaces.Length == 0)
                {
                    MessageBox.Show("未检测到人脸");
                    return;
                }
                Mat face = new Mat(mat, detectFaces[0]);
                faces.Add(new Mat(img_gray, detectFaces[0]));
                switch (i)
                {
                    case 0:
                        pictureBox1.Image = Image.FromStream(face.ToMemoryStream());
                        textBox1.Text = i.ToString();
                        break;
                    case 1:
                        pictureBox2.Image = Image.FromStream(face.ToMemoryStream());
                        textBox2.Text = i.ToString();
                        break;
                    case 2:
                        pictureBox3.Image = Image.FromStream(face.ToMemoryStream());
                        textBox3.Text = i.ToString();
                        break;
                    case 3:
                        pictureBox4.Image = Image.FromStream(face.ToMemoryStream());
                        textBox4.Text = i.ToString();
                        break;
                    case 4:
                        pictureBox5.Image = Image.FromStream(face.ToMemoryStream());
                        textBox5.Text = i.ToString();
                        break;
                    case 5:
                        pictureBox6.Image = Image.FromStream(face.ToMemoryStream());
                        textBox6.Text = i.ToString();
                        break;
                    default:
                        break;
                }
                i += 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            NotNull(textBox1);
            NotNull(textBox2);
            NotNull(textBox3);
            NotNull(textBox4);
            NotNull(textBox5);
            NotNull(textBox6);
            if (labels.Count == 0)
            {
                MessageBox.Show("请上传人脸图片");
                return;
            }
            LBPHFaceRecognizer faceRecognizer = LBPHFaceRecognizer.Create();
            faceRecognizer.Train(faces, labels);
            faceRecognizer.Save("face_model.xml");
            MessageBox.Show("训练完成");
            labels.Clear();
            faces.Clear();
        }

        private void NotNull(TextBox textBox)
        {
            if (int.TryParse(textBox.Text, out int result))
            {
                labels.Add(result);
            }
        }
    }
}
