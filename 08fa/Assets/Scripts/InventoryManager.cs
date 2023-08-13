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
    
    public bool AddItem(ItemData itemData, int id, int stack) {
        foreach(Slot slot in slots) {
            Item item = slot.GetComponentInChildren<Item>();

            // Verifique se algum slot tem o mesmo item com contagem menor que o máximo
            if(item && item.textualID == itemData.textualID) {
                /*
                if((item.stack + stack) < itemData.maxStack) {
                    item.stack += stack;
                    item.RefreshCount();
                    
                    return true;
                }
                */

                int spaceAvailable = itemData.maxStack - item.stack;

                if(spaceAvailable > 0) {
                    if(stack <= spaceAvailable) {
                        item.stack += stack;
                        item.RefreshCount();
                        
                        return true;
                    }
                    else {
                        item.stack += spaceAvailable;
                        stack -= spaceAvailable;
                        item.RefreshCount();

                        if(!item) {
                            SpawnNewItem(slot, itemData, id, stack);

                            return true;
                        }
                    }
                }
            }
            /*
            // Encontre qualquer slot vazio
            else if(!item) {
                SpawnNewItem(slot, itemData, id, stack);

                return true;
            }
            */
        }
        foreach(Slot slot in slots) {
            Item item = slot.GetComponentInChildren<Item>();

            if(!item) {
                SpawnNewItem(slot, itemData, id, stack);

                return true;
            }
        }
        
        return false;
    }

    private void SpawnNewItem(Slot slot, ItemData itemData, int id, int stack) {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);

        Item item = newItem.GetComponent<Item>();
        item.InitialiseItem(itemData, id);
        
        item.stack = stack;
        item.RefreshCount();
    }
}
