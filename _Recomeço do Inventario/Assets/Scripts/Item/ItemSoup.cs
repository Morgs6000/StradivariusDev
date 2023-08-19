using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSoup : Item {
    public ItemSoup(string textualID) : base(textualID) {
        this.setMaxStackSize(1);
    }
}
