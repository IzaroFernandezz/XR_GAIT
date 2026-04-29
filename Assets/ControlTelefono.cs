using UnityEngine;

public class ControlTelefono : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource altavoz;
    public AudioClip sonidoLlamada;
    public AudioClip audioInstrucciones;

    [Header("Configuracion de la Tarea")]
    public Transform cabeza;
    public float distanciaUmbral = 0.25f;

    private bool estaSonando = false;

    void Start()
    {
        Invoke("ActivarLlamada", 15f);
    }

    void Update()
    {
        if (estaSonando)
        {
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);

            float distanciaActual = Vector3.Distance(transform.position, cabeza.position);

            if (distanciaActual < distanciaUmbral)
            {
                ContestarTelefono();
            }
        }
    }

    void ActivarLlamada()
    {
        estaSonando = true;

        if (altavoz != null && sonidoLlamada != null)
        {
            altavoz.clip = sonidoLlamada;
            altavoz.loop = true;
            altavoz.Play();
        }

        Debug.Log("TELÉFONO: Sonando y vibrando.");
    }

    void ContestarTelefono()
    {
        estaSonando = false;

        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

        if (altavoz != null)
        {
            altavoz.Stop();

            if (audioInstrucciones != null)
            {
                altavoz.clip = audioInstrucciones;
                altavoz.loop = false;
                altavoz.Play();
            }
        }

        Debug.Log("TELÉFONO: Contestado. Reproduciendo instrucciones.");

        Invoke("ActivarLlamada", Random.Range(20f, 40f));
    }

    void OnDisable()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}