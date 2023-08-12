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

    public bool AddItem(ItemData itemData) {
        foreach(Slot slot in slots) {
            Item item = slot.GetComponentInChildren<Item>();

            if(!item) {
                SpawnNewItem(slot, itemData);
                return true;
            }
        }

        return false;
    }

    private void SpawnNewItem(Slot slot, ItemData itemData) {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);

        Item item = newItem.GetComponent<Item>();
        item.InitialiseItem(itemData);
    }
}
