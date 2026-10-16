using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnInterval = 1f;
    public float ballSpeed = 7f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBall), 1f, spawnInterval);
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(
            ballPrefab,
            transform.position,
            Quaternion.identity
        );

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.right * ballSpeed;
        }
    }
}