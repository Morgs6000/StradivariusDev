using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData {
    public string textualID;
    public string itemName;

    public Texture itemTexture;
    public Vector2 itemUV;

    public EnumAction enumAction;
    public EnumSlotTag enumSlotTag;

    public int maxStack;
    public int maxDurability;

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
    */

    public ItemData(string id) {
        textualID = id;
    }

    public ItemData setIcon(Texture texture, int x, int y) {
        itemTexture = texture;
        itemUV = new Vector2(x, y);
        return this;
    }

    public ItemData setItemName(string name) {
        itemName = name;
        return this;
    }

    public ItemData setEnumAction(EnumAction action) {
        enumAction = action;
        return this;
    }

    public ItemData setMaxStack(int stack) {
        maxStack = stack;
        return this;
    }

    public ItemData setMaxDurability(int durability) {
        maxDurability = durability;
        return this;
    }

    public ItemData setEnumSlotTag(EnumSlotTag slotTag) {
        enumSlotTag = slotTag;
        return this;
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
