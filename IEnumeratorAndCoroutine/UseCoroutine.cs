using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UseCoroutine : MonoBehaviour {
    //协程主要用于等待加载图片和计时器作用
    string url = "http://www.cugb.edu.cn/uploadCms/album/20180309162101673939B.jpg";
    // Use this for initialization
    IEnumerator Start () {
        WWW www = new WWW(url);
        yield return www;
        print(www.text);
        GetComponent<MeshRenderer>().material.mainTexture = www.texture;
	}
    //Resource.load<>
    //StreamAssets
    //流  bytes  IO  File
    //沙盒路径：apk

	
	// Update is called once per frame
	void Update () {
		
	}
}
