using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {
    private Mesh voxelMesh;
    
    private List<Vector3> vertices = new List<Vector3>();    
    private List<int> triangles = new List<int>();
    private int vertexIndex;

    private List<Vector2> uv = new List<Vector2>();
    private List<Color> colors = new List<Color>();

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    //private ItemScript itemScript;

    //[SerializeField] private EnumVoxels voxelID;

    private void Awake() {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    private void Start() {
        voxelMesh = new Mesh();

        VoxelData voxelData = VoxelData.GetVoxel("grass");

        VoxelGen(new Vector3(0, 0, 0), voxelData);

        MeshGen();
    }

    private void Update() {
        
    }

    private void VoxelGen(Vector3 offset, VoxelData voxelData) {
        //for(int voxelSide = 0; voxelSide < 6; voxelSide++) {
        foreach(EnumVoxelSide voxelSide in System.Enum.GetValues(typeof(EnumVoxelSide))) {
            for(int verts = 0; verts < 4; verts++) {
                vertices.Add(VoxelData.vertices[(int)voxelSide, verts] + offset);

                uv.Add(VoxelData.uv(voxelData.GetUV(voxelSide))[verts]);
                colors.Add(voxelData.GetColor(voxelSide));
            }

            for(int tris = 0; tris < 6; tris++) {
                triangles.Add(VoxelData.triangles[tris] + vertexIndex);
            }

            vertexIndex += 4;
        }
    }

    private void MeshGen() {
        voxelMesh.vertices = vertices.ToArray();
        voxelMesh.triangles = triangles.ToArray();
        voxelMesh.uv = uv.ToArray();
        voxelMesh.colors = colors.ToArray();

        voxelMesh.RecalculateBounds();
        voxelMesh.RecalculateNormals();
        voxelMesh.Optimize();

        meshFilter.mesh = voxelMesh;
        //meshCollider.sharedMesh = voxelMesh;
    }
}
