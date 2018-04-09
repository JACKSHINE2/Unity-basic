using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Text;

public class MobileRead : MonoBehaviour
{
    string path = "/Tip.txt";
    string path1;
    public Text show;
    
    //在移动端发布 txt GUI


    // Use this for initialization
    void Start()
    {

        //window端
        //path = Path.Combine(Application.streamingAssetsPath, path);
        path = Application.streamingAssetsPath + path;
        print(path);

        //byte[] butter = File.ReadAllBytes(path);
        //string item = Encoding.UTF8.GetString(butter);
        //string item = File.ReadAllText(path);
        //show.text = item;
        //show.text = Application.streamingAssetsPath + "[][][][]" + Application.dataPath;

#if UNIYT_ENDITOR
         path = Application.streamingAssetsPath + "/";
        //从本地加载
        AssetBundle assets = AssetBundle.LoadFromFile("D:/MyProject/AssetsBundle/cube.unity3d");
        //AssetBundle assets1=AssetBundle.LoadFromFileAsync
        // SceneManager.LoadScene();
        // SceneManager.LoadSceneAsync();
        AssetBundle assets1 = AssetBundle.LoadFromFile("D:/MyProject/AssetsBundle/material.unity3d");
        GameObject[] objs = assets.LoadAllAssets<GameObject>();
        for (int i = 0; i < objs.Length; i++)
        {
            for (int n =0; n < 10; n++)
            {
                Instantiate(objs[i], Vector3.zero, new Quaternion(0, 0, 0, 0));
                m++;
            }
        
        }
#elif UNITY_ANDROID
        //安卓端
        //path = jar:file:///data/app/Application.dataPath/!/assets;

        //File.Copy("Tip.txt", Application.persistentDataPath);
        //android 的路径
        //jar：file:///data/app/xxx.xxx.xxxx
        //           Appplication.dataPath;
        //path = Application.streamingAssetsPath + "/" + path;

        // WWW www

        //1.将所有的配置文件复制一份到persistentDataPath


        //2.以后所有数据读取和写入都在persistentDataPath



#elif UNITY_IPONE
#endif
    }

    //public IEnumerator CopyStearm()
    //{
    //    WWW www = new WWW()
    //}

    // Update is called once per frame
    IEnumerator Read()
    {
        WWW www = new WWW(Application.streamingAssetsPath + path);
        yield return www;
        if (www.error==null)
        {
            FileInfo fi = new FileInfo(Application.persistentDataPath + path);
            //判断文件是否存在,如果不存在
            if (!fi.Exists)
            {
                //流文件fs
                FileStream fs = fi.OpenWrite();

                fs.Write(www.bytes, 0, www.bytes.Length);

                fs.Flush();

                fs.Close();

                fs.Dispose();
            }
            show.text = File.ReadAllText(Application.persistentDataPath + path);
        }
    }

    void Update()
    {

    }
    public void OnGUI()
    {
    }
}
