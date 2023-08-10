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

    public bool AddItem(ScriptableItem scriptableItem) {
        //for(int i = 0; i < slots.Count; i++) {
        foreach(Slot slot in slots) {
            //Slot slot = slots[i];
            Item item = slot.GetComponentInChildren<Item>();

            if(!item) {
                SpawnNewItem(scriptableItem, slot);
                return true;
            }
        }

        return false;
    }

    public void SpawnNewItem(ScriptableItem scriptableItem, Slot slot) {
        GameObject newItemObject = Instantiate(itemPrefab, slot.transform);

        Item item = newItemObject.GetComponent<Item>();
        item.InitialiseItem(scriptableItem);

        newItemObject.name = scriptableItem.itemName;
    }
}
