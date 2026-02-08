using UnityEngine;

public class EngineBlink : MonoBehaviour
{
    public float minScale = 0.4f;
    public float maxScale = 0.6f;
    public float speed = 5f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = Mathf.Lerp(
            minScale,
            maxScale,
            Mathf.PingPong(Time.time * speed, 1)
        );

        transform.localScale = new Vector3(
            originalScale.x * scale,
            originalScale.y * scale,
            originalScale.z
        );
    }
}
