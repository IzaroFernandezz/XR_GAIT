using UnityEngine;

public class MarkerProxyFollower : MonoBehaviour
{
    [Header("Marker to follow")]
    public Transform marker;

    [Header("Settings")]
    public Vector3 offset = Vector3.zero;
    public bool useSmoothing = true;
    public float smoothingSpeed = 20f;

    private bool hasInitialPosition = false;

    private void LateUpdate()
    {
        if (marker == null)
            return;

        Vector3 targetPosition = marker.position + offset;

        if (!hasInitialPosition)
        {
            transform.position = targetPosition;
            hasInitialPosition = true;
            return;
        }

        if (useSmoothing)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                Time.deltaTime * smoothingSpeed
            );
        }
        else
        {
            transform.position = targetPosition;
        }
    }
}