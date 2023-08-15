using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    private InventoryManager inventoryManager;

    private void Awake() {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

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
                if(Input.GetMouseButtonDown(0)) {
                    foreach(Slot slot in inventoryManager.slots) {
                        Item item1 = slot.GetComponentInChildren<Item>();

                        if(!item1) {
                            item.parrentAfterDrag = slot.transform;
                            item.OnEndDragging();

                            return;
                        }
                    }
                }
            }
            if(item.stack == 0) {
                Destroy(item.gameObject);
            }
        }        
    }
}
