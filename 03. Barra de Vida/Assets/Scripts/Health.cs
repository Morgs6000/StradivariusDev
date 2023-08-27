using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private int current;

    [SerializeField] private Image bar;
    [SerializeField] private Image bar2;

    [SerializeField] private Image icon;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private TextMeshProUGUI textMeshPro;

    [SerializeField] private Hunger hunger;

    [SerializeField] private float tempoDecorrido;
    
    private void Start() {
        max = 20;
        current = max;
    }

    private void Update() {
        UpadteBar();
        HealthUpdate();
    }

    private void HealthUpdate() {
        textMeshPro.text = current.ToString("F0");

        // Se a barra de VIDA estiver mais que 75% cheia:
        if(current >= (max * 0.75f)) {
            icon.sprite = sprites[0];
            textMeshPro.color = Color.green;
        }
        // Se a barra de VIDA estiver mais que 50% cheia:
        else if(current >= (max * 0.50f)) {
            icon.sprite = sprites[1];
            textMeshPro.color = Color.yellow;
        }
        // Se a barra de VIDA estiver mais que 25% cheia:
        else if(current >= (max * 0.25f)) {
            icon.sprite = sprites[2];
            textMeshPro.color = new Color(1.0f, 0.5f, 0.0f);
        }
        // Se a barra de VIDA estiver mais que 0% cheia:
        else if(current >= (max * 0.0f)) {
            icon.sprite = sprites[3];
            textMeshPro.color = Color.red;
        }

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
        bar.fillAmount = (float)current / max;
        bar2.fillAmount = (float)current / max;
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
