using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    [Header("UI")]
    [SerializeField] private Image image;

    private Transform parentAfterDrag;

    private void Awake() {
        image = GetComponentInChildren<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        image.raycastTarget = false;

        // Salve o slot atual
        parentAfterDrag = transform.parent;

        // Jogue o Item para o final da Hierarquia
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        image.raycastTarget = true;

        // Devolva o item para o ultimo slot salvo
        transform.SetParent(parentAfterDrag);
    }
}
