using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hunger : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private int current;

    [SerializeField] private Image bar;
    [SerializeField] private Image bar2;

    [SerializeField] private Image icon;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Start() {
        
        max = 20;
        current = max;
    }

    private void Update() {
        UpadteBar();
        HungerUpdate();
    }

    private void HungerUpdate() {
        textMeshPro.text = current.ToString();

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
