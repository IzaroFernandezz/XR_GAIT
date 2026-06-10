using UnityEngine;

public class FarmTask3Logger : MonoBehaviour
{
    [Header("Point")]
    public string pointName = "Start";

    [Header("Accepted tags")]
    public string acceptedTag1 = "BodyProxy";
    public string acceptedTag2 = "";

    [Header("Settings")]
    public float requiredTimeInside = 0.25f;
    public bool logOnlyOnce = false;

    [Header("Speed source")]
    public BodyProxyFollower bodyProxyForSpeed;

    private bool hasLogged = false;
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
                MetricsLogger.Instance.SetTask("Farm", "Task3");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsAccepted(other))
            return;

        if (logOnlyOnce && hasLogged)
            return;

        hasLoggedDuringThisEntry = false;
        timer = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsAccepted(other))
            return;

        if (logOnlyOnce && hasLogged)
            return;

        if (hasLoggedDuringThisEntry)
            return;

        timer += Time.deltaTime;

        if (timer >= requiredTimeInside)
        {
            float forwardSpeed = GetForwardSpeed();

            MetricsLogger.Instance.LogPoint(
                pointName,
                other.transform.position,
                forwardSpeed
            );

            hasLogged = true;
            hasLoggedDuringThisEntry = true;
            timer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!IsAccepted(other))
            return;

        hasLoggedDuringThisEntry = false;
        timer = 0f;
    }

    private bool IsAccepted(Collider other)
    {
        if (!string.IsNullOrEmpty(acceptedTag1) && other.CompareTag(acceptedTag1))
            return true;

        if (!string.IsNullOrEmpty(acceptedTag2) && other.CompareTag(acceptedTag2))
            return true;

        return false;
    }

    private float GetForwardSpeed()
    {
        if (bodyProxyForSpeed == null)
            return 0f;

        return bodyProxyForSpeed.CurrentVelocity.magnitude;
    }
}