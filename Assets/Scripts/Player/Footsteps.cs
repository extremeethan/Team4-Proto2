using UnityEngine;
using UnityEngine.InputSystem; // Required for the New Input System

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;

    [Header("Input Actions")]
    public InputActionProperty moveAction;
  
    // IMPORTANT: Actions must be enabled to work
    private void OnEnable()
    {
        moveAction.action.Enable();
   
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
      
    }


    void Update()
    {
        // Reads movement vector (WASD/Stick)
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        bool isMoving = moveInput.magnitude > 0.1f;
      

        if (isMoving)
        {
           
            {
                footstepsSound.enabled = true;
              
            }
        }
        else
        {
            footstepsSound.enabled = false;
   
        }
    }
}