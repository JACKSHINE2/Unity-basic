using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {
    public Text countText;
    public Image picture;
    public AudioSource audioSource;
    public Slider volumerSlider;
    public Toggle toggle;
	// Use this for initialization
	void Start () {
        //volumerSlider.onValueChanged.AddListener(ValueChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValueChange(float value)
    {
        //print(value);
        audioSource.volume = value;
    }
    public void ToggleValueChange(bool isOn)
    {
        if (isOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
