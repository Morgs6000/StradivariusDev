using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoal : Item {
    public ItemCoal(string textualID) : base(textualID) {
        this.setMaxDamage(0);
        this.setCreativeTab(CreativeTabs.MATERIALS);
    }
}
