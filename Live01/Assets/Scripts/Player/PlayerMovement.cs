using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private new Camera camera;
    private float xRotation;

    private CharacterController characterController;

    private float speed;
    private float walking = 4.317f;
    private float sprinting = 5.612f;
    private float falling = -77.71f;
    private float jumpHeight = 1.2522f;

    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    private bool isSprinting;

    private void Awake() {
        this.camera = GetComponentInChildren<Camera>();
        this.characterController = GetComponent<CharacterController>();
    }

    private void Start() {
        this.speed = this.walking;
    }

    private void Update() {
        Cursor.lockState = CursorLockMode.Locked;
        UpdateCamera();

        UpdateMovement();
        UpdateFalling();
        UpdateJump();
    }

    private void UpdateCamera() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX);

        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(this.xRotation, -90.0f, 90.0f);

        this.camera.transform.localRotation = Quaternion.Euler(this.xRotation, 0, 0);
    }

    private void UpdateMovement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0.0f, z));

        moveDirection *= this.speed;
        this.characterController.Move(moveDirection * Time.deltaTime);
    }

    private void UpdateFalling() {
        this.velocity.y += falling * Time.deltaTime;
        this.characterController.Move(velocity * Time.deltaTime);

        this.isGrounded = characterController.isGrounded;

        if(this.isGrounded && velocity.y < 0) {
            this.velocity.y = -2.0f;
        }
    }

    private void UpdateJump() {
        if(this.isGrounded && Input.GetKey(KeyCode.Space)) {
            this.isGrounded = false;

            this.velocity.y = Mathf.Sqrt(this.jumpHeight * -2.0f * this.falling);
        }
    }
}
