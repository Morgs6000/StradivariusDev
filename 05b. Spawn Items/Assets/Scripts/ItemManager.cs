using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Texture itemAltas;

    public static List<ItemData> items = new List<ItemData>();

    private void Awake() {
        items.Add(new ItemData(
            "iron_pickaxe",
            itemAltas,
            new Vector2(2, 6)
        ));
        items.Add(new ItemData(
            "apple",
            itemAltas,
            new Vector2(10, 0)
        ));
    }
}
