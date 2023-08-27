using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Texture itemAltas;

    public static List<ItemData> items = new List<ItemData>();

    private void Awake() {
        /*
        items.Add(new ItemData(
            "iron_pickaxe",
            "Picareta de Ferro",
            itemAltas,
            new Vector2(2, 6)
        ));
        items.Add(new ItemData(
            "apple",
            "Maçã",
            itemAltas,
            new Vector2(10, 0),
            10
        ));
        items.Add(new ItemData(
            "coal",
            "Carvão",
            itemAltas,
            new Vector2(7, 0),
            10
        ));
        */

        items.Add(new ItemData("iron_pickaxe").setIcon(itemAltas, 2, 6).setItemName("Picareta de Ferro").setEnumAction(EnumAction.USE).setMaxDurability(10));
        items.Add(new ItemData("apple").setIcon(itemAltas, 10, 0).setItemName("Maçã").setEnumAction(EnumAction.EAT).setMaxStack(10));
        items.Add(new ItemData("coal").setIcon(itemAltas, 7, 0).setItemName("Carvão").setMaxStack(10));
        items.Add(new ItemData("iron_helmet").setIcon(itemAltas, 2, 0).setItemName("Elmo de Ferro").setEnumSlotTag(EnumSlotTag.HELMET));
        items.Add(new ItemData("iron_chestplate").setIcon(itemAltas, 2, 1).setItemName("Peitoral de Ferro").setEnumSlotTag(EnumSlotTag.CHESTPLATE));
        items.Add(new ItemData("iron_leggings").setIcon(itemAltas, 2, 2).setItemName("Calças de Ferro").setEnumSlotTag(EnumSlotTag.LEGGINGS));
        items.Add(new ItemData("iron_boots").setIcon(itemAltas, 2, 3).setItemName("Botas de Ferro").setEnumSlotTag(EnumSlotTag.BOOTS));
        items.Add(new ItemData("diamond_helmet").setIcon(itemAltas, 3, 0).setItemName("Elmo de Diamante").setEnumSlotTag(EnumSlotTag.HELMET));
        items.Add(new ItemData("diamond_chestplate").setIcon(itemAltas, 3, 1).setItemName("Peitoral de Diamante").setEnumSlotTag(EnumSlotTag.CHESTPLATE));
        items.Add(new ItemData("diamond_leggings").setIcon(itemAltas, 3, 2).setItemName("Calças de Diamante").setEnumSlotTag(EnumSlotTag.LEGGINGS));
        items.Add(new ItemData("diamond_boots").setIcon(itemAltas, 3, 3).setItemName("Botas de Diamante").setEnumSlotTag(EnumSlotTag.BOOTS));
    }
}
