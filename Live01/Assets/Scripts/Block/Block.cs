using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block {
    public static List<Block> blocksList = new List<Block>();

    public static Block STONE = new Block().setUVCoord(1, 0);
    public static Block GRASS = new Block().setUVCoord(2, 9);

    private Vector2 blockUV;

    private Block() {
        blocksList.Add(this);
    }

    public Block setUVCoord(int x, int y) {
        this.blockUV = new Vector2(x, y);
        return this;
    }

    public Vector2 getUVCoord() {
        return this.blockUV;
    }
}
