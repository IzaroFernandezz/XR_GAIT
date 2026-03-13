using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Collections;

public class MovimientoPolluelo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public List<Transform> puntos = new List<Transform>();
    public float tiempoDeEspera = 3f;
    public AudioSource altavoz; // El "pío" del polluelo

    private int indiceActual = 0;
    private bool estaCaminando = false;
    private bool esperandoEnElMedio = false;

    void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (anim == null) anim = GetComponent<Animator>();
        if (altavoz == null) altavoz = GetComponent<AudioSource>();

        IrAlSiguientePunto();
    }

    void Update()
    {
        ActualizarAnimacion();

        // Pausa en el centro
        if (!esperandoEnElMedio && Mathf.Abs(transform.position.x) < 0.2f)
        {
            StartCoroutine(PausaEnElMedio());
        }

        // Cambio de punto
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !esperandoEnElMedio)
        {
            IrAlSiguientePunto();
        }
    }

    IEnumerator PausaEnElMedio()
    {
        esperandoEnElMedio = true;
        agent.isStopped = true;

        if (altavoz != null) altavoz.Play();

        yield return new WaitForSeconds(tiempoDeEspera);

        agent.isStopped = false;
        yield return new WaitForSeconds(1f);
        esperandoEnElMedio = false;
    }

    void IrAlSiguientePunto()
    {
        if (puntos.Count == 0) return;
        agent.destination = puntos[indiceActual].position;
        indiceActual = (indiceActual + 1) % puntos.Count;
    }

    void ActualizarAnimacion()
    {
        if (anim == null || agent == null) return;

        bool moviéndose = agent.velocity.magnitude > 0.1f;

        if (moviéndose && !estaCaminando)
        {
            estaCaminando = true;
            anim.SetTrigger("Caminar");
        }
        else if (!moviéndose && estaCaminando)
        {
            estaCaminando = false;
            anim.SetTrigger("Parar");
        }
    }
}