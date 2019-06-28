using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {

        string pcm = "silk_v3_decoder.exe ./amr/msg.amr ./amr/msg.pcm";
        string music = "lame.exe -r -s 24000 --preset voice ./amr/msg.pcm ./amr/msg.mp3";
        public Form2()
        {
            InitializeComponent();
        }

        private void aaa(object sender, EventArgs e)
        {
 
            var task1 = new Task(() =>
            {
                fun(pcm);
            });
            var task2 = new Task(() =>
            {
                Thread.Sleep(50);
                fun(music);
            });
            task2.Start();
            task1.Start();
        }
        public static void fun(string str)
        {
            string currentWorkDir = Environment.CurrentDirectory;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            p.StandardInput.WriteLine(str + "&exit");
            p.StandardInput.AutoFlush = true;
            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            Console.WriteLine(output);
        }
    }
}

