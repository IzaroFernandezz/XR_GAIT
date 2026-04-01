using UnityEngine;

public class VerPuntos : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Esto dibujará una esfera roja física en cada punto, saltándose cualquier error de escala
        foreach (Transform child in transform)
        {
            Gizmos.DrawSphere(child.position, 0.05f);
        }
    }
}