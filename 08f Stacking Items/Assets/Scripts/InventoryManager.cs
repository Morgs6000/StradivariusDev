using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    [SerializeField] private GameObject toolbar;
    [SerializeField] private GameObject invetory;    
    /*[SerializeField] */public List<Slot> slots = new List<Slot>();

    [SerializeField] private GameObject itemPrefab;

    private int maxStack = 10;

    private void Awake() {
        slots.AddRange(toolbar.GetComponentsInChildren<Slot>());
        slots.AddRange(invetory.GetComponentsInChildren<Slot>());
    }

    public bool AddItem(EnumItems itemID) {
        foreach(Slot slot in slots) {
            Item item = slot.GetComponentInChildren<Item>();

            if(item && item.enumItems == itemID && item.stack < maxStack) {
                item.stack++;
                item.RefreshCount();

                return true;
            }
            else if(!item) {
                SpawnNewItem(itemID, slot);

                return true;
            }
        }

        return false;
    }

    private void SpawnNewItem(EnumItems itemID, Slot slot) {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);

        Item item = newItem.GetComponent<Item>();
        item.InitialiseItem(itemID);
    }
}
