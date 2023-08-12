using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntefaceManager : MonoBehaviour {
    //[SerializeField] private GameObject inventory;

    //[SerializeField] private Slot[] slots;

    //[SerializeField] private GameObject toolbar;
    [SerializeField] private GameObject inventory;    
    //[SerializeField] private GameObject invetory2;    
    [SerializeField] private List<Slot> slots = new List<Slot>();

    [SerializeField] private GameObject highlight;

    public bool onEnter;
    
    private void Start() {
        inventory.SetActive(false);

        //slots = FindObjectsOfType<Slot>();
        
        //slots.AddRange(toolbar.GetComponentsInChildren<Slot>());
        slots.AddRange(inventory.GetComponentsInChildren<Slot>());
        //slots.AddRange(invetory2.GetComponentsInChildren<Slot>());
    }

    private void Update() {
        InventoryInputs();
        SlotsHighlightUpdate();
    }

    private void SlotsHighlightUpdate() {  
        Image image = highlight.GetComponent<Image>();

        //if(inventory.activeSelf) {    
            //highlight.SetActive(false);
            //image.color = new Color(1f, 1f, 1f, 0.0f);

            foreach(Slot slot in slots) {
                /*
                Image image = slot.GetComponent<Image>();

                if(slot.onEnter) {
                    image.color = new Color(1f, 1f, 1f, 0.5f);
                }
                else {
                    image.color = new Color(1f, 1f, 1f, 0.0f);
                }
                */
                //if(inventory.activeSelf) {
                    if(slot.onEnter) {
                        //highlight.SetActive(true);
                        //image.color = new Color(1f, 1f, 1f, 0.5f);
                        onEnter = true;

                        highlight.transform.position = slot.transform.position;

                        return;
                    }
                    else {
                        //image.color = new Color(1f, 1f, 1f, 0.0f);
                        onEnter = false;

                        //return;
                    }
                //}
                //else {
                    //highlight.SetActive(false);
                    //image.color = new Color(1f, 1f, 1f, 0.0f);
                //}

                if(onEnter) {
                    image.color = new Color(1f, 1f, 1f, 0.5f);
                }
                else {
                    image.color = new Color(1f, 1f, 1f, 0.0f);
                }

                if(!inventory.activeSelf) {
                    onEnter = false;
                }
            }

            
        //}        
        //else {            
            //highlight.SetActive(false);
            //image.color = new Color(1f, 1f, 1f, 0.0f);
        //}

        /*
        if(!inventory.activeSelf) {
            foreach(Slot slot in slots) {
                Image image = slot.GetComponent<Image>();

                image.color = new Color(1f, 1f, 1f, 0.0f);
            }
        }
        */
    }

    private void InventoryInputs() {
        if(Input.GetKeyDown(KeyCode.E)) {
            inventory.SetActive(!inventory.activeSelf);
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            inventory.SetActive(false);
        }
        //if(!inventory.activeSelf) {
            //foreach(Slot slot in slots) {
                //slot.Deselect();
                /*
                if(slot.color == new Color(1f, 1f, 1f, 0.5f)) {
                    //slot.Deselect();
                    slot.image.color = new Color(1f, 1f, 1f, 0.0f);
                } 
                */ 
                /* 
                if(slot.color == slot.selectedColor) {
                    slot.image.color = slot.deselectedColor;
                }
                //*/
            //}
        //}
    }
}
