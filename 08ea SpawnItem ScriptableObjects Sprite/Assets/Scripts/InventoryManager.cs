using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    [SerializeField] private GameObject toolbar;
    [SerializeField] private GameObject invetory;    
    /*[SerializeField] */public List<Slot> slots = new List<Slot>();

    [SerializeField] private GameObject itemPrefab;

    private void Awake() {
        slots.AddRange(toolbar.GetComponentsInChildren<Slot>());
        slots.AddRange(invetory.GetComponentsInChildren<Slot>());
    }

    public bool AddItem(ItemScript itemScript) {
        foreach(Slot slot in slots) {
            Item item = slot.GetComponentInChildren<Item>();

            if(!item) {
                SpawnNewItem(itemScript, slot);
                return true;
            }
        }

        return false;
    }

    private void SpawnNewItem(ItemScript itemScript, Slot slot) {
        GameObject newItem = Instantiate(itemPrefab, slot.transform);

        Item item = newItem.GetComponent<Item>();
        item.InitialiseItem(itemScript);
    }
}
