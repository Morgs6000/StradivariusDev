using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemNEI : MonoBehaviour, IPointerDownHandler {
    private DemoScript demoScript;

    private Image image;
    //private RawImage rawImage;

    private ItemsManager itemsManager;

    [SerializeField] private EnumItems enumItems;

    private void Awake() {
        demoScript = FindObjectOfType<DemoScript>();

        image = GetComponent<Image>();
        //rawImage = GetComponent<RawImage>();

        itemsManager = FindObjectOfType<ItemsManager>();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        demoScript.PickUpItem(enumItems);
    }

    public void InitialiseItem(ItemScript itemScript) {
        image.sprite = itemScript.sprite;

        //rawImage.texture = itemsManager.itemsAtlas;
        //rawImage.uvRect = itemsManager.uv(itemsManager.GetUV(itemID));

        enumItems = itemScript.itemID;
    }
}
