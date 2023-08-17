using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    private CreativeTabs tabToDisplayOn = null;

    public static Dictionary<string, Item> dictionaryTextualID = new Dictionary<string, Item>();

    public static Item[] itemsList = {
        new Item("iron_shovel").setIconCoord(2, 5),
        new Item("iron_pickaxe").setIconCoord(2, 6),
        new Item("iron_axe").setIconCoord(2, 7),
        new Item("flint_and_steel").setIconCoord(5, 0),
        new ItemFood("apple", 4, 0.3f, false).setIconCoord(10, 0),
        new Item("bow").setIconCoord(5, 1),
        new Item("arrow").setIconCoord(5, 2).setCreativeTab("combat"),
    };

    // O ID deste item.
    protected string textualID;

    // Tamanho máximo da pilha.
    private int maxStackSize = 64;

    private string itemAtlas = "items";
    private Vector2 iconUVRect;

    // Nome completo do item do arquivo de idioma.
    private string itemName;

    protected Item(string textualID) {
        this.textualID = textualID;

        dictionaryTextualID.Add(textualID, this);
        //dictionaryTextualID[textualID] = this;

        setItemName();
    }

    public string getItemAtlas() {
        return this.itemAtlas;
    }

    public Item setIconCoord(int x, int y) {
        this.iconUVRect = new Vector2(x, y);
        return this;
    }

    public Vector2 getIconCoord() {
        return this.iconUVRect;
    }

    // Definir o nome do item do arquivo de idioma.
    public Item setItemName() {
        this.itemName = "item." + textualID + ".name";
        return this;
    }

    public string getItemName() {
        return this.itemName;
    }

    public virtual EnumAction getItemUseAction() {
        return EnumAction.NONE;
    }

    public Item setCreativeTab(string label) {
        this.tabToDisplayOn = CreativeTabs.dictionaryTabLabel[label];
        return this;
    }
}
