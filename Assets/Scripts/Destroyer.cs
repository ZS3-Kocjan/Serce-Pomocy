using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ball")){
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(collision.gameObject);
        }else if(collision.gameObject.CompareTag("Player")){
                        Collider2D playerCollider =
                collision.gameObject.GetComponent<Collider2D>();

            Collider2D obstacleCollider =
                GetComponent<Collider2D>();

            if (playerCollider != null && obstacleCollider != null)
            {
                Physics2D.IgnoreCollision(
                    playerCollider,
                    obstacleCollider,
                    true
                );
            }
        }
    }
}
