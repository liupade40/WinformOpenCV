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

namespace WinformOpenCV
{
    public partial class WarpAffine : Form
    {
        public WarpAffine()
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
                Mat dst = new Mat();
                Mat t = Mat.Zeros(rows:2, 3,  MatType.CV_32F);
                t.At<float>(0, 0) = 1;
                t.At<float>(0, 2) = 50;
                t.At<float>(1, 1) = 1;
                t.At<float>(1, 2) = 10;
                Cv2.WarpAffine(mat, dst, t, mat.Size());
                pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
            }
        }
    }
}
