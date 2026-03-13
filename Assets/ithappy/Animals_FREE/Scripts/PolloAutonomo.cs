using UnityEngine;
using ithappy.Animals_FREE;

public class PolloAutonomo : MonoBehaviour
{
    // Esta línea es la que faltaba declarar aquí arriba:
    private CreatureMover m_Mover;

    void Awake()
    {
        // Buscamos el componente al arrancar
        m_Mover = GetComponent<CreatureMover>();
    }

    void Update()
    {
        if (m_Mover != null)
        {
            // Vector2(0, 1) es "Caminar hacia adelante"
            Vector2 direccion = new Vector2(0, 1);

            // Punto de mira: 10 metros por delante de su posición actual
            Vector3 puntoAlFrente = transform.position + transform.forward * 10f;

            // Le pasamos las órdenes al script de ithappy
            m_Mover.SetInput(direccion, puntoAlFrente, false, false);
        }
    }
}