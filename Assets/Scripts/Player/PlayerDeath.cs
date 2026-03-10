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

            // 1. Find the EnemySound script on the thing we hit and stop its audio
            EnemySound enemySound = other.GetComponent<EnemySound>();
            if (enemySound != null)
            {
                enemySound.HandleDeath();
            }

            // 2. Show the Game Over screen
            gameOverUI.ShowGameOver();
        }
    }
}