using UnityEngine;
using UnityEngine.UIElements;

public class OnTouchScript : MonoBehaviour
{
    public Transform tpTo=null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==2)
        {
            Debug.Log("fell into lava");
            // collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            // collision.gameObject.GetComponent<Transform>().eulerAngles = new Vector3(0,0,90);
            // collision.gameObject.GetComponent<NewBehaviourScript>().speed=0;
            if (tpTo != null)
            {
                collision.gameObject.transform.position = tpTo.position;
            }
        }

    }
}
