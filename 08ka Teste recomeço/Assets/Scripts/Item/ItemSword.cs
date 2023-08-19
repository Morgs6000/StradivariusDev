using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Item {    
    private ToolMaterial toolMaterial;

    private int weaponDamage;

    public ItemSword(string textualID, ToolMaterial toolMaterial) : base(textualID) {
        this.toolMaterial = toolMaterial;
        this.weaponDamage = 4 + toolMaterial.getDamageVsEntity();

        this.maxStackSize = 1;
        this.setMaxDamage(toolMaterial.getMaxUses());
        this.setCreativeTab(CreativeTabs.COMBAT);
    }

    // 🔴 remover função
    public override EnumAction getItemUseAction() {
        return EnumAction.USE;
    }
}
