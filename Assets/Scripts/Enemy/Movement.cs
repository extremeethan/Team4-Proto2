using UnityEngine;
using UnityEngine.AI;

public class EnemySound : MonoBehaviour
{
    private AudioSource audioSource;
    private NavMeshAgent myAgent;
    private bool isDead = false; // Track if the player is dead

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // If dead, don't run any of the movement sound logic
        if (isDead) return;

        if (myAgent.velocity.magnitude > 0.1f)
        {
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    // Call this function from your Health script when the player dies
    public void HandleDeath()
    {
        isDead = true;
        audioSource.Stop(); // Kill the looping movement sound immediately
    }
}