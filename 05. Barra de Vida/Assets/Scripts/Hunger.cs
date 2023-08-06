using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hunger : MonoBehaviour {
    [SerializeField] private int maxHunger;
    [SerializeField] private float currentHunger;

    [SerializeField] private Image barHunger;
    [SerializeField] private Image barHunger2;

    [SerializeField] private Image imageHearth;
    [SerializeField] private Sprite[] spriteHearth;

    [SerializeField] private TextMeshProUGUI currentHungerText;

    private void Start() {
        maxHunger = 20;
        currentHunger = maxHunger;
    }

    private void Update() {
        HungerUpdateBar();
        HungerUpdateSprite();
        HungerUpdateText();
    }

    private void HungerUpdateBar() {
        barHunger.fillAmount = currentHunger / maxHunger;
        barHunger2.fillAmount = currentHunger / maxHunger;
    }

    private void HungerUpdateSprite() {
        // Se a vida for maior que 75%
        if(currentHunger >= (maxHunger * 0.75f)) {
            imageHearth.sprite = spriteHearth[0];
        }
        // Se a vida for maior que 50%
        else if(currentHunger >= (maxHunger * 0.50f)) {
            imageHearth.sprite = spriteHearth[1];
        }
        // Se a vida for mairo que 25% 
        else if(currentHunger >= (maxHunger * 0.25f)) {
            imageHearth.sprite = spriteHearth[2];
        }
        // Se a vida for maior que 0%
        else if(currentHunger >= 0) {
            imageHearth.sprite = spriteHearth[3];
        }
    }

    private void HungerUpdateText() {
        currentHungerText.text = currentHunger.ToString();
        //currentHungerText.text = currentHunger.ToString() + " / " + maxHunger.ToString();

        // Se a vida for maior que 75%
        if(currentHunger >= (maxHunger * 0.75f)) {
            currentHungerText.color = Color.green;
        }
        // Se a vida for maior que 50%
        else if(currentHunger >= (maxHunger * 0.50f)) {
            currentHungerText.color = Color.yellow;
        }
        // Se a vida for mairo que 25% 
        else if(currentHunger >= (maxHunger * 0.25f)) {
            currentHungerText.color = new Color(1.0f, 0.5f, 0.0f);
        }
        // Se a vida for maior que 0%
        else if(currentHunger >= 0) {
            currentHungerText.color = Color.red;
        }
    }

    public void AddHunger() {
        if(currentHunger < maxHunger) {
            currentHunger++;
        }       
    }

    public void RemoveHunger() {
        if(currentHunger > 0) {
            currentHunger--;
        }
    }

    public int getMaxHunger {
        get {
            return maxHunger;
        }
    }

    public float getCurrentHunger {
        get {
            return currentHunger;
        }
    }
}
