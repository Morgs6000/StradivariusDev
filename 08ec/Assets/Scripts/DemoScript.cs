using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;
    //[SerializeField] private ItemsManager itemsManager;

    [SerializeField] private GameObject container;
    [SerializeField] private GameObject itemPrefab;

    //[SerializeField] private ItemScript[] itemsToPickup;
    //[SerializeField] private ItemData[] itemDatas;
    //[SerializeField] private ItemData itemData;

    private void Start() {
        AddItem();
    }

    public void PickUpItem(int id, string textualID) {
        //itemData = ItemData.GetItem("apple");

        bool result = inventoryManager.AddItem(ItemManager.items[id]);

        if(result) {
            Debug.Log("Dado 1 " + textualID + " para o jogador");
        }
        else {
            Debug.Log("Inventario Cheio");
        }
    }

    private void AddItem() {
        /*
        for(int i = 0; i < VoxelManager.voxels.Count; i++) {
            VoxelData voxelData = VoxelManager.voxels[i];
            SpawnNewItem(voxelData, i);
        }
        */

        //foreach(EnumItems itemID in System.Enum.GetValues(typeof(EnumItems))) {
        //foreach(ItemScript itemScript in itemsToPickup) {
        for(int i = 0; i < ItemManager.items.Count; i++) {
        //foreach(ItemData itemData in ItemsManager.items) {
            ItemData itemData = ItemManager.items[i];
            SpawnNewItem(itemData, i);
        }
    }

    private void SpawnNewItem(ItemData itemData, int id) {
        GameObject newItem = Instantiate(itemPrefab, container.transform);

        ItemNEI itemNEI = newItem.GetComponent<ItemNEI>();
        itemNEI.InitialiseItem(itemData, id);
    }

    /*
    private void SpawnNewItem(VoxelData voxelData, int id) {
        GameObject newItem = Instantiate(itemPrefab, container.transform);

        ItemNEI itemNEI = newItem.GetComponent<ItemNEI>();
        itemNEI.InitialiseItem(voxelData, id);
    }
    */
}
