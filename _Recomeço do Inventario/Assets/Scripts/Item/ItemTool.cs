using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTool : Item {
    // O material de que esta ferramenta é feita.
    private ToolMaterial toolMaterial;

    // Danos contra entidades.
    private int damageVsEntity;

    // Matriz de blocos contra a qual a ferramenta tem efeito extra.
    //private Block[] blocksEffectiveAgainst;
    private float efficiencyOnProperMaterial = 4.0f;
    
    public ItemTool(string textualID, ToolMaterial toolMaterial) : base(textualID) {
        this.toolMaterial = toolMaterial;
        //this.damageVsEntity = damageVsEntity + toolMaterial.getDamageVsEntity();

        //this.blocksEffectiveAgainst = blocksEffectiveAgainst;
        this.efficiencyOnProperMaterial = toolMaterial.getEfficiencyOnProperMaterial();
        
        this.maxStackSize = 1;
        this.setMaxDamage(toolMaterial.getMaxUses());
        this.setCreativeTab(CreativeTabs.TOOLS);
    }

    // 🔴 remover função
    public override EnumAction getItemUseAction() {
        return EnumAction.USE;
    }
}
