using UnityEngine;

public class platform : MonoBehaviour
{
    public float speed = 1f;

    private Vector3 touchingPosition = new Vector3(12.5f, 0f, 0f);
    private Vector3 notTouchingPosition = new Vector3(12.5f, -3.2f, 0f);

    private bool playerTouching = false;

    void Update()
    {
        Vector3 targetPosition = playerTouching ? touchingPosition: notTouchingPosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTouching = false;
        }
    }
}