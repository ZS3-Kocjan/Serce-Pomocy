using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollectHearts : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayers;
    private SpriteRenderer heart;
    private bool isAvailable = true;
    private void Awake()
    {
        heart = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsPlayer(other))
            return;

        addPoint();
    }

    private void addPoint()
    {
        if (isAvailable)
        {
           Destroy(heart);
           ScoreManager.instance.addPoint();
            isAvailable = false;
        }
    }

    private bool IsPlayer(Collider2D other)
    {
        return (playerLayers.value & (1 << other.gameObject.layer)) != 0;
    }
}
