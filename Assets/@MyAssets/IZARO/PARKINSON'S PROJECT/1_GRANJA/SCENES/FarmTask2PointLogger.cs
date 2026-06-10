using UnityEngine;

public class FarmTask2PointLogger : MonoBehaviour
{
    [Header("Point")]
    public string pointName = "Start";

    [Header("Filter")]
    public string acceptedTag = "BodyProxy";

    [Header("Stability")]
    public float requiredTimeInside = 0.25f;

    private bool bodyInside = false;
    private bool hasLoggedDuringThisEntry = false;
    private float timer = 0f;

    private static bool taskInitialized = false;

    private void Start()
    {
        if (!taskInitialized)
        {
            taskInitialized = true;

            if (MetricsLogger.Instance != null)
            {
                MetricsLogger.Instance.SetTask("Farm", "Task2");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(acceptedTag))
            return;

        bodyInside = true;
        hasLoggedDuringThisEntry = false;
        timer = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(acceptedTag))
            return;

        if (hasLoggedDuringThisEntry)
            return;

        bodyInside = true;
        timer += Time.deltaTime;

        if (timer >= requiredTimeInside)
        {
            float forwardSpeed = CalculateForwardSpeed(other);

            MetricsLogger.Instance.LogPoint(
                pointName,
                other.transform.position,
                forwardSpeed
            );

            hasLoggedDuringThisEntry = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(acceptedTag))
            return;

        bodyInside = false;
        hasLoggedDuringThisEntry = false;
        timer = 0f;
    }

    private float CalculateForwardSpeed(Collider other)
    {
        BodyProxyFollower bodyProxy = other.GetComponent<BodyProxyFollower>();

        if (bodyProxy == null)
            return 0f;

        return bodyProxy.CurrentVelocity.magnitude;
    }
}