using System.Collections;
using UnityEngine;

public class CRT_General : MonoBehaviour
{
    [SerializeField] protected Vector3 posCerrada;
    [SerializeField] protected Vector3 posAbierta;

    [Header("Ajustes de Movimiento")]
    [SerializeField] protected float distanciaSubida = 0.7f;
    [SerializeField] protected float velocidad = 3f;
    [SerializeField] public bool abierta = false;

    [Header("Temporizador Sorpresa")]
    // 15s (campana) + 5s (margen) = 20s
    // Cámbialo a 21 o 22 en el Inspector si quieres aún más tiempo
    protected float tiempoParaAbrir = 22f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        posCerrada = transform.localPosition;
        posAbierta = posCerrada + new Vector3(0, distanciaSubida, 0);
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
