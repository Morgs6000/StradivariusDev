using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {
    [SerializeField] private GameObject inventory;
    public bool inventoryActive;
    
    private void Start() {
        inventory.SetActive(false);
    }

    private void Update() {
        InputsInventory();
    }

    private void InputsInventory() {
        if(Input.GetKeyDown(KeyCode.E)) {
            inventoryActive = !inventoryActive;
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            inventoryActive = false;
        }

        inventory.SetActive(inventoryActive);
    }
}
