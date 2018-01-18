using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour {
    private Transform player;
    private GameObject other;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
	}	
	// Update is called once per frame
	void Update () {
        Vector3 dir = -transform.position + player.position;
        Ray ray = new Ray(transform.position,dir.normalized);
        RaycastHit hit;
        //Physics.BoxCast    Physics.SphereCast
            
        if(Physics.Raycast(ray,out hit)){
            if (hit.collider.tag!="Player")
            {
                if (other&&hit.collider.name!=other.name)
                {
                    other.SetActive(true);
                }
                hit.collider.gameObject.SetActive(false);
                other = hit.collider.gameObject;
            }
        }
	}
}
