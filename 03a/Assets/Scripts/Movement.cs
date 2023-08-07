using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Camera camera;
    private float xRotation;    

    private Rigidbody rigidbody;
    private float speed;
    private float walkingSpeed = 4.317f;

    private CharacterController characterController;
    private float fallSpeed = -78.4f;
    private float jumpHeight = 1.2522f;
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake() {        
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start() {
        speed = walkingSpeed;
    }

    private void Update() {
        CameraUpdate();
        Cursor.lockState = CursorLockMode.Locked;

        MovementUpdate();
        FallUpdate();
        JumpUpdate();
    }

    private void CameraUpdate() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    private void MovementUpdate() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        /*
        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0.0f, z));
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
        */

        rigidbody.velocity = transform.TransformDirection(new Vector3(x * speed, 0.0f, z * speed));
    }

    private void FallUpdate() {
        velocity.y += fallSpeed * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        
        isGrounded = characterController.isGrounded;

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2.0f;
        }
    }

    private void JumpUpdate() {
        if(isGrounded && Input.GetButton("Jump")) {
            isGrounded = false;

            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * fallSpeed);
        }
    }
}
