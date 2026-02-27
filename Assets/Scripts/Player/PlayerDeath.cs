using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameOverUI gameOverUI;
    bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("Enemy"))
        {
            isDead = true;
            gameOverUI.ShowGameOver();
        }
    }
}
