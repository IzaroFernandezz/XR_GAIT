using UnityEngine;

public class RegistroMetricasGranja : MonoBehaviour
{
    public ControladorColliders Inicio;
    public ControladorColliders Medio;
    public ControladorColliders Fin;
    public ControladorColliders PosicionInicial;
    public ControladorColliders GiroFinal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Inicio.OnColliderEntered += () => MetricsLogger.Instance.LogEvent("1", "BELL", "RING", transform.position);
        Medio.OnColliderEntered += () => MetricsLogger.Instance.LogEvent("2", "BELL", "RING", transform.position);
        Fin.OnColliderEntered += () => MetricsLogger.Instance.LogEvent("3", "BELL", "RING", transform.position);
        PosicionInicial.OnColliderEntered += () => MetricsLogger.Instance.LogEvent("4", "BELL", "RING", transform.position);
        GiroFinal.OnColliderEntered += () => MetricsLogger.Instance.LogEvent("5", "BELL", "RING", transform.position);

        Inicio.OnColliderExited += () => MetricsLogger.Instance.LogEvent("INTERACTION", "BELL", "RING", transform.position);
        Medio.OnColliderExited += () => MetricsLogger.Instance.LogEvent("INTERACTION", "BELL", "RING", transform.position);
        Fin.OnColliderExited += () => MetricsLogger.Instance.LogEvent("INTERACTION", "BELL", "RING", transform.position);
        PosicionInicial.OnColliderExited += () => MetricsLogger.Instance.LogEvent("INTERACTION", "BELL", "RING", transform.position);
        GiroFinal.OnColliderExited += () => MetricsLogger.Instance.LogEvent("INTERACTION", "BELL", "RING", transform.position);
    }
}