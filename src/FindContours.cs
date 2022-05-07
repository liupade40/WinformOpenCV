using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformOpenCV
{
    public partial class FindContours : Form
    {
        public FindContours()
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
                mat = new Mat(openFileDialog.FileName);
                Mat mat_gray = new Mat();
                Cv2.CvtColor(mat, mat_gray, ColorConversionCodes.BGR2GRAY);
                Mat dst = new Mat();  
                Cv2.Threshold(mat_gray, dst, 0, 255, ThresholdTypes.Otsu);
                Mat[] mats;
                Mat h = new Mat();
                Cv2.FindContours(dst, out mats, h, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
                Cv2.DrawContours(mat, mats, -1, new Scalar(0, 0, 255), 2);
                pictureBox2.Image = Image.FromStream(mat.ToMemoryStream());
            }
        }
    }
}
