using UnityEngine;

public class BodyProxyFollower : MonoBehaviour
{
    [Header("Pelvis markers")]
    public Transform LASI;
    public Transform RASI;

    [Header("Settings")]
    public Vector3 offset = Vector3.zero;
    public bool useSmoothing = true;
    public float smoothingSpeed = 15f;

    public Vector3 CurrentVelocity { get; private set; }

    private bool hasInitialPosition = false;
    private Vector3 previousPosition;

    private void LateUpdate()
    {
        if (LASI == null || RASI == null)
            return;

        Vector3 targetPosition = (LASI.position + RASI.position) / 2f;
        targetPosition += offset;

        if (!hasInitialPosition)
        {
            transform.position = targetPosition;
            previousPosition = transform.position;
            CurrentVelocity = Vector3.zero;
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

        if (Time.deltaTime > 0f)
        {
            CurrentVelocity = (transform.position - previousPosition) / Time.deltaTime;
        }

        previousPosition = transform.position;
    }
}