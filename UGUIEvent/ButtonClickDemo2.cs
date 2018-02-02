using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickDemo2 : EventTrigger {
    /// <summary>
    /// 名字text
    /// </summary>
    public InputField mText_Name;
    /// <summary>
    /// 密码text
    /// </summary>
    public InputField mText_Password;
    /// <summary>
    /// 邮箱
    /// </summary>
    public InputField mText_Mail;
    /// <summary>
    /// 确认密码的text
    /// </summary>
    public InputField mText_CPassword;
    /// <summary>
    /// 显示注册信息的面板
    /// </summary>
    public GameObject mPanel_RegisterMeg;
    /// <summary>
    /// 需要显示的信息
    /// </summary>
    public Text registerMessager;

    /// <summary>
    /// 修改注册面板的text
    /// </summary>
    /// 
  
    public void Start()
    {
        //1.获取InputFiled   
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Test");
        mText_Name = Find(objs, "InputField_Name").GetComponent<InputField>();
        mText_Password = Find(objs, "InputField_Password").GetComponent<InputField>();
        mText_CPassword = Find(objs, "InputField_CPassword").GetComponent<InputField>();
        mText_Mail = Find(objs, "InputField_Mail").GetComponent<InputField>();
        registerMessager = Find(objs, "Text").GetComponent<Text>();
        mPanel_RegisterMeg = Find(objs, "Panel_RegisterMeg");
        mPanel_RegisterMeg.SetActive(false);
    }
    private GameObject Find(GameObject[] objs,string mUIName)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].name == mUIName)
                return objs[i];
        }
        return null;
    }
    public void OnRegisterClick()
    {
        mPanel_RegisterMeg.SetActive(true);
        registerMessager.text = TestMessager();
    }

    private string TestMessager()
    {
        //常量  配置文件
        //获取所有面板的text
        string password = mText_Password.text;
        string cPassword = mText_CPassword.text;
        // mText_Name.text == ""||mText_Name.text==null
        //检测他们是否为空  如果账号，密码或者邮箱当中其中一项为空 
        if (string.IsNullOrEmpty(mText_Name.text) || string.IsNullOrEmpty(
          password) || string.IsNullOrEmpty(cPassword)
            || string.IsNullOrEmpty(mText_Mail.text))
            return RegisterMessager.registerLossMeg;
        //如果两次输入的密码不一样
        if (cPassword != password)
            return RegisterMessager.cPasswordLossMeg;
        //都对   
        else
            return RegisterMessager.registerYMeg;
    }
   

    public override void OnPointerClick(PointerEventData eventData)
    {
        OnRegisterClick();
    }
}

  

    

