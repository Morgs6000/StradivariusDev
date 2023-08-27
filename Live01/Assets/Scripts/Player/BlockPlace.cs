using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlace : MonoBehaviour {
    private new Camera camera;
    private float rangeHit = 5.0f;
    private LayerMask groundMask;

    private void Awake() {
        this.camera = GetComponentInChildren<Camera>();
        this.groundMask = LayerMask.GetMask("Ground");
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            UpdateRaycast();
        }
    }

    private void UpdateRaycast() {
        RaycastHit hit;

        if(Physics.Raycast(this.camera.transform.position, this.camera.transform.forward, out hit, this.rangeHit, this.groundMask)) {
            Vector3 pointPos = hit.point + hit.normal / 2;

            float distance = 0.81f;
            float playerDistance = Vector3.Distance(transform.position, pointPos);
            float cameraDistance = Vector3.Distance(camera.transform.position, pointPos);

            if(playerDistance < distance || cameraDistance < distance) {
                return;
            }
            if(pointPos.y > World.worldSizeInBlocks.y) {
                return;
            }

            Chunk c = World.GetChunk(new Vector3(
                Mathf.FloorToInt(pointPos.x),
                Mathf.FloorToInt(pointPos.y),
                Mathf.FloorToInt(pointPos.z)
            ));

            c.SetBlock(pointPos, Block.STONE);
        }
    }
}
