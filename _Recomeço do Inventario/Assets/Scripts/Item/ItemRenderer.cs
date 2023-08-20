using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemRenderer : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    //private Item item;

    private Transform parrentAfterDrag;
    //private Drag drag;

    private string textualID;

    private RawImage rawImage;

    private string itemName;
    //private StringManager stringManager;

    private int currentStackSize;
    private TextMeshProUGUI textMeshPro;

    [SerializeField] private int currentDamage;
    private Image durabilityBar;
    private Transform durabilityFrame;

    private GameObject itemPrefab;

    //private Tooltip tooltip;
    private bool onEnter;

    private void Awake() {
        rawImage = GetComponent<RawImage>();
        //stringManager = FindObjectOfType<StringManager>();

        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        
        durabilityFrame = transform.Find("Durability Frame");
        durabilityBar = durabilityFrame.Find("Durability Bar").GetComponent<Image>();

        //drag = FindObjectOfType<Drag>();

        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemRenderer");

        //tooltip = FindObjectOfType<Tooltip>();
    }

    //private void Start() {
        //InitialiseItem();
    //}

    public void InitialiseItem(Item item) {
        //this.item = newItem;

        this.textualID = item.getTextualID();

        string itemAtlas = item.getItemAtlas();
        this.rawImage.texture = Resources.Load<Texture>("Textures/GUI/" + itemAtlas);
        this.rawImage.uvRect = uv(item.getIconCoord());

        string name = item.getItemName();
        this.itemName = StringManager.Instance.GetString(name);

        this.RefreshStack();
        this.RefreshDamage();
    }

    public ItemRenderer setParrentAfterDrag(Transform transform) {
        this.parrentAfterDrag = transform;
        return this;
    }

    public Transform getParrentAfterDrag() {
        return this.parrentAfterDrag;
    }

    public string getTextualID() {
        return this.textualID;
    }

    private Rect uv(Vector2 textureCoordinate) {
        Vector2 textureSizeInTiles = new Vector2(16, 16);

        float x = textureCoordinate.x;
        float y = textureCoordinate.y;

        float _x = 1.0f / textureSizeInTiles.x;
        float _y = 1.0f / textureSizeInTiles.y;

        y = (textureSizeInTiles.y - 1) - y;

        x *= _x;
        y *= _y;

        float w = _x;
        float h = _y;

        return new Rect(x, y, w, h);
    }

    public string getItemName() {
        return this.itemName;
    }

    public ItemRenderer setCurretnStackSize(int stack) {
        this.currentStackSize = stack;
        return this;
    }

    public int getCurrentStackSize() {
        return this.currentStackSize;
    }

    public void RefreshStack() {
        textMeshPro.text = currentStackSize.ToString();

        bool textActive = currentStackSize > 1;
        textMeshPro.gameObject.SetActive(textActive);
    }

    public ItemRenderer setCurrentDamage(int damage) {
        this.currentDamage = damage;
        return this;
    }

    public int getCurrentDamage() {
        return this.currentDamage;
    }

    public void RefreshDamage() {
        int maxDamage = Item.itemsList[textualID].getMaxDamage();

        //int barWidth = (int)durabilityBar.rect.width;
        int barWidth = 12;

        int result = Mathf.RoundToInt(((float)currentDamage / maxDamage) * barWidth);

        durabilityBar.rectTransform.sizeDelta = new Vector2(result, 1);

        bool barActive;

        if(currentDamage == maxDamage) {
            barActive = false;
        }
        else if(currentDamage == 0) {
            barActive = false;
        }
        else {
            barActive = true;
        }

        durabilityFrame.gameObject.SetActive(barActive);

        if(currentDamage >= (maxDamage * 0.75f)) {
            durabilityBar.color = Color.green;
        }
        else if(currentDamage >= (maxDamage * 0.50f)) {
            durabilityBar.color = Color.yellow;
        }
        else if(currentDamage >= (maxDamage * 0.25f)) {
            durabilityBar.color = new Color(1.0f, 0.5f, 0.0f);
        }
        else if(currentDamage >= 0) {
            durabilityBar.color = Color.red;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Slot slot = GetComponentInParent<Slot>();

        if(slot) {
            DragItem();
        }
        else {
            PickUpItem();
        }
    }

    private void DragItem() {
        if(Drag.Instance.transform.childCount == 0) {
            DragFullStack();
            DragHalfStack();
        }
        else {
            Slot slot = GetComponentInParent<Slot>();

            ItemRenderer itemOnDrag = Drag.Instance.transform.GetComponentInChildren<ItemRenderer>();

            if(Item.itemsList[itemOnDrag.getTextualID()].getEnumSlotTag() == EnumSlotTag.NONE) {
                if(slot.getEnumSlotTag() != EnumSlotTag.NONE) {
                    return;
                }
            }
            if(textualID != itemOnDrag.getTextualID()) {
                ExchangeStack();
            }
            else {
                OnDropping();
            }
        }
    }

    public void OnBeginDragging() {
        parrentAfterDrag = transform.parent;
        transform.SetParent(Drag.Instance.transform);
        rawImage.raycastTarget = false;
    }

    public void OnDragging() {
        transform.position = Input.mousePosition;
    }

    public void OnEndDragging() {
        transform.SetParent(parrentAfterDrag);
        rawImage.raycastTarget = true;
    }

    private void DragFullStack() {
        if(Input.GetMouseButtonDown(0)) {
            OnBeginDragging();
        }
    }

    private void DragHalfStack() {
        if(Input.GetMouseButtonDown(1)) {
            if(currentStackSize <= 1) {
                OnBeginDragging();
            }
            else {
                GameObject newItem = Instantiate(itemPrefab, Drag.Instance.transform);

                ItemRenderer itemOnDrag = newItem.GetComponent<ItemRenderer>();
                itemOnDrag.InitialiseItem(Item.itemsList[textualID]);
                
                string name = itemName;
                newItem.name = StringManager.Instance.GetString(name);

                int result = currentStackSize / 2;
                int remainder = currentStackSize % 2;
                int valueRemaining = result + remainder;

                currentStackSize = result;
                RefreshStack();

                itemOnDrag.currentStackSize = valueRemaining;
                itemOnDrag.RefreshStack();

                itemOnDrag.rawImage.raycastTarget = false;

                //RectTransform prefabRectTransform = itemPrefab.GetComponent<RectTransform>();
                //RectTransform rectTransform = item.GetComponent<RectTransform>();
                //rectTransform.sizeDelta = prefabRectTransform.sizeDelta;
            }
        }
    }

    private void ExchangeStack() {
        ItemRenderer itemOnDrag = Drag.Instance.GetComponentInChildren<ItemRenderer>();

        OnBeginDragging();

        itemOnDrag.setParrentAfterDrag(parrentAfterDrag);
        itemOnDrag.OnEndDragging();
    }

    private void OnDropping() {
        ItemRenderer itemOnDrag = Drag.Instance.GetComponentInChildren<ItemRenderer>();

        int spaceAvailable = Item.itemsList[textualID].getMaxStackSize() - currentStackSize;

        if(spaceAvailable > 0) {
            if(InputManager.Instance.getLeftMouseButtonDown()) {
                if(itemOnDrag.getCurrentStackSize() <= spaceAvailable) {
                    currentStackSize += itemOnDrag.getCurrentStackSize();
                    RefreshStack();

                    itemOnDrag.setCurretnStackSize(0);
                }
                else {
                    currentStackSize += spaceAvailable;
                    RefreshStack();

                    int result = itemOnDrag.getCurrentStackSize() + spaceAvailable;
                    itemOnDrag.setCurretnStackSize(result);
                    itemOnDrag.RefreshStack();
                }
            }
            if(InputManager.Instance.getRightMouseButtonDown()) {
                currentStackSize++;
                RefreshStack();

                int result = itemOnDrag.getCurrentStackSize() - 1;
                itemOnDrag.setCurretnStackSize(result);
                itemOnDrag.RefreshStack();
            }
        }
    }

    private void PickUpItem() {
        if(Input.GetMouseButtonDown(0)) {
            DemoScript.Instance.PickUpItem(textualID, 1);
        }
        if(Input.GetMouseButtonDown(1)) {
            int maxStackSize = Item.itemsList[textualID].getMaxStackSize();
            DemoScript.Instance.PickUpItem(textualID, maxStackSize);
        }

        /*
        if(InputManager.Instance.getLeftMouseButtonDown()) {
            Debug.Log("Botão esquerdo do mouse foi pressionado!");
        }
        if(InputManager.Instance.getRightMouseButtonDown()) {
            Debug.Log("Botão direito do mouse foi pressionado!");
        }
        */
    }

    public bool getOnEnter() {
        return this.onEnter;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        onEnter = true;

        Slot slot = GetComponentInParent<Slot>();

        string content;

        if(slot) {
            if(Item.itemsList[textualID].getItemUseAction() == EnumAction.USE) {
                content = "\n" + "Durability: " + currentDamage + " / " + Item.itemsList[textualID].getMaxDamage();
            }
            else {
                content = null;
            }
        }
        else {
            content = null;
        }

        //string id = "stradivarius_industries:" + textualID;

        Tooltip.Instance.Show(itemName, content, textualID);
    }

    public void OnPointerExit(PointerEventData eventData) {
        onEnter = false;

        Tooltip.Instance.Hide();
    }
}
