using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
/*
     当继承的时候，父类中静态的保护的
     父类中静态的私有的不会继承过来。


    非静态：
    父类中私有的方法：不会被子类拥有
    父类中保护的方法：会被子类拥有，用到时只通过之类的实例化对象来使用某个方法。
    父类中公有的方法：会被子类拥有，用到时可以通过子类的实例化对象，也可以通过父类的实例化对象来使用某个方法。
    
    
    静态：只能通过父类的类名的方式调用
    父类中私有的方法：外界不可访问
    父类中保护的方法：在子类中可以访问
    父类中公有的方法：在子类中可以访问

     */

namespace WindowsFormsApplication7
{
    public partial class Down : Form//当继承了之后，父的方法同时是儿子的方法
    {
        //1定义委托类型
        public delegate void MyDelegate(int i);//在定义委类型的同时，定义函数的参数
        //2声明委托变量
        MyDelegate md;
        public Down()
        {
            InitializeComponent();
            //3实例化委托类型
            md = new MyDelegate(fun);
        }
        public void fun(int value)
        {
            this.progressBar1.Value = value;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个线程
            Thread thr = new Thread(new ParameterizedThreadStart(download));
            thr.Start();
        }

        //线程方法一定要是object参数，返回值是void
        private void download(object obj)
        {
            for (int i = 0; i <= 100; i++)
            {
              
                this.progressBar1.Invoke(md,i);//跨线程调用
                //md(i);
                Thread.Sleep(100);
            }
        }
    }
}

