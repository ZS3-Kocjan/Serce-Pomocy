using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Vector2 ogSpot;
    private Vector3 startPosition = new Vector3(-43.95f, 0f, 2f);
    public int moveBy;
    private bool reachedEnd=false;
    public float scrollSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ogSpot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position,new Vector2(ogSpot.x+moveBy,transform.position.y),3f*Time.deltaTime);            


        if (transform.position.x == ogSpot.x + moveBy)
        {
            reachedEnd=true;
        }
        else if(transform.position.x == ogSpot.x)
        {
            reachedEnd=false;
        }
        if(reachedEnd==false)
        {
            // transform.position = new Vector2(ogSpot.x,transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,new Vector2(ogSpot.x+moveBy,transform.position.y),0.5f*Time.deltaTime);            
        }
        else
        {
            // transform.position = Vector2.MoveTowards(transform.position,new Vector2(ogSpot.x-moveBy,transform.position.y),0.8f*Time.deltaTime); 
            GameObject clone = Instantiate(gameObject);
            clone.transform.position = startPosition;
            Destroy(gameObject);    
        }
    }
}
