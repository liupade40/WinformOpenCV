using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = OpenCvSharp.Point;

namespace WinformOpenCV
{
    public partial class Watch : Form
    {
        Mat img;
        int margin = 5;
        int radius = 220;
        Point center = new OpenCvSharp.Point(225, 225);
        
        public Watch()
        {
            InitializeComponent(); 
            img = Mat.Zeros(443, 660, MatType.CV_8UC3);
            for (int x = 0; x < img.Rows; x++)
            {
                for (int y = 0; y < img.Cols; y++)
                {
                    img.Set<Vec3b>(x, y, new Vec3b(255, 255, 255));
                }
            }
            Cv2.Circle(img, center, radius, new Scalar(0, 0, 0),5);
            List<Point> points = new List<Point>();
            for (int i = 0; i < 60; i++)
            {
                var x1 = center.X + (radius - margin) * Math.Cos(i * 6 * Math.PI / 180);
                var y1 = center.Y + (radius - margin) * Math.Sin(i * 6 * Math.PI / 180);
                var x2 = center.X + (radius - 15) * Math.Cos(i * 6 * Math.PI / 180);
                var y2 = center.Y + (radius - 15) * Math.Sin(i * 6 * Math.PI / 180);
                points.Add(new Point(x1, y1));
                Cv2.Line(img, new Point(x1, y1), new Point(x2, y2), new Scalar(0, 0, 0), 2);
            }
            for (int i = 0; i < 12; i++)
            {
                var x1 = center.X + (radius - 25) * Math.Cos(i * 30 * Math.PI / 180);
                var y1 = center.Y + (radius - 25) * Math.Sin(i * 30 * Math.PI / 180);
                Cv2.Line(img,  points[i*5], new Point(x1, y1), new Scalar(0, 0, 0), 5);
            }
            pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
        }

        private void Watch_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var temp = img.Clone();
                    var now = DateTime.Now;
                    var sec_angle = now.Second * 6 + 270;
                    var sec_x = center.X + (radius - margin) * Math.Cos(sec_angle * Math.PI / 180.0);
                    var sec_y = center.Y + (radius - margin) * Math.Sin(sec_angle * Math.PI / 180.0);
                    Cv2.Line(temp, new Point(center.X,center.Y), new Point((int)(sec_x), (int)(sec_y)),new Scalar (203, 222, 166), 2);
                    var min_angle = now.Minute * 6 + 270;
                    var min_x = center.X + (radius - margin) * Math.Cos(min_angle * Math.PI / 180.0);
                    var min_y = center.Y + (radius - margin) * Math.Sin(min_angle * Math.PI / 180.0);
                    Cv2.Line(temp, new Point(center.X, center.Y), new Point((int)(min_x), (int)(min_y)), new Scalar(186, 199, 137), 8);
                    var hour_angle = now.Hour * 30 + 270;
                    var hour_x = center.X + (radius - margin) * Math.Cos(hour_angle * Math.PI / 180.0);
                    var hour_y = center.Y + (radius - margin) * Math.Sin(hour_angle * Math.PI / 180.0);
                    Cv2.Line(temp, new Point(center.X, center.Y), new Point((int)(hour_x), (int)(hour_y)), new Scalar(169, 198, 26), 15);
                    Cv2.PutText(temp, now.ToString("G"), new Point(55, 275), HersheyFonts.HersheyScriptSimplex, 1, new Scalar(0, 0, 0), 2);
                    pictureBox1.Image = Image.FromStream(temp.ToMemoryStream());
                    Thread.Sleep(100);
                } 
            });
        }
    }
}
