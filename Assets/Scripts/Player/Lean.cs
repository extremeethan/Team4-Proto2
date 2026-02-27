using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lean : MonoBehaviour
{
    public Animator cameraAnim;
    public LayerMask Layers;

    RaycastHit hit;
    PlayerControls controls;
    float leanInput;

    void Awake()
    {
        controls = new PlayerControls();
    }
    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();
    private void Start()
    {
        controls.Player.Lean.performed += ctx => leanInput = ctx.ReadValue<float>();
        controls.Player.Lean.canceled += ctx => leanInput = 0f;
    }
    void Update()
    {
        // Lean Left
        if (leanInput < -0.1f && !Physics.Raycast(transform.position, -transform.right, out hit, 1f, Layers))
        {
            cameraAnim.ResetTrigger("idle");
            cameraAnim.ResetTrigger("right");
            cameraAnim.SetTrigger("left");
        }
        // Lean Right
        else if (leanInput > 0.1f && !Physics.Raycast(transform.position, transform.right, out hit, 1f, Layers))
        {
            cameraAnim.ResetTrigger("idle");
            cameraAnim.ResetTrigger("left");
            cameraAnim.SetTrigger("right");
        }
        // Idle
        else
        {
            cameraAnim.ResetTrigger("right");
            cameraAnim.ResetTrigger("left");
            cameraAnim.SetTrigger("idle");
        }
    }
}
