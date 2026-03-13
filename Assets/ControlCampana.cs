using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlCampana : MonoBehaviour
{
    public AudioSource altavozCampana;
    public Animator animadorCampana; // Variable para arrastrar la campana que tiene la animación
    public float tiempoEsperaAlCargar = 15f;
    public float intervaloEntreToques = 2.1f; // Cambiado a 2 segundos como pediste

    [Header("Conexión con Rejillas")]
    public List<ControlRejilla> listaDeRejillas = new List<ControlRejilla>();

    void Start()
    {
        StartCoroutine(SecuenciaSonido());
    }

    IEnumerator SecuenciaSonido()
    {
        // 1. Espera los 15 segundos iniciales
        yield return new WaitForSeconds(tiempoEsperaAlCargar);

        // 2. Hace sonar la campana y lanza animación
        if (altavozCampana != null)
        {
            // --- PRIMER TOQUE ---
            altavozCampana.Play();
            if (animadorCampana != null)
            {
                // "Play" lanza la animación. Asegúrate de poner el nombre EXACTO de tu clip
                animadorCampana.SetTrigger("Mover");
            }

            // Espera 2 segundos antes del siguiente
            yield return new WaitForSeconds(intervaloEntreToques);

            // --- SEGUNDO TOQUE ---
            altavozCampana.Play();
            if (animadorCampana != null)
            {
                // "Play" lanza la animación. Asegúrate de poner el nombre EXACTO de tu clip
                animadorCampana.SetTrigger("Mover");
            }
        }

        // 3. Espera un poco después del último toque y abre las rejillas
        yield return new WaitForSeconds(1.0f);

        //animadorCampana.SetTrigger("Parar");

        foreach (ControlRejilla rejilla in listaDeRejillas)
        {
            if (rejilla != null)
            {
                rejilla.Abrir();
            }
        }
    }
}