using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Texture itemAtlas;

    public static List<ItemData> items = new List<ItemData>();

    private void Awake() {
        items.Add(new ItemData(
            "iron_pickaxe",
            itemAtlas,
            new Vector2(2, 6)
        ));

        items.Add(new ItemData(
            "apple",
            itemAtlas,
            new Vector2(10, 0)
        ));
    }
}
