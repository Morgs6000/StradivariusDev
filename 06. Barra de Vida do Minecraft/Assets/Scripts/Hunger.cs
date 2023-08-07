using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private int current;

    // Lista de GameObjects com as sprites de pernil
    [SerializeField] private GameObject bar;
    [SerializeField] private Image[] drumsticks;

    // Lista de sprites para representar os diferentes estados de cada pernil
    [SerializeField] private Sprite[] sprites;

    private void Awake() {
        drumsticks = bar.GetComponentsInChildren<Image>();
    }

    private void Start() {
        max = 20;
        current = max;
    }

    private void Update() {
        UpadteBar();
    }

    private void UpadteBar() {
        // Percorre todos os GameObjects com as sprites de pernil
        for(int i = 0; i < drumsticks.Length; i++) {
            // Se o índice atual representar um ponto de fome, ativa o GameObject e altera a sprite para um pernil inteiro
            if(current >= 2 * i + 2) {
                drumsticks[i].gameObject.SetActive(true);
                drumsticks[i].sprite = sprites[0];
            }
            // Se o índice atual representar meio ponto de fome, ativa o GameObject e altera a sprite para meio pernil
            else if(current == 2 * i + 1) {
                drumsticks[i].gameObject.SetActive(true);
                drumsticks[i].sprite = sprites[1];
            }
            // Se o índice atual não representar nenhum ponto de fome, desativa o GameObject
            else {
                drumsticks[i].gameObject.SetActive(false);
            }
        }
    }

    public void Add() {
        if(current < max) {
            current++;
        }       
    }

    public void Remove() {
        if(current > 0) {
            current--;
        }        
    }

    public int getMax {
        get {
            return max;
        }
    }

    public float getCurrent {
        get {
            return current;
        }
    }
}
