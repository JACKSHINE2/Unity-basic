using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 第一种UI事件的检测方式
/// </summary>
public class ButtonClick : MonoBehaviour {

    private bool flag = false;
    public void OnTestButtonClick()
    {
        print("Button按下");
    }
    public void OnTestValueChange()
    {
        flag = !flag;
        print("值被修改:" + flag);
    }
}
