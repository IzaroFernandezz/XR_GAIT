using UnityEngine;
using System.Collections;

public class ControlRejilla : MonoBehaviour
{
    private Vector3 posCerrada;
    private Vector3 posAbierta;

    [Header("Ajustes")]
    public float distanciaSubida = 0.7f; // De 0.1 a 0.8
    public float velocidad = 3f;

    public bool abierta = false;

    void Start()
    {
        // Guarda la posición actual como cerrada
        posCerrada = transform.localPosition;
        // Calcula la abierta
        posAbierta = posCerrada + new Vector3(0, distanciaSubida, 0);
    }

    // --- ESTA ES LA FUNCIÓN QUE TE FALTABA ---
    public void Abrir()
    {
        if (!abierta)
        {
            Alternar();
        }
    }

    public void Alternar()
    {
        StopAllCoroutines();

        if (abierta)
        {
            StartCoroutine(MoverRejilla(posCerrada));
            abierta = false;
        }
        else
        {
            StartCoroutine(MoverRejilla(posAbierta));
            abierta = true;
        }
    }

    IEnumerator MoverRejilla(Vector3 destino)
    {
        while (Vector3.Distance(transform.localPosition, destino) > 0.001f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destino, Time.deltaTime * velocidad);
            yield return null;
        }
        transform.localPosition = destino;
    }
}