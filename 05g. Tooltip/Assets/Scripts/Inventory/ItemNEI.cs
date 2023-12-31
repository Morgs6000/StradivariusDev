using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemNEI : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    private DemoScript demoScript;
    private RawImage rawImage;

    public int itemID;
    public string textualID;
    public string itemName;

    private int stack;
    public int durability;

    [SerializeField] private Tooltip tooltip;

    private void Awake() {
        demoScript = FindObjectOfType<DemoScript>();
        rawImage = GetComponent<RawImage>();
        tooltip = FindObjectOfType<Tooltip>();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        if(Input.GetMouseButtonDown(0)) {
            demoScript.PickUpItem(itemID, textualID, 1, durability);
        }
        if(Input.GetMouseButtonDown(1)) {
            demoScript.PickUpItem(itemID, textualID, stack, durability);
        }
    }

    public void InitialiseItem(ItemData itemData, int id) {
        rawImage.texture = itemData.itemTexture;
        rawImage.uvRect = ItemData.uv(itemData.itemUV);

        itemID = id;
        textualID = itemData.textualID;
        itemName = itemData.itemName;

        stack = itemData.maxStack;
        durability = itemData.maxDurability;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        tooltip.Show(itemName, null, textualID);
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltip.Hide();
    }
}
