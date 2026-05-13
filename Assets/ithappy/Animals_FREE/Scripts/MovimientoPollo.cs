using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Collections;

public class MovimientoPollo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public List<Transform> puntos = new List<Transform>();
    public float tiempoDeEspera = 3f;
    public AudioSource altavozGallina;
    public RoomController roomController;

    [SerializeField] private int indiceActual = 0;
    private bool estaCaminando = false;
    private bool esperandoEnElMedio = false;
    private bool regresandoPorChoque = false;

    void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (anim == null) anim = GetComponent<Animator>();
        if (altavozGallina == null) altavozGallina = GetComponent<AudioSource>();

        if(roomController != null)
        {
            roomController.OnRoomPlaced -= () =>
            {
                Debug.Log("Room colocado, iniciando movimiento del pollo.");
                IrAlSiguientePunto();
            };
            roomController.OnRoomPlaced += () =>
            {
                Debug.Log("Room colocado, iniciando movimiento del pollo.");
                IrAlSiguientePunto();
            };
        }
        //IrAlSiguientePunto();
    }

    void Update()
    {
        actualizarAnimacion();

        if (regresandoPorChoque)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                regresandoPorChoque = false;
                IrAlSiguientePunto();
            }
            return;
        }

        // Si quieres la pausa cuando pase por el centro (eje X cerca de 0)
        if (!esperandoEnElMedio && Mathf.Abs(transform.position.x) < 0.2f && !regresandoPorChoque)
        {
            StartCoroutine(PausaEnElMedio());
        }

        if (!esperandoEnElMedio && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            IrAlSiguientePunto();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter: {other.name}");
        // Detecta el choque con cualquier objeto que se llame REJILLA
        if (other.gameObject.name.ToUpper().Contains("REJILLA"))
        {
            Debug.Log($"OnTriggerEnter Rejilla: {other.name}");
            DarLaVuelta();
        }
    }

    void DarLaVuelta()
    {
        regresandoPorChoque = true;
        // Calculamos el punto anterior de SU lista específica para que vuelva
        indiceActual = (indiceActual + 1) % puntos.Count;
        agent.SetDestination(puntos[indiceActual].position);
        Debug.Log(gameObject.name + " detectó rejilla y regresa a su punto anterior.");
    }

    // ESTA ES LA FUNCIÓN QUE FALTABA Y DABA EL ERROR
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
        // Pequeño margen para que no se pause infinitamente en el mismo sitio
        yield return new WaitForSeconds(1.5f);
        esperandoEnElMedio = false;
    }

  /* COMENTADO
    void IrAlSiguientePunto()
    {
        if (puntos.Count == 0 || regresandoPorChoque) return;
        agent.destination = puntos[indiceActual].position;
        indiceActual = (indiceActual + 1) % puntos.Count;


    }

    */


    void IrAlSiguientePunto()
    {
        if (puntos.Count == 0 || regresandoPorChoque) return;

        // Cambiamos 'destination' para asegurarnos de que use la posición fresca de los puntos
        

        indiceActual = (indiceActual + 1) % puntos.Count;

        agent.SetDestination(puntos[indiceActual].position);
    }

    void actualizarAnimacion()
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

