using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CAMPANA : MonoBehaviour
{
    public AudioSource altavozCampana;
    public Animator animadorCampana;
    public float tiempoEsperaAlCargar = 15f;
    public float intervaloEntreToques = 2.1f;

    void Start()
    {
        // Iniciamos la secuencia al empezar
        StartCoroutine(SecuenciaSonido());
    }

    IEnumerator SecuenciaSonido()
    {
        // 1. Espera los 15 segundos iniciales
        yield return new WaitForSeconds(tiempoEsperaAlCargar);

        // 2. Ejecuta la secuencia de la campana
        if (altavozCampana != null)
        {
            // --- PRIMER TOQUE ---
            altavozCampana.Play();
            if (animadorCampana != null)
            {
                // Asegúrate que el Trigger en el Animator se llame "Mover"
                animadorCampana.SetTrigger("Mover");
            }

            // Espera el intervalo de 2.1 segundos
            yield return new WaitForSeconds(intervaloEntreToques);

            // --- SEGUNDO TOQUE ---
            altavozCampana.Play();
            if (animadorCampana != null)
            {
                animadorCampana.SetTrigger("Mover");
            }
        }

        Debug.Log("Secuencia de CAMPANA completada.");
    }
}