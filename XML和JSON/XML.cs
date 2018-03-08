using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class XML : MonoBehaviour {

    public string path;
    public string txtPath;
    public string xmlPath;
	// Use this for initialization
	void Start () {
        path = Path.Combine(Application.streamingAssetsPath, path);
        txtPath = Path.Combine(Application.streamingAssetsPath, txtPath);
        xmlPath = Path.Combine(Application.streamingAssetsPath, xmlPath);
        //CreateXml(path);
        //WriteXml(txtPath, xmlPath);
    }
	
    public void CreateXml(string path)
    {
        if (File.Exists(path)) return;
        XmlDocument xmlDoc = new XmlDocument();

        //根节点
        XmlElement root = xmlDoc.CreateElement("MessagerConfigTable");

        //一级节点
        XmlElement oneLive = xmlDoc.CreateElement("TowerMessager");
        oneLive.SetAttribute("name", "Tow_Rocket");

        //二级节点
        XmlElement attack = xmlDoc.CreateElement("Attack");
        attack.InnerText = "100";
        XmlElement attackRange = xmlDoc.CreateElement("AttackRange");
        attackRange.InnerText = "10";
        XmlElement attackInterval = xmlDoc.CreateElement("AttackInterval");
        attackInterval.InnerText = "1";

        //将节点保存往上存
        oneLive.AppendChild(attack);
        oneLive.AppendChild(attackRange);
        oneLive.AppendChild(attackInterval);
        root.AppendChild(oneLive);
        xmlDoc.AppendChild(root);
        xmlDoc.Save(path);
    }


    //public void ReadXml(string path)
    //{
    //    if (!File.Exists(txtPath) || File.Exists(xmlPath)) return;
    //    XmlDocument xmldoc = new XmlDocument();
    //    xmldoc.Load(path);
    //    XmlElement lists = (XmlElement)xmldoc.SelectSingleNode("MessagerConfigTable");
    //    XmlElement oneLists = (XmlElement)lists.SelectSingleNode("TowerMessager");
    //    print(oneLists.Name);
    //    //选择当前节点当中名字为Attack的子节点       该节点的值
    //    print(oneLists.SelectSingleNode("Attack").InnerText);
    //    print(oneLists.SelectSingleNode("AttackRange").InnerText);
    //    print(oneLists.SelectSingleNode("AttackInterval").InnerText);
    //}


    public Dictionary<string,Dictionary<string,string>> ReadXml(string xmlPath)
    {
        if (!File.Exists(xmlPath)) return null;
        Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlPath);

        //获取xml文件当中所有的根节点（比如塔的信息，子弹信息）
        XmlNodeList list = xmlDoc.ChildNodes;
        XmlElement root = null;
        XmlNodeList oneLive = null;
        XmlNodeList twoLive = null;
        string oneLiveKey = null;
        string twoLiveKey = null;
        string twoLiveValue = null;
        for (int i = 0; i < list.Count; i++)
        {
            root = list[i] as XmlElement;
            if (root.Name==xmlPath)
            {
                oneLive = root.ChildNodes;
                for (int j = 0; j < oneLive.Count; j++)
                {
                    oneLiveKey = oneLive[j].Name;
                    dic.Add(oneLiveKey, new Dictionary<string, string>());
                    twoLive = oneLive[j].ChildNodes;
                    print("一级节点名称为：" + oneLiveKey);

                    for (int k = 0; k < twoLive.Count; k++)
                    {
                        twoLiveKey = twoLive[k].Name;
                        twoLiveValue = twoLive[k].InnerText;
                        dic[oneLiveKey].Add(twoLiveKey, twoLiveValue);
                    }
                }
            }
        }
        return dic;
    }




    public void WriteXml(string txtPath,string xmlPath)
    {
        if (!File.Exists(txtPath) || File.Exists(xmlPath)) return;
        string[] towerMessage=File.ReadAllLines(txtPath);
        string towerName=null;
        string towerAttribute = null;
        string towerAttributeValue = null;
        string line=null;
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement("TowerMessager");
        XmlElement oneLive = null;
        XmlElement twoLive = null;
        for (int i = 0; i < towerMessage.Length; i++)
        {
            line = towerMessage[i].Trim();
            if (!string.IsNullOrEmpty(line))
            {
                if (line.StartsWith("["))
                {
                    towerName = line.Substring(1, line.Length - 2);
                    oneLive = xmlDoc.CreateElement(towerName);
                    root.AppendChild(oneLive);
                }
                else
                {
                    towerAttribute = line.Split('=')[0];
                    towerAttributeValue = line.Split('=')[1];
                    twoLive = xmlDoc.CreateElement(towerAttribute);
                    twoLive.InnerText = towerAttributeValue;
                    oneLive.AppendChild(twoLive);
                }
            }
        }
        xmlDoc.AppendChild(oneLive);
        xmlDoc.Save(xmlPath);
    }
    void Update () {
		
	}
}
