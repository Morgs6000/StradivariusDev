using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    private CreativeTabs tabToDisplayOn = null;

    public static Dictionary<string, Item> dictionaryTextualID = new Dictionary<string, Item>();

    public static Item[] itemsList = {
        //new Item("iron_shovel").setIconCoord(2, 5),
        //new ItemSpade("iron_shovel", ToolMaterial.dictionaryToolMaterial["iron"]).setIconCoord(2, 5),
        //new ItemSpade("iron_shovel", setToolMaterial("iron")).setIconCoord(2, 5),
        new ItemTool("iron_shovel", ToolMaterial.dictionaryToolMaterial["iron"]).setIconCoord(2, 5),
        new ItemTool("iron_pickaxe", ToolMaterial.dictionaryToolMaterial["iron"]).setIconCoord(2, 6),
        new ItemTool("iron_axe", ToolMaterial.dictionaryToolMaterial["iron"]).setIconCoord(2, 7),
        new ItemFlintAndSteel("flint_and_steel").setIconCoord(5, 0),
        new ItemFood("apple", 4, 0.3f, false).setIconCoord(10, 0),
        new Item("bow").setIconCoord(5, 1),
        new Item("arrow").setIconCoord(5, 2).setCreativeTab("combat"),
        new Item("coal").setIconCoord(7, 0),
        new Item("diamond").setIconCoord(7, 3),
        new Item("iron_ingot").setIconCoord(7, 1),
        new Item("gold_ingot").setIconCoord(7, 2),
        new Item("iron_sword").setIconCoord(2, 4),
        new Item("wooden_sword").setIconCoord(0, 4),
        new ItemTool("wooden_shovel", ToolMaterial.dictionaryToolMaterial["wood"]).setIconCoord(0, 5),
        new ItemTool("wooden_pickaxe", ToolMaterial.dictionaryToolMaterial["wood"]).setIconCoord(0, 6),
        new ItemTool("wooden_axe", ToolMaterial.dictionaryToolMaterial["wood"]).setIconCoord(0, 7),
        new Item("stone_sword").setIconCoord(1, 4),
        new ItemTool("stone_shovel", ToolMaterial.dictionaryToolMaterial["stone"]).setIconCoord(1, 5),
        new ItemTool("stone_pickaxe", ToolMaterial.dictionaryToolMaterial["stone"]).setIconCoord(1, 6),
        new ItemTool("stone_axe", ToolMaterial.dictionaryToolMaterial["stone"]).setIconCoord(1, 7),
        new Item("diamond_sword").setIconCoord(3, 4),
        new ItemTool("diamond_shovel", ToolMaterial.dictionaryToolMaterial["emerald"]).setIconCoord(3, 5),
        new ItemTool("diamond_pickaxe", ToolMaterial.dictionaryToolMaterial["emerald"]).setIconCoord(3, 6),
        new ItemTool("diamond_axe", ToolMaterial.dictionaryToolMaterial["emerald"]).setIconCoord(3, 7),
        new Item("stick").setIconCoord(5, 3),
        new Item("bowl").setIconCoord(7, 4),
        new Item("mushroom_stew").setIconCoord(8, 4),
        new Item("golden_sword").setIconCoord(4, 4),
        new ItemTool("golden_shovel", ToolMaterial.dictionaryToolMaterial["gold"]).setIconCoord(4, 5),
        new ItemTool("golden_pickaxe", ToolMaterial.dictionaryToolMaterial["gold"]).setIconCoord(4, 6),
        new ItemTool("golden_axe", ToolMaterial.dictionaryToolMaterial["gold"]).setIconCoord(4, 7),
        new Item("string").setIconCoord(8, 0),
        new Item("feather").setIconCoord(8, 1),
        new Item("gunpowder").setIconCoord(8, 2),
        new Item("wooden_hoe").setIconCoord(0, 8),
        new Item("stone_hoe").setIconCoord(1, 8),
        new Item("iron_hoe").setIconCoord(2, 8),
        new Item("diamond_hoe").setIconCoord(3, 8),
        new Item("golden_hoe").setIconCoord(4, 8),
        new Item("seeds").setIconCoord(9, 0),
        new Item("wheat").setIconCoord(9, 1),
        new Item("bread").setIconCoord(9, 2),
        new Item("leahter_helmet").setIconCoord(0, 0),
        new Item("leahter_chestplate").setIconCoord(0, 1),
        new Item("leahter_leggings").setIconCoord(0, 2),
        new Item("leahter_boots").setIconCoord(0, 3),
        new Item("chainmail_helmet").setIconCoord(1, 0),
        new Item("chainmail_chestplate").setIconCoord(1, 1),
        new Item("chainmail_leggings").setIconCoord(1, 2),
        new Item("chainmail_boots").setIconCoord(1, 3),
        new Item("iron_helmet").setIconCoord(2, 0),
        new Item("iron_chestplate").setIconCoord(1, 1),
        new Item("iron_leggings").setIconCoord(2, 2),
        new Item("iron_boots").setIconCoord(2, 3),
        new Item("diamond_helmet").setIconCoord(3, 0),
        new Item("diamond_chestplate").setIconCoord(3, 1),
        new Item("diamond_leggings").setIconCoord(3, 2),
        new Item("diamond_boots").setIconCoord(3, 3),
        new Item("golden_helmet").setIconCoord(4, 0),
        new Item("golden_chestplate").setIconCoord(4, 1),
        new Item("golden_leggings").setIconCoord(4, 2),
        new Item("golden_boots").setIconCoord(4, 3),
        new Item("flint").setIconCoord(6, 0),
    };

    // O ID deste item.
    protected string textualID;

    // Tamanho máximo da pilha.
    protected int maxStackSize = 64;

    // Dano máximo que um item pode suportar.
    private int maxDamage = 0;

    private string itemAtlas = "items";
    private Vector2 iconUVRect;

    // Nome completo do item do arquivo de idioma.
    private string itemName;

    protected Item(string textualID) {
        dictionaryTextualID.Add(textualID, this);

        this.textualID = textualID;

        setItemName();
    }

    public string getTextualID() {
        return this.textualID;
    }

    public Item setMaxStackSize(int stack) {
        this.maxStackSize = stack;
        return this;
    }

    public int getMaxStackSize() {
        return this.maxStackSize;
    }

    public Item setItemAtlas(string texture) {
        this.itemAtlas = texture;
        return this;
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

    // definir o dano máximo de um item
    public Item setMaxDamage(int damage) {
        this.maxDamage = damage;
        return this;
    }

    // Retorna o dano máximo que um item pode receber.
    public int getMaxDamage() {
        return this.maxDamage;
    }

    // Definir o nome do item do arquivo de idioma.
    public Item setItemName() {
        this.itemName = "item." + textualID + ".name";
        return this;
    }

    public string getItemName() {
        return this.itemName;
    }

    // retorna a ação que especifica qual animação reproduzir quando os itens estiverem sendo usados
    public virtual EnumAction getItemUseAction() {
        return EnumAction.NONE;
    }

    // return this;
    public Item setCreativeTab(string label) {
        this.tabToDisplayOn = CreativeTabs.dictionaryTabLabel[label];
        return this;
    }

    private ToolMaterial toolMaterial;

    public Item setToolMaterial(string material) {
        this.toolMaterial = ToolMaterial.dictionaryToolMaterial[material];
        return this;
    }
}
