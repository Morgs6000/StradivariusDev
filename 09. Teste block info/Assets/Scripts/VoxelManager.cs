using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelManager : MonoBehaviour {
    //[SerializeField] private Voxel voxel;

    public static List<VoxelData> voxels = new List<VoxelData>();
    
    private void Awake() {
        voxels.Add(new VoxelData(
            "stone", 
            new Vector2(1, 0)
        ));

        voxels.Add(new VoxelData(
            "grass", 
            new Vector2(0, 0),
            new Vector2(3, 0),
            new Vector2(2, 0),
            GetColor(),
            Voxel.voxelSide
        ));
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
