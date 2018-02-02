using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCloseEvent : EventTrigger {

    public GameObject megPanle;
    public override void OnPointerClick(PointerEventData eventData)
    {
        megPanle.SetActive(false);
    }
}
