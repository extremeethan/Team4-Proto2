using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody;
    float XRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        XRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
