using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumVoxelSide { RIGHT, LEFT, TOP, BOTTOM, FRONT, BACK }

public class VoxelData {
    public static Vector3[,] vertices = new Vector3[,] {
        /* RIGHT */ {            
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1),
            new Vector3(1, 0, 1)
        },

        /* LEFT */ {
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 1),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 0)
        },
        
        /* TOP */ {
            new Vector3(0, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 1, 0)
        },
        
        /* BOTTOM */ {
            new Vector3(0, 0, 1),
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1)
        },
        
        /* FRONT */ {
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 1),
            new Vector3(0, 1, 1),
            new Vector3(0, 0, 1)
        },
        
        /* BACK */ {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 0, 0)
        }
    };

    public static int[] triangles = new int[] {
        // Primeiro Triangulo
        0, 1, 2, 
        
        // Segundo Triangulo
        0, 2, 3
    };

    public static Vector2[] uv(Vector2 textureCoordinate) {
        Vector2 textureSizeInTiles = new Vector2(16, 16);
        
        float x = textureCoordinate.x;
        float y = textureCoordinate.y;

        float _x = 1.0f / textureSizeInTiles.x;
        float _y = 1.0f / textureSizeInTiles.y;

        y = (textureSizeInTiles.y - 1) - y;

        x *= _x;
        y *= _y;

        return new Vector2[] {
            new Vector2(x, y),
            new Vector2(x, y + _y),
            new Vector2(x + _x, y + _y),
            new Vector2(x + _x, y)
        };
    }

    public static Vector3[] voxelSide = new Vector3[] {
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, -1, 0),
        new Vector3(0, 0, 1),
        new Vector3(0, 0, -1)
    };

    public string voxelID;    
    public Vector2 itemUV;

    public static EnumVoxelSide side;

    public Vector2 voxelUV_RIGHT;
    public Vector2 voxelUV_LEFT;
    public Vector2 voxelUV_TOP;
    public Vector2 voxelUV_BOTTOM;
    public Vector2 voxelUV_FRONT;
    public Vector2 voxelUV_BACK;

    public Color voxelColor_RIGHT;
    public Color voxelColor_LEFT;
    public Color voxelColor_TOP;
    public Color voxelColor_BOTTOM;
    public Color voxelColor_FRONT;
    public Color voxelColor_BACK;

    public Vector2 GetUV(EnumVoxelSide side) {
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

        return default;
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

    public VoxelData(string id, Vector2 item) {
        voxelID = id;

        itemUV = item;
    }

    public VoxelData(string id, Vector2 item, Vector2 uv) {
        voxelID = id;

        itemUV = item;

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

    public VoxelData(string id, Vector2 item, Vector2 uvTop, Vector2 uvSide, Vector2 uvBottom, Color color, EnumVoxelSide side) {
        voxelID = id;

        itemUV = item;

        voxelUV_RIGHT = uvSide;
        voxelUV_LEFT = uvSide;
        voxelUV_TOP = uvTop;
        voxelUV_BOTTOM = uvBottom;
        voxelUV_FRONT = uvSide;
        voxelUV_BACK = uvSide;

        voxelColor_RIGHT = Color.white;
        voxelColor_LEFT = Color.white;
        voxelColor_TOP = color;
        voxelColor_BOTTOM = Color.white;
        voxelColor_FRONT = Color.white;
        voxelColor_BACK = Color.white;
    }

    public static VoxelData GetVoxel(string id) {
        foreach(VoxelData voxelData in VoxelManager.voxels) {
            if(voxelData.voxelID == id) {
                return voxelData;
            }
        }

        return default;
    }
}
