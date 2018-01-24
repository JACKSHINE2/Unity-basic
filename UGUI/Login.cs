using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
    public InputField username;
    public InputField password;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LogIn()
    {
        if (username.text=="Jack"&&password.text =="2016")
        {
            print("登录成功");
            SceneManager.LoadScene(1);
        }
        else
        {
            print("账户或密码错误");
        }
    }
    public void StringChange(string str)
    {
        print(str);
    }
    public void EndEdit(string str)
    {
        print("End:"+str);
    }


}
