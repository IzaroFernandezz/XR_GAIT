using Oculus.Interaction;
using UnityEngine;

public class ControlTelefono : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource altavoz;
    public AudioClip sonidoLlamada;
    public AudioClip audioInstrucciones;
    public AudioClip audioInstrucciones2;

    [Header("Configuracion de la Tarea")]
    public Transform cabeza;
    public float distanciaUmbral = 0.25f;
    public GrabInteractable telefonoInteractuable;

    private bool estaSonando = false;
    private int numeroLlamada = 1;
    private bool segundaLlamadaActivada = false;

    void Start()
    {
        Invoke("ActivarLlamada", 15f);

        if (telefonoInteractuable != null)
        {
            telefonoInteractuable.WhenStateChanged += BolsaAgarrada;
        }
    }

    void BolsaAgarrada(InteractableStateChangeArgs args)
    {
        if (args.NewState == InteractableState.Select && !segundaLlamadaActivada)
        {
            segundaLlamadaActivada = true;
            ActivarLlamada2();
        }
    }

    void Update()
    {
        if (estaSonando)
        {
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);

            float distanciaActual = Vector3.Distance(transform.position, cabeza.position);

            if (distanciaActual < distanciaUmbral)
            {
                if (numeroLlamada == 1)
                {
                    ContestarTelefono();
                }
                else if (numeroLlamada == 2)
                {
                    ContestarTelefono2();
                }
            }
        }
    }

    void ActivarLlamada()
    {
        numeroLlamada = 1;
        estaSonando = true;

        if (altavoz != null && sonidoLlamada != null)
        {
            altavoz.clip = sonidoLlamada;
            altavoz.loop = true;
            altavoz.Play();
        }

        Debug.Log("TELÉFONO: Primera llamada sonando y vibrando.");
    }

    void ActivarLlamada2()
    {
        numeroLlamada = 2;
        estaSonando = true;

        if (altavoz != null && sonidoLlamada != null)
        {
            altavoz.Stop();
            altavoz.clip = sonidoLlamada;
            altavoz.loop = true;
            altavoz.Play();
        }

        Debug.Log("TELÉFONO: Segunda llamada sonando y vibrando.");
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

        Debug.Log("TELÉFONO: Primera llamada contestada.");
    }

    void ContestarTelefono2()
    {
        estaSonando = false;

        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

        if (altavoz != null)
        {
            altavoz.Stop();

            if (audioInstrucciones2 != null)
            {
                altavoz.clip = audioInstrucciones2;
                altavoz.loop = false;
                altavoz.Play();
            }
        }

        Debug.Log("TELÉFONO: Segunda llamada contestada.");
    }

    void OnDisable()
    {
        if (telefonoInteractuable != null)
        {
            telefonoInteractuable.WhenStateChanged -= BolsaAgarrada;
        }

        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}