using UnityEngine;

public class DepositPoint : MonoBehaviour
{
    public Transform spawnPoint;

    public void ReceiveItem(GameObject item)
    {
        item.transform.position = spawnPoint.position;
        item.SetActive(true);
    }
}
