using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorMaterial {
    public static ArmorMaterial CLOTH = new ArmorMaterial(5, new int[]{1, 3, 2, 1}, 15);
    public static ArmorMaterial CHAIN = new ArmorMaterial(15, new int[]{2, 5, 4, 1}, 12);
    public static ArmorMaterial IRON = new ArmorMaterial(15, new int[]{2, 6, 5, 2}, 9);
    public static ArmorMaterial GOLD = new ArmorMaterial(7, new int[]{2, 5, 3, 1}, 25);
    public static ArmorMaterial DIAMOND = new ArmorMaterial(33, new int[]{3, 8, 6, 3}, 15);

    // Contém o fator máximo de dano (cada peça multiplica pelo seu próprio valor) do material, este é o item dano (quanto pode absorver antes das quebras)
    private int maxDamageFactor;

    // Contém a redução de dano (cada 1 ponto é meio escudo no gui) de cada peça da armadura (capacete, placa, pernas e botas)
    private int[] damageReductionAmountArray;

    // Retorne o fator de encantamento do material
    private int enchantability;

    private ArmorMaterial(int maxDamageFactor, int[] damageReductionAmountArray, int enchantability) {
        this.maxDamageFactor = maxDamageFactor;
        this.damageReductionAmountArray = damageReductionAmountArray;
        this.enchantability = enchantability;
    }

    // Retorna a durabilidade de um slot de armadura para este tipo.
    public int getDurability(int armorType) {
        return ItemArmor.getMaxDamageArray()[armorType] * this.maxDamageFactor;
    }

    //Devolve a redução de dano (cada 1 ponto é meio escudo no gui) do índice da peça passada (0 = capacete, 1 = placa, 2 = pernas e 3 = botas)
    public int getDamageReductionAmount(int armorType) {
        return this.damageReductionAmountArray[armorType];
    }
}
