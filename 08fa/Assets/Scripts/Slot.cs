using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {
    private Drag drag;

    [SerializeField] private GameObject itemPrefab;

    private void Awake() {
        drag = FindObjectOfType<Drag>();
    }

    public void OnDropping() {
        if(transform.childCount == 0) {
            Item item = drag.GetComponentInChildren<Item>();
            item.parrentAfterDrag = transform;

            item.OnEndDragging();
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(drag.transform.childCount == 1) {
            if(Input.GetMouseButtonDown(0)) {
                OnDropping();
            }
            if(Input.GetMouseButtonDown(1)) {
                Item item = drag.GetComponentInChildren<Item>();

                if(item.stack <= 1) {
                    OnDropping();
                }
                else {
                    GameObject newItem = Instantiate(itemPrefab, transform);

                    Item item2 = newItem.GetComponent<Item>();
                    item2.InitialiseItem(ItemManager.items[item.itemID], item.itemID);

                    item.stack--;
                    item.RefreshCount();
                }
            }
        }
    }
}
