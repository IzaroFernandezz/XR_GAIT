using UnityEngine;

public class ControlRejilla_TAREA1 : MonoBehaviour
{
    private Vector3 posCerrada;

    void Start()
    {
        // Guarda la posición actual como cerrada
        posCerrada = transform.localPosition;

        // Asegura que siempre esté cerrada
        transform.localPosition = posCerrada;
    }
}