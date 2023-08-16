using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public static List<Item> itemsList = new List<Item>();

    private void Awake() {
        itemsList.Add(new Item("iron_shovel").setIcon(texture, 0, 0).setItemName("Iron Shovel"));
    }

    public string textualID;

    private Item(string textualID) {
        this.textualID = textualID;
    }

    public Texture texture;
    public Vector2 iconUV;

    private Item setIcon(Texture texture, int x, int y) {
        this.texture = texture;
        this.iconUV = new Vector2(x, y);
        return this;
    }

    public string itemName;

    private Item setItemName(string itemName) {
        this.itemName = itemName;
        return this;
    }
}
