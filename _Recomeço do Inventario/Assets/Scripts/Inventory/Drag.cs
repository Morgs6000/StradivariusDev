using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    public static Drag Instance;

    //private InventoryManager inventoryManager;

    private void Awake() {
        Instance = this;

        //inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Start() {
        
    }

    private void Update() {
        UpdateDrag();
    }

    private void UpdateDrag() {
        OnDragging();
        OnEndDragging();
        DestroyDrag();
    }

    private void OnDragging() {
        if(transform.childCount == 1) {
            ItemRenderer itemRenderer = GetComponentInChildren<ItemRenderer>();
            itemRenderer.OnDragging();
        }
    }

    private void OnEndDragging() {
        if(transform.childCount == 1) {
            ItemRenderer itemRenderer = GetComponentInChildren<ItemRenderer>();

            if(!EventSystem.current.IsPointerOverGameObject()) {
                if(Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape)) {
                    if(itemRenderer.getParrentAfterDrag().transform.childCount == 0) {
                        itemRenderer.OnEndDragging();
                    }
                    else {
                        foreach(Slot slot in InventoryManager.Instance.getSlots()) {
                            ItemRenderer itemRenderer1 = slot.GetComponentInChildren<ItemRenderer>();

                            if(!itemRenderer1) {
                                itemRenderer.setParrentAfterDrag(slot.transform);
                                itemRenderer.OnEndDragging();

                                return;
                            }
                        }
                    }
                }
            }
        }
    }

    private void DestroyDrag() {
        if(transform.childCount == 1) {
            ItemRenderer itemRenderer = GetComponentInChildren<ItemRenderer>();

            if(itemRenderer.getCurrentStackSize() <= 0) {
                Destroy(itemRenderer.gameObject);
            }
        }
    }
}
