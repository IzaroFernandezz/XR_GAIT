using UnityEngine;

public class ControlRejilla_TAREA1 : CRT_General
{
    public override void Start()
    {
        base.Start();
        // Asegura que siempre esté cerrada
        transform.localPosition = posCerrada;
    }
}