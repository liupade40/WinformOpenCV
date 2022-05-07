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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void 图片属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shape shape = new Shape();
            shape.Show();
        }

        private void rOIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ROI oI= new ROI();
            oI.Show();
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Threshold threshold = new Threshold();
            threshold.Show();
        }

        private void 缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resize shape = new Resize();
            shape.Show();
        }

        private void 翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flip flip = new Flip();
            flip.Show();
        }

        private void 平移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarpAffine warpAffine = new WarpAffine();
            warpAffine.Show();
        }

        private void 旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarpAffine2 warpAffine = new WarpAffine2();
            warpAffine.Show();
        }

        private void 表盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Watch watch = new Watch();
            watch.Show();
        }

        private void 边缘检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canny canny = new Canny();
            canny.Show();
        }

        private void 轮廓ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindContours findContours = new FindContours();
            findContours.Show();
        }

        private void 人脸检测ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FaceDetect faceDetect = new FaceDetect();
            faceDetect.Show();
        }

        private void 人脸模型训练ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaceModelTrain faceModelTrain = new FaceModelTrain();
            faceModelTrain.Show();
        }

        private void 人脸识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaceRecognizer recognizer = new FaceRecognizer();
            recognizer.Show();
        }
    }
}
