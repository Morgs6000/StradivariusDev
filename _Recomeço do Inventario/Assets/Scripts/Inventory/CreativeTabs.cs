using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeTabs {    
    //public static CreativeTabs[] CREATIVE_TAB_ARRAY = new CreativeTabs[12];
    public static CreativeTabs BUILDING_BLOCKS = new CreativeTabs("buildingBlocks");
    public static CreativeTabs DECORATIONS = new CreativeTabs("decorations");
    public static CreativeTabs REDSTONE = new CreativeTabs("redstone");
    public static CreativeTabs TRANSPORTATION = new CreativeTabs("transportation");
    public static CreativeTabs MISC = new CreativeTabs("misc");
    public static CreativeTabs SEARCH = new CreativeTabs("search").setBackgroundImageName("search");
    public static CreativeTabs FOOD = new CreativeTabs("food");
    public static CreativeTabs TOOLS = new CreativeTabs("tools");
    public static CreativeTabs COMBAT = new CreativeTabs("combat");
    public static CreativeTabs BREWING = new CreativeTabs("brewing");
    public static CreativeTabs MATERIALS = new CreativeTabs("materials");
    public static CreativeTabs INVENTORY = new CreativeTabs("inventory").setBackgroundImageName("survival_inv");

    private string tabLabel;

    // Textura a ser usada.
    private string backgroundImageName = "list_items";

    public CreativeTabs(string label) {        
        this.tabLabel = label;
    }

    public string getBackgroundImageName() {
        return this.backgroundImageName;
    }

    public CreativeTabs setBackgroundImageName(string texture) {
        this.backgroundImageName = texture;
        return this;
    }
}