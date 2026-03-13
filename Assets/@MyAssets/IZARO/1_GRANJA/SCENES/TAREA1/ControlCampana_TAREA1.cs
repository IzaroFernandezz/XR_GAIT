using UnityEngine;
using System.Collections;

public class ControlCampana_TAREA1 : MonoBehaviour
{
    public AudioSource altavozCampana;
    public Animator animadorCampana;

    public float tiempoEsperaAlCargar = 15f;
    public float intervaloEntreToques = 2.1f;

    void Start()
    {
        StartCoroutine(SecuenciaSonido());
    }

    IEnumerator SecuenciaSonido()
    {
        // Espera inicial
        yield return new WaitForSeconds(tiempoEsperaAlCargar);

        if (altavozCampana != null)
        {
            // PRIMER TOQUE
            altavozCampana.Play();

            if (animadorCampana != null)
            {
                animadorCampana.SetTrigger("Mover");
            }

            yield return new WaitForSeconds(intervaloEntreToques);

            // SEGUNDO TOQUE
            altavozCampana.Play();

            if (animadorCampana != null)
            {
                animadorCampana.SetTrigger("Mover");
            }
        }
    }
}