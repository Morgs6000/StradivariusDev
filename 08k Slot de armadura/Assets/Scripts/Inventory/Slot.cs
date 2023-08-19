using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    private Drag drag;

    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private Image image;

    [SerializeField] public EnumSlotTag enumSlotTag = EnumSlotTag.NONE;

    private void Awake() {
        drag = FindObjectOfType<Drag>();
        image = GetComponent<Image>();
    }

    public void OnDropping() {
        if(transform.childCount == 0) {
            Item item = drag.GetComponentInChildren<Item>();
            item.parrentAfterDrag = transform;

            item.OnEndDragging();
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Item item = drag.GetComponentInChildren<Item>();

        if(enumSlotTag != EnumSlotTag.NONE && item.enumSlotTag != enumSlotTag) {
            return;
        }
        //else {
            if(drag.transform.childCount == 1) {
                //Item item = drag.GetComponentInChildren<Item>();

                if(Input.GetMouseButtonDown(0)) {
                    OnDropping();
                }
                if(Input.GetMouseButtonDown(1)) {
                    if(item.stack <= 1) {
                        OnDropping();
                    }
                    else {
                        GameObject newItem = Instantiate(itemPrefab, transform);

                        Item item1 = newItem.GetComponent<Item>();
                        item1.InitialiseItem(ItemManager.items[item.itemID], item.itemID);

                        item.stack--;
                        item.RefreshCount();
                    }
                }
            }   
        //}
    }

    public void OnPointerEnter(PointerEventData eventData) {
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
}
