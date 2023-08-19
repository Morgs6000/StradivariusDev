using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSword : Item {
    private ToolMaterial toolMaterial;

    public ItemSword(string textualID, ToolMaterial toolMaterial) : base(textualID) {
        this.toolMaterial = toolMaterial;
    }
}
