using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    private CreativeTabs tabToDisplayOn = null;

    //public static Dictionary<string, int> dictionaryItemID = new Dictionary<string, int>();
    public static Dictionary<string, Item> dictionaryTextualID = new Dictionary<string, Item>();

    //public static Item[] itemsList = new Item[32000];
    public static List<Item> itemsList = new List<Item>();
    public static Item IRON_SHOVEL = new ItemTool("iron_shovel", ToolMaterial.IRON).setIconCoord(2, 5);
    public static Item IRON_PICKAXE = new ItemTool("iron_pickaxe", ToolMaterial.IRON).setIconCoord(2, 6);
    public static Item IRON_AXE = new ItemTool("iron_axe", ToolMaterial.IRON).setIconCoord(2, 7);
    public static Item FLINT_AND_STEEL = new ItemFlintAndSteel("flint_and_steel").setIconCoord(5, 0);
    public static Item APPLE = new ItemFood("apple", 4, 0.3f, false).setIconCoord(10, 0);
    public static Item BOW = new ItemBow("bow").setIconCoord(5, 1);
    public static Item ARROW = new Item("arrow").setIconCoord(5, 2).setCreativeTab(CreativeTabs.COMBAT);
    public static Item COAL = new ItemCoal("coal").setIconCoord(7, 0);
    public static Item DIAMOND = new Item("diamond").setIconCoord(7, 3);
    public static Item IRON_INGOT = new Item("iron_ingot").setIconCoord(7, 1);
    public static Item GOLD_INGOT = new Item("gold_ingot").setIconCoord(7, 2);
    public static Item IRON_SWORD = new ItemSword("iron_sword", ToolMaterial.IRON).setIconCoord(2, 4);
    public static Item WOODEN_SWORD = new ItemSword("wooden_sword", ToolMaterial.WOOD).setIconCoord(0, 4);
    public static Item WOODEN_SHOVEL = new ItemTool("wooden_shovel", ToolMaterial.WOOD).setIconCoord(0, 5);
    public static Item WOODEN_PICKAXE = new ItemTool("wooden_pickaxe", ToolMaterial.WOOD).setIconCoord(0, 6);
    public static Item WOODEN_AXE = new ItemTool("wooden_axe", ToolMaterial.WOOD).setIconCoord(0, 7);
    public static Item STONE_SWORD = new ItemSword("stone_sword", ToolMaterial.STONE).setIconCoord(1, 4);
    public static Item STONE_SHOVEL = new ItemTool("stone_shovel", ToolMaterial.STONE).setIconCoord(1, 5);
    public static Item STONE_PICKAXE = new ItemTool("stone_pickaxe", ToolMaterial.STONE).setIconCoord(1, 6);
    public static Item STONE_AXE = new ItemTool("stone_axe", ToolMaterial.STONE).setIconCoord(1, 7);
    public static Item DIAMOND_SWORD = new ItemSword("diamond_sword", ToolMaterial.EMERALD).setIconCoord(3, 4);
    public static Item DIAMOND_SHOVEL = new ItemTool("diamond_shovel", ToolMaterial.EMERALD).setIconCoord(3, 5);
    public static Item DIAMOND_PICKAXE = new ItemTool("diamond_pickaxe", ToolMaterial.EMERALD).setIconCoord(3, 6);
    public static Item DIAMOND_AXE = new ItemTool("diamond_axe", ToolMaterial.EMERALD).setIconCoord(3, 7);
    public static Item STICK = new Item("stick").setIconCoord(5, 3);
    public static Item BOWL = new Item("bowl").setIconCoord(7, 4);
    public static Item MUSHROOM_STEW = new ItemSoup("mushroom_stew").setIconCoord(8, 4);
    public static Item GOLDEN_SWORD = new ItemSword("golden_sword", ToolMaterial.GOLD).setIconCoord(4, 4);
    public static Item GOLDEN_SHOVEL = new ItemTool("golden_shovel", ToolMaterial.GOLD).setIconCoord(4, 5);
    public static Item GOLDEN_PICKAXE = new ItemTool("golden_pickaxe", ToolMaterial.GOLD).setIconCoord(4, 6);
    public static Item GOLDEN_AX = new ItemTool("golden_axe", ToolMaterial.GOLD).setIconCoord(4, 7);
    public static Item STRING = new ItemReed("string").setIconCoord(8, 0);
    public static Item FEATHER = new Item("feather").setIconCoord(8, 1);
    public static Item GUNPOWDER = new Item("gunpowder").setIconCoord(8, 2);
    public static Item WOODEN_HOE = new ItemHoe("wooden_hoe", ToolMaterial.WOOD).setIconCoord(0, 8);
    public static Item STONE_HOE = new ItemHoe("stone_hoe", ToolMaterial.STONE).setIconCoord(1, 8);
    public static Item IRON_HORE = new ItemHoe("iron_hoe", ToolMaterial.IRON).setIconCoord(2, 8);
    public static Item DIAMOND_HOE = new ItemHoe("diamond_hoe", ToolMaterial.EMERALD).setIconCoord(3, 8);
    public static Item GOLDEN_HOE = new ItemHoe("golden_hoe", ToolMaterial.GOLD).setIconCoord(4, 8);
    public static Item SEEDS = new ItemSeeds("seeds").setIconCoord(9, 0);
    public static Item WHEAT = new Item("wheat").setIconCoord(9, 1);
    public static Item BREAD = new ItemFood("bread", 5, 0.6f, false).setIconCoord(9, 2);
    public static Item LEATHER_HELMET = new ItemArmor("leahter_helmet", ArmorMaterial.CLOTH, 0, 0).setIconCoord(0, 0);
    public static Item LEATHER_CHESTPLATE = new ItemArmor("leahter_chestplate", ArmorMaterial.CLOTH, 0, 1).setIconCoord(0, 1);
    public static Item LEATHER_LEGGINGS = new ItemArmor("leahter_leggings", ArmorMaterial.CLOTH, 0, 2).setIconCoord(0, 2);
    public static Item LEATHER_BOOTS = new ItemArmor("leahter_boots", ArmorMaterial.CLOTH, 0, 3).setIconCoord(0, 3);
    public static Item CHAINMAIL_HELMET = new ItemArmor("chainmail_helmet", ArmorMaterial.CHAIN, 1, 0).setIconCoord(1, 0);
    public static Item CHAINMAIL_CHESTPLATE = new ItemArmor("chainmail_chestplate", ArmorMaterial.CHAIN, 1, 1).setIconCoord(1, 1);
    public static Item CHAINMAIL_LEGGINGS = new ItemArmor("chainmail_leggings", ArmorMaterial.CHAIN, 1, 2).setIconCoord(1, 2);
    public static Item CHAINMAIL_BOOTS = new ItemArmor("chainmail_boots", ArmorMaterial.CHAIN, 1, 3).setIconCoord(1, 3);
    public static Item IRON_HELMET = new ItemArmor("iron_helmet", ArmorMaterial.IRON, 2, 0).setIconCoord(2, 0);
    public static Item IRON_CHESTPLATE = new ItemArmor("iron_chestplate", ArmorMaterial.IRON, 2, 1).setIconCoord(1, 1);
    public static Item IRON_LEGGINGS = new ItemArmor("iron_leggings", ArmorMaterial.IRON, 2, 2).setIconCoord(2, 2);
    public static Item IRON_BOOTS = new ItemArmor("iron_boots", ArmorMaterial.IRON, 2, 3).setIconCoord(2, 3);
    public static Item DIAMOND_HELMET = new ItemArmor("diamond_helmet", ArmorMaterial.DIAMOND, 3, 0).setIconCoord(3, 0);
    public static Item DIAMOND_CHESTPLATE = new ItemArmor("diamond_chestplate", ArmorMaterial.DIAMOND, 3, 1).setIconCoord(3, 1);
    public static Item DIAMOND_LEGGINGS = new ItemArmor("diamond_leggings", ArmorMaterial.DIAMOND, 3, 2).setIconCoord(3, 2);
    public static Item DIAMOND_BOOTS = new ItemArmor("diamond_boots", ArmorMaterial.DIAMOND, 3, 3).setIconCoord(3, 3);
    public static Item GOLDEN_HELMET = new ItemArmor("golden_helmet", ArmorMaterial.GOLD, 4, 0).setIconCoord(4, 0);
    public static Item GOLDEN_CHESTPLATE = new ItemArmor("golden_chestplate", ArmorMaterial.GOLD, 4, 1).setIconCoord(4, 1);
    public static Item GOLDEN_LEGGINGS = new ItemArmor("golden_leggings", ArmorMaterial.GOLD, 4, 2).setIconCoord(4, 2);
    public static Item GOLDEN_BOOTS = new ItemArmor("golden_boots", ArmorMaterial.GOLD, 4, 3).setIconCoord(4, 3);
    public static Item FLINT = new Item("flint").setIconCoord(6, 0);

    // O ID deste item.
    //private int itemID;
    private string textualID;

    // Tamanho máximo da pilha.
    protected int maxStackSize = 64;

    // Dano máximo que um item pode suportar.
    private int maxDamage = 0;

    private string itemAtlas = "items";
    private Vector2 iconUVRect;

    // Nome completo do item do arquivo de idioma.
    private string itemName;

    protected Item(string textualID) {
        //dictionaryItemID.Add(textualID, itemID);
        //this.itemID++;
        //itemsList[itemID] = this;
        itemsList.Add(this);
       
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

    // 🔴
    //*
    public virtual EnumSlotTag getEnumSlotTag() {
        return EnumSlotTag.NONE;
    }
    //*/

    public virtual EnumSlotTag getEnumSlotTag(int armorType) {
        return EnumSlotTag.NONE;
    }

    // return this;
    public Item setCreativeTab(CreativeTabs creativeTabs) {
        this.tabToDisplayOn = creativeTabs;
        return this;
    }

    /*
    protected ToolMaterial toolMaterial;

    public Item setToolMaterial(string material) {
        this.toolMaterial = ToolMaterial.dictionaryToolMaterial[material];
        return this;
    }
    //*/
}
