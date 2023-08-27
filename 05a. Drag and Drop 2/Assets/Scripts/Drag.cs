using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    private void Start() {
        
    }

    private void Update() {
        UpdateDrag();
    }

    private void UpdateDrag() {
        if(transform.childCount == 1) {
            Item item = GetComponentInChildren<Item>();
            item.OnDragging();

            if(!EventSystem.current.IsPointerOverGameObject()) {
                if(Input.GetMouseButton(0)) {
                    item.OnEndDragging();
                }
            }
        }        
    }
}
