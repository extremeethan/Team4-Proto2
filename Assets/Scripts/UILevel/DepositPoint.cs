using UnityEngine;

public class DepositPoint : MonoBehaviour
{
    public Transform spawnPoint;
    public int booksNeeded = 3;
    public Slider bookshelfSlider;

    public GameObject crown;

    int booksDeposited = 0;
    bool opened = false;

    public void ReceiveItem(GameObject item)
    {
        item.transform.position = spawnPoint.position;

        booksDeposited++;

        if (!opened && booksDeposited >= booksNeeded)
        {
            opened = true;

            bookshelfSlider.Open();
            crown.SetActive(true);
        }

        Destroy(item); // book disappears after depositing
    }
}