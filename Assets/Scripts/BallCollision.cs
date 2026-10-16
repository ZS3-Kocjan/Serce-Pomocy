using UnityEngine;

public class BallCollsion : MonoBehaviour
{
    public Transform tpTo1;
    public Transform tpTo2;

    private Transform player1;
    private Transform player2;

    private void Start()
    {
        GameObject p1 = GameObject.Find("Player 1");
        GameObject p2 = GameObject.Find("Player 2");

        if (p1 != null)
            player1 = p1.transform;
        else
            Debug.LogError("Player 1 was not found!");

        if (p2 != null)
            player2 = p2.transform;
        else
            Debug.LogError("Player 2 was not found!");
    }

    private void TeleportPlayer(GameObject hitObject)
    {
        if (player1 == null || player2 == null)
            return;

        // Recognize Player 1 and its child colliders
        Transform hit = hitObject.transform;

        if (hit != player1 && !hit.IsChildOf(player1))
            return;

        Transform destination =
            player2.position.y > -2.75f ? tpTo1 : tpTo2;

        if (destination == null)
        {
            Debug.LogWarning("Assign Tp To 1 and Tp To 2!");
            return;
        }

        Rigidbody2D rb = player1.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        player1.position = destination.position;

        Debug.Log("Player 1 teleported!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TeleportPlayer(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TeleportPlayer(collision.gameObject);
    }
}