using System;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class ControladorColliders : MonoBehaviour
{
    public event Action OnColliderEntered;
    public event Action OnColliderExited;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnColliderEntered?.Invoke();
        }
        MetricsLogger.Instance.LogEvent("ENTER", other.name, name, transform.position);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnColliderExited?.Invoke();
        }
        MetricsLogger.Instance.LogEvent("EXIT", other.name, name, transform.position);
    }

}
