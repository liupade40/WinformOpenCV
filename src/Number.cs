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
    public partial class Number : Form
    {
        public Number()
        {
            InitializeComponent();
        }
        //使用像素点画数字
        private void Number_Load(object sender, EventArgs e)
        {
            Rect work_ROI=new Rect();//数字填充区域
            work_ROI.X = 10;
            work_ROI.Y = 10;
            work_ROI.Width = 10;
            work_ROI.Height = 10;
            Mat out_ROI = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
             
            for (int i = 1; i < 8; i++)
            {
                out_ROI.At<byte>(i, 7) = 255;
            }

            Mat mat2 = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            out_ROI.CopyTo(mat2[work_ROI]);

            out_ROI = new Mat(10, 10, MatType.CV_8UC1, new Scalar(0));
            for (int i = 2; i < 8; i++)
            {
                out_ROI.At<byte>(1, i) = 255;
                out_ROI.At<byte>(7, i) = 255;
                out_ROI.At<byte>(i, 2) = 255;
                out_ROI.At<byte>(i, 7) = 255;
            }
            //work_ROI. += 10;
            out_ROI.CopyTo(mat2[work_ROI]);
            pictureBox1.Image = Image.FromStream(mat2.ToMemoryStream());
        }
    }
}
