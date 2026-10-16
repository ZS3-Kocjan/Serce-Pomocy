using UnityEngine;

public class BallRotation : MonoBehaviour
{
    public float rotationMultiplier = 360f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalSpeed = rb.linearVelocity.x;

        float rotation = -horizontalSpeed * rotationMultiplier * Time.deltaTime;

        transform.Rotate(0f, 0f, rotation);
    }
}