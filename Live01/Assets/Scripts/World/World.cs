using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    private GameObject chunkPrefab;
    private Chunk chunk;

    public static Vector3 worldSizeInBlocks = new Vector3(64, 256, 64);

    private Vector3 worldSizeInChunks = new Vector3(
        worldSizeInBlocks.x / Chunk.chunkSizeInBlocks.x,
        worldSizeInBlocks.y / Chunk.chunkSizeInBlocks.y,
        worldSizeInBlocks.z / Chunk.chunkSizeInBlocks.z
    );

    private static List<Chunk> chunks = new List<Chunk>();

    [SerializeField] private Transform player;
    private PlayerMovement playerMovement;

    private bool playerSpawn = false;

    private void Awake() {
        this.chunkPrefab = Resources.Load<GameObject>("Prefabs/Chunk");

        this.playerMovement = player.GetComponent<PlayerMovement>();
    }   

    private void Start() {
        playerMovement.enabled = false;

        StartCoroutine(WorldGen());
    }

    private IEnumerator WorldGen() {
        Vector3 worldSize = new Vector3(
            worldSizeInChunks.x / 2,
            worldSizeInChunks.y,
            worldSizeInChunks.z / 2
        );

        for(int x = -(int)worldSize.x; x < worldSize.x; x++) {
            for(int z = -(int)worldSize.z; z < worldSize.z; z++) {
                
                for(int y = 0; y < worldSize.y; y++) {
                    InstantiateChunk(new Vector3(x, y, z));
                }

                yield return null;
            }
        }

        InstantiatePlayer();
    }

    private void InstantiatePlayer() {
        Vector3 spawnPos = new Vector3(
            0,
            worldSizeInBlocks.y,
            0
        );

        player.position = spawnPos;
        playerSpawn = true;

        if(playerSpawn) {
            playerMovement.enabled = true;
        }
    }

    private void InstantiateChunk(Vector3 offset) {
        int x = (int)offset.x;
        int y = (int)offset.y;
        int z = (int)offset.z;

        Vector3 chunkOffset = new Vector3(
            x * Chunk.chunkSizeInBlocks.x,
            y * Chunk.chunkSizeInBlocks.y,
            z * Chunk.chunkSizeInBlocks.z
        );

        Chunk c = GetChunk(new Vector3(
            Mathf.FloorToInt(chunkOffset.x),
            Mathf.FloorToInt(chunkOffset.y),
            Mathf.FloorToInt(chunkOffset.z)
        ));

        if(c == null) {
            GameObject newChunk = Instantiate(chunkPrefab);
            chunk = newChunk.GetComponent<Chunk>();

            chunks.Add(chunk);

            newChunk.transform.SetParent(transform);
            newChunk.transform.position = chunkOffset;
            newChunk.name = "Chunk: " + x + ", " + z;
        }
    }

    public static Chunk GetChunk(Vector3 pos) {
        for(int i = 0; i < chunks.Count; i++) {
            Vector3 chunkPos = chunks[i].transform.position;

            if(
                pos.x < chunkPos.x || pos.x >= chunkPos.x + Chunk.chunkSizeInBlocks.x ||
                pos.y < chunkPos.y || pos.y >= chunkPos.y + Chunk.chunkSizeInBlocks.y ||
                pos.z < chunkPos.z || pos.z >= chunkPos.z + Chunk.chunkSizeInBlocks.z
            ) {
                continue;
            }

            return chunks[i];
        }

        return null;
    } 
}
