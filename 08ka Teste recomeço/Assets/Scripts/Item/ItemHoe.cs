using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoe : Item {
    private ToolMaterial toolMaterial;

    public ItemHoe(string textualID, ToolMaterial toolMaterial) : base(textualID) {
        this.toolMaterial = toolMaterial;
        this.maxStackSize = 1;
        this.setMaxDamage(toolMaterial.getMaxUses());
        this.setCreativeTab(CreativeTabs.TOOLS);
    }
}
