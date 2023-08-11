using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour {
    public Texture itemsAtlas;

    public Rect uv(Vector2 textureCoordinate) {
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
}
