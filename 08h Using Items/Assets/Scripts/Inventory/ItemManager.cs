using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Texture itemAltas;

    public static List<ItemData> items = new List<ItemData>();

    private void Awake() {
        items.Add(new ItemData("iron_pickaxe").setIcon(itemAltas, 2, 6).setItemName("Picareta de Ferro").setEnumAction(EnumAction.USE).setMaxDurability(10));
        items.Add(new ItemData("apple").setIcon(itemAltas, 10, 0).setItemName("Maçã").setEnumAction(EnumAction.EAT).setMaxStack(10));
        items.Add(new ItemData("coal").setIcon(itemAltas, 7, 0).setItemName("Carvão").setMaxStack(10));
    }
}
