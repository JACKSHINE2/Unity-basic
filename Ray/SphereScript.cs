using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
    }
    private void OnTriggerStay(Collider other)
    {
        print("OnTriggerStay");
    }
    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit");
    }
}
