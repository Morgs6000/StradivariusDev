using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private float current;

    // Lista de GameObjects com as sprites de coração
    [SerializeField] private GameObject bar;
    [SerializeField] private Image[] hearts;

    // Lista de sprites para representar os diferentes estados de cada coração
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Hunger hunger;

    [SerializeField] private float tempoDecorrido;

    private void Awake() {
        hearts = bar.GetComponentsInChildren<Image>();
    }

    private void Start() {
        max = 20;
        current = max;
    }

    private void Update() {
        UpadteBar();
        HealthUpdate();
    }

    private void HealthUpdate() {
        // Se a barra de VIDA estiver cheia e a barra de FOME estiver mais que 0% cheia,
        // resete o contador.
        if(current == max && hunger.getCurrent > 0) {
            tempoDecorrido = 0;
        }
        // Se a barra de FOME estiver mais que 75% cheia,
        // +1 HP a cada 0,5 segundo.
        else if(hunger.getCurrent >= (hunger.getMax * 0.75f)) {
            AddTime(0.5f);
        }
        // Se a barra de FOME estiver mais que 25% cheia,
        // +1 HP a cada 4 segundos.
        else if(hunger.getCurrent >= (hunger.getMax * 0.25f)) {
            AddTime(4.0f);
        }
        // Se a barra de FOme estiver mais que 0% cheia,
        // resete o contador.
        else if(hunger.getCurrent > 0) {
            tempoDecorrido = 0;
        }
        // Se a barra de FOME estiver vazia,
        // -1 HP a cada 4 segundos.
        else if(hunger.getCurrent == 0) {
            //current -= (0.25f * Time.deltaTime);
            RemoveTime(4.0f);
        }
    }

    private void AddTime(float intervalo) {
        tempoDecorrido += Time.deltaTime;

        if(tempoDecorrido >= intervalo) {
            Add();
            tempoDecorrido = 0;
        }
    }

    private void RemoveTime(float intervalo) {
        tempoDecorrido += Time.deltaTime;

        if(tempoDecorrido >= intervalo) {
            Remove();
            tempoDecorrido = 0;
        }
    }

    private void UpadteBar() {
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
}
