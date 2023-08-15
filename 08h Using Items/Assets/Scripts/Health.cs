using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private int current;

    // Lista de GameObjects com as sprites de coração
    [SerializeField] private GameObject bar;
    [SerializeField] private Image[] hearts;

    // Lista de sprites para representar os diferentes estados de cada coração
    [SerializeField] private Sprite[] sprites;

    private void Awake() {
        hearts = bar.GetComponentsInChildren<Image>();
    }
    
    private void Start() {
        max = 20;
        //current = max;
    }

    private void Update() {
        UpdateBar();
    }

    private void UpdateBar() {
        // Percorre todos os GameObjects com as sprites de coração
        for(int i = 0; i < hearts.Length; i++) {
            // Se o índice atual representar um ponto de vida, ativa o GameObject e altera a sprite para um coração inteiro
            if(current >= 2 * i + 2) {
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = sprites[0];
            }
            // Se o índice atual representar meio ponto de vida, ativa o GameObject e altera a sprite para meio coração
            else if(current == 2 * i + 1) {
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = sprites[1];
            }
            // Se o índice atual não representar nenhum ponto de vida, desativa o GameObject
            else {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    public void Add(int value) {
        if(current < max) {
            current += value;
        }
    }

    public void Remove(int value) {
        if(current > 0) {
            current -= value;
        }
    }
}
