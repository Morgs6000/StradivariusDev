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

    [SerializeField] private EnumSlotTag enumSlotTag = EnumSlotTag.NONE;
    [SerializeField] private int armorType;

    private void Awake() {
        //drag = FindObjectOfType<Drag>();
        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemRenderer");
        
        image = GetComponent<Image>();
    }

    private ItemRenderer getItem() {
        return Drag.Instance.GetComponentInChildren<ItemRenderer>();
    }

    public EnumSlotTag getEnumSlotTag() {
        return this.enumSlotTag;
    }

    public void OnPointerDown(PointerEventData eventData) {
        //*
        if(enumSlotTag != EnumSlotTag.NONE && Item.dictionaryTextualID[getItem().getTextualID()].getEnumSlotTag(armorType) != enumSlotTag) {
            return;
        }
        //*/
        if(Drag.Instance.transform.childCount == 1) {
            DropFullStack();
            DropOneStack();
        }
    }

    private void OnDropping() {
        if(transform.childCount == 0) {
            //ItemRenderer itemOnDrag = Drag.Instance.GetComponentInChildren<ItemRenderer>();
            getItem().setParrentAfterDrag(transform);

            getItem().OnEndDragging();
        }
    }

    private void DropFullStack() {
        if(Input.GetMouseButtonDown(0)) {
            OnDropping();
        }
    }

    private void DropOneStack() {
        //ItemRenderer itemOnDrag = Drag.Instance.GetComponentInChildren<ItemRenderer>();

        if(Input.GetMouseButtonDown(1)) {
            if(getItem().getCurrentStackSize() <= 1) {
                OnDropping();
            }
            else {
                GameObject newItem = Instantiate(itemPrefab, transform);

                ItemRenderer itemInSlot = newItem.GetComponent<ItemRenderer>();
                itemInSlot.InitialiseItem(Item.dictionaryTextualID[getItem().getTextualID()]);

                string name = getItem().getItemName();
                newItem.name = StringManager.Instance.GetString(name);

                int result = getItem().getCurrentStackSize() - 1;
                getItem().setCurretnStackSize(result);
                getItem().RefreshStack();

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

public enum EnumSlotTag {
    NONE,
    HELMET,
    CHESTPLATE,
    LEGGINGS,
    BOOTS
}
