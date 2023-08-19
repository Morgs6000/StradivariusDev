using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {
    public static DemoScript Instance;

    //private InventoryManager inventoryManager;
    //private Item[] itemsToPickup;

    private GameObject itemPrefab;
    [SerializeField] private Transform container;

    //[SerializeField] private Transform highlight;
    //private List<ItemRenderer> items = new List<ItemRenderer>();

    private void Awake() {
        Instance = this;

        //inventoryManager = FindObjectOfType<InventoryManager>();

        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemRenderer");
        container = transform.GetChild(1).GetComponent<Transform>();

        //items.AddRange(container.GetComponentsInChildren<ItemRenderer>());
    }

    private void Start() {
        AddItem();
    }

    /*
    private void Update() {
        UpdateItemHighlight();
    }
    */
    
    public void PickUpItem(string textualID, int stack) {
        bool result = InventoryManager.Instance.AddItem(Item.dictionaryTextualID[textualID], stack);

        if(result) {
            //Debug.Log("Dado 1 Item para o jogador");

            string name = Item.dictionaryTextualID[textualID].getItemName();
            Debug.Log("Dado " + stack + " " + StringManager.Instance.GetString(name) + " para o jogador");
        }
        else {
            Debug.Log("ITEM NOT ADD");
            //Debug.Log("Inventario cheio");
        }
    }

    private void AddItem() {
        foreach(Item item in Item.itemsList) {
            SpawnNewItem(Item.dictionaryTextualID[item.getTextualID()]);
        }
    }

    private void SpawnNewItem(Item item) {
        GameObject newItem = Instantiate(itemPrefab, container);

        ItemRenderer itemRenderer = newItem.GetComponent<ItemRenderer>();
        itemRenderer.InitialiseItem(item);

        string name = item.getItemName();
        newItem.name = StringManager.Instance.GetString(name);
    }

    /*
    private void UpdateItemHighlight() {
        foreach(ItemRenderer itemRenderer in items) {
            if(itemRenderer.getOnEnter()) {
                highlight.position = itemRenderer.transform.position;
                highlight.gameObject.SetActive(true);

                return;
            }
            else {
                highlight.gameObject.SetActive(false);
            }
        }
    }
    */
}
