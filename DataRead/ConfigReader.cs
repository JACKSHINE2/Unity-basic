using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class ConfigReader1 : MonoBehaviour {
    string path = "Invoke.txt";
	// Use this for initialization
	void Start () {
        //1.文件真实路径
        path = Path.Combine(Application.streamingAssetsPath,path);
        //2.读取所有内容
        print(File.ReadAllText(path));
        //3.每一行进行读取
        //string[] str = File.ReadAllLines(path);
        //for (int i = 0; i < str.Length; i++)
        //{
        //    print(str[i]);
        //}
        ////4.字节读取，移动端
        //byte[] buffer = File.ReadAllBytes(path);
        //string item = Encoding.UTF8.GetString(buffer);
        //print(item);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
