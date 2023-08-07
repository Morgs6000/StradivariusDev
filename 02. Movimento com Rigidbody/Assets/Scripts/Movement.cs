using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Camera camera;
    private float xRotation;

    private Rigidbody rigidbody;

    private float speed;
    private float walkingSpeed = 4.317f;

    private float fallSpeed = -78.4f;
    private float jumpHeight = 1.2522f;

    [SerializeField] private bool isGrounded;
    private LayerMask groundMask;

    private Vector3 velocity;

    private void Awake() {        
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();

        groundMask = LayerMask.GetMask("Ground");
    }

    private void Start() {
        speed = walkingSpeed;
    }

    private void Update() {        
        Cursor.lockState = CursorLockMode.Locked;
        CameraUpdate();

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

        Vector3 moveDirection = transform.TransformDirection(new Vector3(x, 0.0f, z));
        
        //* Move Position
        //rigidbody.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);

        //* Alterando direto a velocidade
        rigidbody.velocity = transform.TransformDirection(new Vector3(x * speed, rigidbody.velocity.y, z * speed));

        //* Adicionando Força
        //rigidbody.AddForce(moveDirection * speed);
    }

    private void FallUpdate() {
        velocity.y += fallSpeed * Time.deltaTime;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, velocity.y, rigidbody.velocity.z);

        //isGrounded = Physics.CheckSphere(transform.position, 0.4f, groundMask);
        isGrounded = Physics.CheckBox(transform.position, new Vector3(0.29f, 0.01f, 0.29f), transform.rotation, groundMask);

        if(isGrounded && rigidbody.velocity.y < 0) {
            velocity.y = 0;
        }
    }

    private void JumpUpdate() {
        if(isGrounded && Input.GetButton("Jump")) {
            isGrounded = false;

            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * fallSpeed);            
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position + Vector3.zero, 0.4f);
        Gizmos.DrawWireCube(transform.position, new Vector3(0.29f, 0.01f, 0.29f) * 2);
    }

    /*
    private void OnCollisionEnter(Collision other) {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision other) {
        isGrounded = false;
    }
    */
}
