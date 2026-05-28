using UnityEngine;

public class ZoneTriggerLogger : MonoBehaviour
{
    public string zoneName = "Zone";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        MetricsLogger.Instance.LogEvent(
            "ZONE",
            zoneName,
            "ENTER",
            other.transform.position
        );
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        MetricsLogger.Instance.LogEvent(
            "ZONE",
            zoneName,
            "EXIT",
            other.transform.position
        );
    }
}