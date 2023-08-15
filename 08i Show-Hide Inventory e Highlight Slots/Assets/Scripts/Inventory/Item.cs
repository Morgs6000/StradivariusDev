using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerDownHandler {
    public Transform parrentAfterDrag;
    private RawImage rawImage;
    private Drag drag;

    [SerializeField] private GameObject itemPrefab;

    public int itemID;
    public string textualID;
    public string itemName;

    public EnumAction enumAction = EnumAction.NONE;

    public int stack = 1;
    private TextMeshProUGUI textMeshPro;

    public int durability = 1;
    [SerializeField] private Image durabilityBar;
    [SerializeField] private Image durabilityFrame;

    private void Awake() {
        rawImage = GetComponent<RawImage>();
        drag = FindObjectOfType<Drag>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void OnBeginDragging() {
        // Salva o slot atual
        parrentAfterDrag = transform.parent;

        // Jogar o item para o final da Hierarquia do Canvas
        transform.SetParent(drag.transform);

        rawImage.raycastTarget = false;
    }

    public void OnDragging() {
        transform.position = Input.mousePosition;
    }

    public void OnEndDragging() {
        // Retonar o item para o ultimo slot salvo
        transform.SetParent(parrentAfterDrag);

        rawImage.raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(drag.transform.childCount == 0) {
            if(Input.GetMouseButtonDown(0)) {
                OnBeginDragging();
            }
            if(Input.GetMouseButtonDown(1)) {
                if(stack <= 1) {
                    OnBeginDragging();
                }
                else {
                    GameObject newItem = Instantiate(itemPrefab, drag.transform);

                    Item item = newItem.GetComponent<Item>();
                    item.InitialiseItem(ItemManager.items[itemID], itemID);

                    int result = stack / 2;
                    int remainder = stack % 2;
                    int valueRemaining = result + remainder;

                    stack = result;
                    RefreshCount();

                    item.stack = valueRemaining;
                    item.RefreshCount();

                    item.rawImage.raycastTarget = false;

                    RectTransform prefabRectTransform = itemPrefab.GetComponent<RectTransform>();
                    RectTransform rectTransform = item.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = prefabRectTransform.sizeDelta;

                    newItem.name = ItemManager.items[itemID].textualID;
                }
            }            
        }      
        else {
            Item item = drag.GetComponentInChildren<Item>();

            if(textualID != item.textualID) {
                OnBeginDragging();

                item.parrentAfterDrag = parrentAfterDrag;
                item.OnEndDragging();
            }
            else {
                int spaceAvailable = ItemManager.items[itemID].maxStack - stack;

                if(spaceAvailable > 0) {
                    if(Input.GetMouseButtonDown(0)) {
                        if(item.stack <= spaceAvailable) {
                            stack += item.stack;
                            RefreshCount();

                            item.stack = 0;
                        }
                        else {
                            stack += spaceAvailable;
                            RefreshCount();

                            item.stack -= spaceAvailable;
                            item.RefreshCount();
                        }
                    }
                    if(Input.GetMouseButtonDown(1)) {
                        stack++;
                        RefreshCount();

                        item.stack--;
                        item.RefreshCount();
                    }
                }
            }            
        }  
    }

    public void InitialiseItem(ItemData itemData, int id) {
        rawImage.texture = itemData.itemTexture;
        rawImage.uvRect = ItemData.uv(itemData.itemUV);

        itemID = id;
        textualID = itemData.textualID;
        itemName = itemData.itemName;

        enumAction = itemData.enumAction;

        RefreshCount();
    }

    public void RefreshCount() {
        textMeshPro.text = stack.ToString();

        bool textActive = stack > 1;
        textMeshPro.gameObject.SetActive(textActive);
    }

    public void RefreshDurability() {
        durabilityBar.fillAmount = (float)durability / ItemManager.items[itemID].maxDurability;

        bool barActive = enumAction == EnumAction.USE;
        durabilityFrame.gameObject.SetActive(barActive);
    }
}
