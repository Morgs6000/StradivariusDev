using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemNEI : MonoBehaviour, IPointerDownHandler {
    private DemoScript demoScript;

    private RawImage rawImage;

    private ItemsManager itemsManager;

    private EnumItems enumItems;

    private void Awake() {
        demoScript = FindObjectOfType<DemoScript>();

        rawImage = GetComponent<RawImage>();
        itemsManager = FindObjectOfType<ItemsManager>();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        demoScript.PickUpItem(enumItems);
    }

    public void InitialiseItem(EnumItems itemID) {
        rawImage.texture = itemsManager.itemsAtlas;
        rawImage.uvRect = itemsManager.uv(itemsManager.GetUV(itemID));

        enumItems = itemID;
    }
}
