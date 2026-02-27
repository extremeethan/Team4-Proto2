using UnityEngine;
using UnityEngine.InputSystem;
public class MouseLook : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody;
    float XRotation = 0f;

    PlayerControls controls;
    Vector2 lookInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        XRotation = 0f;
        controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }
    void Awake()
    {
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
    // Update is called once per frame
    void Update()
    {
        float mouseX = lookInput.x * sensitivity * Time.deltaTime;
        float mouseY = lookInput.y * sensitivity * Time.deltaTime;
        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
