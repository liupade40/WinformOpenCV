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
    public partial class WarpAffine2 : Form
    {
        public WarpAffine2()
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double angle =double.Parse(textBox1.Text);
            OpenCvSharp.Size size = mat.Size();
            int len = mat.Cols > mat.Rows ? mat.Cols : mat.Rows;
            OpenCvSharp.Point2f center = new Point2f(len / 2, len / 2);
            Mat rot = Cv2.GetRotationMatrix2D(center, angle, 1.0);
            Mat dst = new Mat();
            Cv2.WarpAffine(mat,dst, rot, size);
            pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
        }
    }
}
