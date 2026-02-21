using UnityEngine;
using UnityEngine.AI;
public class WeepingAng : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    Camera cam;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        bool visible = CanPlayerSeeMe();
        if (visible)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }
    bool CanPlayerSeeMe()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.z < 0) return false;
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1) return false;
        Ray ray = new Ray(cam.transform.position, transform.position - cam.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform != transform)
                return false;
        }
        return true;
    }
}
