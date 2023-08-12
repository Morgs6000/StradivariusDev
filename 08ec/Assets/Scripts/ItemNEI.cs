using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemNEI : MonoBehaviour, IPointerDownHandler {
    private DemoScript demoScript;

    //private Image image;
    private RawImage rawImage;

    //private ItemManager itemManager;

    //[SerializeField] private EnumItems enumItems;
    //[SerializeField] private ItemData item;
    public int itemID;
    public string textualID;

    private void Awake() {
        demoScript = FindObjectOfType<DemoScript>();

        //image = GetComponent<Image>();
        rawImage = GetComponent<RawImage>();

        //itemManager = FindObjectOfType<ItemManager>();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        demoScript.PickUpItem(itemID, textualID);
    }

    public void InitialiseItem(ItemData itemData, int id) {
        //image.sprite = itemScript.sprite;

        //rawImage.texture = itemManager.itemAtlas;
        rawImage.texture = itemData.texture;
        if(itemData.isAtlas) {
            rawImage.uvRect = ItemData.uv(itemData.itemUV);
        }

        //enumItems = itemScript.itemID;
        itemID = id;

        textualID = itemData.itemID;
    }
}
