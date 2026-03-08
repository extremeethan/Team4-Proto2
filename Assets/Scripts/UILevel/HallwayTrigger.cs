using UnityEngine;

public class HallwayTrigger : MonoBehaviour
{
    public AngelEnemy firstEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (firstEnemy != null)
        {
            firstEnemy.isAwake = true;
        }

        gameObject.SetActive(false);
    }
}
