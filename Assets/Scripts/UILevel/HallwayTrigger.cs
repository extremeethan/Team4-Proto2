using UnityEngine;

public class HallwayTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        AngelEnemy[] enemies = FindObjectsByType<AngelEnemy>(FindObjectsSortMode.None);

        foreach (AngelEnemy enemy in enemies)
        {
            enemy.isAwake = true;
        }

        gameObject.SetActive(false);
    }
}
