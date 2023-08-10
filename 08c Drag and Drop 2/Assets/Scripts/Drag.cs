using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    private Item item;

    private void Start() {
        
    }

    private void Update() {
        DragUpdate();
    }

    private void DragUpdate() {
        if(transform.childCount == 1) {
            item = GetComponentInChildren<Item>();

            item.OnDragging();

            if(!EventSystem.current.IsPointerOverGameObject()) {
                // NOTA: Da pra fazer um Axis para usar os dois botões do mouse
                if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape)) {
                    if(item.parrentAfterDrag.transform.childCount == 0) {
                        item.OnEndDragging();
                    }
                }
            }
        }
    }
}
