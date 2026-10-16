using UnityEngine;
using System.Collections.Generic;

public class BoxButton : MonoBehaviour
{
    public Sprite pressedButtonTexture;
    public Sprite unpressedButtonTexture;
    public GameObject boxPrefab;
    public Transform spawner;
    public LayerMask playerLayers;
    private readonly HashSet<Collider2D> touchingColliders = new();
    private SpriteRenderer buttonRenderer;
    private bool isPressed;


    private void Awake()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsPlayer(other))
            return;

        touchingColliders.Add(other);
        UpdatePressedState();
    }

    private bool IsPlayer(Collider2D other)
    {
        return (playerLayers.value & (1 << other.gameObject.layer)) != 0;
    }

    private void UpdatePressedState()
    {
        bool shouldBePressed = touchingColliders.Count > 0;

        if (isPressed == shouldBePressed)
            return;

        isPressed = shouldBePressed;

        if (buttonRenderer != null)
        {
            buttonRenderer.sprite = isPressed
                ? pressedButtonTexture
                : unpressedButtonTexture;
        }

        Instantiate(boxPrefab, new Vector2(spawner.position.x, spawner.position.y), Quaternion.identity);
    }

    private void OnDisable()
    {
        touchingColliders.Clear();

        if (isPressed)
        {
            isPressed = false;

            if (buttonRenderer != null)
                buttonRenderer.sprite = unpressedButtonTexture;
            
        }
    }
}
