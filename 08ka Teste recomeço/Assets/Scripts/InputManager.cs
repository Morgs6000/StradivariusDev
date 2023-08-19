using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public static InputManager Instance;

    private bool leftMouseButtonDown;
    private bool rightMouseButtonDown;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        
    }

    private void Update() {
        leftMouseButtonDown = Input.GetMouseButtonDown(0);
        rightMouseButtonDown = Input.GetMouseButtonDown(1);

        if(getLeftMouseButtonDown()) {
            //Debug.Log("Left");
        }
        if(getRightMouseButtonDown()) {
            //Debug.Log("Right");
        }
    }

    public InputManager setLeftMouseButtonDown(bool input) {
        this.leftMouseButtonDown = input;
        return this;
    }

    public bool getLeftMouseButtonDown() {
        return this.leftMouseButtonDown;
    }

    public bool getRightMouseButtonDown() {
        return this.rightMouseButtonDown;
    }
}
