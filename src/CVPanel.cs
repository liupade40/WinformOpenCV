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
using Point = OpenCvSharp.Point;

namespace WinformOpenCV
{
    public partial class CVPanel : Form
    {
        readonly List<Mat> stack = new List<Mat>();
        Mat img;
        Mat img2;
        Color PanelColor = Color.FromArgb(0, 0, 0);
        public CVPanel()
        {
            InitializeComponent();
            img = Mat.Zeros(pictureBox1.Height, pictureBox1.Width, MatType.CV_8UC3);
            stack.Add(img.Clone());
            pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
            listBox1.Items.Add("直线");
            listBox1.Items.Add("曲线");
            listBox1.Items.Add("画笔");
            listBox1.Items.Add("箭头");
            listBox1.Items.Add("圆");
            listBox1.Items.Add("椭圆");
            listBox1.Items.Add("矩形");
            listBox1.Items.Add("文字");
            listBox1.Items.Add("橡皮擦");
            listBox1.SetSelected(0, true);
            listBox2.Items.Add("楷体");
            listBox2.Items.Add("隶书");
            listBox2.Items.Add("宋体");
            listBox2.Items.Add("微软雅黑");
            listBox2.Items.Add("黑体");
            listBox2.SetSelected(0, true);
            listBox3.Items.Add(FontStyle.Bold);
            listBox3.Items.Add(FontStyle.Italic);
            listBox3.Items.Add(FontStyle.Regular);
            listBox3.Items.Add(FontStyle.Strikeout);
            listBox3.Items.Add(FontStyle.Underline);
            listBox3.SetSelected(0, true);
            color = Color.FromArgb(255, 0, 0);
            button3.BackColor = color;
            button6.BackColor = PanelColor;
            panel1.Hide();
            panel2.Hide();
        }
        bool drawing;
        Point start;
        int x, y;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            start = new Point(e.X, e.Y);
            x = e.X;
            y = e.Y;
            switch (listBox1.SelectedItem.ToString())
            {
                case "曲线":
                case "画笔":
                case "文字":
                case "橡皮擦":
                    img2 = img.Clone();
                    break;
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            switch (listBox1.SelectedItem.ToString())
            {
                case "圆":
                    break;
                case "直线":
                    break;
                case "椭圆":
                    panel1.Show();
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    textBox4.Text = "360";
                    break;
                case "文字":
                    panel2.Show();
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {

                switch (listBox1.SelectedItem.ToString())
                {
                    case "直线":
                        img2 = img.Clone();
                        Cv2.Line(img2, start, new Point(e.X, e.Y), new Scalar(color.B, color.G, color.R), int.Parse(textBox1.Text) > 0 ? int.Parse(textBox1.Text) : 1);
                        break;
                    case "曲线":
                    case "画笔":
                        Cv2.Line(img2, new Point(x, y), new Point(e.X, e.Y), new Scalar(color.B, color.G, color.R), int.Parse(textBox1.Text) > 0 ? int.Parse(textBox1.Text) : 1);
                        x = e.X;
                        y = e.Y;
                        break;
                    case "矩形":
                        img2 = img.Clone();
                        Cv2.Rectangle(img2, start, new Point(e.X, e.Y), new Scalar(color.B, color.G, color.R), int.Parse(textBox1.Text));
                        break;
                    case "箭头":
                        img2 = img.Clone();
                        Cv2.ArrowedLine(img2, start, new Point(e.X, e.Y), new Scalar(color.B, color.G, color.R), int.Parse(textBox1.Text));
                        break;
                    //case "画笔": 
                    //    Cv2.Line(img2, new Point(x, y), new Point(e.X, e.Y), new Scalar(color.B, color.G, color.R), int.Parse(textBox1.Text));
                    //    x = e.X;
                    //    y = e.Y;
                    //    break;
                    case "圆":
                        img2 = img.Clone();
                        Cv2.Circle(img2, new Point(e.X, e.Y), Math.Abs((e.X - start.X) / 2), new Scalar(color.B, color.G, color.R), int.Parse(textBox1.Text));
                        break;
                    case "椭圆":
                        img2 = img.Clone();
                        Cv2.Ellipse(img2, new Point(e.X, e.Y), new OpenCvSharp.Size(Math.Abs(e.X - start.X), Math.Abs(e.Y - start.Y)), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), new Scalar(color.B, color.G, color.R), int.Parse(textBox1.Text));
                        break;
                    case "橡皮擦":
                        if (isCustomize)
                        {
                            MessageBox.Show("橡皮擦不可用于编辑本地图片");
                            listBox1.SetSelected(0, true);
                            return;
                        }
                        Cv2.Line(img2, new Point(x, y), new Point(e.X, e.Y), new Scalar(PanelColor.B, PanelColor.G, PanelColor.R), 10);
                        x = e.X;
                        y = e.Y;
                        break;
                    default:
                        break;
                }
                pictureBox1.Image = Image.FromStream(img2.ToMemoryStream());
            }
        }
        int CurrentIndex = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            CurrentIndex -= 1;
            if (CurrentIndex == -1)
            {
                CurrentIndex = 0;
            }
            img = stack[CurrentIndex];
            pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (img2 == null || listBox1.SelectedItem.ToString() == "文字")
            {
                return;
            }
            img = img2.Clone();
            if (CurrentIndex == stack.Count - 1)
            {
                CurrentIndex += 1;
            }
            else
            {
                stack.RemoveRange(CurrentIndex + 1, stack.Count - CurrentIndex - 1);
                CurrentIndex += 1;
            }
            stack.Add(img.Clone());
            drawing = false;
        }
        Color color;
        private void button3_Click(object sender, EventArgs e)
        {
            //显示颜色对话框
            DialogResult dr = colorDialog1.ShowDialog();
            //如果选中颜色，单击“确定”按钮则改变文本框的文本颜色
            if (dr == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
                color = colorDialog1.Color;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                return;
            }
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                Font font = new Font(listBox2.SelectedItem.ToString(), int.Parse(textBox5.Text), Enum.Parse<FontStyle>(listBox3.SelectedItem.ToString()));
                g.DrawString(textBox6.Text, font, new SolidBrush(color), new PointF(start.X, start.Y));
            }
            img = Cv2.ImDecode(ToBinary(pictureBox1.Image), ImreadModes.Color);
            //Cv2.PutText(img2, textBox6.Text, new Point(start.X, start.Y), Enum.Parse<HersheyFonts>(listBox2.SelectedItem.ToString()), int.Parse(textBox5.Text), new Scalar(color.B, color.G, color.R));
            pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
            if (CurrentIndex == stack.Count - 1)
            {
                CurrentIndex += 1;
            }
            else
            {
                stack.RemoveRange(CurrentIndex + 1, stack.Count - CurrentIndex - 1);
                CurrentIndex += 1;
            }
            stack.Add(img.Clone());
            drawing = false;
        }

        private static byte[] ToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                BinaryReader reader = new BinaryReader(ms);
                return ms.ToArray();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentIndex += 1;
            if (CurrentIndex >= stack.Count)
            {
                CurrentIndex = stack.Count - 1;
            }
            img = stack[CurrentIndex];
            pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "请选择要保存的文件路径";

            //初始化保存目录，默认exe文件目录

            saveFileDialog1.InitialDirectory = Application.StartupPath;

            //设置保存文件的类型

            saveFileDialog1.Filter = "图片文件|*.jpg,*.png";
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddhhmmss");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获得保存文件的路径 
                string filePath = saveFileDialog1.FileName;
                //保存 
                pictureBox1.Image.Save(filePath);

            }
            img.SaveImage(DateTime.Now.ToString("yyyyMMddhhmmss") + ".png");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("切换面板背景色将覆盖现有内容，确认吗？可以选择先保存。", "警告", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //显示颜色对话框
                DialogResult dr2 = colorDialog1.ShowDialog();
                //如果选中颜色，单击“确定”按钮则改变文本框的文本颜色
                if (dr2 == DialogResult.OK)
                {
                    img = Mat.Zeros(pictureBox1.Height, pictureBox1.Width, MatType.CV_8UC3);
                    isCustomize = false;
                    button6.BackColor = colorDialog1.Color;
                    PanelColor = colorDialog1.Color;
                    for (int x = 0; x < img.Rows; x++)
                    {
                        for (int y = 0; y < img.Cols; y++)
                        {
                            img.Set<Vec3b>(x, y, new Vec3b(PanelColor.B, PanelColor.G, PanelColor.R));
                        }
                    }
                    stack.Clear();
                    stack.Add(img.Clone());
                    CurrentIndex = 0;
                    pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
                }
            }

        }
        bool isCustomize = false;

        private void button8_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("切换面板背景色将覆盖现有内容，确认吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                img = Mat.Zeros(pictureBox1.Height, pictureBox1.Width, MatType.CV_8UC3);
                isCustomize = false;
                for (int x = 0; x < img.Rows; x++)
                {
                    for (int y = 0; y < img.Cols; y++)
                    {
                        img.Set<Vec3b>(x, y, new Vec3b(PanelColor.B, PanelColor.G, PanelColor.R));
                    }
                }
                stack.Clear();
                stack.Add(img.Clone());
                CurrentIndex = 0;
                pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(pictureBox1.Image);
        }

        private void CVPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DialogResult.OK != MessageBox.Show("确定关闭画板吗？请检查是否保存内容。", "提示", MessageBoxButtons.OKCancel);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("上传图片将覆盖现有内容，确认吗？可以选择先保存。", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //显示颜色对话框
                DialogResult dr2 = openFileDialog1.ShowDialog();
                //如果选中颜色，单击“确定”按钮则改变文本框的文本颜色
                if (dr2 == DialogResult.OK)
                {
                    isCustomize = true;
                    //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    img = new Mat(openFileDialog1.FileName);
                    stack.Clear();
                    stack.Add(img.Clone());
                    CurrentIndex = 0;
                    pictureBox1.Image = Image.FromStream(img.ToMemoryStream());
                }
            }
        }

    }
}
