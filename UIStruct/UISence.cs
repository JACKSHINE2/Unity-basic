using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISence : MonoBehaviour {

    //递归   查找子物体的
    public void Start()
    {
        //   Transform t=  SceneHelper.FindChild(this.transform, "Label");
        //  print(t.name);
        print(SceneHelper.FindChild
            <Text>(this.transform, "Label").text);
    }
}
public class SceneHelper
{
    public static Transform FindChild(Transform item,string name)
    {
        Transform t = null;
        t = item.Find(name);
        if (t != null) return t;
        for (int i = 0; i < item.childCount; i++)
        {
            t = FindChild(item.GetChild(i),name);
            if (t != null)
                return t;
        }
        return null;
    }
    public static T FindChild<T>(Transform item, string name)
        where T : Component
    {
        Transform t = null;
        t = item.Find(name);
        if (t != null) return t.GetComponent<T>();
        for (int i = 0; i < item.childCount; i++)
        {
            t = FindChild(item.GetChild(i), name);
            if (t != null)
                return t.GetComponent<T>();
        }
        return null;
    }

}
