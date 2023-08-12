using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelManager : MonoBehaviour {
    public static List<VoxelData> voxels = new List<VoxelData>();
    
    private void Awake() {
        voxels.Add(new VoxelData(
            "stone",
            new Vector2(1, 0),

            new Vector2(1, 0)
        ));
        
        /*
        voxels.Add(new VoxelData(
            "stone",
            new Vector2(1, 0)
        ));

        voxels.Add(new VoxelData(
            "grass",
            new Vector2(3, 0)
        ));

        voxels.Add(new VoxelData(
            "dirt",
            new Vector2(2, 0)
        ));

        voxels.Add(new VoxelData(
            "cobblestone",
            new Vector2(0, 1)
        ));

        voxels.Add(new VoxelData(
            "oak_planks",
            new Vector2(4, 0)
        ));

        voxels.Add(new VoxelData(
            "spruce_planks",
            new Vector2(6,12)
        ));

        voxels.Add(new VoxelData(
            "birch_planks",
            new Vector2(6, 13)
        ));

        voxels.Add(new VoxelData(
            "jungle_planks",
            new Vector2(7, 12)
        ));

        voxels.Add(new VoxelData(
            "oak_sapling",
            new Vector2(15, 15)
        ));

        voxels.Add(new VoxelData(
            "spruce_sapling",
            new Vector2(15, 3)
        ));

        voxels.Add(new VoxelData(
            "birch_sapling",
            new Vector2(15, 4)
        ));

        voxels.Add(new VoxelData(
            "jungle_sapling",
            new Vector2(14, 14)
        ));

        voxels.Add(new VoxelData(
            "bedrock",
            new Vector2(1, 1)
        ));

        voxels.Add(new VoxelData(
            "water",
            new Vector2(13, 12)
        ));

        voxels.Add(new VoxelData(
            "lava",
            new Vector2(13, 14)
        ));

        voxels.Add(new VoxelData(
            "sand",
            new Vector2(2, 1)
        ));

        voxels.Add(new VoxelData(
            "gravel",
            new Vector2(3, 1)
        ));

        voxels.Add(new VoxelData(
            "gold_ore",
            new Vector2(0, 2)
        ));

        voxels.Add(new VoxelData(
            "iron_ore",
            new Vector2(1, 2)
        ));

        voxels.Add(new VoxelData(
            "coal_ore",
            new Vector2(2, 2)
        ));

        voxels.Add(new VoxelData(
            "oak_wood",
            new Vector2(4, 1)
        ));

        voxels.Add(new VoxelData(
            "spruce_wood",
            new Vector2(4, 7)
        ));

        voxels.Add(new VoxelData(
            "birch_wood",
            new Vector2(5, 7)
        ));

        voxels.Add(new VoxelData(
            "jungle_wood",
            new Vector2(9, 9)
        ));

        voxels.Add(new VoxelData(
            "oak_leaves",
            new Vector2(4, 3)
        ));

        voxels.Add(new VoxelData(
            "spruce_leaves",
            new Vector2(4, 8)
        ));

        voxels.Add(new VoxelData(
            "birch_leaves",
            new Vector2(4, 3)
        ));

        voxels.Add(new VoxelData(
            "jungle_leaves",
            new Vector2(4, 12)
        ));

        voxels.Add(new VoxelData(
            "sponge",
            new Vector2(0, 3)
        ));

        voxels.Add(new VoxelData(
            "glass",
            new Vector2(1, 3)
        ));

        voxels.Add(new VoxelData(
            "lapis_lazuli_ore",
            new Vector2(0, 10)
        ));

        voxels.Add(new VoxelData(
            "lapis_lazuli_block",
            new Vector2(0, 9)
        ));
        */
    }

    private Color GetColor() {
        //string hex = "#79C05A"; // Foreste Biome
        string hex = "#59C93C"; // Jungle Biome
        Color color;

        if(ColorUtility.TryParseHtmlString(hex, out color)) {
            return color;
        }

        return default;
    }
}

