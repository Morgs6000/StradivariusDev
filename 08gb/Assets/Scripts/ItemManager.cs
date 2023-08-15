using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Texture itemAltas;

    public static List<ItemData> items = new List<ItemData>();

    private void Awake() {
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
    }
}
