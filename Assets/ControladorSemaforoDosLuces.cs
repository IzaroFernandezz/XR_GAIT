using UnityEngine;
using System.Collections;

public class SemaforoSimple : MonoBehaviour
{
    [Header("Tus luces de Unity")]
    public GameObject RedLight;
    public GameObject GreenLight;

    [Header("Tiempos de espera")]
    public float tiempoRojo = 2f;
    public float tiempoVerde = 3f;

    void Start()
    {
        // Empezamos el ciclo
        StartCoroutine(CicloSemaforo());
    }

    IEnumerator CicloSemaforo()
    {
        while (true)
        {
            // FASE ROJA
            if (RedLight) RedLight.SetActive(true);
            if (GreenLight) GreenLight.SetActive(false);
            yield return new WaitForSeconds(tiempoRojo);

            // FASE VERDE
            if (RedLight) RedLight.SetActive(false);
            if (GreenLight) GreenLight.SetActive(true);
            yield return new WaitForSeconds(tiempoVerde);
        }
    }
}