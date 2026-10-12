using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{


    public Rigidbody2D door;
    public int moveByX=2;
    private Vector2 ogSpot;
    public bool moveY;
    // public Rigidbody2D otherButton = null;
    public ButtonScript otherButtonScript = null;
    private List<int> toucher = new List<int>();
    private bool moveDoor= false;
    void Start()
    {
        ogSpot=door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // while(moveDoor==true && (door.transform.position.y <= door.transform.position.y + 2))
        // {
        //     door.transform.position=new Vector2(ogSpot.x,door.transform.position.y+0.01f);
        // }
        if (moveDoor == true)
        {
            Debug.Log("hoj");
            if (moveY == true)
            {
                Debug.Log("mnie streli");
                door.transform.position = Vector2.MoveTowards(door.transform.position,new Vector2(door.transform.position.x,ogSpot.y+moveByX),2f*Time.deltaTime);            
            }
            else
            {
                door.transform.position = Vector2.MoveTowards(door.transform.position,new Vector2(ogSpot.x+moveByX,door.transform.position.y),2f*Time.deltaTime);            
            }

        }
        else
        {
            if (otherButtonScript != null)
            {
                if (otherButtonScript.moveDoor == true)
                {
                    Debug.Log("fajny ten skrypcik :))))");
                    return;
                }
            }

            if (moveY == true)
            {
                door.transform.position = Vector2.MoveTowards(door.transform.position,new Vector2(door.transform.position.x,ogSpot.y),2f*Time.deltaTime);            
            }
            else 
            {
                door.transform.position = Vector2.MoveTowards(door.transform.position,new Vector2(ogSpot.x,door.transform.position.y),2f*Time.deltaTime);            
            }
        }
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touched");

        if (collision.gameObject.layer == 2 || collision.gameObject.layer==3)
        {
            moveDoor=true;
            Debug.Log(moveDoor);
            toucher.Add(1);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (toucher.Count != 0)
        {
            toucher.RemoveAt(toucher.Count-1);
        }
        if (toucher.Contains(1))
        {
            return;
        }
        moveDoor=false;
    }
}
