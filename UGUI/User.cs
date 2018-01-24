using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviour {
    public float coldTime;
    Image mask;
    bool iscolding;

    // Use this for initialization
    void Start () {

    }
	

	// Update is called once per frame
	void Update () {
        if (mask&&mask.fillAmount>0)
        {
            mask.fillAmount = Mathf.MoveTowards(mask.fillAmount, 0, Time.deltaTime / 6.0f);
        }
        else if(mask)
        {
            iscolding = false;
        }
	}

    public void SkillCool(Button sender)  //必须public
    {
        mask = sender.transform.Find("Mask").GetComponent<Image>();
        if (iscolding)
        {
            return;
        }
        else
        {
            mask.fillAmount = 1;
            iscolding = true;
        }
    }

}
