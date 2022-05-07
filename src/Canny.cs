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
    public partial class Canny : Form
    {
        public Canny()
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
                mat = new Mat(openFileDialog.FileName,MatType.CV_8U);
                Mat dst = new Mat();
                Cv2.Threshold(mat, dst, 0, 255, ThresholdTypes.Otsu);
                Cv2.Canny(mat, dst, int.Parse(textBox1.Text), int.Parse(textBox1.Text));
                pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Mat dst = new Mat();
            Cv2.Canny(mat, dst, int.Parse(textBox1.Text), int.Parse(textBox1.Text));
            pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Mat dst = new Mat();
            Cv2.Canny(mat, dst, int.Parse(textBox1.Text), int.Parse(textBox1.Text));
            pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
        }
    }
}
