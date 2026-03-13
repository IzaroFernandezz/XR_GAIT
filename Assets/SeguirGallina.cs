using UnityEngine;

public class SeguirGallina : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform gallinaGrande; // Arrastra aquí a la gallina madre en el Inspector

    [Header("Ajustes de Movimiento")]
    public float velocidad = 0.6f;       // Un poco más que la madre (0.4) para que la alcance
    public float distanciaSegura = 1.2f; // Se detendrá a esta distancia de ella
    public float suavizadoGiro = 5.0f;   // Controla qué tan rápido gira para mirar a la madre

    void Update()
    {
        // Si no hemos asignado a la madre, el script no hace nada para evitar errores
        if (gallinaGrande == null) return;

        // 1. Calcular la distancia actual
        float distancia = Vector3.Distance(transform.position, gallinaGrande.position);

        // 2. Si la gallina está lejos, el polluelo la sigue
        if (distancia > distanciaSegura)
        {
            // Calcular dirección hacia la madre (ignorando la altura para que el polluelo no vuele)
            Vector3 direccion = (gallinaGrande.position - transform.position).normalized;
            direccion.y = 0;

            // Rotación suave: Mira hacia la gallina poco a poco
            if (direccion != Vector3.zero)
            {
                Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * suavizadoGiro);
            }

            // Mover el polluelo hacia adelante
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
        // Si la gallina se para (distancia < distanciaSegura), el polluelo simplemente se queda quieto
    }
}