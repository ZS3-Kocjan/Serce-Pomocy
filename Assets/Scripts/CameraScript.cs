using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class TwoPlayerPixelCamera : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    public PixelPerfectCamera pixelCamera;

    public float followSpeed = 8f;
    public float zoomStepDistance = 4f;

    private Vector3 cameraVelocity;

    void LateUpdate()
    {
        if (player1 == null || player2 == null || pixelCamera == null)
            return;

        Vector3 midpoint = (player1.position + player2.position) * 0.5f;
        Vector3 targetPosition = new Vector3(midpoint.x, midpoint.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(
    transform.position,
    targetPosition,
    ref cameraVelocity,
    0.25f
);

        float distance = Vector2.Distance(player1.position, player2.position);

        pixelCamera.refResolutionY = 400;
    }
}