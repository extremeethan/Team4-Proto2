using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.81f;
    Vector2 moveInput;
    Vector3 velocity;
    CharacterController controller;
    PlayerControls controls;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        controls = new PlayerControls();
    }
    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Convert input to world direction
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        // Ground stick
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Combine horizontal + vertical
        Vector3 finalMove = move * speed + Vector3.up * velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }
}
