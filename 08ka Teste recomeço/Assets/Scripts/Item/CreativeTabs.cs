using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeTabs {
    public static Dictionary<string, CreativeTabs> dictionaryTabLabel = new Dictionary<string, CreativeTabs>();
    
    public static CreativeTabs[] CREATIVE_TAB_ARRAY = {
        new CreativeTabs("buildingBlocks"),
        new CreativeTabs("decorations"),
        new CreativeTabs("redstone"),
        new CreativeTabs("transportation"),
        new CreativeTabs("misc"),
        new CreativeTabs("search").setBackgroundImageName("search.png"),
        new CreativeTabs("food"),
        new CreativeTabs("tools"),
        new CreativeTabs("combat"),
        new CreativeTabs("brewing"),
        new CreativeTabs("materials"),
        new CreativeTabs("inventory").setBackgroundImageName("survival_inv.png"),
    };

    private string tabLabel;

    // Textura a ser usada.
    private string backgroundImageName = "list_items.png";

    public CreativeTabs(string label) {
        this.tabLabel = label;

        dictionaryTabLabel.Add(label, this);
        //dictionaryTabLabel[label] = this;
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