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
using OpenCvSharp;

namespace WinformOpenCV
{
    public partial class Shape : Form
    {
        public Shape()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;";
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            { 
                pictureBox1.Load(openFileDialog.FileName);
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                Mat mat = new Mat(openFileDialog.FileName);
                label2.Text = $"宽：{mat.Height}，高：{mat.Width}，通道:{mat.Channels()},像素:{mat.Height*mat.Width*mat.Channels()}";
            }
        }
    }
}
