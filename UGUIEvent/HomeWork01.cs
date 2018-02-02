using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 注册面板
/// </summary>
public class HomeWork01 : MonoBehaviour {

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
    
    public void OnRegisterClick()
    {
        mPanel_RegisterMeg.SetActive(true);
        registerMessager.text = TestMessager();
    }
    public void OnClickClose()
    {
        mPanel_RegisterMeg.SetActive(false);
    }
   
    /// <summary>
    /// 输出注册信息面板的信息
    /// </summary>
    /// <returns></returns>
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
            ||string.IsNullOrEmpty(mText_Mail.text))
            return RegisterMessager.registerLossMeg;
        //如果两次输入的密码不一样
        if (cPassword != password)
            return RegisterMessager.cPasswordLossMeg;
        //都对   
        else
            return RegisterMessager.registerYMeg;
    }
}
public struct RegisterMessager
{
    /// <summary>
    /// 登陆失败信息
    /// </summary>
    public const string registerLossMeg = "账号，密码，邮箱不能为空";
    /// <summary>
    /// 密码校验失败信息
    /// </summary>
    public const string cPasswordLossMeg = "两次输出的密码不相同";
    /// <summary>
    /// 注册成功信息
    /// </summary>
    public const string registerYMeg = "注册成功";
}
