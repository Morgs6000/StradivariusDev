using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    private Drag drag;

    //public Image image;
    //public Color color = Color.white;
    //public Color selectedColor = new Color(1f, 1f, 1f, 0.5f);
    //public Color deselectedColor = new Color(1f, 1f, 1f, 0.0f);

    public bool onEnter;

    //[SerializeField] private GameObject highlight;
    //[SerializeField] private Transform highlight;

    //[SerializeField] private IntefaceManager intefaceManager;

    private void Awake() {
        drag = FindObjectOfType<Drag>();

        //image = GetComponent<Image>();

        //intefaceManager = FindObjectOfType<IntefaceManager>();
    }

    private void Start() {
        //Deselect();
    }

    private void Update() {
        //image.color = color;
    }

    public void OnDropping() {
        if(transform.childCount == 0) {
            Item item = drag.GetComponentInChildren<Item>();
            item.setParrentAfterDrag = transform;

            item.OnEndDragging();
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        OnDropping();
    }

    public void Selecte() {
        //color.a = 0.5f;
        //image.color = selectedColor;
    }

    public void Deselect() {
        //color.a = 0.0f;
        //image.color = deselectedColor;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        //Selecte();
        onEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        //Deselect();
        onEnter = false;
    }
}
