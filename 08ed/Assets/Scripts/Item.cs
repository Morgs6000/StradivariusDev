using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerDownHandler {
    public Transform parrentAfterDrag;

    private RawImage rawImage;
    private Drag drag;

    private void Awake() {
        rawImage = GetComponent<RawImage>();
        drag = FindObjectOfType<Drag>();
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
            OnBeginDragging();
        }      
        else {
            OnBeginDragging();

            Item item = drag.GetComponentInChildren<Item>();
            item.parrentAfterDrag = parrentAfterDrag;

            item.OnEndDragging();
        }  
    }

    public void InitialiseItem(ItemData itemData) {
        rawImage.texture = itemData.itemTexture;
        rawImage.uvRect = ItemData.uv(itemData.GetUV());
    }
}
