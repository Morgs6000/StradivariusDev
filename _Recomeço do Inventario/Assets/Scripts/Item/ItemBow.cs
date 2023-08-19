using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBow : Item {
    public ItemBow(string textualID) : base(textualID) {
        this.maxStackSize = 1;
        this.setMaxDamage(384);
        this.setCreativeTab(CreativeTabs.COMBAT);
    }
}
