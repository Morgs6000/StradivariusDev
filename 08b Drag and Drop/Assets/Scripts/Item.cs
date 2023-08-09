using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private Image image;
    private Transform parrentAfterDrag;

    private void Awake() {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Comece a arrastar");

        // Salva o Slot atural
        parrentAfterDrag = transform.parent;

        // Jogar o Item para o final da Hierarquia do Canvas
        transform.SetParent(transform.root);

        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Arrastando");

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("Fim de arrastar");

        // Retornar o Item para o ultimo Slot salvo
        transform.SetParent(parrentAfterDrag);

        image.raycastTarget = true;
    }

    public Transform setParrentAfterDrag {
        set {
            parrentAfterDrag = value;
        }
    }
}
