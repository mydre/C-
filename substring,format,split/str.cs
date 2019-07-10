                s1 = path_filename.Substring(0,index);
                s2 = path_filename.Substring(index + 1);

                string path_mp3 = string.Format("{0}.{1}",s1,"mp3");


		string[] sArray = path_filename.Split('.');
         	   int len = sArray.Length;

          	  //Console.WriteLine(sArray[len-1]);
          	  string postfix = sArray[len - 1];