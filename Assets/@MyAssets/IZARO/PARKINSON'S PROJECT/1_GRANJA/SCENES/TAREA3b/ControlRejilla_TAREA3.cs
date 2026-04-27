using UnityEngine;
using System.Collections;

public class ControlRejilla_TAREA3 : CRT_General
{
    public override void Start()
    {
        base.Start();
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
}