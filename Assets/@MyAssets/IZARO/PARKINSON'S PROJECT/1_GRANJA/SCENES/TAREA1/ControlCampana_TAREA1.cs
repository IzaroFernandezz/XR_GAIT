using UnityEngine;
using System.Collections;

public class ControlCampana_TAREA1 : MonoBehaviour
{
    public AudioSource altavozCampana;
    public Animator animadorCampana;

    public float tiempoEsperaAlCargar = 15f;
    public float intervaloEntreToques = 2.1f;

    private bool taskStarted = false;

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
            // PRIMER TOQUE AQUÍ EMPIEZA TODO
            altavozCampana.Play();

            if (animadorCampana != null)
                animadorCampana.SetTrigger("Mover");

            // IMPORTANTE
            if (!taskStarted)
            {
                taskStarted = true;

                //MetricsLogger.Instance.StartTask();
                /*
                MetricEvent bellEvent = new MetricEvent
                (
                    MetricsLogger.Instance.scenarioName + "_" + MetricsLogger.Instance.taskName + "_" + MetricsLogger.Instance.trialNumber,
                    MetricsLogger.Instance.scenarioName,
                    MetricsLogger.Instance.taskName,
                    MetricsLogger.Instance.trialNumber,
                    "INTERACTION",
                    "BELL",
                    "RING",
                    Time.time,
                    transform.position
                );
                */
                MetricsLogger.Instance.LogEvent(
                    "INTERACTION",
                    "BELL",
                    "RING",
                    transform.position
                );
                
            }

            yield return new WaitForSeconds(intervaloEntreToques);

            // SEGUNDO TOQUE (solo sonido, no reinicia nada)
            altavozCampana.Play();

            if (animadorCampana != null)
                animadorCampana.SetTrigger("Mover");
        }
    }
}