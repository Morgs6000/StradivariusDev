using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler {
    private Image image;
    private Transform parrentAfterDrag;

    //private GameObject drag;
    private Drag drag;

    private void Awake() {
        image = GetComponent<Image>();

        //onDrag = GameObject.Find("Drag");
        drag = FindObjectOfType<Drag>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(drag.transform.childCount == 0) {
            OnBeginDragging();
        }
        else {            
            OnBeginDragging();
            
            Item item = drag.GetComponentInChildren<Item>();
            item.setParrentAfterDrag = parrentAfterDrag;

            item.OnEndDragging();
        }
    }

    public void OnBeginDragging() {
        // Salva o Slot atual
        parrentAfterDrag = transform.parent;

        // Transforma o Item em um objeto filho do GameObject "Drag"
        transform.SetParent(drag.transform);

        image.raycastTarget = false;
    }

    public void OnDragging() {
        transform.position = Input.mousePosition;
    }

    public void OnEndDragging() {        
        // Retornar o Item para o ultimo Slot salvo
        transform.SetParent(parrentAfterDrag);

        image.raycastTarget = true;
    }

    public Transform setParrentAfterDrag {
        get {
            return parrentAfterDrag;
        }
        set {
            parrentAfterDrag = value;
        }
    }
}
