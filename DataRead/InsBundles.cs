using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class InsBundles : MonoBehaviour
{
        //assetsBundle加载资源的几种方式  
        /// <summary>
        ///1.同步本地加载   不需要IEnumerator，不需要请求
        /// </summary>
        void Start()
    {
        //AssetBundle assets = AssetBundle.LoadFromFile("AssetsBundle/cube");  //同步
        //GameObject[] objs = assets.LoadAllAssets<GameObject>();
        //for (int i = 0; i < objs.Length; i++)
        //{
        //    Instantiate(objs[i]);
        //}


        //string path1 = "AssetsBundle/cube";
        //AssetBundle ab1 = AssetBundle.LoadFromMemory(File.ReadAllBytes(path1));
        ////  AssetBundle assets = AssetBundle.LoadFromFile("AssetsBundle/cube");  同步
        //GameObject[] obj1 = ab1.LoadAllAssets<GameObject>();
        //for (int i = 0; i < obj1.Length; i++)
        //{
        //    Instantiate(obj1[i]);
        //}

        //协程 异步本地
        //StartCoroutine(Start1());
        //StartCoroutine(Start2());
        //StartCoroutine(Start3());
        //StartCoroutine(Start4());
        Start5();

    }

    /// <summary>
    ///2.异步本地加载    需要IEnumerator
    /// </summary>
    /// <returns></returns>
    IEnumerator Start1()
    {
        string path1 = "AssetsBundle/cube";
        //AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path1);
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path1));
        yield return request;
        AssetBundle ab = request.assetBundle;
        GameObject obj = ab.LoadAsset<GameObject>("cube");  //加载了cube这个集合的资源
        //GameObject obj = ab.LoadAsset<GameObject>("cube.prefab");  //加载了一个cub.prefab的资源
        Instantiate(obj);
    }


    /// <summary>
    ///3.cache会根据相应的本地或网络下载，已下载过就调用起本地位置，未下载即从相应网址下载
    /// </summary>
    
    //从本地文件中访问
    IEnumerator Start2() {
        WWW www = WWW.LoadFromCacheOrDownload(@"file://C:\Users\God\Desktop\Unity\AssetsBundle\sphere", 4);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
            yield break;
        }

        AssetBundle ab = www.assetBundle;
        GameObject obj = ab.LoadAsset<GameObject>("sphere.prefab");
        Instantiate(obj);

    }

    //从本地服务器访问
    IEnumerator Start3() {
        WWW www = WWW.LoadFromCacheOrDownload(@"file:///C:/Users/God/Desktop/Unity/AssetsBundle/sphere", 1);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
            yield break;
        }
        
            AssetBundle ab = www.assetBundle;
            GameObject obj = ab.LoadAsset<GameObject>("sphere.prefab");
            Instantiate(obj);        
    }

    /// <summary>
    /// 从服务器下载资源，UnityWebRequest 可以替代WWW类
    /// </summary>

    IEnumerator Start4() {
        UnityWebRequest webRequest = UnityWebRequest.GetAssetBundle(@"file:///C:/Users/God/Desktop/Unity/AssetsBundle/sphere");
        yield return webRequest.Send();
        AssetBundle ab = (webRequest.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        GameObject obj = ab.LoadAsset<GameObject>("sphere.prefab");
        Instantiate(obj);
    }
    

    /// <summary>
    /// 获取manifest中文件中的内容
    /// </summary>
    // Update is called once per frame
    void Start5()
    {
        AssetBundle ab = AssetBundle.LoadFromFile("AssetsBundle/AssetsBundle");
        AssetBundleManifest abm = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //获取manifest文件中打包资源的名称
        foreach (var item in abm.GetAllAssetBundles())
        {
            print(item);
        }
        //获取cube资源包依赖文件的名称
        string[] name = abm.GetAllDependencies("cube");
        foreach (var item in name)
        {
            print(item);

        }


    }
    void Update()
    {

    }
}
