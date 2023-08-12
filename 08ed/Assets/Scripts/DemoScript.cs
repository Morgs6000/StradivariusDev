using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject cotainer;

    private void Awake() {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Start() {
        AddItem();
    }

    public void PickUpItem(int id, string textualID) {
        bool result = inventoryManager.AddItem(ItemManager.items[id]);

        if(result) {
            Debug.Log("Dado 1 " + textualID + " para o jogador");
        }
        else {
            Debug.Log("Inventario Cheio");
        }
    }

    private void AddItem() {
        for(int i = 0; i < ItemManager.items.Count; i++) {
            ItemData itemData = ItemManager.items[i];

            SpawnNewItem(itemData, i);
        }
    }

    private void SpawnNewItem(ItemData itemData, int id) {
        GameObject newItem = Instantiate(itemPrefab, cotainer.transform);

        ItemNEI itemNEI = newItem.GetComponent<ItemNEI>();
        itemNEI.InitialiseItem(itemData, id);
    }
}
