using UnityEngine;
using System.Collections;

public class ControlRejilla_TAREA3 : MonoBehaviour
{
    private Vector3 posCerrada;
    private Vector3 posAbierta;

    [Header("Ajustes de Movimiento")]
    public float distanciaSubida = 0.7f;
    public float velocidad = 3f;
    public bool abierta = false;

    [Header("Temporizador Sorpresa")]
    // 15s (campana) + 5s (margen) = 20s
    // Cámbialo a 21 o 22 en el Inspector si quieres aún más tiempo
    public float tiempoParaAbrir = 22f;

    void Start()
    {
        posCerrada = transform.localPosition;
        posAbierta = posCerrada + new Vector3(0, distanciaSubida, 0);

        // Forzamos posición CERRADA al empezar
        abierta = false;
        transform.localPosition = posCerrada;

        // Arranca la cuenta atrás
        StartCoroutine(EsperarYAbrir());
    }

    IEnumerator EsperarYAbrir()
    {
        // Espera el tiempo total definido
        yield return new WaitForSeconds(tiempoParaAbrir);

        // Solo se abre si el usuario no la ha abierto ya manualmente con el botón
        if (!abierta)
        {
            Alternar();
        }
    }

    public void Alternar()
    {
        StopAllCoroutines();
        abierta = !abierta;
        Vector3 destino = abierta ? posAbierta : posCerrada;
        StartCoroutine(MoverRejilla(destino));
    }

    IEnumerator MoverRejilla(Vector3 destino)
    {
        // Usamos un margen pequeño para el destino
        while (Vector3.Distance(transform.localPosition, destino) > 0.001f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destino, Time.deltaTime * velocidad);
            yield return null;
        }
        transform.localPosition = destino;
    }
}