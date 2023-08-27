using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHighlight : MonoBehaviour {
    private new Camera camera;
    private float rangeHit = 5.0f;
    private LayerMask groundMask;

    [SerializeField] private Transform highlight;

    private void Awake() {
        this.camera = GetComponentInChildren<Camera>();
        this.groundMask = LayerMask.GetMask("Ground");
    }

    private void Update() {
        UpdateRaycast();
    }

    private void UpdateRaycast() {
        RaycastHit hit;

        if(Physics.Raycast(this.camera.transform.position, this.camera.transform.forward, out hit, this.rangeHit, this.groundMask)) {
            Vector3 pointPos = hit.point - hit.normal / 2;

            this.highlight.position = new Vector3(
                Mathf.FloorToInt(pointPos.x),
                Mathf.FloorToInt(pointPos.y),
                Mathf.FloorToInt(pointPos.z)
            );

            this.highlight.gameObject.SetActive(true);
        }
        else {
            this.highlight.gameObject.SetActive(false);
        }
    }
}
