using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour {
    [SerializeField] private int maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private Image barHealth;
    [SerializeField] private Image barHealth2;

    [SerializeField] private Image imageHearth;
    [SerializeField] private Sprite[] spriteHearth;

    [SerializeField] private TextMeshProUGUI currentHealthText;

    [SerializeField] private Hunger hunger;    

    [SerializeField] private float tempoDecorrido = 0;

    private void Start() {
        maxHealth = 20;
        currentHealth = maxHealth;
    }

    private void Update() {
        HealthUpdateBar();
        HealthUpdateSprite();
        HealthUpdateText();
        HealtUpdate();
    }

    private void HealthUpdateBar() {
        barHealth.fillAmount = currentHealth / maxHealth;
        barHealth2.fillAmount = currentHealth / maxHealth;
    }

    private void HealthUpdateSprite() {
        // Se a barra de VIDA estiver mais que 75% cheia:
        if(currentHealth >= (maxHealth * 0.75f)) {
            imageHearth.sprite = spriteHearth[0];
        }
        // Se a barra de VIDA estiver mais que 50% cheia:
        else if(currentHealth >= (maxHealth * 0.50f)) {
            imageHearth.sprite = spriteHearth[1];
        }
        // Se a barra de VIDA estiver mais que 25% cheia: 
        else if(currentHealth >= (maxHealth * 0.25f)) {
            imageHearth.sprite = spriteHearth[2];
        }
        // Se a barra de VIDA estiver mais que 0% cheia:
        else if(currentHealth >= 0) {
            imageHearth.sprite = spriteHearth[3];
        }
    }

    private void HealthUpdateText() {
        currentHealthText.text = currentHealth.ToString("F0");
        //currentHealthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

        // Se a barra de VIDA estiver mais que 75% cheia:
        if(currentHealth >= (maxHealth * 0.75f)) {
            currentHealthText.color = Color.green;
        }
        // Se a barra de VIDA estiver mais que 50% cheia:
        else if(currentHealth >= (maxHealth * 0.50f)) {
            currentHealthText.color = Color.yellow;
        }
        // Se a barra de VIDA estiver mais que 25% cheia: 
        else if(currentHealth >= (maxHealth * 0.25f)) {
            currentHealthText.color = new Color(1.0f, 0.5f, 0.0f);
        }
        // Se a barra de VIDA estiver mais que 0% cheia:
        else if(currentHealth >= 0) {
            currentHealthText.color = Color.red;
        }
    }

    private void HealtUpdate() {
        // Se a barra de VIDA estiver cheia e a barra de FOME estiver mais que 0% cheia,
        // resete o contador.
        if(currentHealth >= maxHealth && hunger.getCurrentHunger > 0) {
            tempoDecorrido = 0;
        }
        // Se a barra de FOME estiver mais que 75% cheia,
        // +1 HP a cada 0,5 segundo.
        else if(hunger.getCurrentHunger >= (hunger.getMaxHunger * 0.75f)) {
            IncreaseHealthOverTime(0.5f);
        }
        // Se a barra de FOME estiver mais que 25% cheia,
        // +1 HP a cada 4 segundos.
        else if(hunger.getCurrentHunger >= (hunger.getMaxHunger * 0.25f)) {
            IncreaseHealthOverTime(4.0f);
        }
        // Se a barra de FOME estiver mais que 0% cheia,
        // resete o contador.
        else if(hunger.getCurrentHunger > 0) {
            tempoDecorrido = 0;
        }
        // Se a barra de FOME estiver vazia,
        // -1 HP a cada 4 segundos.
        else if(hunger.getCurrentHunger == 0) {
            //currentHealth -= (0.25f * Time.deltaTime);
            DecreaseHealthOverTime(4.0f);
        }

        // Na dificuldade Facil, a saúde do jogador para de cair em 50%,
        // no Normal, para em 5%,
        // e no Dificil, continua drenando até que o jogador coma alguma coisa ou morra de fome.
    }

    private void IncreaseHealthOverTime(float interval) {
        tempoDecorrido += Time.deltaTime;

        // Se o tempo decorrido for maior ou igual ao intervalo em segundos, 
        // chame o método AddHealth() e resete o contador.
        if(tempoDecorrido >= interval) {
            AddHealth();
            tempoDecorrido = 0;
        }
    }

    private void DecreaseHealthOverTime(float interval) {
        tempoDecorrido += Time.deltaTime;

        // Se o tempo decorrido for maior ou igual ao intervalo em segundos,
        // chame o método RemoveHealth() e resete o contador.
        if(tempoDecorrido >= interval) {
            RemoveHealth();
            tempoDecorrido = 0;
        }
    }

    public void AddHealth() {
        if(currentHealth < maxHealth) {
            currentHealth++;
        }       
    }

    public void RemoveHealth() {
        if(currentHealth > 0) {
            currentHealth--;
        }
    }
}
