using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;

    [SerializeField] private GameObject container;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private EnumItems enumItems;

    private void Start() {
        AddItem();
    }

    public void PickUpItem(EnumItems itemID) {
        bool result = inventoryManager.AddItem(itemID);

        if(result) {
            Debug.Log("Dado 1 " + itemID + " para o jogador");
        }
        else {
            Debug.Log("Inventario Cheio");
        }
    }

    private void AddItem() {
        foreach(EnumItems itemID in System.Enum.GetValues(typeof(EnumItems))) {
            SpawnNewItem(itemID);
        }
    }

    private void SpawnNewItem(EnumItems itemID) {
        GameObject newItem = Instantiate(itemPrefab, container.transform);

        ItemNEI itemNEI = newItem.GetComponent<ItemNEI>();
        itemNEI.InitialiseItem(itemID);
    }
}
