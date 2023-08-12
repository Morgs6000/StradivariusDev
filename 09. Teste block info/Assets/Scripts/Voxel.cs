using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel {
    // ID
    // Coordenadas UVs
    // Sprite no inventario
    // Stack
    // Nome do bloco

    public string voxelID;

    public static EnumVoxelSide voxelSide;

    //public Vector2 voxelUV;
    public Vector2 voxelUV_RIGHT;
    public Vector2 voxelUV_LEFT;
    public Vector2 voxelUV_TOP;
    public Vector2 voxelUV_BOTTOM;
    public Vector2 voxelUV_FRONT;
    public Vector2 voxelUV_BACK;

    //public Color voxelColor;
    public Color voxelColor_RIGHT;
    public Color voxelColor_LEFT;
    public Color voxelColor_TOP;
    public Color voxelColor_BOTTOM;
    public Color voxelColor_FRONT;
    public Color voxelColor_BACK;

    //public static List<Voxel> voxels = new List<Voxel>();

    /*
    private void Awake() {
        voxels.Add(new Voxel(
            "stone", 
            new Vector2(1, 0)
        ));

        voxels.Add(new Voxel(
            "grass", 
            new Vector2(0, 0),
            new Vector2(3, 0),
            new Vector2(2, 0),
            voxelSide
        ));
    }
    */

    /*
    public static Vector2 GetUV(EnumVoxels voxelID, EnumVoxelSide voxelSide) {
        // STONE
        if(voxelID == EnumVoxels.stone) {
            return new Vector2(1, 0);
        }
        
        // GRASS
        if(voxelID == EnumVoxels.grass) {
            if(voxelSide == EnumVoxelSide.TOP) {
                return new Vector2(0, 0);
            }
            if(voxelSide == EnumVoxelSide.BOTTOM) {
                return new Vector2(2, 0);
            }
                
            return new Vector2(3, 0);
        }

        return default;
    }
    */

    public Vector2 GetUV(EnumVoxelSide side) {
        /*
        if(side == voxelSide) {
            return voxelUV;
        }
        */
        
        //foreach(Voxel voxel in VoxelManager.voxels) {
            //if(voxelID == id) {
                //*
                if(side == EnumVoxelSide.RIGHT) {
                    return voxelUV_RIGHT;
                }
                if(side == EnumVoxelSide.LEFT) {
                    return voxelUV_LEFT;
                }
                if(side == EnumVoxelSide.TOP) {
                    return voxelUV_TOP;
                }
                if(side == EnumVoxelSide.BOTTOM) {
                    return voxelUV_BOTTOM;
                }
                if(side == EnumVoxelSide.FRONT) {
                    return voxelUV_FRONT;
                }
                if(side == EnumVoxelSide.BACK) {
                    return voxelUV_BACK;
                }
                //*/
            //}
        //}

        return default;
        //return voxelUV;
    }

    public Color GetColor(EnumVoxelSide side) {
        if(side == EnumVoxelSide.RIGHT) {
            return voxelColor_RIGHT;
        }
        if(side == EnumVoxelSide.LEFT) {
            return voxelColor_LEFT;
        }
        if(side == EnumVoxelSide.TOP) {
            return voxelColor_TOP;
        }
        if(side == EnumVoxelSide.BOTTOM) {
            return voxelColor_BOTTOM;
        }
        if(side == EnumVoxelSide.FRONT) {
            return voxelColor_FRONT;
        }
        if(side == EnumVoxelSide.BACK) {
            return voxelColor_BACK;
        }
        
        return default;
    }

    public Voxel(string id, Vector2 uv) {
        voxelID = id;

        //voxelUV = uv;

        //*
        voxelUV_RIGHT = uv;
        voxelUV_LEFT = uv;
        voxelUV_TOP = uv;
        voxelUV_BOTTOM = uv;
        voxelUV_FRONT = uv;
        voxelUV_BACK = uv;
        //*/

        voxelColor_RIGHT = Color.white;
        voxelColor_LEFT = Color.white;
        voxelColor_TOP = Color.white;
        voxelColor_BOTTOM = Color.white;
        voxelColor_FRONT = Color.white;
        voxelColor_BACK = Color.white;
    }

    public Voxel(string id, Vector2 uvTop, Vector2 uvSide, Vector2 uvBottom, Color color, EnumVoxelSide side) {
        voxelID = id;

        /*
        if(side == EnumVoxelSide.RIGHT) {
            voxelUV = uvSide;
        }
        if(side == EnumVoxelSide.LEFT) {
            voxelUV = uvSide;
        }
        if(side == EnumVoxelSide.TOP) {
            voxelUV = uvTop;
        }
        if(side == EnumVoxelSide.BOTTOM) {
            voxelUV = uvBottom;
        }
        if(side == EnumVoxelSide.FRONT) {
            voxelUV = uvSide;
        }
        if(side == EnumVoxelSide.BACK) {
            voxelUV = uvSide;
        }
        */

        //*
        voxelUV_RIGHT = uvSide;
        voxelUV_LEFT = uvSide;
        voxelUV_TOP = uvTop;
        voxelUV_BOTTOM = uvBottom;
        voxelUV_FRONT = uvSide;
        voxelUV_BACK = uvSide;
        //*/

        voxelColor_RIGHT = Color.white;
        voxelColor_LEFT = Color.white;
        voxelColor_TOP = color;
        voxelColor_BOTTOM = Color.white;
        voxelColor_FRONT = Color.white;
        voxelColor_BACK = Color.white;
    }

    /*
    public static Voxel GetVoxel(string id) {
        foreach(Voxel voxel in VoxelManager.voxels) {
            if(voxel.voxelID == id) {
                return voxel;
            }
        }

        return default;
    }
    */
}
