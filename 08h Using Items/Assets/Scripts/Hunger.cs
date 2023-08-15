using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private int current;

    // Lista de GameObjects com as sprites de coração
    [SerializeField] private GameObject bar;
    [SerializeField] private Image[] drumsticks;

    // Lista de sprites para representar os diferentes estados de cada coração
    [SerializeField] private Sprite[] sprites;

    private void Awake() {
        drumsticks = bar.GetComponentsInChildren<Image>();
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
        for(int i = 0; i < drumsticks.Length; i++) {
            // Se o índice atual representar um ponto de vida, ativa o GameObject e altera a sprite para um coração inteiro
            if(current >= 2 * i + 2) {
                drumsticks[i].gameObject.SetActive(true);
                drumsticks[i].sprite = sprites[0];
            }
            // Se o índice atual representar meio ponto de vida, ativa o GameObject e altera a sprite para meio coração
            else if(current == 2 * i + 1) {
                drumsticks[i].gameObject.SetActive(true);
                drumsticks[i].sprite = sprites[1];
            }
            // Se o índice atual não representar nenhum ponto de vida, desativa o GameObject
            else {
                drumsticks[i].gameObject.SetActive(false);
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
