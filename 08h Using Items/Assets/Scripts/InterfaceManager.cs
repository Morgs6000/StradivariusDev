using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {
    [SerializeField] private GameObject inventory;
    public bool inventoryActive;

    private void Start() {
        //inventoryActive = false;
    }

    private void Update() {
        InputInventory();
    }

    private void InputInventory() {
        if(Input.GetKeyDown(KeyCode.E)) {
            inventoryActive = !inventoryActive;            
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            inventoryActive = false;
        }

        inventory.SetActive(inventoryActive);
    }
}
