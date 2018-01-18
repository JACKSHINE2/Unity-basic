using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {
    private Rigidbody mRigidbody;
	// Use this for initialization
	void Start () {
        mRigidbody = GetComponent<Rigidbody>();
        
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            //设置初速度
            //mRigidbody.velocity = new Vector3(0, 10, 0);
            //mRigidbody.AddForce(0, 0, 10,ForceMode.Impulse);
            //添加力  ForceMode
            //force               f*t = m*v
            //acceleration    f*t = 1*v
            //impulse           f*1 = m*v
            //velocityChange  f*1=1*v
            //以世界坐标
            //mRigidbody.AddForceAtPosition(new Vector3(0,0,50),new Vector3 (-0.4f,0.9f,-0.4f));
            //mRigidbody.AddTorque(0,50,0);
            //以自身坐标
            //mRigidbody.AddRelativeForce(new Vector3 (0,0,50));
            //mRigidbody.AddRelativeTorque(0,50,0);
            //返回有碰撞器组件的物体
            //Collider[] colliders = Physics.OverlapSphere(mRigidbody.position, 3, 1);
            //for (int i = 0; i < colliders.Length; i++)
            //{
            //    Collider col = colliders[i];
            //    Rigidbody rig = col.GetComponent<Rigidbody>();
            //    if (rig && rig.tag != "Player")
            //    {
            //        //爆炸
            //        rig.AddExplosionForce(6, mRigidbody.position, 3, 2, ForceMode.Impulse);  //只能原地爆炸一次
            //    }
            //    else if (rig && rig.tag == "Player")
            //    {
            //        //爆炸物消失
            //        Destroy(rig.gameObject);
            //    }
            //}
            //移动到固定距离
            //mRigidbody.MovePosition(mRigidbody.position + new Vector3(0, 0, 0.5f));
            }
    }

    void Update () {
	}


    //Collision是碰撞信息
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Sphere")
        {
            print("OnCollisionEnter");
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
     }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            print("OnCollisionStay");
        }
     }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            print("OncollisionExit");
        }
     }
}
