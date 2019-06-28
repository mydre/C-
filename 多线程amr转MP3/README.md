当把命令行窗口中的命令复制到visual studio中时，可能会发生改变 如 -s 会变成 - s<br/>
Environment.CurrentDirectory命令会得到一个字符串，这个字符串在项目的Debug目录<br/>
重要的两个命令，显是讲amr转为pcm，然后将pcm转为mp3<br/>
        string pcm = "silk_v3_decoder.exe ./amr/msg.amr ./amr/msg.pcm";<br/>
        string music = "lame.exe -r -s 24000 --preset voice ./amr/msg.pcm ./amr/msg.mp3";<br/>
使用斜杠而不是反斜杠，这里使用的是相对路径，.代表当前路径。刚开始是使用绝对路径，并且使用的还是反斜杠(估计这样都不行)<br/>
当含有可能会导致进程阻塞的操作是，尽量将该操作定义在函数中，然后将该函数封装在一个task中，这样最多也是task阻塞，不会影响运行<br/>
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
	    <br/>
然后就是模拟cmd的操作啦，使用的是斜杠，相对路径.<br/>
