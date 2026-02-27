using UnityEngine;

public class Slider : MonoBehaviour
{
    public Transform closedPos;
    public Transform openPos;
    public float openDuration = 2f;

    float t = 0f;
    bool opening = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!opening) return;

        t += Time.deltaTime / openDuration;

        transform.position = Vector3.Lerp(closedPos.position, openPos.position, t);

        if (t >= 1f)
        {
            t = 1f;
            opening = false;
        }
    }

    public void Open()
    {
        opening = true;
    }
}
