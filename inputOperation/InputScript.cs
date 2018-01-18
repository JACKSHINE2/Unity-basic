using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Input类
        if (Input.GetKey(KeyCode.A))
        {
            print("getkey");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("GetKeyDown");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            print("GetKeyUp");
        }
        //if (Input.GetButton("Jump"))
        //{
        //    print("jump");
        //}
        float hor = Input.GetAxis("Horizontal");   //水平方向
        float ver = Input.GetAxis("Vertical");      //竖直方向
        print("hor="+hor+" ver="+ver);

        float jump = Input.GetAxis("Jump");
        print(jump);

        //print( Input.mousePosition);
        if(Input.GetMouseButton(0))  //0是左键 ，1是右键，2滚轮
        {
            print("持续按下鼠标左键");
        }
        //鼠标位移和滚轮
        float a = Input.GetAxis("Mouse X");
        print("a="+a);
        float b = Input.GetAxis("Mouse ScrollWheel");
        print(" b="+b);
        //触摸的点和次数
        int c = Input.touchCount;
        Touch[] touchu = Input.touches;
    }
}
