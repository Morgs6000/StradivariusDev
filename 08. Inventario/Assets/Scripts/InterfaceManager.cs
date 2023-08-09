using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
    [SerializeField] private GameObject inventory;

    [SerializeField] private Button inventoryButton;

    private void Awake() {
        inventoryButton.onClick.AddListener(InventoryButton);
    }

    private void Start() {        
        inventory.SetActive(false);
    }

    private void Update() {
        InventoryInput();
    }

    private void InventoryInput() {
        if(Input.GetKeyDown(KeyCode.E)) {
            inventory.SetActive(!inventory.activeSelf);
        }            
        if(Input.GetKeyDown(KeyCode.Escape)) {
            inventory.SetActive(false);
        }
    }

    public void InventoryButton() {
        inventory.SetActive(!inventory.activeSelf);
    }
}
