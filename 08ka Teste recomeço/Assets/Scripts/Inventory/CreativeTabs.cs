using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeTabs {
    public static Dictionary<string, CreativeTabs> dictionaryTabLabel = new Dictionary<string, CreativeTabs>();
    
    public static CreativeTabs[] creativeTabArray = {
        new CreativeTabs("buildingBlocks"),
        new CreativeTabs("decorations"),
        new CreativeTabs("redstone"),
        new CreativeTabs("transportation"),
        new CreativeTabs("misc"),
        new CreativeTabs("search").setBackgroundImageName("search"),
        new CreativeTabs("food"),
        new CreativeTabs("tools"),
        new CreativeTabs("combat"),
        new CreativeTabs("brewing"),
        new CreativeTabs("materials"),
        new CreativeTabs("inventory").setBackgroundImageName("survival_inv")
    };

    private string tabLabel;

    // Textura a ser usada.
    private string backgroundImageName = "list_items";

    public CreativeTabs(string label) {
        dictionaryTabLabel.Add(label, this);
        
        this.tabLabel = label;
    }

    /*
    public string getTabLabel() {
        return this.tabLabel;
    }
    */

    public string getBackgroundImageName() {
        return this.backgroundImageName;
    }

    public CreativeTabs setBackgroundImageName(string texture) {
        this.backgroundImageName = texture;
        return this;
    }
}