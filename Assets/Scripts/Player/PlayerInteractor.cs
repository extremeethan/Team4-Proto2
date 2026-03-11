using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class PlayerInteractor : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform holdPoint;
    public AngelEnemy[] angels;

    public AudioClip pickupSound;
    public AudioClip angelWakeSound;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(0f, 1f)] public float angelWakeVolume = 1f;

    List<GameObject> heldItems = new List<GameObject>();
    PlayerControls controls;
    public Text booksText;
    public int booksNeeded = 3;
    int booksCollected = 0;
    bool ignoreFirstInteract = true;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Start()
    {
        controls.Player.Interact.performed += OnInteract;
        UpdateBookText();
    }

    void OnInteract(InputAction.CallbackContext ctx)
    {
        // Prevent interaction firing automatically when the game starts
        if (ignoreFirstInteract)
        {
            ignoreFirstInteract = false;
            return;
        }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            CrownPickup crown = hit.collider.GetComponent<CrownPickup>();
            if (crown)
            {
                hit.collider.gameObject.SetActive(false);
                return;
            }
            PickupItem item = hit.collider.GetComponent<PickupItem>();

            if (item && item.enabled && item.gameObject.activeInHierarchy)
            {
                if (pickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(pickupSound, item.transform.position, volume);
                }

                heldItems.Add(item.gameObject);
                item.gameObject.SetActive(false);

                booksCollected++;
                UpdateBookText();
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
    void UpdateBookText()
    {
        booksText.text = booksCollected + "/" + booksNeeded + " BOOKS COLLECTED";
    }
    void WakeNextAngel()
    {
        int angelIndex = booksCollected;

        if (angelIndex < angels.Length)
        {
            angels[angelIndex].isAwake = true;
            StartCoroutine(PlayAngelWakeSound());
        }
    }

    IEnumerator PlayAngelWakeSound()
    {
        yield return new WaitForSeconds(0.7f); // delay so pickup sound finishes

        if (angelWakeSound != null)
        {
            AudioSource.PlayClipAtPoint(angelWakeSound, transform.position, angelWakeVolume);
        }
    }
}