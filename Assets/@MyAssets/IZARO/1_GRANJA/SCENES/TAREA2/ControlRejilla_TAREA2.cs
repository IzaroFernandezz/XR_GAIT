using UnityEngine;
using System.Collections;

public class ControlRejilla_TAREA2 : CRT_General
{
    public override void Start()
    {
        base.Start();
        // Forzamos la posición inicial según el booleano
        transform.localPosition = abierta ? posAbierta : posCerrada;
    }

}