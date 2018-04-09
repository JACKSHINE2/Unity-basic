using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public static class Hero
{
    public static int Hp;
    public static int Mp;
    public static int Att;
    public static int Def;
    public static int Coin;
    public static int Inte;
}
   


public class InforShow : EventTrigger {
    string path = "Goods.txt";
    Transform inforShow;
    string[] info;
    Text message;
    int liner;
    string[] str;
    int value;
    // Use this for initialization
    void Start () {
        inforShow = GameObject.FindWithTag("Finish").transform.GetChild(1);
        message = inforShow.GetChild(0).GetComponent<Text>();
        inforShow.gameObject.SetActive(false);
        path = Path.Combine(Application.streamingAssetsPath,path);
        info = File.ReadAllLines(path);
        liner = gameObject.name[5] - 48;
        str = info[liner].Split(',');
        value = int.Parse(str[2]);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        inforShow.gameObject.SetActive(true);
        inforShow.position = Input.mousePosition;
        message.text = info[liner];
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        inforShow.gameObject.SetActive(false);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        switch(liner)
        {
            case 1:
                {
                    Hero.Hp += value;
                    break;
                }
            case 2:
                {
                    Hero.Mp += value;
                    break;
                }
            case 3:
                {
                    Hero.Def += value;
                    break;
                }
            case 4:
                {
                    Hero.Coin += value;
                    break;
                }
            case 5:
                {
                    Hero.Inte += value;
                    break;
                }
            case 6:
                {
                    Hero.Att += value;
                    break;
                }
        }


    }


    // Update is called once per frame
    void Update () {
        inforShow.position = Input.mousePosition;

    }
}
