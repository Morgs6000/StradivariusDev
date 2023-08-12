using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData {
    public string itemID;
    public Texture itemTexture;
    public Vector2 itemUV;

    public static Rect uv(Vector2 textureCoordinate) {
        Vector2 textureSizeInTile = new Vector2(16, 16);

        float x = textureCoordinate.x;
        float y = textureCoordinate.y;

        float _x = 1.0f /  textureSizeInTile.x;
        float _y = 1.0f /  textureSizeInTile.y;

        y = (textureSizeInTile.y - 1) - y;

        x *= _x;
        y *= _y;

        float w = _x;
        float h = _y;

        return new Rect(x, y, w, h);
    }

    public Vector2 GetUV() {
        return itemUV;
    }

    public ItemData(string id, Texture texture, Vector2 uv) {
        itemID = id;
        itemTexture = texture;
        itemUV = uv;
    }

    public static ItemData GetItem(string id) {
        foreach(ItemData itemData in ItemManager.items) {
            if(itemData.itemID == id) {
                return itemData;
            }
        }
        
        return default;
    }
}
