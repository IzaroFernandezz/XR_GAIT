using UnityEngine;

public class ParkTask3Logger : MonoBehaviour
{
    [Header("Point")]
    public string pointName = "Start";

    [Header("Accepted tags")]
    public string acceptedTag1 = "BodyProxy";
    public string acceptedTag2 = "";

    [Header("Settings")]
    public float requiredTimeInside = 0.25f;
    public bool logOnlyOnce = true;

    [Header("Speed source")]
    public BodyProxyFollower bodyProxyForSpeed;

    [Header("Phone call event")]
    public bool logPhoneCall = false;
    public string phoneCallPointName = "Phone_Call";
    public float phoneCallTimeAfterStart = 15f;

    private bool hasLogged = false;
    private bool hasLoggedDuringThisEntry = false;
    private float timer = 0f;

    private static bool taskInitialized = false;

    private static bool startPointLogged = false;
    private static float startPointTime = 0f;

    private static bool phoneCallLogged = false;

    private void Start()
    {
        if (!taskInitialized)
        {
            taskInitialized = true;

            startPointLogged = false;
            phoneCallLogged = false;
            startPointTime = 0f;

            if (MetricsLogger.Instance != null)
            {
                MetricsLogger.Instance.SetTask("Park", "Task3");
            }
        }
    }

    private void Update()
    {
        if (!logPhoneCall)
            return;

        if (phoneCallLogged)
            return;

        if (!startPointLogged)
            return;

        if (Time.time - startPointTime >= phoneCallTimeAfterStart)
        {
            Vector3 position = transform.position;
            float forwardSpeed = 0f;

            if (bodyProxyForSpeed != null)
            {
                position = bodyProxyForSpeed.transform.position;
                forwardSpeed = bodyProxyForSpeed.CurrentVelocity.magnitude;
            }

            MetricsLogger.Instance.LogPoint(
                phoneCallPointName,
                position,
                forwardSpeed
            );

            phoneCallLogged = true;
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
            float forwardSpeed = GetForwardSpeed(other);

            MetricsLogger.Instance.LogPoint(
                pointName,
                other.transform.position,
                forwardSpeed
            );

            if (pointName == "Start" && !startPointLogged)
            {
                startPointLogged = true;
                startPointTime = Time.time;
            }

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

    private float GetForwardSpeed(Collider other)
    {
        BodyProxyFollower bodyProxy = other.GetComponent<BodyProxyFollower>();

        if (bodyProxy != null)
            return bodyProxy.CurrentVelocity.magnitude;

        if (bodyProxyForSpeed != null)
            return bodyProxyForSpeed.CurrentVelocity.magnitude;

        return 0f;
    }
}