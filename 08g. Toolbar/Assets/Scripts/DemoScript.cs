using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoScript : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject container;

    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Animator animator;

    private void Awake() {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Start() {
        AddItem();
    }

    public void PickUpItem(int id, string textualID, int stack) {
        bool result = inventoryManager.AddItem(ItemManager.items[id], id, stack);

        if(result) {
            Debug.Log("Dado " + stack + " " +  ItemManager.items[id].itemName + " para o jogador");
        }
        else {
            //Debug.Log("Inventario Cheio");
            //animator.SetTrigger("reset");

            WarningMensage();
        }
    }

    private void WarningMensage() {
        //foreach(Slot slot in inventoryManager.slots) {
            //Item item = slot.GetComponentInChildren<Item>();

            //if(item) {
                textMeshPro.text = "Inventario Cheio";
                //textMeshPro.gameObject.SetActive(true);

                ColorUtility.TryParseHtmlString("#FC5454", out Color color);
                textMeshPro.color = color;
                
                animator.SetTrigger("fadout");
            //}
            //else {                
                //textMeshPro.gameObject.SetActive(false);
            //}
        //}
    }

    private void AddItem() {
        for(int i = 0; i < ItemManager.items.Count; i++) {
            ItemData itemData = ItemManager.items[i];

            SpawnNewItem(itemData, i);

            //return;
        }
    }

    private void SpawnNewItem(ItemData itemData, int id) {
        GameObject newItem = Instantiate(itemPrefab, container.transform);

        ItemNEI itemNEI = newItem.GetComponent<ItemNEI>();
        itemNEI.InitialiseItem(itemData, id);
    }
}
