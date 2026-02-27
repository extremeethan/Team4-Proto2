using UnityEngine;
using UnityEngine.AI;

public class AngelEnemy : MonoBehaviour
{    
    [Range(0.5f, 15f)] public float moveSpeed = 3.5f;
    public Transform player;                 // drag your Player here
    public bool movesWhenSeen = false;        // false = Weeping Angel, true = Reverse Angel
    public bool isAwake = false;
    private NavMeshAgent agent;              // pathfinding mover
    public Camera cam;                      // the camera used to check visibility

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // grabs the NavMeshAgent on THIS enemy
        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (!isAwake) return;
        agent.speed = moveSpeed;
        bool visible = CanPlayerSeeMe();      // true if enemy is in camera view AND not blocked

        if (movesWhenSeen)
        {
            // Reverse Angel behavior:
            // - move when visible
            // - stop when not visible

            agent.isStopped = !visible;       // if NOT visible, stop. if visible, allow movement.

            if (visible)
            {
                agent.SetDestination(player.position); // chase player while being watched
            }
        }
        else
        {
            // Weeping Angel behavior:
            // - stop when visible
            // - move when not visible

            agent.isStopped = visible;        // if visible, stop. if not visible, allow movement.

            if (!visible)
            {
                agent.SetDestination(player.position); // chase only when NOT watched
            }
        }
    }

    bool CanPlayerSeeMe()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);

        if (viewPos.z < 0) return false;

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
            return false;

        Ray ray = new Ray(cam.transform.position, transform.position - cam.transform.position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform != transform)
                return false;
        }

        return true;
    }
}