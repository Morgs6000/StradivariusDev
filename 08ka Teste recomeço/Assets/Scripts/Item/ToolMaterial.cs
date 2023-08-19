using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMaterial {
    public static Dictionary<string, ToolMaterial> dictionaryToolMaterial = new Dictionary<string, ToolMaterial>();

    public static ToolMaterial[] toolMaterials = {
        new ToolMaterial("wood", 0, 59, 2.0f, 0, 15),
        new ToolMaterial("stone", 1, 131, 4.0f, 1, 5),
        new ToolMaterial("iron", 2, 250, 6.0f, 2, 14),
        new ToolMaterial("emerald", 3, 1561, 8.0f, 3, 10),
        new ToolMaterial("gold", 0, 32, 12.0f, 0, 22)
    };

    // O nível de material que esta ferramenta pode colher (3 = DIAMANTE, 2 = FERRO, 1 = PEDRA, 0 = FERRO/OURO)
    private int harvestLevel;

    // O número de utilizações que este material permite. (madeira = 59, pedra = 131, ferro = 250, diamante = 1561, ouro = 32)
    private int maxUses;

    // A resistência deste material de ferramenta contra blocos contra os quais é eficaz.
    private float efficiencyOnProperMaterial;

    // Danos contra entidades.
    private int damageVsEntity;

    // Define o fator de encantamento natural do material.
    private int enchantability;

    public ToolMaterial(string material, int harvestLevel, int maxUses, float efficiencyOnProperMaterial, int damageVsEntity, int enchantability) {
        dictionaryToolMaterial.Add(material, this);

        this.harvestLevel = harvestLevel;
        this.maxUses = maxUses;
        this.efficiencyOnProperMaterial = efficiencyOnProperMaterial;
        this.damageVsEntity = damageVsEntity;
        this.enchantability = enchantability;
    }

    // O número de utilizações que este material permite. (madeira = 59, pedra = 131, ferro = 250, diamante = 1561, ouro = 32)
    public int getMaxUses() {
        return this.maxUses;
    }

    // A resistência deste material de ferramenta contra blocos contra os quais é eficaz.
    public float getEfficiencyOnProperMaterial() {
        return this.efficiencyOnProperMaterial;
    }

    // Danos contra entidades.
    public int getDamageVsEntity() {
        return this.damageVsEntity;
    }
}
