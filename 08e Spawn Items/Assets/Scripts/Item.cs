using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerDownHandler {
    public Transform parrentAfterDrag;

    public RawImage rawImage;

    //[SerializeField] private GameObject drag;
    private Drag drag;

    private ItemsManager itemsManager;

    private void Awake() {
        rawImage = GetComponent<RawImage>();

        //drag = GameObject.Find("Drag");
        drag = FindObjectOfType<Drag>();
        itemsManager = FindObjectOfType<ItemsManager>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(drag.transform.childCount == 0) {
            OnBeginDragging();
        }      
        else {
            OnBeginDragging();

            Item item = drag.GetComponentInChildren<Item>();
            item.parrentAfterDrag = parrentAfterDrag;

            item.OnEndDragging();
        }  
    }
    
    public void OnBeginDragging() {
        //Debug.Log("Comece a arrastar");

        // Salva o slot atual
        parrentAfterDrag = transform.parent;

        // Jogar o item para o final da Hierarquia do Canvas
        transform.SetParent(drag.transform);

        rawImage.raycastTarget = false;
    }

    public void OnDragging() {
        //Debug.Log("Arrastando");

        transform.position = Input.mousePosition;
    }

    public void OnEndDragging() {
        //Debug.Log("Fim de arratar");

        // Retonar o item para o ultimo slot salvo
        transform.SetParent(parrentAfterDrag);

        rawImage.raycastTarget = true;
    }

    public void InitialiseItem(EnumItems itemID) {
        rawImage.texture = itemsManager.itemsAtlas;
        rawImage.uvRect = itemsManager.uv(itemsManager.GetUV(itemID));
    }
}
