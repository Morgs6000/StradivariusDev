using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
        if(transform.childCount == 0) {
            Item item = eventData.pointerDrag.GetComponent<Item>();
            item.setParrentAfterDrag = transform;
        }
    }
}
