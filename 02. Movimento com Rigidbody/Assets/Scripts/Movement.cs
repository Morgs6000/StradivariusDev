using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Camera camera;
    private float xRotation;

    private Rigidbody rigidbody;

    private float speed;
    private float walkingSpeed = 4.317f;

    private void Awake() {        
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        speed = walkingSpeed;
    }

    private void Update() {        
        Cursor.lockState = CursorLockMode.Locked;
        CameraUpdate();

        MovementUpdate();
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

        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0.0f, z));
        
        //* Move Position
        //rigidbody.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);

        //* Alterando direto a velocidade
        rigidbody.velocity = transform.TransformDirection(new Vector3(x * speed, rigidbody.velocity.y, z * speed));

        //* Adicionando Força
        //rigidbody.AddForce(moveDirection * speed);
    }

    private void JumpUpdate() {
        if(Input.GetButton("Jump")) {
            
        }
    }
}
