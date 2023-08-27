using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    [SerializeField] private GameObject toolbar;
    [SerializeField] private GameObject inventory;
    
    public List<Slot> slots = new List<Slot>();

    [SerializeField] private GameObject itemPrefab;

    private void Awake() {
        slots.AddRange(toolbar.GetComponentsInChildren<Slot>());
        slots.AddRange(inventory.GetComponentsInChildren<Slot>());
    }
    
    public bool AddItem(ItemData itemData, int id, int stack, int durability) {
        foreach(Slot slot in slots) {
            Item item = slot.GetComponentInChildren<Item>();

            if(item && item.textualID == itemData.textualID) {
                int spaceAvailable = itemData.maxStack - item.stack;

                if(spaceAvailable > 0) {
                    if(stack <= spaceAvailable) {
                        item.stack += stack;
                        item.RefreshCount();

                        return true;
                    }
                    else {
                        item.stack += spaceAvailable;
                        item.RefreshCount();

                        stack -= spaceAvailable;

                        if(!item) {
                            SpawnNewItem(slot, itemData, id, stack, durability);

                            return true;
                        }
                    }
                }
            }
        }
        
        foreach(Slot slot in slots) {
            Item item = slot.GetComponentInChildren<Item>();

            if(!item) {
                SpawnNewItem(slot, itemData, id, stack, durability);

                return true;
            }
        }
        
        return false;
    }

    private void SpawnNewItem(Slot slot, ItemData itemData, int id, int stack, int durability) {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);

        Item item = newItem.GetComponent<Item>();
        item.InitialiseItem(itemData, id);

        newItem.name = itemData.textualID;

        item.stack = stack;
        item.RefreshCount();

        item.durability = durability;
        item.RefreshDurability();
    }
}
