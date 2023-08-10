using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerDownHandler {
    public Transform parrentAfterDrag;

    public Image image;

    //[SerializeField] private GameObject drag;
    private Drag drag;

    /*[SerializeField] */private ScriptableItem scriptableItem;

    private void Awake() {
        image = GetComponent<Image>();

        //drag = GameObject.Find("Drag");
        drag = FindObjectOfType<Drag>();
    }

    /*
    private void Start() {
        InitialiseItem(scriptableItem);
    }
    */

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

        image.raycastTarget = false;
    }

    public void OnDragging() {
        //Debug.Log("Arrastando");

        transform.position = Input.mousePosition;
    }

    public void OnEndDragging() {
        //Debug.Log("Fim de arratar");

        // Retonar o item para o ultimo slot salvo
        transform.SetParent(parrentAfterDrag);

        image.raycastTarget = true;
    }

    public void InitialiseItem(ScriptableItem newItem) {
        scriptableItem = newItem;
        image.sprite = newItem.sprite;
    }
}
