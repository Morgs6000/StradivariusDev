using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlintAndSteel : Item {
    public ItemFlintAndSteel(string textualID) : base(textualID) {
        this.maxStackSize = 1;
        this.setMaxDamage(64);
        this.setCreativeTab(CreativeTabs.TOOLS);
    }

    // 🔴 remover função
    public override EnumAction getItemUseAction() {
        return EnumAction.USE;
    }
}
