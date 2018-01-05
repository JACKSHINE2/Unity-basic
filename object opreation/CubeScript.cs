using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScript : MonoBehaviour {
    //[SerializeField]     // 序列化
    public Transform parent;
    //[HideInInspector] //特性
    public float speed = 3;
    float starttime = 0;
    Vector3 dir;
    public float angelSpeed;
    // Use this for initialization
    void Start () {
        //transform.position      相对于世界坐标的位置
        //transform.localtion     相对父物体的位子
        //transform.localPosition = new Vector3(1,0,0);
        //transform.Rotate();     欧拉角的旋转
        //transform.RotateAround(); //围绕一个点的一个轴转多少度
        //transform.rotation      四元素的旋转角
        //transform.localScale   缩放
        //父子关系
        //transform.parent
        //transform.SetParent(,)
        //transform.parent = null;  解绑父物体
        //transform.SetParent(null);
        //Transform parent = transform.Find("RedCube");  //只能找子物体
        parent = GameObject.Find ("RedCube").transform;
        dir = parent.position - transform.position;
        //transform.parent = parent;
        //print(parent.name);
        //print(transform.position);
        //print(transform.localPosition);
        //V3
        //Vector3.zero;
        Vector3 direction = new Vector3(2,3,4);
        //标准化
        direction.Normalize();
        Vector3 d = direction.normalized;
        //模长
        float a = direction.magnitude;
        //颜色
        //Color color = new Color(,);



        float f = Vector3.Angle(parent.position,transform.position);
        print(f);
        float e = Vector3.Dot(parent.position.normalized,transform.position.normalized);
        print(e);
        float distance = Vector3.Distance(parent.position,transform.position);
        print(distance);
        print((parent.position-transform.position).magnitude);

        //四元素
        //Quaternion qua = Quaternion.identity;
        //qua = Quaternion.LookRotation(parent.forward);
        //transform.rotation *= qua;
        //qua.eulerAngles ;  //四元素转欧拉角


    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(parent);   //一直面向
        //transform.Translate(new Vector3(0, 0, 0.02f));  //平移,默认space.self                                             
        //transform.Translate(Vector3.up* 0.02f,Space.World);
        Time.timeScale = 1;
        //transform.Translate(dir.normalized * speed * Time.deltaTime * Time.timeScale);
        starttime = Time.time;

        //transform.Translate(dir*0.002f );
        //transform.Rotate(new Vector3(0,2,0));   //欧拉旋转
        //transform.rotation *= Quaternion.Euler(new Vector3(0, 2, 0));   //四元素旋转,欧拉转四元素

        //transform.localScale += new Vector3(0, 0.1f, 0);



        Debug.DrawLine(Vector3.zero, transform.position, Color.green);
        Debug.DrawLine(Vector3.zero, parent.position, Color.green);
        //Debug.DrawRay(Vector3.zero,parent.position,Color.blue);


        //if (Vector3.Distance(transform.position, parent.position) > 0.1f)
        //{
        //    //a = a + (b-a)*f
        //    transform.position = Vector3.Lerp(transform.position, parent.position, 0.01f);
        //}
        //else
        //{
        //    transform.position = parent.position;
        //}

        //四元素
        //if (Vector3.Angle(transform.forward, parent.forward) > 0.05f)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, parent.rotation, 0.02f);
        //}
        //else
        //{
        //    transform.rotation = parent.rotation;
        //}

        //if (Time.time >=2)
        //{
        //    speed = 0;
        //}

        transform.RotateAround(parent.position, parent.up, angelSpeed*Time.deltaTime);

    }
        
}
