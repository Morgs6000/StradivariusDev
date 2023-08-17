using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRenderer : MonoBehaviour {
    [SerializeField] private string textualID;

    private RawImage rawImage;

    [SerializeField] private string itemName;

    private void Awake() {
        rawImage = GetComponent<RawImage>();
    }

    private void Start() {
        InitialiseItem();
    }

    public void InitialiseItem() {
        string itemAtlas = Item.dictionaryTextualID[textualID].getItemAtlas();
        rawImage.texture = Resources.Load<Texture>("Textures/GUI/" + itemAtlas);
        rawImage.uvRect = uv(Item.dictionaryTextualID[textualID].getIconCoord());

        string name = Item.dictionaryTextualID[textualID].getItemName();
        itemName = StringManager.Instance.GetString(name);
    }

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
}
