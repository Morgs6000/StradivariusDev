using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;

    private void Awake() {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Update() {
        UpdateDrag();
    }

    private void UpdateDrag() {
        if(transform.childCount == 1) {
            Item item = GetComponentInChildren<Item>();
            item.OnDragging();

            if(!EventSystem.current.IsPointerOverGameObject()) {
                // NOTA: Da pra fazer um Axis para usar os dois botões do mouse
                if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape)) {
                    if(item.parrentAfterDrag.transform.childCount == 0) {
                        item.OnEndDragging();
                    }
                    else {
                        foreach(Slot slot in inventoryManager.slots) {
                            Item item2 = slot.GetComponentInChildren<Item>();

                            if(!item2) {
                                item.transform.SetParent(slot.transform);
                                item.rawImage.raycastTarget = true;

                                return;
                            }
                        }
                    }
                }
            }
        }        
    }
}
