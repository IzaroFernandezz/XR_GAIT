using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonPuerta_TAREA2 : MonoBehaviour
{
    [Header("Conexión")]
    public ControlRejilla_TAREA2 rejillaAsociada;
    public TextMeshProUGUI textoBoton;

    [Header("Apariencia")]
    public Material materialRojo;   // Aquí arrastras el material "Rojo_Boton"
    public Material materialVerde;  // Aquí arrastras el material "Verde_Boton"
    public Image miImagen;          // Aquí arrastras el componente Image del botón

    void Start()
    {
        if (miImagen == null) miImagen = GetComponent<Image>();
        if (textoBoton == null) textoBoton = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (rejillaAsociada != null && miImagen != null)
        {
            if (rejillaAsociada.abierta)
            {
                // Extraemos el color del material verde y lo aplicamos a la imagen
                miImagen.color = materialVerde.color;
                if (textoBoton != null) textoBoton.text = "ABIERTO";
            }
            else
            {
                // Extraemos el color del material rojo y lo aplicamos a la imagen
                miImagen.color = materialRojo.color;
                if (textoBoton != null) textoBoton.text = "CERRADO";
            }
        }
    }

    // Esta es la función que conectas al evento del ISDK o al Button de Unity
    public void AlPulsar()
    {
        if (rejillaAsociada != null)
        {
            rejillaAsociada.Alternar();
        }
    }
}