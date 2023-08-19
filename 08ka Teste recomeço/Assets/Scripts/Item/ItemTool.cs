using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTool : Item {
    // Matriz de blocos contra a qual a ferramenta tem efeito extra.
    //private Block[] blocksEffectiveAgainst;
    protected float efficiencyOnProperMaterial = 4.0f;

    // Danos contra entidades.
    private int damageVsEntity;

    // O material de que esta ferramenta é feita.
    protected ToolMaterial toolMaterial;

    /*
    protected ItemTool(string textualID, Block[] blocksEffectiveAgainst, int damageVsEntity, ToolMaterial toolMaterial) : base(textualID) {
        //this.blocksEffectiveAgainst = blocksEffectiveAgainst;
        this.efficiencyOnProperMaterial = toolMaterial.getEfficiencyOnProperMaterial();
        
        this.damageVsEntity = damageVsEntity + toolMaterial.getDamageVsEntity();        
        this.toolMaterial = toolMaterial;
        
        this.maxStackSize = 1;
        this.setMaxDamage(toolMaterial.getMaxUses());
        this.setCreativeTab("tools");
    }
    */

    //*
    public ItemTool(string textualID, ToolMaterial toolMaterial) : base(textualID) {
        //this.blocksEffectiveAgainst = blocksEffectiveAgainst;
        this.efficiencyOnProperMaterial = toolMaterial.getEfficiencyOnProperMaterial();
        
        //this.damageVsEntity = damageVsEntity + toolMaterial.getDamageVsEntity();        
        this.toolMaterial = toolMaterial;
        
        this.maxStackSize = 1;
        this.setMaxDamage(toolMaterial.getMaxUses());
        this.setCreativeTab("tools");
    }
    //*/

    // 🔴 remover função
    public override EnumAction getItemUseAction() {
        return EnumAction.USE;
    }
}
