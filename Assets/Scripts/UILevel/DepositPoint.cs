using UnityEngine;

public class DepositPoint : MonoBehaviour
{
    public Transform spawnPoint;
    public int booksNeeded = 3;
    public Slider bookshelfSlider;

    public GameObject crown;                // the crown object to enable

    int booksDeposited = 0;
    bool opened = false;

    public void ReceiveItem(GameObject item)
    {
        item.transform.position = spawnPoint.position;
        item.SetActive(true);

        booksDeposited++;

        if (!opened && booksDeposited >= booksNeeded)
        {
            opened = true;

            bookshelfSlider.Open();        // move the shelf
            crown.SetActive(true);         // make the crown exist
        }
    }
}