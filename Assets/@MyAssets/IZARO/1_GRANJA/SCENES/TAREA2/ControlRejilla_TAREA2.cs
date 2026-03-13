using UnityEngine;
using System.Collections;

public class ControlRejilla_TAREA2 : MonoBehaviour
{
    private Vector3 posCerrada;
    private Vector3 posAbierta;

    [Header("Ajustes")]
    public float distanciaSubida = 0.7f;
    public float velocidad = 3f;
    public bool abierta = true; // Para Tarea 2, márcala como TRUE en el inspector

    void Start()
    {
        posCerrada = transform.localPosition;
        posAbierta = posCerrada + new Vector3(0, distanciaSubida, 0);

        // Forzamos la posición inicial según el booleano
        transform.localPosition = abierta ? posAbierta : posCerrada;
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
        while (Vector3.Distance(transform.localPosition, destino) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destino, Time.deltaTime * velocidad);
            yield return null;
        }
        transform.localPosition = destino;
    }
}