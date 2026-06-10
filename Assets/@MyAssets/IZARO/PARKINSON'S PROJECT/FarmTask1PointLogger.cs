using UnityEngine;

public class FarmTask1PointLogger : MonoBehaviour
{
    [Header("Point")]
    public string pointName = "Start";

    [Header("Route index")]
    public int routeIndex = 0;

    [Header("Filter")]
    public string acceptedTag = "BodyProxy";

    [Header("Stability")]
    public float requiredTimeInside = 0.25f;

    private float timer = 0f;

    private static int currentTargetIndex = 0;
    private static bool goingBack = false;
    private static bool taskCompleted = false;

    private static Vector3 startPosition;
    private static Vector3 turnPosition;
    private static bool hasStartPosition = false;
    private static bool hasTurnPosition = false;

    private void Awake()
    {
        if (routeIndex == 0)
        {
            startPosition = transform.position;
            hasStartPosition = true;
        }

        if (routeIndex == 4)
        {
            turnPosition = transform.position;
            hasTurnPosition = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (taskCompleted)
            return;

        if (!other.CompareTag(acceptedTag))
            return;

        if (routeIndex != currentTargetIndex)
            return;

        timer += Time.deltaTime;

        if (timer >= requiredTimeInside)
        {
            float forwardSpeed = CalculateForwardSpeed(other);

            MetricsLogger.Instance.LogPoint(
                pointName,
                other.transform.position,
                forwardSpeed
            );

            AdvanceRoute();
            timer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(acceptedTag))
            return;

        timer = 0f;
    }

    private float CalculateForwardSpeed(Collider other)
    {
        if (!hasStartPosition || !hasTurnPosition)
            return 0f;

        Vector3 routeVector = turnPosition - startPosition;

        if (routeVector.magnitude < 0.001f)
            return 0f;

        Vector3 routeDirection = routeVector.normalized;

        BodyProxyFollower bodyProxy = other.GetComponent<BodyProxyFollower>();

        if (bodyProxy == null)
            return 0f;

        float speedOnRoute = Vector3.Dot(bodyProxy.CurrentVelocity, routeDirection);

        return Mathf.Abs(speedOnRoute);
    }

    private void AdvanceRoute()
    {
        if (!goingBack)
        {
            if (currentTargetIndex < 4)
            {
                currentTargetIndex++;
            }
            else
            {
                goingBack = true;
                currentTargetIndex = 3;
            }
        }
        else
        {
            if (currentTargetIndex > 0)
            {
                currentTargetIndex--;
            }
            else
            {
                taskCompleted = true;
            }
        }
    }

    private void OnApplicationQuit()
    {
        ResetProgress();
    }

    public static void ResetProgress()
    {
        currentTargetIndex = 0;
        goingBack = false;
        taskCompleted = false;
    }
}