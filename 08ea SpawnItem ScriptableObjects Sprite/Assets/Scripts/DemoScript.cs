using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;

    [SerializeField] private GameObject container;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private ItemScript[] itemsToPickup;

    private void Start() {
        AddItem();
    }

    public void PickUpItem(EnumItems itemID) {
        bool result = inventoryManager.AddItem(itemsToPickup[(int)itemID]);

        if(result) {
            Debug.Log("Dado 1 " + itemID + " para o jogador");
        }
        else {
            Debug.Log("Inventario Cheio");
        }
    }

    private void AddItem() {
        //foreach(EnumItems itemID in System.Enum.GetValues(typeof(EnumItems))) {
        //foreach(ItemScript itemScript in itemsToPickup) {
        for(int i = 0; i < itemsToPickup.Length; i++) {
            SpawnNewItem(itemsToPickup[i]);
        }
    }

    private void SpawnNewItem(ItemScript itemScript) {
        GameObject newItem = Instantiate(itemPrefab, container.transform);

        ItemNEI itemNEI = newItem.GetComponent<ItemNEI>();
        itemNEI.InitialiseItem(itemScript);
    }
}
