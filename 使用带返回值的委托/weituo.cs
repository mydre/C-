public delegate int MyDelegate();
        public delegate void MyDelegate2(string str);
        private void button1_Click(object sender, EventArgs e)
        {
            MyDelegate dele = new MyDelegate(displayVoice);
            IAsyncResult result = dele.BeginInvoke(null, null);

            while (result.IsCompleted == false)
            {
                Thread.Sleep(20);

            }
            int d = dele.EndInvoke(result);
        }

        private static int displayVoice()//这个函数负责播放
        {
            string namespaceName = Assembly.GetExecutingAssembly().GetName().Name.ToString();
            Assembly assembly = Assembly.GetExecutingAssembly();
            MediaPlayer.MediaPlayer mr = new MediaPlayer.MediaPlayer();
            mr.FileName = @"D:\用户目录\我的文档\Visual Studio 2015\Projects\WindowsFormsApplication5\WindowsFormsApplication5\bin\Debug\amr\msg.mp3";
            mr.Play();

            return 1;
        }