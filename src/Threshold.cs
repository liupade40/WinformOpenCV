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
    public partial class Threshold : Form
    {
        public Threshold()
        {
            InitializeComponent();
            List<KeyValuePair<int,string>> dic = new List<KeyValuePair<int, string>>();
            dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.Binary, ThresholdTypes.Binary.ToString()));
            dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.BinaryInv, ThresholdTypes.BinaryInv.ToString()));
            dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.Trunc, ThresholdTypes.Trunc.ToString()));
            dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.Tozero, ThresholdTypes.Tozero.ToString())); 
            dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.TozeroInv, ThresholdTypes.TozeroInv.ToString())); 
            //dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.Mask, ThresholdTypes.Mask.ToString())); 
            //dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.Otsu, ThresholdTypes.Otsu.ToString())); 
            //dic.Add(new KeyValuePair<int, string>((int)ThresholdTypes.Triangle, ThresholdTypes.Triangle.ToString())); 
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember="Value";
            comboBox1.DataSource = dic;
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
                Cv2.Threshold(mat, dst, 127, 255, Enum.Parse<ThresholdTypes>(value: comboBox1.SelectedValue?.ToString()));
                pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mat dst = new Mat(); 
            if (mat!=null)
            {
                Cv2.Threshold(mat, dst, int.Parse(textBox1.Text), 255, Enum.Parse<ThresholdTypes>(value: comboBox1.SelectedValue?.ToString()));
                pictureBox2.Image = Image.FromStream(dst.ToMemoryStream());
            }
        }
    }
}
