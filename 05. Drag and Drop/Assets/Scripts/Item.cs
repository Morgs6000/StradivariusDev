using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private Transform parrentAfterDrag;

    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }
    
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Comece a arrastar");

        // Salva o slot atual
        parrentAfterDrag = transform.parent;

        // Jogar o item para o final da Hierarquia do Canvas
        transform.SetParent(transform.root);

        image.raycastTarget = false;


    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Arrastando");

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("Fim de arratar");

        // Retonar o item para o ultimo slot salvo
        transform.SetParent(parrentAfterDrag);

        image.raycastTarget = true;
    }

    public Transform setParrentAfterDrag {
        set {
            parrentAfterDrag = value;
        }
    }
}
