using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FanLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isOn =true; 
    public int fanStrentgh=2;
    public SpriteRenderer SR;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    private int spriteIndex=1;
    private ArrayList objects= new ArrayList();

    void Start()
    {
        StartCoroutine(animate());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer==2 || collision.gameObject.layer == 3)
        {
            Debug.Log("i");
            objects.Add(collision);
            
            StartCoroutine(Floater(collision));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if (objects[i] == collision)
            {
                Debug.Log(collision.gameObject.name);
                objects.Remove(collision);
                if (!objects.Contains(collision))
                {
                    Debug.Log("works?");
                }
                return;
            }
        }
    }


    IEnumerator Floater(Collider2D collision){

        while (objects.Contains(collision))
        {
            if (isOn == true)
            {
                if (collision.gameObject.layer == 2)
                {
                    collision.gameObject.GetComponent<NewBehaviourScript>().jumped=true;
                }
                Rigidbody2D RB= collision.gameObject.GetComponent<Rigidbody2D>();
                RB.linearVelocityY += fanStrentgh;                 
                Debug.Log("iteracja");


                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator animate()
    {
        while (true)
        {
            if (isOn == true)
            {
                
            
                if (spriteIndex == 1)
                {
                    Debug.Log("zmiana1");
                    SR.sprite=sprite1;
                    spriteIndex=2;
                }
                else if(spriteIndex == 2)
                {
                    Debug.Log("zmiana2");
                    SR.sprite=sprite2;
                    spriteIndex=3;
                }
                else
                {
                    Debug.Log("zmiana3");
                    SR.sprite=sprite3;
                    spriteIndex=1;

                }
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
}
}


