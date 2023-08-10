using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scritable object/Item", fileName = "New Item")]
public class ScriptableItem : ScriptableObject {
    //public EnumItem itemID;
    public Sprite sprite;
    public string itemName;
    //public int maxStack = 1;
    //public EnumAction getItemUseAction;
}
