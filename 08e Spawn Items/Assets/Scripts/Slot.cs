using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {
    private Drag drag;

    private void Awake() {
        drag = FindObjectOfType<Drag>();
    }

    public void OnPointerDown(PointerEventData eventData) {        
        if(drag.transform.childCount == 1) {
            OnDropping();
        }
    }

    public void OnDropping() {
        if(transform.childCount == 0) {
            Item item = drag.GetComponentInChildren<Item>();
            item.parrentAfterDrag = transform;

            item.OnEndDragging();
        }
    }
}

