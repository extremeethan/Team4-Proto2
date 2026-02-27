using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInteractor : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform holdPoint;
    List<GameObject> heldItems = new List<GameObject>();
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
            if (item)
            {
                heldItems.Add(item.gameObject);
                item.gameObject.SetActive(false);
                return;
            }

            DepositPoint point = hit.collider.GetComponent<DepositPoint>();
            if (point && heldItems.Count > 0)
            { 
                GameObject itemToDrop = heldItems[0];
                heldItems.RemoveAt(0);
                point.ReceiveItem(itemToDrop);
            }
        }
    }
}
