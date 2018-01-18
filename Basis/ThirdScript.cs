using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //通过name查找
        //GameObject monster = GameObject.Find("monster");
        //monster.SetActive(false);
        //Destroy(monster, 3);

        //通过tag查找一组相同tag的元素对象
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.SetActive(false);
            Destroy(player, 3);
        }
        
    }


}
