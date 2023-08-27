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

    private int stack;

    private void Awake() {
        demoScript = FindObjectOfType<DemoScript>();
        rawImage = FindObjectOfType<RawImage>();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        if(Input.GetMouseButtonDown(0)) {
            demoScript.PickUpItem(itemID, textualID, 1);
        }
        if(Input.GetMouseButtonDown(1)) {
            demoScript.PickUpItem(itemID, textualID, stack);
        }
    }

    public void InitialiseItem(ItemData itemData, int id) {
        rawImage.texture = itemData.itemTexture;
        rawImage.uvRect = ItemData.uv(itemData.itemUV);

        itemID = id;
        textualID = itemData.textualID;

        stack = itemData.maxStack;
    }
}
