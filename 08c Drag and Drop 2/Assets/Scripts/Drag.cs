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

        /*
        if(EventSystem.current.IsPointerOverGameObject()) {
            Debug.Log("O mouse esta sobre um objeto");

            if(EventSystem.current.currentSelectedGameObject) {
                Debug.Log("currentSelectedGameObject");
            }
            if(EventSystem.current.currentSelectedGameObject.GetComponent<Slot>()) {
                Debug.Log("O mouse esta sobre um slot");
            }
            if(EventSystem.current.currentSelectedGameObject.GetComponent<Item>()) {
                Debug.Log("O mouse esta sobre um item");
            }
        }
        */
    }

    private void DragUpdate() {
        if(transform.childCount == 1) {
            item = GetComponentInChildren<Item>();

            item.OnDragging();

            if(!EventSystem.current.IsPointerOverGameObject()) {
                // NOTA: Da pra fazer um Axis para usar os dois botões do mouse
                if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape)) {
                    if(item.setParrentAfterDrag.transform.childCount == 0) {
                        item.OnEndDragging();
                    }
                }
            }
        }
    }
}
