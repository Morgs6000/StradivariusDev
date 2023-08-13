using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;

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
                if(Input.GetMouseButton(0)) {
                    //if(item.parrentAfterDrag.transform.childCount == 0) {
                        //item.OnEndDragging();
                    //}
                    //else {
                        foreach(Slot slot in inventoryManager.slots) {
                            Item item2 = slot.GetComponentInChildren<Item>();

                            if(!item2) {
                                /*
                                item.transform.SetParent(slot.transform);
                                item.rawImage.raycastTarget = true;
                                */
                                item.parrentAfterDrag = slot.transform;
                                item.OnEndDragging();

                                return;
                            }
                        }
                    //}
                }
            }
            if(item.stack == 0) {
                Destroy(item.gameObject);
            }
        }        
    }
}
