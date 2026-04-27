using UnityEngine;

public class ControlTelefono : MonoBehaviour
{
    [Header("Configuracion de la Tarea")]
    public AudioSource altavoz;    // Arrastra aqui el componente con el sonido 'phone_ringing'
    public Transform cabeza;       // Arrastra aqui el 'CenterEyeAnchor'
    public float distanciaUmbral = 0.25f; // Distancia para que se apague (25 cm)

    private bool estaSonando = false;

    void Start()
    {
        // La primera llamada ocurrirá a los 10 segundos de empezar
        Invoke("ActivarLlamada", 15f);
    }

    void Update()
    {
        if (estaSonando)
        {
            // 1. Activar la vibración del mando derecho (RTouch)
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);

            // 2. Calcular la distancia entre el teléfono y las gafas
            float distanciaActual = Vector3.Distance(transform.position, cabeza.position);

            // 3. Comprobar si el paciente ha acercado el teléfono lo suficiente
            if (distanciaActual < distanciaUmbral)
            {
                FinalizarLlamada();
            }
        }
    }

    void ActivarLlamada()
    {
        estaSonando = true;
        if (altavoz != null)
        {
            altavoz.Play();
        }
        Debug.Log("TELÉFONO: Sonando y vibrando. Esperando respuesta del paciente.");
    }

    void FinalizarLlamada()
    {
        estaSonando = false;

        // Detener sonido y vibración inmediatamente
        if (altavoz != null)
        {
            altavoz.Stop();
        }
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

        Debug.Log("TELÉFONO: Tarea completada con éxito.");

        // Programar la siguiente llamada (ejemplo: entre 20 y 40 segundos después)
        Invoke("ActivarLlamada", Random.Range(20f, 40f));
    }

    // Por seguridad: si se sale del juego o se destruye el objeto, paramos la vibración
    void OnDisable()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}