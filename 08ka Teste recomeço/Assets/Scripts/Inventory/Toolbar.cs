using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Toolbar : MonoBehaviour {
    private GameObject toolbarSlots;
    private Slot[] slots;
    private int slotIndex;

    private Transform highlight;
    private TextMeshProUGUI textMeshPro;

    private void Awake() {
        toolbarSlots = GameObject.Find("Toolbar Slots");
        slots = toolbarSlots.GetComponentsInChildren<Slot>();

        highlight = transform.Find("Highlight");
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start() {
        
    }

    private void Update() {
        KeyInputs();
        ScrollInputs();

        highlight.position = slots[slotIndex].transform.position;
        getItemName();

        if(Input.GetMouseButtonDown(1)) {
            getSelectedItem();
        }
    }

    private Toolbar setSlotIndex(int index) {
        this.slotIndex = index;
        return this;
    }

    private int getSlotIndex() {
        return this.slotIndex;
    }

    /*
    private int SlotIndex {
        get {
            return slotIndex;
        }
        set {
            slotIndex = value;
            //animator.SetTrigger("reset");
        }
    }
    */

    private void KeyInputs() {
        int result = getSlotIndex();

        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            result = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            result = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            result = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            result = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            result = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)) {
            result = 5;
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)) {
            result = 6;
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)) {
            result = 7;
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)) {
            result = 8;
        }

        setSlotIndex(result);
    }

    private void ScrollInputs() {
        int result = getSlotIndex();

        if(Input.GetAxis("Mouse ScrollWheel") > 0) {
            result = getSlotIndex() - 1;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0) {
            result = getSlotIndex() + 1;
        }

        if(result > slots.Length - 1) {
            result = 0;
        }
        if(result < 0) {
            result = slots.Length - 1;
        }

        setSlotIndex(result);
    }

    private Slot getSlot() {
        return this.slots[slotIndex];
    }

    private ItemRenderer getItem() {
        return this.getSlot().GetComponentInChildren<ItemRenderer>();
    }

    private void getItemName() {
        if(getItem()) {
            textMeshPro.text = getItem().getItemName();
            textMeshPro.gameObject.SetActive(true);
        }
        else {
            textMeshPro.gameObject.SetActive(false);
        }
    }

    private void getSelectedItem() {
        if(getItem()) {
            if(Item.dictionaryTextualID[getItem().getTextualID()].getItemUseAction() == EnumAction.EAT) {
                int result = getItem().getCurrentStackSize() - 1;
                getItem().setCurretnStackSize(result);

                if(getItem().getCurrentStackSize() <= 0) {
                    Destroy(getItem().gameObject);
                }
                else {
                    getItem().RefreshStack();
                }
            }
            if(Item.dictionaryTextualID[getItem().getTextualID()].getItemUseAction() == EnumAction.USE) {
                int result = getItem().getCurrentDamage() - 1;
                getItem().setCurrentDamage(result);

                if(getItem().getCurrentStackSize() <= 0) {
                    Destroy(getItem().gameObject);
                }
                else {
                    getItem().RefreshDamage();
                }
            }
        }
    }
}
