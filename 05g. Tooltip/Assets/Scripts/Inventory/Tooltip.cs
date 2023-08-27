using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    [SerializeField] private RectTransform tooltipRect;
    [SerializeField] private Canvas canvas;
    [SerializeField] private bool tooltipActive;
    [SerializeField] private InterfaceManager interfaceManager;

    [Space(20)]
    [SerializeField] private TextMeshProUGUI headerField;
    [SerializeField] private TextMeshProUGUI contentField;
    [SerializeField] private TextMeshProUGUI idField;

    [Space(20)]
    [SerializeField] private LayoutElement layoutElement;
    [SerializeField] private int characterWrapLimit = 30;

    private void Awake() {
        interfaceManager = FindObjectOfType<InterfaceManager>();
    }

    private void Start() {
        tooltipActive = false;
    }

    private void Update() {
        UpdateTooltip();

        if(!interfaceManager.inventoryActive) {
            Hide();
        }
    }

    private void UpdateTooltip() {
        Vector2 mousePostion = Input.mousePosition;
        Vector2 tooltipPositon = new Vector2(mousePostion.x + 15, mousePostion.y - 10);

        float tooltipWidth = tooltipRect.rect.width * canvas.scaleFactor;
        float tooltipHeight = tooltipRect.rect.height * canvas.scaleFactor;

        if(tooltipPositon.x + tooltipWidth > Screen.width) {
            tooltipPositon.x = Screen.width - tooltipWidth;
        }
        if(tooltipPositon.x < 0) {
            tooltipPositon.x = 0;
        }
        if(tooltipPositon.y > Screen.height) {
            tooltipPositon.y = Screen.height;
        }
        if(tooltipPositon.y - tooltipHeight < 0) {
            tooltipPositon.y = tooltipHeight;
        }

        tooltipRect.pivot = new Vector2(0, 1);
        tooltipRect.position = tooltipPositon;

        tooltipRect.gameObject.SetActive(tooltipActive);
    }

    public void SetText(string header, string content, string id) {
        headerField.text = header;

        if(!string.IsNullOrEmpty(content)) {
            contentField.text = content;
            contentField.gameObject.SetActive(true);
        }
        else {
            contentField.gameObject.SetActive(false);
        }

        int textLenght = contentField.text.Length;

        if(textLenght > characterWrapLimit) {
            layoutElement.enabled = true;
        }
        else {
            layoutElement.enabled = false;
        }
        
        idField.text = id;
    }

    public void Show(string header, string content, string id) {
        tooltipActive = true;

        SetText(header, content, id);
    }

    public void Hide() {
        tooltipActive = false;
    }
}
