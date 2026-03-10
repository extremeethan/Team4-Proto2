using UnityEngine;

public class DepositPoint : MonoBehaviour
{
    public Transform spawnPoint;
    public int booksNeeded = 3;
    public Slider bookshelfSlider;
    public GameObject crown;

    static int booksDeposited = 0;
    static bool opened = false;

    public void ReceiveItem(GameObject item)
    {
        item.transform.position = spawnPoint.position;
        item.transform.rotation = spawnPoint.rotation;

        item.SetActive(true); // make sure the book stays visible

        PickupItem pickup = item.GetComponent<PickupItem>();
        if (pickup) pickup.enabled = false;

        booksDeposited++;

        if (!opened && booksDeposited >= booksNeeded)
        {
            opened = true;

            bookshelfSlider.Open();
            crown.SetActive(true);
        }
    }
}