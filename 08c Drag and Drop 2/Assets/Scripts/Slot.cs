using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {
    //private GameObject drag;
    private Drag drag;

    private void Awake() {
        //onDrag = GameObject.Find("Drag");
        drag = FindObjectOfType<Drag>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(drag.transform.childCount == 1) {
            OnDropping();
        }
    }

    private void OnDropping() {
        if(transform.childCount == 0) {
            Item item = drag.GetComponentInChildren<Item>();
            item.setParrentAfterDrag = transform;

            item.OnEndDragging();
        }
        /*
        else {
            Item item2 = transform.GetComponentInChildren<Item>();
            item2.OnBeginDragging();
        }
        */
    }
}
