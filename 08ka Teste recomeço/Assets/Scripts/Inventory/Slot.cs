using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    //private Drag drag;

    private GameObject itemPrefab;
    
    private Image image;
    //private bool onEnter;

    private void Awake() {
        //drag = FindObjectOfType<Drag>();
        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemRenderer");
        
        image = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(Drag.Instance.transform.childCount == 1) {
            DropFullStack();
            DropOneStack();
        }
    }

    private void OnDropping() {
        if(transform.childCount == 0) {
            ItemRenderer itemOnDrag = Drag.Instance.GetComponentInChildren<ItemRenderer>();
            itemOnDrag.setParrentAfterDrag(transform);

            itemOnDrag.OnEndDragging();
        }
    }

    private void DropFullStack() {
        if(Input.GetMouseButtonDown(0)) {
            OnDropping();
        }
    }

    private void DropOneStack() {
        ItemRenderer itemOnDrag = Drag.Instance.GetComponentInChildren<ItemRenderer>();

        if(Input.GetMouseButtonDown(1)) {
            if(itemOnDrag.getCurrentStackSize() <= 1) {
                OnDropping();
            }
            else {
                GameObject newItem = Instantiate(itemPrefab, transform);

                ItemRenderer itemInSlot = newItem.GetComponent<ItemRenderer>();
                itemInSlot.InitialiseItem(Item.dictionaryTextualID[itemOnDrag.getTextualID()]);

                string name = itemOnDrag.getItemName();
                newItem.name = StringManager.Instance.GetString(name);

                int result = itemOnDrag.getCurrentStackSize() - 1;
                itemOnDrag.setCurretnStackSize(result);
                itemOnDrag.RefreshStack();

                itemInSlot.setCurretnStackSize(1);
                //itemInSlot.RefreshStack();
            }
        }
    }

    /*
    public bool getOnEnter() {
        return this.onEnter;
    }
    */

    public void OnPointerEnter(PointerEventData eventData) {
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        //onEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        //onEnter = false;
    }
}
