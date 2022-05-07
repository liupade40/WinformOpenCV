namespace WinformOpenCV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.图片属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.轮廓ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人脸检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人脸检测ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.人脸模型训练ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人脸识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(134, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 285);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(318, 84);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "打开画板";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图片属性ToolStripMenuItem,
            this.rOIToolStripMenuItem,
            this.thresholdToolStripMenuItem,
            this.缩放ToolStripMenuItem,
            this.翻转ToolStripMenuItem,
            this.平移ToolStripMenuItem,
            this.旋转ToolStripMenuItem,
            this.表盘ToolStripMenuItem,
            this.边缘检测ToolStripMenuItem,
            this.轮廓ToolStripMenuItem,
            this.人脸检测ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 图片属性ToolStripMenuItem
            // 
            this.图片属性ToolStripMenuItem.Name = "图片属性ToolStripMenuItem";
            this.图片属性ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.图片属性ToolStripMenuItem.Text = "图片属性";
            this.图片属性ToolStripMenuItem.Click += new System.EventHandler(this.图片属性ToolStripMenuItem_Click);
            // 
            // rOIToolStripMenuItem
            // 
            this.rOIToolStripMenuItem.Name = "rOIToolStripMenuItem";
            this.rOIToolStripMenuItem.Size = new System.Drawing.Size(138, 21);
            this.rOIToolStripMenuItem.Text = "ROI（提取某个区域）";
            this.rOIToolStripMenuItem.Click += new System.EventHandler(this.rOIToolStripMenuItem_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(110, 21);
            this.thresholdToolStripMenuItem.Text = "Threshold(阈值)";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.缩放ToolStripMenuItem.Text = "缩放";
            this.缩放ToolStripMenuItem.Click += new System.EventHandler(this.缩放ToolStripMenuItem_Click);
            // 
            // 翻转ToolStripMenuItem
            // 
            this.翻转ToolStripMenuItem.Name = "翻转ToolStripMenuItem";
            this.翻转ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.翻转ToolStripMenuItem.Text = "翻转";
            this.翻转ToolStripMenuItem.Click += new System.EventHandler(this.翻转ToolStripMenuItem_Click);
            // 
            // 平移ToolStripMenuItem
            // 
            this.平移ToolStripMenuItem.Name = "平移ToolStripMenuItem";
            this.平移ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.平移ToolStripMenuItem.Text = "平移";
            this.平移ToolStripMenuItem.Click += new System.EventHandler(this.平移ToolStripMenuItem_Click);
            // 
            // 旋转ToolStripMenuItem
            // 
            this.旋转ToolStripMenuItem.Name = "旋转ToolStripMenuItem";
            this.旋转ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.旋转ToolStripMenuItem.Text = "旋转";
            this.旋转ToolStripMenuItem.Click += new System.EventHandler(this.旋转ToolStripMenuItem_Click);
            // 
            // 表盘ToolStripMenuItem
            // 
            this.表盘ToolStripMenuItem.Name = "表盘ToolStripMenuItem";
            this.表盘ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.表盘ToolStripMenuItem.Text = "时钟";
            this.表盘ToolStripMenuItem.Click += new System.EventHandler(this.表盘ToolStripMenuItem_Click);
            // 
            // 边缘检测ToolStripMenuItem
            // 
            this.边缘检测ToolStripMenuItem.Name = "边缘检测ToolStripMenuItem";
            this.边缘检测ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.边缘检测ToolStripMenuItem.Text = "边缘检测";
            this.边缘检测ToolStripMenuItem.Click += new System.EventHandler(this.边缘检测ToolStripMenuItem_Click);
            // 
            // 轮廓ToolStripMenuItem
            // 
            this.轮廓ToolStripMenuItem.Name = "轮廓ToolStripMenuItem";
            this.轮廓ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.轮廓ToolStripMenuItem.Text = "轮廓";
            this.轮廓ToolStripMenuItem.Click += new System.EventHandler(this.轮廓ToolStripMenuItem_Click);
            // 
            // 人脸检测ToolStripMenuItem
            // 
            this.人脸检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.人脸检测ToolStripMenuItem1,
            this.人脸模型训练ToolStripMenuItem,
            this.人脸识别ToolStripMenuItem});
            this.人脸检测ToolStripMenuItem.Name = "人脸检测ToolStripMenuItem";
            this.人脸检测ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.人脸检测ToolStripMenuItem.Text = "人脸";
            // 
            // 人脸检测ToolStripMenuItem1
            // 
            this.人脸检测ToolStripMenuItem1.Name = "人脸检测ToolStripMenuItem1";
            this.人脸检测ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.人脸检测ToolStripMenuItem1.Text = "人脸检测";
            this.人脸检测ToolStripMenuItem1.Click += new System.EventHandler(this.人脸检测ToolStripMenuItem1_Click);
            // 
            // 人脸模型训练ToolStripMenuItem
            // 
            this.人脸模型训练ToolStripMenuItem.Name = "人脸模型训练ToolStripMenuItem";
            this.人脸模型训练ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.人脸模型训练ToolStripMenuItem.Text = "人脸模型训练";
            this.人脸模型训练ToolStripMenuItem.Click += new System.EventHandler(this.人脸模型训练ToolStripMenuItem_Click);
            // 
            // 人脸识别ToolStripMenuItem
            // 
            this.人脸识别ToolStripMenuItem.Name = "人脸识别ToolStripMenuItem";
            this.人脸识别ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.人脸识别ToolStripMenuItem.Text = "人脸识别";
            this.人脸识别ToolStripMenuItem.Click += new System.EventHandler(this.人脸识别ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 图片属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 翻转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表盘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 边缘检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 轮廓ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人脸检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人脸检测ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 人脸模型训练ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人脸识别ToolStripMenuItem;
    }
}
