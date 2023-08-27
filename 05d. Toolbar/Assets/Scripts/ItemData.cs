using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData {
    public string textualID;
    public string itemName;

    public Texture itemTexture;
    public Vector2 itemUV;

    public int maxStack;

    public static Rect uv(Vector2 textureCoordinate) {
        Vector2 textureSizeInTiles = new Vector2(16, 16);

        float x = textureCoordinate.x;
        float y = textureCoordinate.y;

        float _x = 1.0f / textureSizeInTiles.x;
        float _y = 1.0f / textureSizeInTiles.y;

        y = (textureSizeInTiles.y - 1) - y;

        x *= _x;
        y *= _y;

        float w = _x;
        float h = _y;

        return new Rect(x, y, w, h);
    }

    public ItemData(string id, string name, Texture texture, Vector2 uv) {
        textualID = id;
        itemName = name;

        itemTexture = texture;
        itemUV = uv;
    }

    public ItemData(string id, string name, Texture texture, Vector2 uv, int stack) {
        textualID = id;
        itemName = name;

        itemTexture = texture;
        itemUV = uv;
        maxStack = stack;
    }

    public static ItemData GetItem(string id) {
        foreach(ItemData itemData in ItemManager.items) {
            if(itemData.textualID == id) {
                return itemData;
            }
        }

        return default;
    }
}
