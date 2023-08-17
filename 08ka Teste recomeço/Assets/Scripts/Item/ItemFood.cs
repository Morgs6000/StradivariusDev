using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFood : Item {
    // Número de ticks a serem executados durante 'EnumAction' até o resultado.
    public int itemUseDuration;

    // A quantidade que este alimento cura o jogador.
    private int healAmout;
    private float saturationModifier;

    // Se os lobos gostam desta comida (verdadeiro para costelas de porco cruas e cozidas).
    private bool isWolfsFavoriteMeat;

    public ItemFood(string textualID, int healAmout, float saturationModifier, bool isWolfsFavoriteMeat) : base(textualID) {
        this.itemUseDuration = 32;

        this.healAmout = healAmout;
        this.saturationModifier = saturationModifier;

        this.isWolfsFavoriteMeat = isWolfsFavoriteMeat;

        this.setCreativeTab("food");
    }

    public override EnumAction getItemUseAction() {
        return EnumAction.EAT;
    }
}
