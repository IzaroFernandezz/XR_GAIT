using UnityEngine;
using System.Collections;

public class SemaforoInteligente : MonoBehaviour
{
    [Header("Tus Luces (Arrastra tus objetos aquí)")]
    public GameObject RedLight;
    public GameObject YellowLight;
    public GameObject GreenLight;

    [Header("Materiales Encendidos (Los originales)")]
    public Material matRojoOn;
    public Material matAmarilloOn;
    public Material matVerdeOn;

    [Header("Material Apagado (El negro que creaste)")]
    public Material matApagado;

    private MeshRenderer mesh;

    void Start()
    {
        // Obtenemos el componente que tiene los materiales
        mesh = GetComponent<MeshRenderer>();

        if (mesh == null)
        {
            Debug.LogError("¡No hay MeshRenderer en este objeto! Pon el script en MM_SemaforoFree.");
            return;
        }

        StartCoroutine(CicloSemaforo());
    }

    IEnumerator CicloSemaforo()
    {
        while (true)
        {
            // FASE VERDE (Elemento 6 en tu lista)
            ActualizarTodo(false, false, true, 6, matVerdeOn);
            yield return new WaitForSeconds(5f);

            // FASE AMARILLA (Elemento 5 en tu lista)
            ActualizarTodo(false, true, false, 5, matAmarilloOn);
            yield return new WaitForSeconds(2f);

            // FASE ROJA (Elemento 4 en tu lista)
            ActualizarTodo(true, false, false, 4, matRojoOn);
            yield return new WaitForSeconds(5f);
        }
    }

    void ActualizarTodo(bool r, bool a, bool v, int indiceOn, Material materialBrillante)
    {
        // 1. Encender/Apagar tus luces Point Light
        if (RedLight) RedLight.SetActive(r);
        if (YellowLight) YellowLight.SetActive(a);
        if (GreenLight) GreenLight.SetActive(v);

        // 2. Cambiar los materiales del semáforo para que se vea negro
        if (mesh != null)
        {
            Material[] nuevosMateriales = mesh.materials;

            // Ponemos los 3 cristales en negro (4, 5 y 6)
            nuevosMateriales[4] = matApagado;
            nuevosMateriales[5] = matApagado;
            nuevosMateriales[6] = matApagado;

            // Encendemos solo el que toca ahora
            nuevosMateriales[indiceOn] = materialBrillante;

            // Aplicamos los cambios al modelo
            mesh.materials = nuevosMateriales;
        }
    }
}