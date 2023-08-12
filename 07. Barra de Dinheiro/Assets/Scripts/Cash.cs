using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cash : MonoBehaviour {
    [SerializeField] private int current;

    [SerializeField] private TextMeshProUGUI textMeshPro;
    //[SerializeField] private GameObject icon;
    [SerializeField] private Image image;
    //[SerializeField] private Color color = Color.white;
    [SerializeField] private Sprite[] sprites;

    private static int mil = 100 * 10;
    private static int dezMil = mil * 10;
    private static int cemMil = dezMil * 10;
    private static int milhão = cemMil * 10;
    private static int dezMilhão = milhão * 10;
    private static int cemMilhão = dezMilhão * 10;
    private static int bilhão = cemMilhão * 10;

    private void Awake() {
        //image = icon.GetComponentInChildren<Image>();
    }

    private void Start() {
        
    }

    private void Update() {
        UpdateText();
        UpdateSprite();
    }

    private void UpdateText() {
        bool textActive = current > 0;
        textMeshPro.gameObject.SetActive(textActive);

        //if(current == 0) {
            //textMeshPro.gameObject.SetActive(false);
        //}
        //else {
            //textMeshPro.gameObject.SetActive(true);
            
            if(current >= 1) {
                textMeshPro.text = current.ToString();
                textMeshPro.color = Color.yellow;
            }
            if(current >= mil) {
                textMeshPro.text = (current / mil).ToString() + " K";
                textMeshPro.color = Color.white;
            }
            if(current >= milhão) {
                textMeshPro.text = (current / milhão).ToString() + " M";
                textMeshPro.color = Color.green;
            }
            if(current >= bilhão) {
                textMeshPro.text = (current / bilhão).ToString() + " B";
                textMeshPro.color = Color.cyan;
            }
        //}        
    }

    private void UpdateSprite() {
        //icon.color = color;

        bool iconActive = current > 0;
        image.gameObject.SetActive(iconActive);
        
        //if(current == 0) {
            //image.sprite = null;
            //color.a = 0.0f;
            //image.gameObject.SetActive(false);
        //}
        //else {
            //color.a = 1.0f;
            //textMeshPro.gameObject.SetActive(true);

            if(current == 1) {
                image.sprite = sprites[1];
            }
            if(current == 2) {
                image.sprite = sprites[2];
            }
            if(current == 3) {
                image.sprite = sprites[3];
            }
            if(current == 4) {
                image.sprite = sprites[4];
            }
            if(current >= 5) {
                image.sprite = sprites[5];
            }
            if(current >= 25) {
                image.sprite = sprites[6];
            }
            if(current >= 100) {
                image.sprite = sprites[7];
            }
            if(current >= 250) {
                image.sprite = sprites[8];
            }
            if(current >= mil) {
                image.sprite = sprites[9];
            }
            if(current >= dezMil) {
                image.sprite = sprites[10];
            }
        //}
    }

    public void Add(int value) {
        if(current <= int.MaxValue - value) {
            current += value;
        }
        else {
            Debug.Log("Operação inválida: o valor máximo (" + int.MaxValue + ") do inteiro seria excedido.");
        }

        // O número máximo de moedas que os jogadores podem manter em uma única pilha de inventário é 2.147.483.647 (2,1 bilhões) devido ao uso do tipo de dados inteiros de 32 bits assinados (valor máximo de 2^31-1 ).

        // Em muitas linguagens, o 'int' é de 32 bits, e o intervalo típico é de -2.147.483.648 a 2.147.483.647.
    }

    public void Remove(int value) {
        if(current >= value) {
            current -= value;
        }
        else {
            Debug.Log("Operação inválida: a quantidade a ser subtraída é maior do que o valor atual.");
        }
    }
}
