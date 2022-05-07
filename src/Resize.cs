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
    public partial class Resize : Form
    {
        public Resize()
        {
            InitializeComponent();
        }
        double size = 1;
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

        private void button3_Click(object sender, EventArgs e)
        {
            size += 0.1;
            Mat dst = new Mat();
            OpenCvSharp.Size s = new OpenCvSharp.Size();
            Cv2.Resize(mat, dst, s, size, size);
            pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            size -= 0.1;
            Mat dst = new Mat();
            OpenCvSharp.Size s = new OpenCvSharp.Size();
            Cv2.Resize(mat, dst, s, size, size);
            pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mat dst = new Mat();
            OpenCvSharp.Size s = new OpenCvSharp.Size(int.Parse(textBox1.Text),int.Parse(textBox2.Text));
            Cv2.Resize(mat, dst, s, 0, 0);
            pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mat dst = new Mat();
            var calwidth = pictureBox1.Image.Width - float.Parse(textBox1.Text);
            var calheight = pictureBox1.Image.Height - float.Parse(textBox2.Text);
            var height = 0f;
            var width = 0f;
            if (int.Parse(textBox1.Text)>0)
            {
                width = int.Parse(textBox1.Text);
                height = pictureBox1.Image.Height - pictureBox1.Image.Height * (calwidth / pictureBox1.Image.Width);
            }
            else  
            {
                height = int.Parse(textBox2.Text);
                width = pictureBox1.Image.Width - pictureBox1.Image.Width * (calheight / pictureBox1.Image.Height);
            }
            OpenCvSharp.Size s = new OpenCvSharp.Size(width, height);
            Cv2.Resize(mat, dst, s, 0, 0);
            pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
        }
    }
}
