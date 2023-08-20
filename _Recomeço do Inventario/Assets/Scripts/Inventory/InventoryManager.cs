using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager Instance;

    private GameObject toolbarSlots;
    private GameObject inventorySlots;

    private List<Slot> slots = new List<Slot>();

    private GameObject itemPrefab;

    //[SerializeField] private Transform highlight;

    [SerializeField] private GameObject inventory;
    private bool inventoryActive;

    private void Awake() {
        Instance = this;

        toolbarSlots = GameObject.Find("Toolbar Slots");
        slots.AddRange(toolbarSlots.GetComponentsInChildren<Slot>());

        inventorySlots = GameObject.Find("Inventory Slots");
        slots.AddRange(inventorySlots.GetComponentsInChildren<Slot>());

        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemRenderer");
    }

    private void Update() {
        //UpdateSlotHighlight();
        InputInventory();
    }

    public List<Slot> getSlots() {
        return this.slots;
    }

    public bool AddItem(Item item, int stack) {
        foreach(Slot slot in slots) {
            ItemRenderer itemInSlot = slot.GetComponentInChildren<ItemRenderer>();

            if(itemInSlot && itemInSlot.getTextualID() == item.getTextualID()) {
                int spaceAvailable = item.getMaxStackSize() - itemInSlot.getCurrentStackSize();

                if(spaceAvailable > 0) {
                    if(stack <= spaceAvailable) {
                        int result = itemInSlot.getCurrentStackSize() + stack;
                        itemInSlot.setCurretnStackSize(result);
                        itemInSlot.RefreshStack();

                        return true;
                    }
                    else {
                        int result = itemInSlot.getCurrentStackSize() + spaceAvailable;
                        itemInSlot.setCurretnStackSize(result);
                        itemInSlot.RefreshStack();

                        stack -= spaceAvailable;

                        if(!itemInSlot) {
                            SpawnNewItem(item, slot, stack);

                            return true;
                        }
                    }
                }
            }
        }
        
        foreach(Slot slot in slots) {
            ItemRenderer itemInSlot = slot.GetComponentInChildren<ItemRenderer>();

            if(!itemInSlot) {
                SpawnNewItem(item, slot, stack);

                return true;
            }
        }
        
        return false;
    }

    private void SpawnNewItem(Item item, Slot slot, int stack) {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);

        ItemRenderer itemRenderer = newItem.GetComponent<ItemRenderer>();
        itemRenderer.InitialiseItem(item);

        string name = item.getItemName();
        newItem.name = StringManager.Instance.GetString(name);

        itemRenderer.setCurretnStackSize(stack);
        itemRenderer.RefreshStack();

        itemRenderer.setCurrentDamage(Item.itemsList[itemRenderer.getTextualID()].getMaxDamage());
        itemRenderer.RefreshDamage();
    }

    /*
    private void UpdateSlotHighlight() {
        foreach(Slot slot in slots) {
            bool onEnter = slot.getOnEnter();

            if(onEnter) {
                onEnter = true;
            }
            else {
                onEnter = false;
            }

            if(!inventoryActive) {
                onEnter = false;
            }

            highlight.position = slot.transform.position;
            highlight.gameObject.SetActive(onEnter);

            return;
        }
    }
    */

    private void InputInventory() {
        if(Input.GetKeyDown(KeyCode.E)) {
            inventoryActive = !inventoryActive;
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            inventoryActive = false;
        }

        inventory.SetActive(inventoryActive);
    }
}
