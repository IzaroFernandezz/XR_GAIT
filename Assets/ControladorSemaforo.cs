using UnityEngine;
using System.Collections;

public class ControladorSemaforo : MonoBehaviour
{
    public GameObject RedLight, YellowLight, GreenLight;
    public Material matRojoOn, matAmarilloOn, matVerdeOn, matApagado;
    public AudioSource altavoz;

    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        if (altavoz == null) altavoz = GetComponent<AudioSource>();

        StartCoroutine(CicloSemaforo());
    }

    IEnumerator CicloSemaforo()
    {
        while (true)
        {
            // FASE VERDE: Empieza el sonido
            if (altavoz != null)
            {
                altavoz.time = 0.5f; // Empieza desde el principio del archivo
                altavoz.Play();
            }
            ActualizarTodo(false, false, true, 6, matVerdeOn);
            yield return new WaitForSeconds(5f); // Sonará solo estos 5 segundos

            // FASE AMARILLA: Cortamos el sonido
            if (altavoz != null) altavoz.Stop();
            ActualizarTodo(false, true, false, 5, matAmarilloOn);
            yield return new WaitForSeconds(2f);

            // FASE ROJA: Sigue en silencio
            ActualizarTodo(true, false, false, 4, matRojoOn);
            yield return new WaitForSeconds(5f);
        }
    }

    void ActualizarTodo(bool r, bool a, bool v, int indiceOn, Material materialBrillante)
    {
        if (RedLight) RedLight.SetActive(r);
        if (YellowLight) YellowLight.SetActive(a);
        if (GreenLight) GreenLight.SetActive(v);

        if (mesh != null)
        {
            Material[] mats = mesh.materials;
            mats[4] = matApagado;
            mats[5] = matApagado;
            mats[6] = matApagado;
            mats[indiceOn] = materialBrillante;
            mesh.materials = mats;
        }
    }
}