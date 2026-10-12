using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D doorBody;
    [SerializeField] private bool moveY;
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float speed = 2f;

    private readonly HashSet<ButtonScript> pressedButtons = new();
    private Vector2 closedPosition;

    private void Awake()
    {
        if (doorBody == null)
            doorBody = GetComponent<Rigidbody2D>();

        closedPosition = doorBody.position;
    }

    public void SetButtonPressed(ButtonScript button, bool isPressed)
    {
        if (button == null)
            return;

        if (isPressed)
            pressedButtons.Add(button);
        else
            pressedButtons.Remove(button);
    }

    private void FixedUpdate()
    {
        Vector2 direction = moveY ? Vector2.up : Vector2.right;
        Vector2 targetPosition = pressedButtons.Count > 0
            ? closedPosition + direction * moveDistance
            : closedPosition;

        Vector2 nextPosition = Vector2.MoveTowards(
            doorBody.position,
            targetPosition,
            speed * Time.fixedDeltaTime
        );

        doorBody.MovePosition(nextPosition);
    }
}