using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform holdPoint;
    GameObject heldItem;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Start()
    {
        controls.Player.Interact.performed += OnInteract;
    }

    void OnInteract(InputAction.CallbackContext ctx)
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            PickupItem item = hit.collider.GetComponent<PickupItem>();
            if (item && heldItem == null)
            {
                heldItem = item.gameObject;
                heldItem.SetActive(false);
                return;
            }

            DepositPoint point = hit.collider.GetComponent<DepositPoint>();
            if (point && heldItem != null)
            {
                point.ReceiveItem(heldItem);
                heldItem = null;
            }
        }
    }
}
