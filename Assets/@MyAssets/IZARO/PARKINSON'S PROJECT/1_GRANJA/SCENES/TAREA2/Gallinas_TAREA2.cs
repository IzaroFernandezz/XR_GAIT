using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Collections;

public class Gallinas_TAREA2 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public List<Transform> puntos = new List<Transform>();
    public float tiempoDeEspera = 3f;
    public AudioSource altavozGallina;

    private int indiceActual = 0;
    private bool estaCaminando = false;
    private bool esperandoEnElMedio = false;
    private bool regresandoPorChoque = false;

    void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (anim == null) anim = GetComponent<Animator>();
        if (altavozGallina == null) altavozGallina = GetComponent<AudioSource>();

        IrAlSiguientePunto();
    }

    void Update()
    {
        ActualizarAnimacion();

        if (regresandoPorChoque)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                regresandoPorChoque = false;
                IrAlSiguientePunto();
            }
            return;
        }

        // Pausa cuando pasa por el centro del pasillo
        if (!esperandoEnElMedio && Mathf.Abs(transform.position.x) < 0.2f)
        {
            StartCoroutine(PausaEnElMedio());
        }

        if (!esperandoEnElMedio && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            IrAlSiguientePunto();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ControlRejilla_TAREA2 rejilla = collision.gameObject.GetComponent<ControlRejilla_TAREA2>();

        if (rejilla != null)
        {
            DarLaVuelta();
        }
    }

    void DarLaVuelta()
    {
        regresandoPorChoque = true;

        indiceActual = (indiceActual - 2 + puntos.Count) % puntos.Count;

        agent.SetDestination(puntos[indiceActual].position);

        Debug.Log(gameObject.name + " chocó con una rejilla y se da la vuelta.");
    }

    IEnumerator PausaEnElMedio()
    {
        esperandoEnElMedio = true;

        agent.isStopped = true;

        if (altavozGallina != null)
        {
            altavozGallina.Play();
        }

        yield return new WaitForSeconds(tiempoDeEspera);

        agent.isStopped = false;

        yield return new WaitForSeconds(1.5f);

        esperandoEnElMedio = false;
    }

    void IrAlSiguientePunto()
    {
        if (puntos.Count == 0 || regresandoPorChoque) return;

        agent.SetDestination(puntos[indiceActual].position);

        indiceActual = (indiceActual + 1) % puntos.Count;
    }

    void ActualizarAnimacion()
    {
        if (anim == null || agent == null) return;

        if (agent.velocity.magnitude > 0.1f && !estaCaminando)
        {
            estaCaminando = true;
            anim.SetTrigger("Caminar");
        }
        else if (agent.velocity.magnitude <= 0.1f && estaCaminando)
        {
            estaCaminando = false;
            anim.SetTrigger("Parar");
        }
    }
}