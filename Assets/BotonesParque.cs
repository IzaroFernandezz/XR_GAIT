using UnityEngine;
using UnityEngine.UI;


public class BotonesParque : MonoBehaviour
{
    [Header("Materiales")]
    public Material materialRojo;
    public Material materialVerde;
    [SerializeField]
    private Renderer miRenderer;
    private bool estado = false; // false = rojo, true = verde


    void Start()
    {
        if (miRenderer == null)
        {
            miRenderer = GetComponent<Renderer>();
        }
        ActualizarColor();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AlPulsar();
        }
    }

    public void AlPulsar()
    {
        estado = !estado;
        ActualizarColor();
    }

    void ActualizarColor()
    {
        if (miRenderer != null)
        {
            miRenderer.material = estado ? materialVerde : materialRojo;
        }
    }
}