using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Toolbar : MonoBehaviour {
    [SerializeField] private GameObject slotsInToolbar;
    [SerializeField] private Slot[] slots;
    private int slotIndex;

    [SerializeField] private Transform highlight;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Animator animator;

    private void Awake() {
        slots = slotsInToolbar.GetComponentsInChildren<Slot>();
    }

    private void Start() {
        
    }

    private void Update() {
        KeyInputs();
        ScrollInputs();

        highlight.position = slots[slotIndex].transform.position;
        GetItemName();
    }

    private void KeyInputs() {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            SlotIndex = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            SlotIndex = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            SlotIndex = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            SlotIndex = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            SlotIndex = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)) {
            SlotIndex = 5;
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)) {
            SlotIndex = 6;
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)) {
            SlotIndex = 7;
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)) {
            SlotIndex = 8;
        }
    }

    private void ScrollInputs() {
        if(Input.GetAxis("Mouse ScrollWheel") > 0) {
            SlotIndex--;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0) {
            SlotIndex++;
        }

        if(slotIndex > slots.Length - 1) {
            SlotIndex = 0;
        }
        if(slotIndex < 0) {
            SlotIndex = slots.Length - 1;
        }
    }

    private void GetItemName() {
        Slot slot = slots[slotIndex];
        Item item = slot.GetComponentInChildren<Item>();

        if(item) {
            textMeshPro.text = item.itemName;
            textMeshPro.gameObject.SetActive(true);
            
            animator.SetTrigger("fadout");
        }
        else {
            textMeshPro.gameObject.SetActive(false);
        }
    }

    private int SlotIndex {
        get {
            return slotIndex;
        }
        set {
            slotIndex = value;
            animator.SetTrigger("reset");
        }
    }
}
