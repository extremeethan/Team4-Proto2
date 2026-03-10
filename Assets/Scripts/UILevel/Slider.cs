using UnityEngine;

public class Slider : MonoBehaviour
{
    public Transform closedPos;
    public Transform openPos;
    public float openDuration = 2f;

    public AudioClip slideSound;
    [Range(0f, 1f)] public float volume = 1f;

    float t = 0f;
    bool opening = false;

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

        if (slideSound != null)
        {
            AudioSource.PlayClipAtPoint(slideSound, transform.position, volume);
        }
    }
}
