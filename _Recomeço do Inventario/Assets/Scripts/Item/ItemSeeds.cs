using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSeeds : Item {
    public ItemSeeds(string textualID) : base(textualID) {
        this.setCreativeTab(CreativeTabs.MATERIALS);
    }
}
