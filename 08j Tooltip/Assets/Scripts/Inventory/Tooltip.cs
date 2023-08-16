using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    //private static Tooltip curret;

    [SerializeField] private RectTransform tooltipRect;
    [SerializeField] private Canvas canvas;

    private static bool tooltipActive;

    [Space(20)]
    //[SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private LayoutElement layoutElement;
    [SerializeField] private int characterWrapLimit;

    [Space(20)]
    [SerializeField] private TextMeshProUGUI headerField;
    [SerializeField] private TextMeshProUGUI contentField;
    [SerializeField] private TextMeshProUGUI idField;

    [SerializeField] private InterfaceManager interfaceManager;

    private void Awake() {
        //curret = this;

        interfaceManager = FindObjectOfType<InterfaceManager>();
    }

    private void Start() {
        tooltipActive = false;
        //tooltipRect.gameObject.SetActive(false);
    }

    private void Update() {
        TooltipPosition();
        //SetText();

        if(!interfaceManager.inventoryActive) {
            Hide();
        }
    }

    private void TooltipPosition() {
        // Obtém a posição do mouse na tela
        Vector2 mousePosition = Input.mousePosition;

        // Joga o tooltipo um tiquinho pra baixo do mouse
        Vector2 tooltipPosition = new Vector2(mousePosition.x + 15, mousePosition.y - 10);

        // Ajusta a largura e a altura do tooltip para levar em consideração o Scale Factor do Canvas
        float tooltipWidth = tooltipRect.rect.width * canvas.scaleFactor;
        float tooltipHeight = tooltipRect.rect.height * canvas.scaleFactor;

        // Verifica se o tooltip está dentro dos limites da tela
        if(tooltipPosition.x + tooltipWidth > Screen.width) {
            tooltipPosition.x = Screen.width - tooltipWidth;
        }
        if(tooltipPosition.x < 0) {
            tooltipPosition.x = 0;
        }        
        if(tooltipPosition.y > Screen.height) {
            tooltipPosition.y = Screen.height;
        }
        if(tooltipPosition.y - tooltipHeight < 0) {
            tooltipPosition.y = tooltipHeight;
        }

        // Define a posição do tooltip
        tooltipRect.pivot = new Vector2(0, 1);
        tooltipRect.position = tooltipPosition;

        tooltipRect.gameObject.SetActive(tooltipActive);
    }

    public void Show(string header, string content, string id) {
        //curret.tooltipRect.gameObject.SetActive(true);
        tooltipActive = true;

        //curret.TooltipPosition();

        SetText(header, content, id);
    }

    public void Hide() {
        //curret.tooltipRect.gameObject.SetActive(false);
        tooltipActive = false;
    }

    private void SetText(string header, string content, string id) {
        //textMeshPro.text = "Hello World!";
        headerField.text = header;
        //contentField.text = content;
        idField.text = id;

        if(!string.IsNullOrEmpty(content)) {
            contentField.text = content;
            contentField.gameObject.SetActive(true);
        }
        else {
            contentField.gameObject.SetActive(false);
        }

        int textLength = contentField.text.Length;
        //Debug.Log("Text Length: " + textLength);

        //RectTransform textRect = textMeshPro.GetComponent<RectTransform>();

        if(textLength > characterWrapLimit) {
            layoutElement.enabled = true;
            //Debug.Log("Enabling LayoutElement");
        }
        else {
            layoutElement.enabled = false;
            //Debug.Log("Disabling LayoutElement");
        }
    }
}
