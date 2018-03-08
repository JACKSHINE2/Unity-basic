using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;



public  struct Index
{
    public string des;
    public string tipt;
    public string title;
    public string zs;
}

public struct Weather
{
    public string date;
    public string dayPictureUrl;
    public string nightPictureUrl;
    public string weather;
    public string wind;
    public string temperature;
    
}
public class JsonWrite : MonoBehaviour {
    public string path;
    WWW www;
    public string api = "http://api.map.baidu.com/telematics/v3/weather?location= 成都&output=json&ak=G0dStAGfFDOfwPYGagYt8FDKNKw2lRE1";
    Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
    IEnumerator Start()
    {
        //  CreatJson1();
        //  CreatJsonArray();
        // File.WriteAllText(路径，字符串(内容))
        //  File.Create(//路径+后缀  .txt);
        //{[TowerMessager:{[TowerRocket:{}]}] }
         www = new WWW(api);
        yield return www;
        print(www.text);
        path = Path.Combine(Application.streamingAssetsPath, path);
        File.WriteAllText(path, www.text);
        ReadTxt();
    }
    public void ReadTxt()
    {
        string[] allLine=null;
        string[] element = null;
        string mainKey=null;
        string subKey=null;
        string subValue=null;
        allLine = File.ReadAllLines(path);

        JsonData jsonData = JsonMapper.ToObject(www.text);
        print(jsonData["error"]);

    }

    public void CreateJson()
    {
        //申明json写入对象,花括号
        JsonWriter writer = new JsonWriter();
        //第一种{对象写入}
        writer.WriteObjectStart();
        writer.WritePropertyName("Attack");
        writer.Write("10");
        writer.WritePropertyName("AttackRange");
        writer.Write("100");
        writer.WritePropertyName("BulletName");
        writer.Write("CubeBullet");
        //结束json对象写入
        writer.WriteObjectEnd();
        print(writer.ToString());
        //
    }

    public void CreateJson1()
    {
        //创建复合对象
        JsonWriter writer = new JsonWriter();
        //第一种{对象写入}
        writer.WriteObjectStart();
        writer.WritePropertyName("Tow_Rocket");
        writer.WriteObjectStart();
        writer.WritePropertyName("Attack");
        writer.Write("10");
        writer.WritePropertyName("AttackRange");
        writer.Write("100");
        writer.WritePropertyName("BulletName");
        writer.Write("CubeBullet");
        //结束json对象写入
        writer.WriteObjectEnd();
        writer.WriteObjectEnd();
        print(writer.ToString());
    }

    public void CreateJsonArray() {
        //第二种{数组写入} ,方括号
        //声明Json写入对象
        JsonWriter writer = new JsonWriter();

        writer.WriteObjectStart();
        writer.WritePropertyName("TowerRocket");

        writer.WriteArrayStart();

        writer.WriteObjectStart();
        writer.WritePropertyName("AttackRange");
        writer.Write("100");
        writer.WritePropertyName("BulletName");
        writer.Write("CubeBullet");
        writer.WriteObjectEnd();

        writer.WriteArrayEnd();

        writer.WriteObjectEnd();
        print(writer.ToString());
        //  JsonWrite writer1 = new JsonWrite();
    }

    

    void CreateJson2()
    {
        JsonData data = new JsonData();
        data["TowerRocket"] = new JsonData();
        data["TowerRocket"]["Attack"] = "100";
        data["TowerRocket"]["AttackRange"] = "10";
        data["TowerRocket"]["AttackInterval"] = "2";
        print(data.ToJson());
    }

    ////IO
    //链接：本地文件 file：// D:DD
    //    网络  http：//

    // Update is called once per frame
    void Update () {
		
	}
}
