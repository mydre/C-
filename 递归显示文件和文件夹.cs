using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 遍历文件夹和子文件夹
{
    class Program
    {
        private static FileStream fs;
        private static StreamWriter sw;

        static void Main(string[] args)
        {
            string path;
            int leval = 0;

            Console.WriteLine("请输入需要列出内容的文件夹的完整路径和文件名：");
            path = Console.ReadLine();
            path.Replace('\\', '/');

            fs = new FileStream("result.txt", FileMode.Create);
            sw = new StreamWriter(fs);

            //开始写入文件
            sw.WriteLine("遍历结果如下：");
            sw.WriteLine(path);

            listDirectory(path, leval);

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            Console.WriteLine("请按任意键继续……");
            Console.ReadKey();
        }

        /// <summary>
        /// 列出path路径对应的文件夹中的子文件夹和文件
        /// 然后再递归列出子文件夹内的文件和文件夹
        /// </summary>
        /// <param name="path">需要列出内容的文件夹的路径</param>
        /// <param name="leval">当前递归层级，用于控制输出前导空格的数量</param>
        private static void listDirectory(string path, int leval)
        {
            DirectoryInfo theFolder = new DirectoryInfo(@path);

            leval++;

            //遍历文件
            foreach (FileInfo NextFile in theFolder.GetFiles())
            {
                for (int i = 0; i < leval; i++) sw.Write('\t');
                sw.Write("-->");
                sw.WriteLine(NextFile.Name);
            }

            //遍历文件夹
            foreach (DirectoryInfo NextFolder in theFolder.GetDirectories())
            {
                for (int i = 0; i < leval; i++) sw.Write('\t');
                sw.Write("--)");
                sw.WriteLine(NextFolder.Name);
                listDirectory(NextFolder.FullName, leval);
            }
        }
    }
}
