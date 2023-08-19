using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArmor : Item {
    // Contém o maxDamage 'base' que cada armorType tem.
    private static int[] maxDamageArray = new int[] {11, 16, 15, 13};

    // Armazena o tipo de armadura: 0 é capacete, 1 é placa, 2 são pernas e 3 são botas
    private int armorType;

    // Mantém a quantidade de dano que a armadura reduz em durabilidade total.
    private int damageReduceAmount;

    // Usado no RenderPlayer para selecionar a armadura correspondente a ser renderizada no jogador: 0 é pano, 1 é corrente, 2 é ferro, 3 é diamante e 4 é ouro.
    private int renderIndex;

    // O ArmorMaterial usado para este ItemArmor
    private ArmorMaterial armorMaterial;

    public ItemArmor(string textualID, ArmorMaterial armorMaterial, int renderIndex, int armorType) : base(textualID) {
        this.armorMaterial = armorMaterial;
        this.armorType = armorType;
        this.renderIndex = renderIndex;
        this.damageReduceAmount = armorMaterial.getDamageReductionAmount(armorType);
        this.setMaxDamage(armorMaterial.getDurability(armorType));
        this.maxStackSize = 1;
        this.setCreativeTab(CreativeTabs.COMBAT);

        this.getEnumSlotTag(armorType);
    }

    // Retorna a matriz de fator de 'dano máximo' para a armadura, cada peça de armadura tem um fator de durabilidade (que fica  multiplicado pelo fator de material da armadura)
    public static int[] getMaxDamageArray() {
        return maxDamageArray;
    }

    // 🔴 remover função
    public override EnumAction getItemUseAction() {
        return EnumAction.USE;
    }

    // 🔴
    private static EnumSlotTag[] enumSlotTags = new EnumSlotTag[] {EnumSlotTag.HELMET, EnumSlotTag.CHESTPLATE, EnumSlotTag.LEGGINGS, EnumSlotTag.BOOTS};

    // 🔴
    public override EnumSlotTag getEnumSlotTag(int armorType) {
        return enumSlotTags[armorType];
    }
}
