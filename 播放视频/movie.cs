using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExampleWinForm
{
    public partial class FormPlayVideo1 : Form
    {        
        private bool isPlaying = false;     //是否正在播放

        public FormPlayVideo1()
        {
            InitializeComponent();
        }

        private void FormPlayVideo1_Load(object sender, EventArgs e)
        {
            //下面是播放视频动画的核心代码
            string fileName = @"D:\用户目录\我的文档\WeChat Files\lht1010101\FileStorage\Video\2019-06\4c550d6e1e1e9fd558119e73b77f7da4.mp4";
            this.axWindowsMediaPlayer1.URL = fileName;
            this.axWindowsMediaPlayer1.Visible = true;
            this.axWindowsMediaPlayer1.BringToFront();
            this.axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem tsi = e.ClickedItem;
            object tag = tsi.Tag;
            if (tag == null) return;

            string s = tag.ToString().ToLower();
            if (s == "openandplay")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                DialogResult result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = dlg.FileName;
                    this.axWindowsMediaPlayer1.URL = fileName;

                    //MessageBox.Show(fileName);
                    //

                    this.axWindowsMediaPlayer1.Visible = true;
                    this.axWindowsMediaPlayer1.BringToFront();
                    this.axWindowsMediaPlayer1.Ctlcontrols.play();
                }

            }
            else if (s == "play")
            {
                if (this.isPlaying == false)
                {
                    this.isPlaying = true;
                    this.axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
            else if (s == "pause")
            {
                //需判断是否真正在播放视频
                if (this.isPlaying == true && string.IsNullOrEmpty(this.axWindowsMediaPlayer1.URL) == false)
                {
                    this.isPlaying = false;
                    this.axWindowsMediaPlayer1.Ctlcontrols.pause();
                }
            }
            else if (s == "stop")
            {
                //需判断是否真正在播放视频
                if (this.isPlaying == true && string.IsNullOrEmpty(this.axWindowsMediaPlayer1.URL) == false)
                {
                    this.isPlaying = false;
                    this.axWindowsMediaPlayer1.Ctlcontrols.stop();
                }
            }
            else if (s == "close")
            {
                if (this.isPlaying == true)
                {
                    this.axWindowsMediaPlayer1.Ctlcontrols.stop();
                    this.axWindowsMediaPlayer1.Dispose();
                }
                this.Close();
            }
        }

    }
}

