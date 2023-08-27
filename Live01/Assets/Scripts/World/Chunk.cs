using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Chunk : MonoBehaviour {
    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();
    private List<Vector2> uv = new List<Vector2>();

    private int vertexIndex;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    private Material material;

    public static Vector3 chunkSizeInBlocks = new Vector3(16, 256, 16);

    private Block[,,] blocks = new Block[
        (int)chunkSizeInBlocks.x,
        (int)chunkSizeInBlocks.y,
        (int)chunkSizeInBlocks.z
    ];

    private void Awake() {
        this.meshFilter = gameObject.AddComponent<MeshFilter>();
        this.meshRenderer = gameObject.AddComponent<MeshRenderer>();
        this.meshCollider = gameObject.AddComponent<MeshCollider>();

        this.material = Resources.Load<Material>("Materials/Terrain");
    }

    private void Start() {
        BlockMapGen();
    }

    public void SetBlock(Vector3 worldPos, Block block) {
        Vector3 localPos = worldPos - transform.position;

        int x = Mathf.FloorToInt(localPos.x);
        int y = Mathf.FloorToInt(localPos.y);
        int z = Mathf.FloorToInt(localPos.z);

        blocks[x, y, z] = block;

        ChunkGen();
    }

    public Block GetBlock(Vector3 worldPos) {
        Vector3 localPos = worldPos - transform.position;

        int x = Mathf.FloorToInt(localPos.x);
        int y = Mathf.FloorToInt(localPos.y);
        int z = Mathf.FloorToInt(localPos.z);

        if(
            x < 0 || x >= chunkSizeInBlocks.x ||
            y < 0 || y >= chunkSizeInBlocks.y ||
            z < 0 || z >= chunkSizeInBlocks.z
        ) {
            Debug.LogError("Coordinates out of range");

            return default(Block);
        }

        return blocks[x, y, z];
    }

    private void BlockMapGen() {
        for(int x = 0; x < chunkSizeInBlocks.x; x++) {
            for(int y = 0; y < chunkSizeInBlocks.y; y++) {
                for(int z = 0; z < chunkSizeInBlocks.z; z++) {
                    LayerGen(new Vector3(x, y, z));
                }
            }
        }

        ChunkGen();
    }

    private void LayerGen(Vector3 offset) {
        int x = (int)offset.x;
        int y = (int)offset.y;
        int z = (int)offset.z;

        float _x = x + transform.position.x;
        float _y = y + transform.position.y;
        float _z = z + transform.position.z;

        _x += World.worldSizeInBlocks.x;
        //_y += World.worldSizeInBlocks.y;
        _z += World.worldSizeInBlocks.z;

        int noise = (int)Noise.Perlin(_x, _z);
        
        if(_y == noise) {
            blocks[x, y, z] = Block.GRASS;
        }
        if(_y < noise) {
            blocks[x, y, z] = Block.STONE;
        }
    }

    private void ChunkGen() {
        Init();

        for(int x = 0; x < chunkSizeInBlocks.x; x++) {
            for(int y = 0; y < chunkSizeInBlocks.y; y++) {
                for(int z = 0; z < chunkSizeInBlocks.z; z++) {
                    if(blocks[x, y, z] != null) {
                        BlockGen(new Vector3(x, y, z));
                    }
                }
            }
        }

        MeshGen();
    }

    public void Init() {
        vertices.Clear();
        triangles.Clear();
        uv.Clear();

        vertexIndex = 0;
    }

    private void BlockGen(Vector3 offset) {
        int x = (int)offset.x;
        int y = (int)offset.y;
        int z = (int)offset.z;

        for(int side = 0; side < 6; side++) {
            if(!HasSolidNeighbor(BlockData.blockSide[side] + offset)) {
                for(int verts = 0; verts < 4; verts++) {
                    vertices.Add(BlockData.vertices[side, verts] + offset);

                    uv.Add(BlockData.uv(blocks[x, y, z].getUVCoord())[verts]);
                }
                for(int tris = 0; tris < 6; tris++) {
                    triangles.Add(BlockData.triangles[tris] + vertexIndex);
                }

                vertexIndex += 4;
            }
        }
    }

    private bool HasSolidNeighbor(Vector3 offset) {
        int x = (int)offset.x;
        int y = (int)offset.y;
        int z = (int)offset.z;

        if(
            x < 0 || x > chunkSizeInBlocks.x - 1 ||
            y < 0 || y > chunkSizeInBlocks.y - 1 ||
            z < 0 || z > chunkSizeInBlocks.z - 1
        ) {
            return false;
        }
        if(blocks[x, y, z] == null) {
            return false;
        }

        return true;
    }

    private void MeshGen() {
        Mesh chunkMesh = new Mesh();
        chunkMesh.name = "Chunk";

        chunkMesh.vertices = vertices.ToArray();
        chunkMesh.triangles = triangles.ToArray();
        chunkMesh.uv = uv.ToArray();

        chunkMesh.RecalculateBounds();
        chunkMesh.RecalculateNormals();
        chunkMesh.RecalculateTangents();
        chunkMesh.Optimize();

        meshFilter.mesh = chunkMesh;
        meshRenderer.material = material;
        meshCollider.sharedMesh = chunkMesh;
    }
}
