
using UnityEngine;

public class CampanaInteractiva : MonoBehaviour
{
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        Sonar();
    }

    public void Sonar()
    {
        audioSource.Play();
    }
}


