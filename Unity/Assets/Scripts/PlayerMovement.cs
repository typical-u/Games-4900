using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 2f;

    Rigidbody rb;
    Transform cam;
    float pitch = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        cam = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // mouse look
        var mouse = Mouse.current.delta.ReadValue() * lookSpeed * 0.1f;
        transform.Rotate(0f, mouse.x, 0f);

        pitch -= mouse.y;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        cam.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void FixedUpdate()
    {
        // wasd movement
        var kb = Keyboard.current;
        float x = 0f, z = 0f;

        if (kb.wKey.isPressed) z += 1f;
        if (kb.sKey.isPressed) z -= 1f;
        if (kb.dKey.isPressed) x += 1f;
        if (kb.aKey.isPressed) x -= 1f;

        var move = (transform.forward * z + transform.right * x).normalized * speed;
        move.y = rb.linearVelocity.y; // keep gravity
        rb.linearVelocity = move;
    }
}