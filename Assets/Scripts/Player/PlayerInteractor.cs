using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInteractor : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform holdPoint;
    public AngelEnemy[] angels;
    List<GameObject> heldItems = new List<GameObject>();
    PlayerControls controls;
    int booksCollected = 0;

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

                booksCollected++;
                WakeNextAngel();

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
    void WakeNextAngel()
    {
        if (booksCollected == 1 && angels.Length > 1)
        {
            angels[1].isAwake = true;
        }
        else if (booksCollected == 2 && angels.Length > 2)
        {
            angels[2].isAwake = true;
        }
    }
}
