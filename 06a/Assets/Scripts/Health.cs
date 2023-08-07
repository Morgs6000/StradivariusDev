using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private float curret;

    [SerializeField] private GameObject bar;
    [SerializeField] private Image[] hearts;

    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Hunger hunger;

    [SerializeField] private float tempoDecorrido;

    private void Awake() {
        hearts = bar.GetComponentsInChildren<Image>();
    }

    private void Start() {
        max = 20;
        curret = max;
    }

    private void Update() {
        UpdateBar();
        HealthUpdate();
    }

    private void UpdateBar() {
        for(int i = 0; i < hearts.Length; i++) {
            if(curret >= 2 * i + 2) {
                hearts[i].sprite = sprites[0];
                hearts[i].gameObject.SetActive(true);
            }
            else if(curret == 2 * i + 1) {
                hearts[i].sprite = sprites[1];
                hearts[i].gameObject.SetActive(true);
            }
            else {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    private void HealthUpdate() {
        // Se a barra de VIDA estiver cheia e a barra de FOME estiver mais que 0% cheia,
        // resete o contador.
        if(curret == max && hunger.getCurrent > 0) {
            tempoDecorrido = 0;
        }
        // Se a bara de FOME estiver mais que 75% cheia,
        // +1 HP a cada 0,5 segundo.
        else if(hunger.getCurrent >= (hunger.getMax * 0.75f)) {
            AddTime(0.5f);
        }
        // Se a barra de FOME estiver mais que 25% cheia,
        // +1 HP a cada 4 segunods.
        else if(hunger.getCurrent >= (hunger.getMax * 0.25f)) {
            AddTime(4.0f);
        }
        // Se a barra de FOME estiver mais que 0% cheia,
        // reseta o contador.
        else if(hunger.getCurrent > 0) {
            tempoDecorrido = 0;
        }
        // Se a bara de FOME estiver vazia,
        // -1 HP a cada 4 segundos.
        else if(hunger.getCurrent == 0) {
            //curret -= (Time.deltaTime / 4);
            RemoveTime(4.0f);
        }
    }

    private void AddTime(float value) {
        tempoDecorrido += Time.deltaTime;

        if(tempoDecorrido >= value) {
            Add();
            tempoDecorrido = 0;
        }
    }

    private void RemoveTime(float value) {
        tempoDecorrido += Time.deltaTime;

        if(tempoDecorrido >= value) {
            Remove();
            tempoDecorrido = 0;
        }
    }

    public void Add() {
        if(curret < max) {
            curret++;
        }
    }

    public void Remove() {
        if(curret > 0) {
            curret--;
        }
    }
}
