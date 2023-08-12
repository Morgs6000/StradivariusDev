using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Texture itemAtlas;
    public Texture voxelAtlas;
    public Texture renderTexture;

    public static List<ItemData> items = new List<ItemData>();

    private void Awake() {
        //items.Add(VoxelManager.voxels);
        //foreach(VoxelData voxelData in VoxelManager.voxels) {
        for(int i = 0; i < VoxelManager.voxels.Count; i++) {
            VoxelData voxelData = VoxelManager.voxels[i];
            /*
            ItemData newItem = new ItemData(
                "teste",
                new Vector2(11, 2)
            );
            */
            //*
            ItemData newItem = new ItemData(
                voxelData.voxelID,
                renderTexture,
                voxelData.itemUV
            );
            //*/
            /*
            ItemData newItem = new ItemData(
                voxelData.voxelID,
                renderTexture,
                false
            );
            */

            items.Add(newItem);
        }

        items.Add(new ItemData(
            "iron_pickaxe",
            itemAtlas,
            new Vector2(2, 6)
        ));

        items.Add(new ItemData(
            "apple",
            itemAtlas,
            new Vector2(10, 0)
        ));
        
        items.Add(new ItemData(
            "coal",
            itemAtlas,
            new Vector2(7, 0)
        ));
    }
}
