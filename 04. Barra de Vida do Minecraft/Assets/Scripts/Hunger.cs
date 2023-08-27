using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour {
    [SerializeField] private int max;
    [SerializeField] private int curret;

    [SerializeField] private GameObject bar;
    [SerializeField] private Image[] drumsticks;

    [SerializeField] private Sprite[] sprites;

    private void Awake() {
        drumsticks = bar.GetComponentsInChildren<Image>();
    }
    private void Start() {
        max = 20;
        curret = max;
    }

    private void Update() {
        UpdateBar();
    }

    private void UpdateBar() {
        for(int i = 0; i < drumsticks.Length; i++) {
            if(curret >= 2 * i + 2) {
                drumsticks[i].sprite = sprites[0];
                drumsticks[i].gameObject.SetActive(true);
            }
            else if(curret == 2 * i + 1) {
                drumsticks[i].sprite = sprites[1];
                drumsticks[i].gameObject.SetActive(true);
            }
            else {
                drumsticks[i].gameObject.SetActive(false);
            }
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

    public int getMax {
        get {
            return max;
        }
    }

    public int getCurrent {
        get {
            return curret;
        }
    }
}
