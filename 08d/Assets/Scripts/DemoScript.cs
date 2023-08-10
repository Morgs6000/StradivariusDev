using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ScriptableItem[] itemsToPickup;

    public void PickUpItem(int id) {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);

        if(result) {
            Debug.Log("Item added: " + itemsToPickup[id].itemName);
            //Debug.Log("Given x " + itemsToPickup[id].itemName + " to Morgs6000");
        }
        else {
            Debug.Log("ITEM NOT ADDED");
            //Debug.Log("Inventario Cheio");
        }
    }
}
