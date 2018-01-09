using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFunc : MonoBehaviour {
    Color orgColor;
    float z;
    Vector3 offest;

	void Start () {
        orgColor = GetComponent<MeshRenderer>().material.color;
	}
	
	void Update () {
	}

    private void OnMouseDown()
    {
        //transform.localScale += new Vector3(1,0,0);
        print("OnMouseDown");
        //calculate the offset in world  between mousePosition and transformPosition
        z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 pos1 = new Vector3(Input.mousePosition.x,Input.mousePosition.y,z);
        Vector3 pos2 = Camera.main.ScreenToWorldPoint(pos1);
        offest = transform.position - pos2;
    }
    private void OnMouseUp()
    {
        print("OnMouseUp");
    }
    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = orgColor;
    }
    private void OnMouseDrag()
    {
        print("OnMouseDrag");
        //transform the position of mousePosition on screen to the world
        z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 orgPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,z);
        Vector3 point = Camera.main.ScreenToWorldPoint(orgPosition);
        transform.position = new Vector3(point.x+offest.x,point.y+offest.y,transform.position.z);
    }
}
