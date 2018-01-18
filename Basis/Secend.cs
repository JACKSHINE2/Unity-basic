using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secend:MonoBehaviour {
    private void Start()
    {
        GameObject monster;
        monster = GameObject.Find("monster");
        print(monster.tag);
        //monster = GameObject.FindWithTag("Cube");
        //Destroy(gameObject);
        //gameObject.SetActive(false);
        GameObject[] gb = GameObject.FindGameObjectsWithTag("Cube");  //找一组Cube的object；

       
    }

}
