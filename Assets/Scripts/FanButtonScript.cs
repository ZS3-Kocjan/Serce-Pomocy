using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FanButtonScript : MonoBehaviour
{
   [SerializeField] private Sprite pressedButtonTexture;
   [SerializeField] private Sprite unpressedButtonTexture;
   public FanLogic fan;
   private List<int> toucher = new List<int>();
   private SpriteRenderer button;

   void Start()
   {
       button = GetComponent<SpriteRenderer>();
   }


   void OnTriggerEnter2D(Collider2D collision)
   {
       Debug.Log("touched");

       if (collision.gameObject.layer == 2 || collision.gameObject.layer==3)
       {
           toucher.Add(1);
           button.sprite = pressedButtonTexture;
           fan.isOn=false;
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
        fan.isOn=true;
       button.sprite = unpressedButtonTexture;
   }
}