using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData {
    public string itemID;
    public Vector2 itemUV;
    public Texture texture;
    public bool isAtlas = true;

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

    /*
    public Vector2 GetUV(EnumItems itemID) {
        if(itemID == EnumItems.iron_pickaxe) {
            return new Vector2(2, 6);
        }
        if(itemID == EnumItems.apple) {
            return new Vector2(10, 0);
        }
        if(itemID == EnumItems.coal) {
            return new Vector2(7, 0);
        }
        
        return default;
    }
    */

    //*
    public Vector2 GetUV() {
        return itemUV;
    }
    //*/

    public ItemData(string id, Texture t, bool b) {
        itemID = id;
        texture = t;
        isAtlas = b;
    }

    public ItemData(string id, Texture t, Vector2 uv) {
        itemID = id;
        texture = t;
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
