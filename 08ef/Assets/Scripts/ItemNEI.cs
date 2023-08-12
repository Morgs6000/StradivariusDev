using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemNEI : MonoBehaviour, IPointerDownHandler {
    private DemoScript demoScript;
    private RawImage rawImage;

    public int itemID;
    public string textualID;

    private void Awake() {
        demoScript = FindObjectOfType<DemoScript>();
        rawImage = FindObjectOfType<RawImage>();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        demoScript.PickUpItem(itemID, textualID);
    }

    public void InitialiseItem(ItemData itemData, int id) {
        rawImage.texture = itemData.itemTexture;
        rawImage.uvRect = ItemData.uv(itemData.itemUV);

        itemID = id;
        textualID = itemData.itemID;
    }
}
