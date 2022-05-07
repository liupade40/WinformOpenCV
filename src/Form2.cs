using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace WinformOpenCV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shape shape = new Shape();
            shape.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ROI shape = new ROI();
            shape.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Threshold shape = new Threshold();
            shape.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Resize shape = new Resize();
            shape.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Flip flip = new Flip();
            flip.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WarpAffine warpAffine = new WarpAffine();
            warpAffine.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WarpAffine2 warpAffine = new WarpAffine2();
            warpAffine.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mat img = Mat.Zeros(285, 500, MatType.CV_8UC3);

            Cv2.Circle(img, 256, 256, 50, new Scalar(0, 0, 0), -1);
            Cv2.Ellipse(img,new OpenCvSharp.Point (250, 50),new OpenCvSharp.Size (40, 40), 60, 60, 360,new Scalar (0, 0, 255,0), -1);
            Cv2.Circle(img, 250, 50, 20, new Scalar(0, 0, 0), -1);

            Cv2.Circle(img, 210, 340, 50, new Scalar(0, 0, 0), -1);
            Cv2.Ellipse(img, new OpenCvSharp.Point(200, 130), new OpenCvSharp.Size(40, 40), 310, 60, 360, new Scalar(0, 255, 0, 0), -1);
            Cv2.Circle(img, 200, 130, 20, new Scalar(0, 0, 0), -1);


            Cv2.Circle(img, 300, 340, 50, new Scalar(0, 0, 0), -1);
            Cv2.Ellipse(img, new OpenCvSharp.Point(290, 130), new OpenCvSharp.Size(40, 40), 250, 60, 360, new Scalar(255, 0, 0, 0), -1);
            Cv2.Circle(img, 290, 130, 20, new Scalar(0, 0, 0), -1);

            Cv2.PutText(img, "OpenCV", new OpenCvSharp.Point(10, 250), HersheyFonts.HersheySimplex, 4, new Scalar(255, 255, 255, 0), 2, LineTypes.Link4);
            pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CVPanel panel = new CVPanel();
            panel.Show();
        }
    }
}
