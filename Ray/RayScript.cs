using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour {
    Vector3 target;
	// Use this for initialization
	void Start () {
        target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    print(hit.collider.name);
        //}

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    print(hit.collider.name);
            //    target = new Vector3(hit.point.x,0.5f,hit.point.z);
            //}
            RaycastHit[] hitArray = Physics.RaycastAll(ray, 15);
            foreach (var a in hitArray)
            {
                print(a.collider.name);
            }
            Debug.DrawLine(Camera.main.transform.position, hitArray[hitArray.Length - 1].transform.position, Color.green);
        }
        //transform.position = Vector3.Lerp(transform.position, target,Time.fixedDeltaTime * 2);
    }
}
