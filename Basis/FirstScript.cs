using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour {
	//唤醒，只执行一次
	void Awake(){
		Debug.Log ("Awake");
        //当前脚本组件挂靠的游戏对象
        Debug.Log (gameObject.name);
	}
	//当可用时
	void OnEnable(){
		Debug.Log ("OnEnble");
	}

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        //获取当前脚本组件挂靠的游戏物体的特定类型组件
        GetComponent<Transform>();
        Collider collider = GetComponent<Collider>();  //碰撞器组件，是引用类型
        //collider.enabled = false;

    }

    //物理更新，固定0.02s，可修改
    void FixedUpdate(){
		Debug.Log ("FixedUpdate");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Update");
	}
	void LateUpdate(){
		Debug.Log ("LateUpdate");
	}
	void OnGUI(){
		Debug.Log ("OnGUI");
	}
	void OnDisable(){
		Debug.Log ("OnDisable");
	}
    //当被销毁或退出时
    void OnDestroy()
    {
        Debug.Log("OnDestory");
    }
}
