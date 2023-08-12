using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager;

    private void Awake() {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Update() {
        UpdateDrag();

        /*
        // Cria um raio a partir do ponteiro do mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        // Verifica cada objeto atingido pelo raio
        foreach (RaycastHit hit in hits) {
            // Verifica se o objeto é um elemento de UI
            if(hit.collider.GetComponent<Slot>() != null) {
                // Este objeto é um elemento de UI, faça algo com ele
                Debug.Log("UI Element selecionado: " + hit.collider.gameObject.name);

                // Você pode adicionar lógica adicional aqui, dependendo do que deseja fazer com a UI
                // Por exemplo, verificar se é um botão, verificar o texto, etc.
            }
        } 
        */   
    }

    private void UpdateDrag() {
        if(transform.childCount == 1) {
            Item item = GetComponentInChildren<Item>();
            item.OnDragging();

            if(!EventSystem.current.IsPointerOverGameObject()) {
                // NOTA: Da pra fazer um Axis para usar os dois botões do mouse
                if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape)) {
                    if(item.parrentAfterDrag.transform.childCount == 0) {
                        item.OnEndDragging();
                    }
                    else {
                        foreach(Slot slot in inventoryManager.slots) {
                            Item item2 = slot.GetComponentInChildren<Item>();

                            if(!item2) {
                                item.transform.SetParent(slot.transform);
                                //item.image.raycastTarget = true;
                                item.rawImage.raycastTarget = true;

                                return;
                            }
                        }
                    }
                }
            }
        }        
    }
}
