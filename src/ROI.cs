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
using Point = System.Drawing.Point;

namespace WinformOpenCV
{
    public partial class ROI : Form
    {
        Label label1;
        Label label2;
        public ROI()
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
        int i = 0;
        int X = 0;
        int Y = 0;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (i)
            {
                case 0:
                    if (label1!=null)
                    {
                        this.Controls.Remove(label1);
                    }
                    label1 = new Label();
                    label1.Width = 3;
                    label1.Height = 3;  
                    label1.BackColor = Color.Red;
                    label1.Location = new Point(pictureBox1.Left + e.X,pictureBox1.Top + e.Y);
                    X = e.X;
                    Y = e.Y;
                    this.Controls.Add(label1);
                    label1.BringToFront();
                    textBox1.Text= $"{e.X},{e.Y}";
                    i+=1;
                    break;
                case 1:
                    if (label2 != null)
                    {
                        this.Controls.Remove(label2);
                    }
                    label2 = new Label();
                    label2.Location = new Point( pictureBox1.Left + e.X,pictureBox1.Top + e.Y); 
                    label2.Width = 3;
                    label2.Height = 3;
                    //label1.
                    label2.BackColor = Color.Red;
                    this.Controls.Add(label2);
                    label2.BringToFront();
                    textBox2.Text = $"{e.X},{e.Y}";
                    i = 0;
                    Mat dst = mat[new Rect(X, Y, e.X - X, e.Y - Y)];
                    pictureBox2.Image= Image.FromStream(dst.ToMemoryStream());
                    
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
